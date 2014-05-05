namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class ServerQueryBaseResult
    {
        public bool Success { get; set; }

        [PropertyMapping("id", Required = true)]
        public int ErrorId { get; set; }

        [PropertyMapping("msg", Required = true)]
        public string ErrorMessage { get; set; }

        [PropertyMapping("extra_msg")]
        public string ExtraMessage { get; set; }

        [PropertyMapping("failed_permid")]
        public int FailedPermId { get; set; }

        public string Response { get; set; }

        public ServerQueryBaseResult()
        {

        }

        public ServerQueryBaseResult(bool success)
        {
            Success = success;
        }

        public virtual bool Parse(string message)
        {
            if (this.MapPropertyValuesFrom(message))
            {
                Success = ErrorId == 0;
                Response = message;

                return true;
            }

            return false;
        }
    }
}
