using System;

namespace TentacleSoftware.TeamSpeakQuery
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PropertyMappingAttribute : Attribute
    {
        public string Name { get; set; }

        public bool Required { get; set; }

        public PropertyMappingAttribute(string name)
        {
            Name = name;
        }

        public PropertyMappingAttribute(string name, bool required)
        {
            Name = name;
            Required = required;
        }
    }
}
