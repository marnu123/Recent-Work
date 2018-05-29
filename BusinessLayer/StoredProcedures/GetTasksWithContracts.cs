using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Classes;
using DataLayer.Attributes;

namespace BusinessLayer.StoredProcedures
{
    [StoredProcedure("sproc_GetTasksWithContracts")]
    class GetTasksWithContracts
    {
        public GetTasksWithContracts(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        [StoredProcedureParameter("startDate")]
        public DateTime StartDate { get; set; }
        [StoredProcedureParameter("endDate")]
        public DateTime EndDate { get; set; }
    }
}
