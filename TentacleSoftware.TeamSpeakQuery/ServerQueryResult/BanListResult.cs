using System.Collections.Generic;
using System.Linq;

namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class BanListResult : ServerQueryBaseResult
    {
        public List<BanInfoResult> Values { get; set; }

        public override bool Parse(string message)
        {
            // Is this an error response?
            if (base.Parse(message))
            {
                return true;
            }

            Values = message.ToResultList<BanInfoResult>();

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
