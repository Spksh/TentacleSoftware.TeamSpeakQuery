namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class BanAddResult : ServerQueryBaseResult
    {
        [PropertyMapping("banid", Required = true)]
        public int BanId { get; set; }

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
