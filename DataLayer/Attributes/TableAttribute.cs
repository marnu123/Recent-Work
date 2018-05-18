using System;

namespace DataLayer.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class TableAttribute : Attribute
    {
        private string name;
        public string Name { get => name; }

        public TableAttribute(string name)
        {
            this.name = name;
        }
    }
}
