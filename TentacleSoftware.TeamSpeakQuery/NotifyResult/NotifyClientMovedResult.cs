namespace TentacleSoftware.TeamSpeakQuery.NotifyResult
{
    [TypeMapping("notifyclientmoved")]
    public class NotifyClientMovedResult : NotifyBaseResult
    {
        [PropertyMapping("ctid", Required = true)]
        public string Ctid { get; set; }

        [PropertyMapping("reasonid", Required = true)]
        public string Reasonid { get; set; }

        [PropertyMapping("clid", Required = true)]
        public string Clid { get; set; }

        public override bool Parse(string notification)
        {
            if (this.MapPropertyValuesFrom(notification))
            {
                return true;
            }

            return false;
        }
    }
}
