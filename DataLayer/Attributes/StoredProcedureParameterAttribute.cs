using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Attributes
{
    public class StoredProcedureParameterAttribute : Attribute
    {
        public string Name { get; private set; }

        public StoredProcedureParameterAttribute(string name)
        {
            Name = name;
        }
    }
}
