using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using System.ComponentModel;

namespace BusinessLayer.CallCentre
{
    interface ICallerQueue
    {
        string GetNextCall();
        void AddCall(string call);
        string PeekNextCall();
        int Count();
    }
}
