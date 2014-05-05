TentacleSoftware.TeamSpeakQuery
===============================

A task-based event-driven Team Speak 3 ServerQuery client that supports SOCKS4 proxies.

You should be familiar with the TS3 ServerQuery command syntax. Bedtime reading is available here: http://media.teamspeak.com/ts3_literature/TeamSpeak%203%20Server%20Query%20Manual.pdf

Step 1. Instantiate a shiny new ServerQueryClient, passing in destination host and ServerQuery port (this is 10011 by default). 

Include a throttle timespan to avoid flooding the server. If you're not on the server's whitelist, your throttle will need to be higher. We don't want to get banned, do we?

```
ServerQueryClient client = new ServerQueryClient("host.teamspeakprovider.com", 10011, TimeSpan.FromSeconds(3));
```

Step 2. Subscribe to client events.

```
client.ConnectionClosed += (sender, eventArgs) => Console.WriteLine(":sadface:");
```

If you're planning to subscribe to server notifications (and your login credentials have the required permissions), saddle those event handlers up too:

* NotifyChannelDescriptionChanged
* NotifyChannelEdited
* NotifyClientEnterView
* NotifyClientLeftView
* NotifyClientMoved
* NotifyServerEdited
* NotifyTextMessage

For example:

```
client.NotifyClientEnterView += (source, notification) => Console.WriteLine("ClientEnterView {0}: {1}", notification.Clid, notification.ClientNickname);
```

Step 3: Initialize the client and observe the task result. Once the task has completed, you are connected.

```
ServerQueryBaseResult connected = client.Initialize().Result;
Console.WriteLine("connected {0}", connected.Success);
```

You can pass in SOCKS4 proxy credentials instead:

```
ServerQueryBaseResult connected = client.Initialize("myproxy.proxy.com", 3453, null).Result;
```

Step 4: Log in if you have credentials. This is not your normal TeamSpeak username and password; see the manual above for instructions on creating a ServerQuery user.

```
ServerQueryBaseResult login = client.Login("myserverqueryuser", "s3cr3t").Result;
Console.WriteLine("login {0} {1} {2}", login.Success, login.ErrorId, login.ErrorMessage);
```

Step 5: Select the TeamSpeak instance you will be manipulating. You can select the instance using the port (which is the port number you connect to with your normal TeamSpeak client) or serverId if you know it. See the manual above for more information.

```
ServerQueryBaseResult use = client.Use(UseServerBy.Port, 5555).Result;
Console.WriteLine("use {0} {1} {2}", use.Success, use.ErrorId, use.ErrorMessage);
```

Step 6: If you're registering for server notifications later, you may want a keepalive. This is just a simple task loop that requests a "whoami" response from the server.

```
client.KeepAlive(TimeSpan.FromMinutes(2));
```

Step 7: Register for the server notifications you care about.

```
ServerQueryBaseResult registerTextChannel = client.ServerNotifyRegister(Event.textchannel).Result;
Console.WriteLine("registerTextChannel {0} {1} {2}", registerTextChannel.Success, registerTextChannel.ErrorId, registerTextChannel.ErrorMessage);
```

Step 8: Have your way with the poor, innocent server!

```
ClientListResult clientList = client.ClientList().Result;
Console.WriteLine("clientList {0} {1} [x{2}]", channelList.Success, channelList.ErrorId, clientList.Values != null ? clientList.Values.Count : 0);
```

Commands are named the same as the text commands in the TS3 ServerQuery manual. I've explicitly implemented some of the commands I most use as methods on ServerQueryClient:

* Quit
* Login
* Logout
* Use
* ServerInfo
* ChannelList
* ChannelInfo
* ClientList
* ClientInfo
* ClientMove
* ClientKick
* ClientPoke
* WhoAmI
* ServerNotifyRegister
* ServerNotifyUnregister
* SendTextMessage
* BanList
* BanAdd
* BanDel
* BanDellAll

Other commands can be created using the ServerQueryCommand class and adding parameters and options as per the TS3 ServerQuery manual. Send your new command using ServerQueryClient.SendCommandAsync() with an appropriate response class. The implementations above should give you a good starting point.

Or you can just send text commands and get back the raw response using the ServerQueryClient.SendCommandAsync(string command) overload.

Clean up: Be a good ServerQuery client and say goodbye.

```
ServerQueryBaseResult unregister = client.ServerNotifyUnregister().Result;
Console.WriteLine("unregister {0} {1} {2}", unregister.Success, unregister.ErrorId, unregister.ErrorMessage);

ServerQueryBaseResult logout = client.Logout().Result;
Console.WriteLine("logout {0} {1} {2}", logout.Success, logout.ErrorId, logout.ErrorMessage);

ServerQueryBaseResult quit = client.Quit().Result;
Console.WriteLine("quit {0} {1} {2}", quit.Success, quit.ErrorId, quit.ErrorMessage);
```
