namespace TentacleSoftware.TeamSpeakQuery.NotifyResult
{
    [TypeMapping("notifyclientleftview")]
    public class NotifyClientLeftViewResult : NotifyBaseResult
    {
        [PropertyMapping("cfid", Required = true)]
        public string Cfid { get; set; }

        [PropertyMapping("ctid", Required = true)]
        public string Ctid { get; set; }

        [PropertyMapping("reasonid", Required = true)]
        public string Reasonid { get; set; }

        [PropertyMapping("reasonmsg", Required = true)]
        public string Reasonmsg { get; set; }

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
