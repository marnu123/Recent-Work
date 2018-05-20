using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IStoredProcedure { }

    public interface IReturnStoredProcedure : IStoredProcedure { }

    public interface IVoidStoredProcedure : IStoredProcedure { }
}
