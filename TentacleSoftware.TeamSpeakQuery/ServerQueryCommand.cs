using System;
using System.Collections.Generic;
using TentacleSoftware.TeamSpeakQuery.ServerQueryResult;

namespace TentacleSoftware.TeamSpeakQuery
{
    public class ServerQueryCommand<TResult> where TResult : ServerQueryBaseResult
    {
        public Command Command { get; set; }

        public Dictionary<Parameter, object> Parameters { get; set; }

        public List<Option> Options { get; set; }

        public Func<string, TResult> Parser { get; set; }
        
        public ServerQueryCommand(Command command)
        {
            Command = command;
            Parameters = new Dictionary<Parameter, object>();
            Options = new List<Option>();
            Parser = ResultFactory.FromMessage<TResult>;
        }

        /// <summary>
        /// Add a key=value to the command. An IList passed as a value will be rendered as key=value[0]|key=value[1]|key=value[2].
        /// </summary>
        public ServerQueryCommand<TResult> Add(Parameter parameter, object value)
        {
            Parameters.Add(parameter, value);

            return this;
        }

        /// <summary>
        /// Add a -option to the command.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public ServerQueryCommand<TResult> Add(Option option)
        {
            Options.Add(option);

            return this;
        }

        public ServerQueryCommand<TResult> With(Func<string, TResult> parser)
        {
            Parser = parser;

            return this;
        }
    }
}
