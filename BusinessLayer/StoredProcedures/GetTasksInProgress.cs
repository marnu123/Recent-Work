using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Attributes;
using DataLayer;

namespace BusinessLayer.StoredProcedures
{
    [StoredProcedure("sproc_GetTasksInProgress")]
    class GetTasksInProgress : IReturnStoredProcedure
    {
    }
}
