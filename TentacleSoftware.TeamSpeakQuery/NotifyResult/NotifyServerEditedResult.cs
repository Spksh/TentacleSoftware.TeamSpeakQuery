namespace TentacleSoftware.TeamSpeakQuery.NotifyResult
{
    [TypeMapping("notifyserveredited")]
    public class NotifyServerEditedResult : NotifyBaseResult
    {
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
