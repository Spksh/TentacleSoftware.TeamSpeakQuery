using System.Collections.Generic;
using System.Linq;

namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class ServerListResult : ServerQueryBaseResult
    {
        public List<ServerListInfoResult> Values { get; set; }

        public override bool Parse(string message)
        {
            // Is this an error response?
            if (base.Parse(message))
            {
                return true;
            }

            Values = message.ToResultList<ServerListInfoResult>();

            if (Values.Any())
            {
                Success = true;
                Response = message;

                return true;
            }

            return false;
        }
    }
}
