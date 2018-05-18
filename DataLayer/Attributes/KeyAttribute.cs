using System;

namespace DataLayer.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class KeyAttribute : Attribute
    {
        public bool IsAutoNumber { get; set; }

        public KeyAttribute(bool isAutoNumber = false)
        {
            IsAutoNumber = isAutoNumber;
        }
    }
}
