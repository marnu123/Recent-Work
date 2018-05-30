using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Classes;

namespace BusinessLayer
{
    public class TaskPrioritiser
    {
        public List<TaskWithContract> Items { get; }

        public TaskPrioritiser(List<TaskWithContract> unassignedItems)
        {
            Items = unassignedItems;
        }

        //Return a dictionary of tasks grouped by date
        /*public Dictionary<DateTime, List<TaskWithContract>> GetTasksByDatePriority()
        {
            Dictionary<DateTime, List<Task>> keyValuePairs = new Dictionary<DateTime, List<Task>>();
            var result = Items.GroupBy(t => t.DateAdded);

            foreach (IGrouping<DateTime, Task> element in result)
            {
                keyValuePairs.Add(element.Key, element.ToList());
            }

            return keyValuePairs;
        }*/

        //Sort the list of tasks based on a client's most recent contract and the time already passed
        public List<KeyValuePair<TaskWithContract, float>> GetTasksSortedByPriority()
        {
            PriorityCalculator cal = new PriorityCalculator(2);
            List<KeyValuePair<TaskWithContract, float>> calculatedPriorities = new List<KeyValuePair<TaskWithContract, float>>();

            foreach (TaskWithContract item in Items)
            {
                if (item.Contract == null || item.Contract == "") calculatedPriorities.Add(new KeyValuePair<TaskWithContract, float>(item, 0));
                else calculatedPriorities.Add(new KeyValuePair<TaskWithContract, float>(item, cal.CalculatePriority(new ContractID(item.Contract), item.Task.DateAdded)));
            }

            calculatedPriorities.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            return calculatedPriorities;
        }
    }
}
