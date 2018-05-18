using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Attributes
{
    public class ForeignKeyAttribute : Attribute
    {
        private Type parentTable;

        public Type ParentTable { get => parentTable; set => parentTable = value; }
        public ForeignKeyAttribute(Type parentTable)
        {
            ParentTable = parentTable;
        }
    }
}
