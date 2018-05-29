using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Attributes;
using DataLayer;

namespace BusinessLayer.StoredProcedures
{
    [StoredProcedure("sproc_GetUnassginedTasksWithContracts")]
    class GetUnassignedTasksWithContracts : IReturnStoredProcedure
    {

    }
}
