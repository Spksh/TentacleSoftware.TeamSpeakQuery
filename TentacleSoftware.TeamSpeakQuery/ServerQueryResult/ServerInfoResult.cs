namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class ServerInfoResult : ServerQueryBaseResult
    {
        /// <summary> 
        /// Name of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_name", Required = true)]
        public string VirtualServerName { get; set; }

        /// <summary> 
        /// Welcome message of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_welcomemessage", Required = true)]
        public string VirtualServerWelcomemessage { get; set; }

        /// <summary> 
        /// Number of slots available on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_maxclients", Required = true)]
        public string VirtualServerMaxclients { get; set; }

        /// <summary> 
        /// Password of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_password", Required = true)]
        public string VirtualServerPassword { get; set; }

        /// <summary> 
        /// Indicates whether the server has a password set or not
        /// </summary>
        [PropertyMapping("virtualserver_flag_password", Required = true)]
        public string VirtualServerFlagPassword { get; set; }

        /// <summary> 
        /// Number of clients connected to the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_clientsonline", Required = true)]
        public string VirtualServerClientsonline { get; set; }

        /// <summary> 
        /// Number of ServerQuery clients connected to the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_queryclientsonline", Required = true)]
        public string VirtualServerQueryclientsonline { get; set; }

        /// <summary> 
        /// Number of channels created on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_channelsonline", Required = true)]
        public string VirtualServerChannelsonline { get; set; }

        /// <summary> 
        /// Creation date and time of the virtual server as UTC timestamp
        /// </summary>
        [PropertyMapping("virtualserver_created", Required = true)]
        public string VirtualServerCreated { get; set; }

        /// <summary> 
        /// Uptime in seconds
        /// </summary>
        [PropertyMapping("virtualserver_uptime", Required = true)]
        public string VirtualServerUptime { get; set; }

        /// <summary> 
        /// Host message of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_hostmessage", Required = true)]
        public string VirtualServerHostmessage { get; set; }

        /// <summary> 
        /// Host message mode of the virtual server (see Definitions)
        /// </summary>
        [PropertyMapping("virtualserver_hostmessage_mode", Required = true)]
        public string VirtualServerHostmessageMode { get; set; }

        /// <summary> 
        /// Default server group ID
        /// </summary>
        [PropertyMapping("virtualserver_default_server_group", Required = true)]
        public string VirtualServerDefaultServerGroup { get; set; }

        /// <summary> 
        /// Default channel group ID
        /// </summary>
        [PropertyMapping("virtualserver_default_channel_group", Required = true)]
        public string VirtualServerDefaultChannelGroup { get; set; }

        /// <summary> 
        /// Default channel administrator group ID
        /// </summary>
        [PropertyMapping("virtualserver_default_channel_admin_group", Required = true)]
        public string VirtualServerDefaultChannelAdminGroup { get; set; }

        /// <summary> 
        /// Operating system the server is running on
        /// </summary>
        [PropertyMapping("virtualserver_platform", Required = true)]
        public string VirtualServerPlatform { get; set; }

        /// <summary> 
        /// Server version information including build number
        /// </summary>
        [PropertyMapping("virtualserver_version", Required = true)]
        public string VirtualServerVersion { get; set; }

        /// <summary> 
        /// Max bandwidth for outgoing file transfers on the virtual server (Bytes/s)
        /// </summary>
        [PropertyMapping("virtualserver_max_download_total_bandwidth", Required = true)]
        public string VirtualServerMaxDownloadTotalBandwidth { get; set; }

        /// <summary> 
        /// Max bandwidth for incoming file transfers on the virtual server (Bytes/s)
        /// </summary>
        [PropertyMapping("virtualserver_max_upload_total_bandwidth", Required = true)]
        public string VirtualServerMaxUploadTotalBandwidth { get; set; }

        /// <summary> 
        /// Host banner URL opened on click
        /// </summary>
        [PropertyMapping("virtualserver_hostbanner_url", Required = true)]
        public string VirtualServerHostbannerUrl { get; set; }

        /// <summary> 
        /// Host banner URL used as image source
        /// </summary>
        [PropertyMapping("virtualserver_hostbanner_gfx_url", Required = true)]
        public string VirtualServerHostbannerGfxUrl { get; set; }

        /// <summary> 
        /// Interval for reloading the banner on client-side
        /// </summary>
        [PropertyMapping("virtualserver_hostbanner_gfx_interval", Required = true)]
        public string VirtualServerHostbannerGfxInterval { get; set; }

        /// <summary> 
        /// Number of complaints needed to ban a client automatically
        /// </summary>
        [PropertyMapping("virtualserver_complain_autoban_count", Required = true)]
        public string VirtualServerComplainAutobanCount { get; set; }

        /// <summary> 
        /// Time in seconds used for automatic bans triggered by complaints
        /// </summary>
        [PropertyMapping("virtualserver_complain_autoban_time", Required = true)]
        public string VirtualServerComplainAutobanTime { get; set; }

        /// <summary> 
        /// Time in seconds before a complaint is deleted automatically
        /// </summary>
        [PropertyMapping("virtualserver_complain_remove_time", Required = true)]
        public string VirtualServerComplainRemoveTime { get; set; }

        /// <summary> 
        /// Number of clients in the same channel needed to force silence
        /// </summary>
        [PropertyMapping("virtualserver_min_clients_in_channel_before_forced_silence", Required = true)]
        public string VirtualServerMinClientsInChannelBeforeForcedSilence { get; set; }

        /// <summary> 
        /// Client volume lowered automatically while a priority speaker is talking
        /// </summary>
        [PropertyMapping("virtualserver_priority_speaker_dimm_modificator", Required = true)]
        public string VirtualServerPrioritySpeakerDimmModificator { get; set; }

        /// <summary> 
        /// Anti-flood points removed from a client for being good
        /// </summary>
        [PropertyMapping("virtualserver_antiflood_points_tick_reduce", Required = true)]
        public string VirtualServerAntifloodPointsTickReduce { get; set; }

        /// <summary> 
        /// Anti-flood points needed to block commands being executed by the client
        /// </summary>
        [PropertyMapping("virtualserver_antiflood_points_needed_command_block", Required = true)]
        public string VirtualServerAntifloodPointsNeededCommandBlock { get; set; }

        /// <summary> 
        /// Anti-flood points needed to block incoming connections from the client
        /// </summary>
        [PropertyMapping("virtualserver_antiflood_points_needed_ip_block", Required = true)]
        public string VirtualServerAntifloodPointsNeededIpBlock { get; set; }

        /// <summary> 
        /// The display mode for the virtual servers hostbanner (see Definitions)
        /// </summary>
        [PropertyMapping("virtualserver_hostbanner_mode", Required = true)]
        public string VirtualServerHostbannerMode { get; set; }

        /// <summary> 
        /// Indicates whether the initial privilege key for the virtual server has been used or not
        /// </summary>
        [PropertyMapping("virtualserver_ask_for_privilegekey", Required = true)]
        public string VirtualServerAskForPrivilegekey { get; set; }

        /// <summary> 
        /// Total number of clients connected to the virtual server since it was last started
        /// </summary>
        [PropertyMapping("virtualserver_client_connections", Required = true)]
        public string VirtualServerClientConnections { get; set; }

        /// <summary> 
        /// Total number of ServerQuery clients connected to the virtual server since it was last started
        /// </summary>
        [PropertyMapping("virtualserver_query_client_connections", Required = true)]
        public string VirtualServerQueryClientConnections { get; set; }

        /// <summary> 
        /// Text used for the tooltip of the host button on client-side
        /// </summary>
        [PropertyMapping("virtualserver_hostbutton_tooltip", Required = true)]
        public string VirtualServerHostbuttonTooltip { get; set; }

        /// <summary> 
        /// Text used for the tooltip of the host button on client-side
        /// </summary>
        [PropertyMapping("virtualserver_hostbutton_gfx_url", Required = true)]
        public string VirtualServerHostbuttonGfxUrl { get; set; }

        /// <summary> 
        /// URL opened on click on the host button
        /// </summary>
        [PropertyMapping("virtualserver_hostbutton_url", Required = true)]
        public string VirtualServerHostbuttonUrl { get; set; }

        /// <summary> 
        /// Download quota for the virtual server (MByte)
        /// </summary>
        [PropertyMapping("virtualserver_download_quota", Required = true)]
        public string VirtualServerDownloadQuota { get; set; }

        /// <summary> 
        /// Download quota for the virtual server (MByte)
        /// </summary>
        [PropertyMapping("virtualserver_upload_quota", Required = true)]
        public string VirtualServerUploadQuota { get; set; }

        /// <summary> 
        /// Number of bytes downloaded from the virtual server on the current month
        /// </summary>
        [PropertyMapping("virtualserver_month_bytes_downloaded", Required = true)]
        public string VirtualServerMonthBytesDownloaded { get; set; }

        /// <summary> 
        /// Number of bytes uploaded to the virtual server on the current month
        /// </summary>
        [PropertyMapping("virtualserver_month_bytes_uploaded", Required = true)]
        public string VirtualServerMonthBytesUploaded { get; set; }

        /// <summary> 
        /// Number of bytes downloaded from the virtual server since it was last started
        /// </summary>
        [PropertyMapping("virtualserver_total_bytes_downloaded", Required = true)]
        public string VirtualServerTotalBytesDownloaded { get; set; }

        /// <summary> 
        /// Number of bytes uploaded to the virtual server since it was last started
        /// </summary>
        [PropertyMapping("virtualserver_total_bytes_uploaded", Required = true)]
        public string VirtualServerTotalBytesUploaded { get; set; }

        /// <summary> 
        /// Unique ID of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_unique_identifier", Required = true)]
        public string VirtualServerUniqueIdentifer { get; set; }

        /// <summary> 
        /// Database ID of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_id", Required = true)]
        public int VirtualServerId { get; set; }

        /// <summary> 
        /// Machine ID identifying the server instance associated with the virtual server in the database
        /// </summary>
        [PropertyMapping("virtualserver_machine_id", Required = true)]
        public int VirtualServerMachineId { get; set; }

        /// <summary> 
        /// UDP port the virtual server is listening on
        /// </summary>
        [PropertyMapping("virtualserver_port", Required = true)]
        public int VirtualServerPort { get; set; }

        /// <summary> 
        /// Indicates whether the server starts automatically with the server instance or not
        /// </summary>
        [PropertyMapping("virtualserver_autostart", Required = true)]
        public string VirtualServerAutostart { get; set; }

        /// <summary> 
        /// Current bandwidth used for outgoing file transfers (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_filetransfer_bandwidth_sent", Required = true)]
        public string ConnectionFiletransferBandwidthSent { get; set; }

        /// <summary> 
        /// Current bandwidth used for incoming file transfers (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_filetransfer_bandwidth_received", Required = true)]
        public string ConnectionFiletransferBandwidthReceived { get; set; }

        /// <summary> 
        /// Total amount of packets sent
        /// </summary>
        [PropertyMapping("connection_packets_sent_total", Required = true)]
        public string ConnectionPacketsSentTotal { get; set; }

        /// <summary> 
        /// Total amount of packets received
        /// </summary>
        [PropertyMapping("connection_packets_received_total", Required = true)]
        public string ConnectionPacketsReceivedTotal { get; set; }

        /// <summary> 
        /// Total amount of bytes sent
        /// </summary>
        [PropertyMapping("connection_bytes_sent_total", Required = true)]
        public string ConnectionBytesSentTotal { get; set; }

        /// <summary> 
        /// Total amount of bytes received
        /// </summary>
        [PropertyMapping("connection_bytes_received_total", Required = true)]
        public string ConnectionBytesReceivedTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for outgoing data in the last second (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_sent_last_second_total", Required = true)]
        public string ConnectionBandwidthSentLastSecondTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for incoming data in the last second (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_received_last_second_total", Required = true)]
        public string ConnectionBandwidthReceivedLastSecondTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for outgoing data in the last minute (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_sent_last_minute_total", Required = true)]
        public string ConnectionBandwidthSentLastMinuteTotal { get; set; }

        /// <summary> 
        /// Average bandwidth used for incoming data in the last minute (Bytes/s)
        /// </summary>
        [PropertyMapping("connection_bandwidth_received_last_minute_total", Required = true)]
        public string ConnectionBandwidthReceivedLastMinuteTotal { get; set; }

        /// <summary> 
        /// Status of the virtual server (online | virtual online | offline | booting up | shutting down | …)
        /// </summary>
        [PropertyMapping("virtualserver_status", Required = true)]
        public string VirtualServerStatus { get; set; }

        /// <summary> 
        /// Indicates whether the server logs events related to clients or not
        /// </summary>
        [PropertyMapping("virtualserver_log_client", Required = true)]
        public string VirtualServerLogClient { get; set; }

        /// <summary> 
        /// Indicates whether the server logs events related to ServerQuery clients or not
        /// </summary>
        [PropertyMapping("virtualserver_log_query", Required = true)]
        public string VirtualServerLogQuery { get; set; }

        /// <summary> 
        /// Indicates whether the server logs events related to channels or not
        /// </summary>
        [PropertyMapping("virtualserver_log_channel", Required = true)]
        public string VirtualServerLogChannel { get; set; }

        /// <summary> 
        /// Indicates whether the server logs events related to permissions or not
        /// </summary>
        [PropertyMapping("virtualserver_log_permissions", Required = true)]
        public string VirtualServerLogPermissions { get; set; }

        /// <summary> 
        /// Indicates whether the server logs events related to server changes or not
        /// </summary>
        [PropertyMapping("virtualserver_log_server", Required = true)]
        public string VirtualServerLogServer { get; set; }

        /// <summary> 
        /// Indicates whether the server logs events related to file transfers or not
        /// </summary>
        [PropertyMapping("virtualserver_log_filetransfer", Required = true)]
        public string VirtualServerLogFiletransfer { get; set; }

        /// <summary> 
        /// Min client version required to connect
        /// </summary>
        [PropertyMapping("virtualserver_min_client_version", Required = true)]
        public string VirtualServerMinClientVersion { get; set; }

        /// <summary> 
        /// Minimum client identity security level required to connect to the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_needed_identity_security_level", Required = true)]
        public string VirtualServerNeededIdentitySecurityLevel { get; set; }

        /// <summary> 
        /// Phonetic name of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_name_phonetic", Required = true)]
        public string VirtualServerNamePhonetic { get; set; }

        /// <summary> 
        /// CRC32 checksum of the virtual server icon
        /// </summary>
        [PropertyMapping("virtualserver_icon_id", Required = true)]
        public string VirtualServerIconId { get; set; }

        /// <summary> 
        /// Number of reserved slots available on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_reserved_slots", Required = true)]
        public string VirtualServerReservedSlots { get; set; }

        /// <summary> 
        /// The average packet loss for speech data on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_total_packetloss_speech", Required = true)]
        public string VirtualServerTotalPacketlossSpeech { get; set; }

        /// <summary> 
        /// The average packet loss for keepalive data on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_total_packetloss_keepalive", Required = true)]
        public string VirtualServerTotalPacketlossKeepalive { get; set; }

        /// <summary> 
        /// The average packet loss for control data on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_total_packetloss_control", Required = true)]
        public string VirtualServerTotalPacketlossControl { get; set; }

        /// <summary> 
        /// The average packet loss for all data on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_total_packetloss_total", Required = true)]
        public string VirtualServerTotalPacketlossTotal { get; set; }

        /// <summary> 
        /// The average ping of all clients connected to the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_total_ping", Required = true)]
        public string VirtualServerTotalPing { get; set; }

        /// <summary> 
        /// The IPv4 address the virtual server is listening on
        /// </summary>
        [PropertyMapping("virtualserver_ip", Required = true)]
        public string VirtualServerIp { get; set; }

        /// <summary> 
        /// Indicates whether the server appears in the global web server list or not
        /// </summary>
        [PropertyMapping("virtualserver_weblist_enabled", Required = true)]
        public string VirtualServerWeblistEnabled { get; set; }

        /// <summary> 
        /// The global codec encryption mode of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_codec_encryption_mode", Required = true)]
        public string VirtualServerCodecEncryptionMode { get; set; }

        /// <summary> 
        /// The directory where the virtual servers filebase is located
        /// </summary>
        [PropertyMapping("virtualserver_filebase", Required = true)]
        public string VirtualServerFilebase { get; set; }

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
