using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Attributes
{
    public class StoredProcedureAttribute : Attribute
    {
        public string Name { get; private set; }

        public StoredProcedureAttribute(string name)
        {
            Name = name;
        }
    }
}
