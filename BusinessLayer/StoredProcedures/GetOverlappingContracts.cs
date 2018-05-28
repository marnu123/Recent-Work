using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.StoredProcedures
{
    [StoredProcedure("sproc_GetOverlappingContracts")]
    public class GetOverlappingContracts
    {
        [StoredProcedureParameter("clientID")]
        public string ClientID { get; set; }
        [StoredProcedureParameter("startDate")]
        public DateTime StartDate { get; set; }
        [StoredProcedureParameter("endDate")]
        public DateTime EndDate { get; set; }

        public GetOverlappingContracts(string clientID, DateTime startDate, DateTime endDate)
        {
            ClientID = clientID;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
