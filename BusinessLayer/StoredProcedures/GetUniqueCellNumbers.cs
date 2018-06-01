using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.StoredProcedures;
using DataLayer.Attributes;
using DataLayer;

namespace BusinessLayer.StoredProcedures
{
    [StoredProcedure("sproc_GetUniqueCellNumbers")]
    public class GetUniqueCellNumbers : IReturnStoredProcedure
    {
    }
}
