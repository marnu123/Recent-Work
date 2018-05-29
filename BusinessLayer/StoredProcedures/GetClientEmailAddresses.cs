using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.StoredProcedures;
using DataLayer.Attributes;
using DataLayer;

namespace BusinessLayer.StoredProcedures
{
    [StoredProcedure("sproc_GetClientEmailAddresses")]
    public class GetClientEmailAddresses : IReturnStoredProcedure
    {
        [StoredProcedureParameter("searchString")]
        public string SearchString { get; set; }
        public GetClientEmailAddresses(string searchString)
        {
            SearchString = searchString;
        }
    }
}
