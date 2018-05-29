using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Classes;

namespace BusinessLayer
{
    class PriorityCalculator
    {
        private int priorityMultiplier;
        public PriorityCalculator(int priorityMultiplier)
        {
            this.priorityMultiplier = priorityMultiplier;
        }

        //Calculate a task's priority by determining the percentage of allowable waiting days that has passed
        public float CalculatePriority(ContractID contractID, DateTime dateAdded)
        {
            //Make "A" start at 1
            int clientPriority = contractID.ClientImportance - 64;
            //Use the priorityMultiplier to specify how many days per priority index may pass before a task has to be completed.
            int maxAllowableDays = contractID.ClientImportance * priorityMultiplier;
            TimeSpan timePassed = DateTime.Now - dateAdded.AddDays(maxAllowableDays);
            return timePassed.Days / maxAllowableDays;
        }
    }
}
