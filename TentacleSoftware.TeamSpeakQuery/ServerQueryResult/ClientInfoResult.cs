namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class ClientInfoResult : ServerQueryBaseResult
    {
        /// <summary> 
        /// Unique ID of the client
        /// </summary>
        [PropertyMapping("client_unique_identifier")]
        public string ClientUniqueIdentifier { get; set; }

        /// <summary> 
        /// Nickname of the client
        /// </summary>
        [PropertyMapping("client_nickname", Required = true)]
        public string ClientNickname { get; set; }

        /// <summary> 
        /// Client version information including build number
        /// </summary>
        [PropertyMapping("client_version")]
        public string ClientVersion { get; set; }

        /// <summary> 
        /// Operating system the client is running on
        /// </summary>
        [PropertyMapping("client_platform")]
        public string ClientPlatform { get; set; }

        /// <summary> 
        /// Indicates whether the client has their microphone muted or not
        /// </summary>
        [PropertyMapping("client_input_muted")]
        public string ClientInputMuted { get; set; }

        /// <summary> 
        /// Indicates whether the client has their speakers muted or not
        /// </summary>
        [PropertyMapping("client_output_muted")]
        public string ClientOutputMuted { get; set; }

        /// <summary> 
        /// Indicates whether the client has enabled their capture device or not
        /// </summary>
        [PropertyMapping("client_input_hardware")]
        public string ClientInputHardware { get; set; }

        /// <summary> 
        /// Indicates whether the client has enabled their playback device or not
        /// </summary>
        [PropertyMapping("client_output_hardware")]
        public string ClientOutputHardware { get; set; }

        /// <summary> 
        /// Default channel of the client
        /// </summary>
        [PropertyMapping("client_default_channel")]
        public string ClientDefaultChannel { get; set; }

        /// <summary> 
        /// Username of a ServerQuery client
        /// </summary>
        [PropertyMapping("client_login_name")]
        public string ClientLoginName { get; set; }

        /// <summary> 
        /// Database ID of the client
        /// </summary>
        [PropertyMapping("client_database_id", Required = true)]
        public string ClientDatabaseId { get; set; }

        /// <summary> 
        /// Current channel group ID of the client
        /// </summary>
        [PropertyMapping("client_channel_group_id")]
        public string ClientChannelGroupId { get; set; }

        /// <summary> 
        /// Current server group IDs of the client separated by a comma
        /// </summary>
        [PropertyMapping("client_server_groups")]
        [PropertyMapping("client_servergroups")]
        public string ClientServerGroups { get; set; }

        /// <summary> 
        /// Creation date and time of the clients first connection to the server as UTC timestamp
        /// </summary>
        [PropertyMapping("client_created")]
        public string ClientCreated { get; set; }

        /// <summary> 
        /// Creation date and time of the clients last connection to the server as UTC timestamp
        /// </summary>
        [PropertyMapping("client_lastconnected")]
        public string ClientLastconnected { get; set; }

        /// <summary> 
        /// Total number of connections from this client since the server was started
        /// </summary>
        [PropertyMapping("client_totalconnections")]
        public string ClientTotalconnections { get; set; }

        /// <summary> 
        /// Indicates whether the client is away or not
        /// </summary>
        [PropertyMapping("client_away")]
        public string ClientAway { get; set; }

        /// <summary> 
        /// Away message of the client
        /// </summary>
        [PropertyMapping("client_away_message")]
        public string ClientAwayMessage { get; set; }

        /// <summary> 
        /// Indicates whether the client is a ServerQuery client or not
        /// </summary>
        [PropertyMapping("client_type", Required = true)]
        public string ClientType { get; set; }

        /// <summary> 
        /// Indicates whether the client has set an avatar or not
        /// </summary>
        [PropertyMapping("client_flag_avatar")]
        public string ClientFlagAvatar { get; set; }

        /// <summary> 
        /// The clients current talk power
        /// </summary>
        [PropertyMapping("client_talk_power")]
        public string ClientTalkPower { get; set; }

        /// <summary> 
        /// Indicates whether the client is requesting talk power or not
        /// </summary>
        [PropertyMapping("client_talk_request")]
        public string ClientTalkRequest { get; set; }

        /// <summary> 
        /// The clients current talk power request message
        /// </summary>
        [PropertyMapping("client_talk_request_msg")]
        public string ClientTalkRequestMsg { get; set; }

        /// <summary> 
        /// Indicates whether the client is able to talk or not
        /// </summary>
        [PropertyMapping("client_is_talker")]
        public string ClientIsTalker { get; set; }

        /// <summary> 
        /// Number of bytes downloaded by the client on the current month
        /// </summary>
        [PropertyMapping("client_month_bytes_downloaded")]
        public string ClientMonthBytesDownloaded { get; set; }

        /// <summary> 
        /// Number of bytes uploaded by the client on the current month
        /// </summary>
        [PropertyMapping("client_month_bytes_uploaded")]
        public string ClientMonthBytesUploaded { get; set; }

        /// <summary> 
        /// Number of bytes downloaded by the client since the server was started
        /// </summary>
        [PropertyMapping("client_total_bytes_downloaded")]
        public string ClientTotalBytesDownloaded { get; set; }

        /// <summary> 
        /// Number of bytes uploaded by the client since the server was started
        /// </summary>
        [PropertyMapping("client_total_bytes_uploaded")]
        public string ClientTotalBytesUploaded { get; set; }

        /// <summary> 
        /// Indicates whether the client is a priority speaker or not
        /// </summary>
        [PropertyMapping("client_is_priority_speaker")]
        public string ClientIsPrioritySpeaker { get; set; }

        /// <summary> 
        /// Number of unread offline messages in this clients inbox
        /// </summary>
        [PropertyMapping("client_unread_messages")]
        public string ClientUnreadMessages { get; set; }

        /// <summary> 
        /// Phonetic name of the client
        /// </summary>
        [PropertyMapping("client_nickname_phonetic")]
        public string ClientNicknamePhonetic { get; set; }

        /// <summary> 
        /// Brief description of the client
        /// </summary>
        [PropertyMapping("client_description")]
        public string ClientDescription { get; set; }

        /// <summary> 
        /// The clients current ServerQuery view power
        /// </summary>
        [PropertyMapping("client_needed_serverquery_view_power")]
        public string ClientNeededServerqueryViewPower { get; set; }

        /// <summary> 
        /// Current bandwidth used for outgoing file transfers (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_filetransfer_bandwidth_sent")]
        public string ConnectionFiletransferBandwidthSent { get; set; }

        /// <summary> 
        /// Current bandwidth used for incoming file transfers (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_filetransfer_bandwidth_received")]
        public string ConnectionFiletransferBandwidthReceived { get; set; }

        /// <summary> 
        /// Total amount of packets sent
        /// </summary>
        [PropertyMapping("connection_packets_sent_total")]
        public string ConnectionPacketsSentTotal { get; set; }

        /// <summary> 
        /// Total amount of packets received
        /// </summary>
        [PropertyMapping("connection_packets_received_total")]
        public string ConnectionPacketsReceivedTotal { get; set; }

        /// <summary> 
        /// Total amount of bytes sent
        /// </summary>
        [PropertyMapping("connection_bytes_sent_total")]
        public string ConnectionBytesSentTotal { get; set; }

        /// <summary> 
        /// Total amount of bytes received
        /// </summary>
        [PropertyMapping("connection_bytes_received_total")]
        public string ConnectionBytesReceivedTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for outgoing data in the last second (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_sent_last_second_total")]
        public string ConnectionBandwidthSentLastSecondTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for incoming data in the last second (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_received_last_second_total")]
        public string ConnectionBandwidthReceivedLastSecondTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for outgoing data in the last minute (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_sent_last_minute_total")]
        public string ConnectionBandwidthSentLastMinuteTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for incoming data in the last minute (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_received_last_minute_total")]
        public string ConnectionBandwidthReceivedLastMinuteTotal { get; set; }

        /// <summary> 
        /// The IPv4 address of the client
        /// </summary>
        [PropertyMapping("connection_client_ip")]
        public string ConnectionClientIp { get; set; }

        /// <summary> 
        /// Indicates whether the client is a channel commander or not
        /// </summary>
        [PropertyMapping("client_is_channel_commander")]
        public string ClientIsChannelCommander { get; set; }

        /// <summary> 
        /// CRC32 checksum of the client icon
        /// </summary>
        [PropertyMapping("client_icon_id")]
        public string ClientIconId { get; set; }

        /// <summary> 
        /// The country identifier of the client (i.e. DE)
        /// </summary>
        [PropertyMapping("client_country")]
        public string ClientCountry { get; set; }

        [PropertyMapping("cid")]
        public string ChannelId { get; set; }

        [PropertyMapping("clid")]
        public string ClientId { get; set; }

        [PropertyMapping("client_channel_group_inherited_channel_id")]
        public string ClientChannelGroupInheritedChannelId { get; set; }

        [PropertyMapping("client_flag_talking")]
        public string ClientFlagTalking { get; set; }

        [PropertyMapping("client_idle_time")]
        public string ClientIdleTime { get; set; }

        [PropertyMapping("client_is_recording")]
        public string ClientIsRecording { get; set; }

        public override bool Parse(string message)
        {
            // Is this an error response?
            if (base.Parse(message))
            {
                return true;
            }

            if (this.MapPropertyValuesFrom(message))
            {
                Success = true;
                Response = message;

                return true;
            }

            return false;
        }
    }
}
