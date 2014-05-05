using System;

namespace TentacleSoftware.TeamSpeakQuery
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TypeMappingAttribute : Attribute
    {
        public string Name { get; set; }

        public TypeMappingAttribute(string name)
        {
            Name = name;
        }
    }
}
