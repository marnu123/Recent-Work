using System;

namespace DataLayer.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    public class ColumnAttribute : Attribute
    {
        private string name;
        //private string type;
        public string Name { get => name; }

        public ColumnAttribute(string name)
        {
            this.name = name;
        }
    }
}
