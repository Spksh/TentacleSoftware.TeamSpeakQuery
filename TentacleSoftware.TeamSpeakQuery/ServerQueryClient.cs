using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TentacleSoftware.TeamSpeakQuery.NotifyResult;
using TentacleSoftware.TeamSpeakQuery.ServerQueryResult;
using TentacleSoftware.Telnet;

namespace TentacleSoftware.TeamSpeakQuery
{
    public class ServerQueryClient
    {
        public EventHandler<NotifyTextMessageResult> NotifyTextMessage;

        public EventHandler<NotifyClientEnterViewResult> NotifyClientEnterView;

        public EventHandler<NotifyClientLeftViewResult> NotifyClientLeftView;

        public EventHandler<NotifyClientMovedResult> NotifyClientMoved;

        public EventHandler<NotifyServerEditedResult> NotifyServerEdited;

        public EventHandler<NotifyChannelEditedResult> NotifyChannelEdited;

        public EventHandler<NotifyChannelDescriptionChangedResult> NotifyChannelDescriptionChanged;

        public EventHandler ConnectionClosed;

        private readonly CancellationTokenSource _cancellationSource;
        private readonly TelnetClient _telnetClient;
        private readonly SemaphoreSlim _commandQueue;

        /// <summary>
        /// TeamSpeak 3 ServerQuery client. See http://media.teamspeak.com/ts3_literature/TeamSpeak%203%20Server%20Query%20Manual.pdf.
        /// </summary>
        /// <param name="host">TeamSpeak 3 server hostname or IP address</param>
        /// <param name="port">ServerQuery port, you should probably set this to 10011. This is NOT the port your normal TS3 client connects to.</param>
        /// <param name="sendRate">Minimum time span between sends. This is a throttle to prevent flooding the server. Recommend 3+ seconds if you're not on the whitelist.</param>
        public ServerQueryClient(string host, int port, TimeSpan sendRate)
        {
            _commandQueue = new SemaphoreSlim(1);
            _cancellationSource = new CancellationTokenSource();
            _telnetClient = new TelnetClient(host, port, sendRate, _cancellationSource.Token);
            _telnetClient.ConnectionClosed += HandleConnectionClosed;
            _telnetClient.MessageReceived += HandleMessageReceived;
        }

        /// <summary>
        /// Connect via telnet and wait for header and welcome message. 
        /// When this task completes you are connected.
        /// </summary>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> Initialize()
        {
            return Initialize(client => client.Connect());
        }

        /// <summary>
        /// Connect via telnet with a SOCKS4 proxy and wait for header and welcome message.
        /// When this task completes you are connected. 
        /// </summary>
        /// <param name="socks4ProxyHost">Hostname or IP</param>
        /// <param name="socks4ProxyPort">Port</param>
        /// <param name="socks4ProxyUser">Can be null</param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> Initialize(string socks4ProxyHost, int socks4ProxyPort, string socks4ProxyUser)
        {
            return Initialize(client => client.Connect(socks4ProxyHost, socks4ProxyPort, socks4ProxyUser));
        }

        /// <summary>
        /// Execute an action that eventually calls TcpClient.Connect() and wait for header and welcome message. 
        /// When this task completes you are connected. 
        /// </summary>
        /// <param name="connect"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> Initialize(Action<TelnetClient> connect)
        {
            bool headerReceived = false;
            bool welcomeReceived = false;

            return SendCommandAsync(connect, message =>
            {
                if (message.Equals("TS3", StringComparison.InvariantCultureIgnoreCase))
                {
                    headerReceived = true;
                }

                if (message.StartsWith("Welcome to the TeamSpeak 3 ServerQuery interface", StringComparison.InvariantCultureIgnoreCase))
                {
                    welcomeReceived = true;
                }

                if (headerReceived && welcomeReceived)
                {
                    return new ServerQueryBaseResult(true);
                }

                return null;
            });
        }

        /// <summary>
        /// Poll the server to prevent idle disconnection.
        /// </summary>
        /// <param name="pollRate">Time between keep-alive polls.</param>
        /// <returns></returns>
        public Task KeepAlive(TimeSpan pollRate)
        {
            return Task.Run(async () =>
            {
                while (!_cancellationSource.Token.IsCancellationRequested)
                {
                    // TODO: restart counter whenever another command is sent to save unnecessary polling.
                    await Task.Delay(pollRate, _cancellationSource.Token);
                    await WhoAmI();
                }

            }, _cancellationSource.Token);
        }

