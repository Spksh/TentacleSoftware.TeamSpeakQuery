namespace TentacleSoftware.TeamSpeakQuery.NotifyResult
{
    [TypeMapping("notifychanneledited")]
    public class NotifyChannelEditedResult : NotifyBaseResult
    {
        [PropertyMapping("cid", Required = true)]
        public string Cid { get; set; }

        [PropertyMapping("reasonid", Required = true)]
        public string Reasonid { get; set; }

        [PropertyMapping("invokerid", Required = true)]
        public string Invokerid { get; set; }

        [PropertyMapping("invokername", Required = true)]
        public string Invokername { get; set; }

        [PropertyMapping("invokeruid", Required = true)]
        public string Invokeruid { get; set; }

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
