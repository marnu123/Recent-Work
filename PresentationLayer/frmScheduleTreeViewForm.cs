using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Helpers;
using BusinessLayer.Classes;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmScheduleTreeViewForm : Form
    {

        public frmScheduleTreeViewForm()
        {
            InitializeComponent();
            buildTree();
        }

        private void buildTree()
        { 
            treeSchedules.Nodes.Add(new TreeNode("In Progress", getAssignedTasks()));
            treeSchedules.Nodes.Add(new TreeNode("Unassigned Tasks", getUnassignedTasks()));
        }

        private TreeNode[] getAssignedTasks()
        {
            List<Schedule> schedules = StoredProcedureHelper.GetScheduledTasksInProgress();
            var groupedData = schedules.GroupBy(t => t.FK_EmployeeId);
            TreeNode[] result = new TreeNode[groupedData.Count()];

            TreeNode[] toAdd;
            int lengthResult = 0;
            int lengthToAdd = 0;
            foreach (IGrouping<string, Schedule> item in groupedData)
            {
                toAdd = new TreeNode[item.Count()];

                lengthToAdd = 0;
                foreach (Schedule schedule in item)
                {
                    toAdd[lengthToAdd++] = new TreeNode(schedule.Id + ", " + schedule.Task.FK_ClientId + ", " + schedule.Task.DateAdded);
                }

                result[lengthResult++] = new TreeNode(item.Key, toAdd);
            }

            return result;
        }

        private TreeNode[] getUnassignedTasks()
        {
            TaskPrioritiser tp = new TaskPrioritiser(StoredProcedureHelper.GetUnassginedTasksWithContracts());
            List<KeyValuePair<TaskWithContract, float>> tasks = tp.GetTasksSortedByPriority();
            TreeNode[] unassignedTasks = new TreeNode[tasks.Count];

            Task item;

            for (int i = 0; i < tasks.Count; i++)
            {
                item = tasks[i].Key.Task;
                unassignedTasks[i] = new TreeNode(item.Id + ", " + item.FK_ClientId + ", " + tasks[i].Value);
            }

            return unassignedTasks;
        }
    }
}
