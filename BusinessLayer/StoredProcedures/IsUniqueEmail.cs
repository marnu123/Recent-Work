using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Attributes;
using DataLayer;

namespace BusinessLayer.StoredProcedures
{
    [StoredProcedure("sproc_IsUniqueEmail")]
    public class IsUniqueEmail : IReturnStoredProcedure
    {
        [StoredProcedureParameter("Email")]
        public string Email { get; set; }
        public IsUniqueEmail(string email) { Email = email; }
    }
}
