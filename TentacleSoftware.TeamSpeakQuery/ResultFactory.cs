using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using TentacleSoftware.TeamSpeakQuery.NotifyResult;
using TentacleSoftware.TeamSpeakQuery.ServerQueryResult;

namespace TentacleSoftware.TeamSpeakQuery
{
    public static class ResultFactory
    {
        private static Dictionary<Type, Regex> _notifyTypeMap;

        public static Dictionary<Type, Regex> NotifyTypeMap
        {
            get
            {
                if (_notifyTypeMap == null)
                {
                    _notifyTypeMap = new Dictionary<Type, Regex>();

                    foreach (Type type in Assembly.GetAssembly(typeof(NotifyBaseResult)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(NotifyBaseResult))))
                    {
                        TypeMappingAttribute mapping = type.GetCustomAttribute<TypeMappingAttribute>();

                        if (mapping != null)
                        {
                            _notifyTypeMap.Add(type, new Regex(mapping.Name, RegexOptions.Compiled | RegexOptions.IgnoreCase));
                        }
                    }
                }

                return _notifyTypeMap;
            }
        }
        
        public static string Escape(this string message)
        {
            message = message.Replace("\\", "\\\\");
            message = message.Replace("/", "\\/");
            message = message.Replace(" ", "\\s");
            message = message.Replace("|", "\\p");
            message = message.Replace("\a", "\\a");
            message = message.Replace("\b", "\\b");
            message = message.Replace("\f", "\\f");
            message = message.Replace("\n", "\\n");
            message = message.Replace("\r", "\\r");
            message = message.Replace("\t", "\\t");
            message = message.Replace("\v", "\\v");

            return message;
        }

        public static string Unescape(this string message)
        {
            message = message.Replace("\\v", "\v");
            message = message.Replace("\\t", "\t");
            message = message.Replace("\\r", "\r");
            message = message.Replace("\\n", "\n");
            message = message.Replace("\\f", "\f");
            message = message.Replace("\\b", "\b");
            message = message.Replace("\\a", "\a");
            message = message.Replace("\\p", "|");
            message = message.Replace("\\s", " ");
            message = message.Replace("\\/", "/");
            message = message.Replace("\\\\", "\\");

            return message;
        }

        public static TResult FromNotification<TResult>(string notification) where TResult : NotifyBaseResult
        {
            if (string.IsNullOrWhiteSpace(notification))
            {
                // Could be newline, could be something else not printable
                // Definitely nothing we can work with here
                return null;
            }

            TResult result = Activator.CreateInstance<TResult>();

            if (result.Parse(notification))
            {
                return result;
            }

            // Not the response we were expecting
            return null;
        }

        public static TResult FromMessage<TResult>(string message) where TResult : ServerQueryBaseResult
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                // Could be newline, could be something else not printable
                // Definitely nothing we can work with here
                return null;
            }

            if (NotifyTypeMap.Any(n => n.Value.IsMatch(message)))
            {
                // Don't try to handle notifications here
                return null;
            }
            
            TResult result = Activator.CreateInstance<TResult>();

            if (result.Parse(message))
            {
                return result;
            }

            // Not the response we were expecting
            return null;
        }

        public static T ToResult<T>(this IDictionary<string, object> values) where T : class
        {
            ConstructorInfo ctor = typeof(T).GetConstructor(Type.EmptyTypes);

            if (ctor != null)
            {
                T result = (T)ctor.Invoke(null);

                if (result.MapPropertyValuesFrom(values))
                {
                    return result;
                }
            }

            return null;
        }

        public static List<T> ToResultList<T>(this string message) where T : class
        {
            return message
                .Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(messagePart => messagePart.ToPropertyValueMap().ToResult<T>())
                .Where(item => item != null)
                .ToList();
        }

        public static Dictionary<string, object> ToPropertyValueMap(this string message)
        {
            Dictionary<string, object> propertyValueMap = new Dictionary<string, object>();
                
            // Sometimes we get duplicate property/value pairs
            // I've only seen these with multiple logins from the same username when calling "clientinfo clid={id}"
            //
            // Duplicates were:
            // - connection_filetransfer_bandwidth_received
            // - connection_filetransfer_bandwidth_sent
            //
            // So, we'll play it safe.
            foreach (string[] property in message.Split(new[] {' '}, StringSplitOptions.None).Select(p => p.Split(new[] {'='}, 2, StringSplitOptions.None)))
            {
                string key = property[0];
                object value = property.Length >= 2 ? property[1].Unescape() : null;

                if (!propertyValueMap.ContainsKey(key))
                {
                    propertyValueMap.Add(key, value);
                }
                else if (propertyValueMap[key] == null)
                {
                    // Overwrite existing property/value if previous value is null
                    propertyValueMap[key] = value;
                }
            }

            return propertyValueMap;
        }

        public static bool MapPropertyValuesFrom<T>(this T target, string message)
        {
            return MapPropertyValuesFrom<T>(target, message.ToPropertyValueMap());
        }

        public static bool MapPropertyValuesFrom<T>(this T target, IDictionary<string, object> propertyValues)
        {
            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                // We may have more than one candidate property mapping
                // We use the value of whichever we find first in the incoming property values map
                foreach (PropertyMappingAttribute mapping in property.GetCustomAttributes<PropertyMappingAttribute>())
                {
                    if (propertyValues.ContainsKey(mapping.Name))
                    {
                        object value = propertyValues[mapping.Name];

                        // Can't ChangeType for null values
                        // Property value will already be null/default, so skip setting
                        if (value != null)
                        {
                            property.SetValue(target, Convert.ChangeType(propertyValues[mapping.Name], property.PropertyType), null);    
                        }
                        
                        break;
                    }

                    if (mapping.Required)
                    {
                        // This mapping is required, and we didn't find it
                        return false;
                    }
                }
            }

            return true;
        }

        public static string ToCommandString<T>(this ServerQueryCommand<T> command) where T : ServerQueryBaseResult
        {
            StringBuilder commandBuilder = new StringBuilder();

            // Command
            commandBuilder.Append(command.Command);

            // Parameters
            // key=value
            // key=value[0]|key=value[1]|key=value[2] if value is a collection
            // String values must be escaped
            foreach (KeyValuePair<Parameter, object> parameter in command.Parameters)
            {
                // Don't add parameters with null values
                if (parameter.Value == null)
                {
                    continue;
                }

                // Don't add parameters with string.empty values
                if (parameter.Value is string && string.IsNullOrWhiteSpace((string) parameter.Value))
                {
                    continue;
                }

                // Check if we've been passed a collection of values for this parameter
                IList values = parameter.Value as IList;

                // key=value[0]|key=value[1]|key=value[2] if value is a collection
                if (values != null && values.Count > 0)
                {
                    commandBuilder.Append(" ");
                    
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (i > 0)
                        {
                            commandBuilder.Append("|");
                        }
                        
                        commandBuilder.Append(parameter.Key);
                        commandBuilder.Append("=");
                        commandBuilder.Append(values[i].ToString().Escape());
                    }

                    continue;
                }
                
                // Not a collection, just a single key/value pair
                // key=value
                commandBuilder.Append(" ");
                commandBuilder.Append(parameter.Key);
                commandBuilder.Append("=");
                commandBuilder.Append(parameter.Value.ToString().Escape());
            }

            // Options
            // -option
            foreach (Option option in command.Options)
            {
                commandBuilder.Append(" ");
                commandBuilder.Append("-");
                commandBuilder.Append(option);
            }

            return commandBuilder.ToString();
        }
    }
}
