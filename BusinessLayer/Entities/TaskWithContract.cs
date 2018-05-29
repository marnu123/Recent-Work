using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Classes;

namespace BusinessLayer.Classes
{
    public class TaskWithContract
    {
        public TaskWithContract(string contract, Task task)
        {
            Contract = contract;
            Task = task;
        }

        public string Contract { get; set; }
        public Task Task { get; set; }


    }
}
