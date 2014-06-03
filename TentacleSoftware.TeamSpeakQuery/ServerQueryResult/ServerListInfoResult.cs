namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class ServerListInfoResult : ServerQueryBaseResult
    {
        /// <summary> 
        /// Database ID of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_id", Required = true)]
        public int VirtualServerId { get; set; }

        /// <summary> 
        /// UDP port the virtual server is listening on
        /// </summary>
        [PropertyMapping("virtualserver_port", Required = true)]
        public int VirtualServerPort { get; set; }

        /// <summary> 
        /// Status of the virtual server (online | virtual online | offline | booting up | shutting down | …)
        /// </summary>
        [PropertyMapping("virtualserver_status", Required = true)]
        public string VirtualServerStatus { get; set; }

        /// <summary> 
        /// Number of clients connected to the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_clientsonline")]
        public int VirtualServerClientsonline { get; set; }

        /// <summary> 
        /// Number of ServerQuery clients connected to the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_queryclientsonline")]
        public int VirtualServerQueryclientsonline { get; set; }

        /// <summary> 
        /// Number of slots available on the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_maxclients")]
        public int VirtualServerMaxclients { get; set; }

        /// <summary> 
        /// Uptime in seconds
        /// </summary>
        [PropertyMapping("virtualserver_uptime")]
        public long VirtualServerUptime { get; set; }

        /// <summary> 
        /// Name of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_name")]
        public string VirtualServerName { get; set; }

        /// <summary> 
        /// Indicates whether the server starts automatically with the server instance or not
        /// </summary>
        [PropertyMapping("virtualserver_autostart")]
        public string VirtualServerAutostart { get; set; }

        /// <summary> 
        /// Machine ID identifying the server instance associated with the virtual server in the database
        /// </summary>
        [PropertyMapping("virtualserver_machine_id")]
        public int VirtualServerMachineId { get; set; }

        /// <summary> 
        /// Unique ID of the virtual server
        /// </summary>
        [PropertyMapping("virtualserver_unique_identifier")]
        public string VirtualServerUniqueIdentifer { get; set; }

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
