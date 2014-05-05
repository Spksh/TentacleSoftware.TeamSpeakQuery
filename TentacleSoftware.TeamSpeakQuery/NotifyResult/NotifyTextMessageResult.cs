namespace TentacleSoftware.TeamSpeakQuery.NotifyResult
{
    [TypeMapping("notifytextmessage")]
    public class NotifyTextMessageResult : NotifyBaseResult
    {
        [PropertyMapping("targetmode", Required = true)]
        public string Targetmode { get; set; }

        [PropertyMapping("msg", Required = true)]
        public string Msg { get; set; }

        [PropertyMapping("target")]
        public string Target { get; set; }

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
