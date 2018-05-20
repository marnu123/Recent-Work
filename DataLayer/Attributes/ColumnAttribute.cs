using System;

namespace DataLayer.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    public class ColumnAttribute : Attribute
    {
        private string name;
        public bool IsAutoNumber { get; private set; }
        //private string type;
        public string Name { get => name; }

        public ColumnAttribute(string name, bool isAutoNumber = false)
        {
            this.name = name;
            IsAutoNumber = isAutoNumber;
        }
    }
}
