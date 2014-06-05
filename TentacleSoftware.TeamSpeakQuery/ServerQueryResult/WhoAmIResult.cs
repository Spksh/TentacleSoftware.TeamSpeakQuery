namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class WhoAmIResult : ServerQueryBaseResult
    {
        [PropertyMapping("virtualserver_status", Required = true)]
        public string VirtualServerStatus { get; set; }

        [PropertyMapping("virtualserver_id", Required = true)]
        public int VirtualServerId { get; set; }

        [PropertyMapping("virtualserver_unique_identifier")]
        public string VirtualServerUniqueIdentifier { get; set; }

        [PropertyMapping("virtualserver_port", Required = true)]
        public int VirtualServerPort { get; set; }

        [PropertyMapping("client_id", Required = true)]
        public int ClientId { get; set; }

        [PropertyMapping("client_channel_id", Required = true)]
        public int ClientChannelId { get; set; }

        [PropertyMapping("client_nickname", Required = true)]
        public string ClientNickname { get; set; }

        [PropertyMapping("client_database_id", Required = true)]
        public int ClientDatabaseId { get; set; }

        [PropertyMapping("client_login_name", Required = true)]
        public string ClientLoginName { get; set; }

        [PropertyMapping("client_unique_identifier", Required = true)]
        public string ClientUniqueIdentifier { get; set; }

        [PropertyMapping("client_origin_server_id", Required = true)]
        public int ClientOriginServerId { get; set; }

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
