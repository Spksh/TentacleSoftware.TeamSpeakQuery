namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class BanInfoResult : ServerQueryBaseResult
    { 
        [PropertyMapping("banid", Required = true)]
        public int BanId { get; set; }

        [PropertyMapping("ip", Required = true)]
        public string Ip { get; set; }

        [PropertyMapping("name", Required = true)]
        public string Name { get; set; }

        [PropertyMapping("uid", Required = true)]
        public string UniqueId { get; set; }

        [PropertyMapping("lastnickname", Required = true)]
        public string LastNickname { get; set; }

        [PropertyMapping("created", Required = true)]
        public string Created { get; set; }

        [PropertyMapping("duration", Required = true)]
        public string Duration { get; set; }

        [PropertyMapping("invokername", Required = true)]
        public string Invokername { get; set; }

        [PropertyMapping("invokercldbid", Required = true)]
        public string Invokercldbid { get; set; }

        [PropertyMapping("invokeruid", Required = true)]
        public string Invokeruid { get; set; }

        [PropertyMapping("reason", Required = true)]
        public string Reason { get; set; }

        [PropertyMapping("enforcements", Required = true)]
        public int Enforcements { get; set; }

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
