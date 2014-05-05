namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class TextResult : ServerQueryBaseResult
    {
        public override bool Parse(string message)
        {
            // Is this an error response?
            if (base.Parse(message))
            {
                return true;
            }

            Success = true;
            Response = message;

            return true;
        }
    }
}
