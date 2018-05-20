using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer.StoredProcedures
{
    public static class StoredProcedureHelper
    {
        public static bool IsUniqueEmail(string email)
        {
            return DataHandler.GetInstance().ExecuteProcedure(new IsUniqueEmail(email)).Rows.Count == 0;
        }
    }
}
