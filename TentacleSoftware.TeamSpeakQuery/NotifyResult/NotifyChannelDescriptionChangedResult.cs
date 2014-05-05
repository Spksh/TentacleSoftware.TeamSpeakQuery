namespace TentacleSoftware.TeamSpeakQuery.NotifyResult
{
    [TypeMapping("notifychanneldescriptionchanged")]
    public class NotifyChannelDescriptionChangedResult : NotifyBaseResult
    {
        [PropertyMapping("cid", Required = true)]
        public string Cid { get; set; }

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
