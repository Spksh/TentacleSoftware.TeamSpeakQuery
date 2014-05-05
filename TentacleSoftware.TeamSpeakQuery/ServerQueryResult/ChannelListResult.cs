using System.Collections.Generic;
using System.Linq;

namespace TentacleSoftware.TeamSpeakQuery.ServerQueryResult
{
    public class ChannelListResult : ServerQueryBaseResult
    {
        public List<ChannelInfoResult> Values { get; set; }

        public override bool Parse(string message)
        {
            // Is this an error response?
            if (base.Parse(message))
            {
                return true;
            }

            Values = message.ToResultList<ChannelInfoResult>();

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