        /// <summary>
        /// Closes the ServerQuery connection to the TeamSpeak 3 Server instance.
        /// </summary>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> Quit()
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.quit));
        }

        /// <summary>
        /// Authenticates with the TeamSpeak 3 Server instance using given ServerQuery login credentials.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> Login(string username, string password)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.login)
                .Add(Parameter.client_login_name, username)
                .Add(Parameter.client_login_password, password));
        }

        /// <summary>
        /// Deselects the active virtual server and logs out from the server instance.
        /// </summary>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> Logout()
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.logout));
        }

        /// <summary>
        /// Selects the virtual server specified with sid or port to allow further interaction. 
        /// The ServerQuery client will appear on the virtual server and acts like a real TeamSpeak 3 Client, except it's unable to send or receive voice data.
        /// If your database contains multiple virtual servers using the same UDP port, use will select a random virtual server using the specified port.
        /// </summary>
        /// <param name="useServerBy"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> Use(UseServerBy useServerBy, int value)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.use)
                .Add(useServerBy == UseServerBy.ServerId ? Parameter.sid : Parameter.port, value));
        }

        /// <summary>
        /// Displays a list of virtual servers including their ID, status, number of clients online, etc.
        /// If you're using the -all option, the server will list all virtual servers stored in the database.
        /// </summary>
        /// <returns></returns>
        public Task<ServerListResult> ServerList()
        {
            return SendCommandAsync(new ServerQueryCommand<ServerListResult>(Command.serverlist)
                .Add(Option.all)
                .Add(Option.uid));
        }

        /// <summary>
        /// Displays detailed configuration information about the selected virtual server including unique ID, number of clients online, configuration, etc.
        /// </summary>
        /// <returns></returns>
        public Task<ServerInfoResult> ServerInfo()
        {
            return SendCommandAsync(new ServerQueryCommand<ServerInfoResult>(Command.serverinfo));
        }

        /// <summary>
        /// Displays a list of channels created on a virtual server including their ID, order, name, etc. 
        /// All command options are specified (-topic -flags -voice -limits -icon).
        /// </summary>
        /// <returns></returns>
        public Task<ChannelListResult> ChannelList()
        {
            return SendCommandAsync(new ServerQueryCommand<ChannelListResult>(Command.channellist)
                .Add(Option.topic)
                .Add(Option.flags)
                .Add(Option.voice)
                .Add(Option.limits)
                .Add(Option.icon));
        }

        /// <summary>
        /// Displays detailed configuration information about a channel including ID, topic, description, etc.
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public Task<ChannelInfoResult> ChannelInfo(int channelId)
        {
            return SendCommandAsync(new ServerQueryCommand<ChannelInfoResult>(Command.channelinfo)
                .Add(Parameter.cid, channelId));
        }

        /// <summary>
        /// Displays a list of clients online on a virtual server including their ID, nickname, status flags, etc.
        /// All command options are specified (-uid -away -voice -times -groups -info -icon -country).
        /// Please note that the output will only contain clients which are currently in channels you're able to subscribe to.
        /// </summary>
        /// <returns></returns>
        public Task<ClientListResult> ClientList()
        {
            return SendCommandAsync(new ServerQueryCommand<ClientListResult>(Command.clientlist)
                .Add(Option.uid)
                .Add(Option.away)
                .Add(Option.voice)
                .Add(Option.times)
                .Add(Option.groups)
                .Add(Option.info)
                .Add(Option.icon)
                .Add(Option.country));
        }

        /// <summary>
        /// Displays detailed configuration information about a client including unique ID, nickname, client version, etc.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public Task<ClientInfoResult> ClientInfo(int clientId)
        {
            return SendCommandAsync(new ServerQueryCommand<ClientInfoResult>(Command.clientinfo)
                .Add(Parameter.clid, clientId));
        }

        /// <summary>
        /// Moves one or more clients specified with clid to the channel with ID cid. 
        /// If the target channel has a password, it needs to be specified with cpw. 
        /// If the channel has no password, the parameter can be omitted.
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="channelPassword"></param>
        /// <param name="clientIds"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> ClientMove(int channelId, string channelPassword, params int[] clientIds)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.clientmove)
                .Add(Parameter.cid, channelId)
                .Add(Parameter.cpw, channelPassword)
                .Add(Parameter.clid, clientIds));
        }

        /// <summary>
        /// Kicks one or more clients specified with clid from their currently joined channel or from the server, depending on reasonid. 
        /// The reasonmsg parameter specifies a text message sent to the kicked clients. This parameter is optional and may only have a maximum of 40 characters.
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="message"></param>
        /// <param name="clientIds"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> ClientKick(ReasonIdentifier reason, string message, params int[] clientIds)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.clientkick)
                .Add(Parameter.reasonid, (int)reason)
                .Add(Parameter.reasonmsg, message)
                .Add(Parameter.clid, clientIds));
        }

        /// <summary>
        /// Sends a poke message to the client specified with clid.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> ClientPoke(string message, int clientId)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.clientkick)
                .Add(Parameter.clid, clientId)
                .Add(Parameter.msg, message));
        }

        /// <summary>
        /// Displays information about your current ServerQuery connection including your loginname, etc.
        /// </summary>
        /// <returns></returns>
        public Task<WhoAmIResult> WhoAmI()
        {
            return SendCommandAsync(new ServerQueryCommand<WhoAmIResult>(Command.whoami));
        }

        /// <summary>
        /// Registers for a specified category of events on a virtual server to receive notification messages. 
        /// Depending on the notifications you've registered for, the server will send you a message on every event in the view of your ServerQuery client (e.g. clients joining your channel, incoming text messages, server configuration changes, etc). 
        /// The event source is declared by the event parameter while id can be used to limit the notifications to a specific channel.
        /// </summary>
        /// <param name="notifyEvent"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> ServerNotifyRegister(Event notifyEvent)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.servernotifyregister)
                .Add(Parameter.@event, notifyEvent));
        }

        /// <summary>
        /// Registers for a specified category of events on a virtual server to receive notification messages. 
        /// Depending on the notifications you've registered for, the server will send you a message on every event in the view of your ServerQuery client (e.g. clients joining your channel, incoming text messages, server configuration changes, etc). 
        /// The event source is declared by the event parameter while id can be used to limit the notifications to a specific channel.
        /// </summary>
        /// <param name="notifyEvent"></param>
        /// <param name="channelId">Set channelId to 0 to subscribe to all channels. This does not work for textchannel notifications.</param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> ServerNotifyRegister(Event notifyEvent, int channelId)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.servernotifyregister)
                .Add(Parameter.@event, notifyEvent)
                .Add(Parameter.id, channelId));
        }

        /// <summary>
        /// Unregisters all events previously registered with servernotifyregister so you will no longer receive notification messages.
        /// </summary>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> ServerNotifyUnregister()
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.servernotifyunregister));
        }

        /// <summary>
        /// Sends a text message a specified target. 
        /// The type of the target is determined by targetmode while target specifies the ID of the recipient, whether it be a virtual server, a channel or a client.
        /// </summary>
        /// <param name="targetMode"></param>
        /// <param name="targetId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> SendTextMessage(TextMessageTargetMode targetMode, int targetId, string message)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.sendtextmessage)
                .Add(Parameter.targetmode, targetMode)
                .Add(Parameter.target, targetId)
                .Add(Parameter.msg, message));
        }

        /// <summary>
        /// Displays a list of active bans on the selected virtual server.
        /// </summary>
        /// <returns></returns>
        public Task<BanListResult> BanList()
        {
            return SendCommandAsync(new ServerQueryCommand<BanListResult>(Command.banlist));
        }

        /// <summary>
        /// Adds a new ban rule on the selected virtual server. 
        /// All parameters are optional but at least one of the following must be set: ip, name, or uid.
        /// </summary>
        /// <param name="ip">IP or regex</param>
        /// <param name="name">Name or regex</param>
        /// <param name="uid">UniqueId or regex</param>
        /// <param name="timeInSeconds"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public Task<BanAddResult> BanAdd(string ip, string name, string uid, int? timeInSeconds, string reason)
        {
            return SendCommandAsync(new ServerQueryCommand<BanAddResult>(Command.banadd)
                .Add(Parameter.ip, ip)
                .Add(Parameter.name, name)
                .Add(Parameter.uid, uid)
                .Add(Parameter.time, timeInSeconds)
                .Add(Parameter.banreason, reason));
        }

        /// <summary>
        /// Deletes the ban rule with ID banid from the server.
        /// </summary>
        /// <param name="banId"></param>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> BanDel(int banId)
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.bandel)
                .Add(Parameter.banid, banId));
        }

        /// <summary>
        /// Deletes all active ban rules from the server.
        /// </summary>
        /// <returns></returns>
        public Task<ServerQueryBaseResult> BanDelAll()
        {
            return SendCommandAsync(new ServerQueryCommand<ServerQueryBaseResult>(Command.bandelall));
        }

        public Task<TextResult> SendCommandAsync(string command)
        {
            return SendCommandAsync(client => client.Send(command), ResultFactory.FromMessage<TextResult>);
        }

        public Task<TResult> SendCommandAsync<TResult>(ServerQueryCommand<TResult> command) where TResult : ServerQueryBaseResult
        {
            return SendCommandAsync(client => client.Send(command.ToCommandString()), command.Parser);
        }

        public Task<TResult> SendCommandAsync<TResult>(Action<TelnetClient> command, Func<string, TResult> parser) where TResult : ServerQueryBaseResult
        {
            TaskCompletionSource<TResult> completionSource = new TaskCompletionSource<TResult>();

            // Store result outside handler
            // Complex results return data and then a normal ServerQueryResult to signify command completion
            // We need to wait for that command completed result before releasing
            TResult result = null;

            // Handle incoming messages, pass them through our parser
            // If we parse successfully, and we've received a command completed result, the task has completed
            EventHandler<string> messageReceived = (sender, message) =>
            {
                if (result == null)
                {
                    result = parser(message);
                }

                // If we're expecting a basic ServerQueryResult, just return it
                // If we're expecting something else, wait for a ServerQueryResult to signify command completion
                if (result != null && (typeof(TResult) == typeof(ServerQueryBaseResult) || ResultFactory.FromMessage<ServerQueryBaseResult>(message) != null))
                {
                    completionSource.TrySetResult(result);
                }
            };

            // Cancel the cancel cancel if we cancel the cancel
            CancellationTokenRegistration cancellationRegistration = _cancellationSource.Token.Register(completionSource.SetCanceled);

            // Clean up after our task finishes
            completionSource.Task.ContinueWith(task =>
            {
                // We don't care about cancellation anymore
                // If we don't unbind this, we'll get errors about trying to cancel an already-completed task
                cancellationRegistration.Dispose();
                
                // Unbind MessageReceived handler to prevent leaks
                _telnetClient.MessageReceived -= messageReceived;

                // We're done, other commands may now start
                _commandQueue.Release();
            });

            // Wait for other commands to complete, then run our command
            _commandQueue.WaitAsync(_cancellationSource.Token).ContinueWith(_ =>
            {
                // Start listening!
                _telnetClient.MessageReceived += messageReceived;

                // Execute command
                command(_telnetClient);
            });

            return completionSource.Task;
        }

        private void HandleConnectionClosed(object sender, EventArgs eventArgs)
        {
            // Blow away any executing tasks
            // This is for our ReadLineAsync loop in TelnetClient and our KeepAlive loop here
            _cancellationSource.Cancel();

            // Tell our consumers they probably want to do something
            EventHandler connectionClosed = ConnectionClosed;

            if (connectionClosed != null)
            {
                connectionClosed(this, new EventArgs());
            }
        }

        private void HandleMessageReceived(object sender, string message)
        {
            ServerQueryBaseResult result = ResultFactory.FromMessage<ServerQueryBaseResult>(message);

            if (result != null && result.ErrorId == 3329)
            {
                throw new InvalidOperationException(string.Format("Error {0} {1} {2}", result.ErrorId, result.ErrorMessage, result.ExtraMessage));
            }

            foreach (KeyValuePair<Type, Regex> notifyType in ResultFactory.NotifyTypeMap)
            {
                if (!notifyType.Value.IsMatch(message))
                {
                    continue;
                }

                if (notifyType.Key == typeof (NotifyTextMessageResult))
                {
                    OnNotify(NotifyTextMessage, message);
                    break;
                }
                
                if (notifyType.Key == typeof(NotifyClientEnterViewResult))
                {
                    OnNotify(NotifyClientEnterView, message);
                    break;
                }

                if (notifyType.Key == typeof(NotifyClientLeftViewResult))
                {
                    OnNotify(NotifyClientLeftView, message);
                    break;
                }

                if (notifyType.Key == typeof(NotifyClientMovedResult))
                {
                    OnNotify(NotifyClientMoved, message);
                    break;
                }

                if (notifyType.Key == typeof(NotifyServerEditedResult))
                {
                    OnNotify(NotifyServerEdited, message);
                    break;
                }

                if (notifyType.Key == typeof(NotifyChannelEditedResult))
                {
                    OnNotify(NotifyChannelEdited, message);
                    break;
                }

                if (notifyType.Key == typeof(NotifyChannelDescriptionChangedResult))
                {
                    OnNotify(NotifyChannelDescriptionChanged, message);
                    break;
                }
            }
        }

        private void OnNotify<TNotify>(EventHandler<TNotify> eventHandler, string message) where TNotify : NotifyBaseResult
        {
            TNotify notification = ResultFactory.FromNotification<TNotify>(message);

            if (notification == null)
            {
                return;
            }
            
            EventHandler<TNotify> handler = eventHandler;

            if (handler != null)
            {
                handler(this, notification);
            }
        }
    }
}
