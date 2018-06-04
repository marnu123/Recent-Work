using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BusinessLayer.Helpers;
using BusinessLayer.Classes;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmScheduleTreeViewForm : Form
    {
        volatile bool stopThreads = false;
        Thread buildTreeThread;

        public frmScheduleTreeViewForm()
        {
            CenterToScreen();
            InitializeComponent();
            buildTreeThread = new Thread(new ThreadStart(buildTree));
            buildTreeThread.Start();
        }

        //Run this method on a separate thread because the construction of the tree can be a timely process
        private void buildTree()
        {
            TreeNode[] temp = getAssignedTasks();
            if (stopThreads) return;
            treeSchedules.Invoke((MethodInvoker)delegate { treeSchedules.Nodes.Add(new TreeNode("In Progress", temp)); });
            if (stopThreads) return;
            temp = getUnassignedTasks();
            if (stopThreads) return;
            treeSchedules.Invoke((MethodInvoker) delegate { treeSchedules.Nodes.Add(new TreeNode("Unassigned Tasks", temp)); }) ;
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
                //Stop the running thread if the form thread closes
                if (stopThreads) return null;

                toAdd = new TreeNode[item.Count()];
                TreeNode nodeToAdd;

                lengthToAdd = 0;
                foreach (Schedule schedule in item)
                {
                    nodeToAdd = new TreeNode(schedule.Id + ", " + schedule.Task.FK_ClientId + ", " + schedule.Task.DateAdded);
                    nodeToAdd.Tag = schedule;
                    nodeToAdd.Name = "Scheduled Task";
                    toAdd[lengthToAdd++] = nodeToAdd;
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
            TreeNode nodeToAdd;

            for (int i = 0; i < tasks.Count; i++)
            {
                //Stop the running thread if the form thread closes
                if (stopThreads) return null;

                item = tasks[i].Key.Task;
                nodeToAdd = new TreeNode(item.Id + ", " + item.FK_ClientId + ", " + item.DateAdded.ToShortDateString() + ", " + tasks[i].Key.Contract + ", " + tasks[i].Value);
                nodeToAdd.Tag = item;
                nodeToAdd.Name = "Unassigned Task";
                unassignedTasks[i] = nodeToAdd;
            }

            return unassignedTasks;
        }

        private void treeNode_OnViewClick(object sender, EventArgs e)
        {
            MenuItem clickedMenu = sender as MenuItem;

            TreeNode selectedNode = treeSchedules.SelectedNode;
            switch (selectedNode.Name)
            {
                case "Scheduled Task":
                    showSchedule((Schedule)selectedNode.Tag);
                    break;

                case "Unassigned Task":
                    showTask((Task)selectedNode.Tag);
                    break;
            }
        }

        private void treeNode_OnDeleteClick(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this item?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                MenuItem clickedMenu = sender as MenuItem;

                TreeNode selectedNode = treeSchedules.SelectedNode;
                switch (selectedNode.Name)
                {
                    case "Scheduled Task":
                        ((Schedule)selectedNode.Tag).Delete();
                        break;

                    case "Unassigned Task":
                        ((Task)selectedNode.Tag).Delete();
                        break;
                }

                selectedNode.Remove();
                MessageBox.Show("Item deleted", "Modification status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showTask(Task task)
        {
            frmTaskDetails frm = new frmTaskDetails(task);
            frm.Show();
            frm.FormClosed += (s, events) => Show();
            Hide();
        }

        private void showSchedule(Schedule task)
        {
            frmScheduleDetails frm = new frmScheduleDetails(task);
            frm.Show();
            frm.FormClosed += (s, events) => Show();
            Hide();
        }

        private void treeSchedules_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            
        }

        private void treeNode_OnScheduleClick(object sender, EventArgs e)
        {
            Task task = (Task)treeSchedules.SelectedNode.Tag;
            frmScheduleDetails frm = new frmScheduleDetails(task, true);
            frm.Show();
            frm.FormClosed += (s, events) =>
            {
                treeSchedules.Nodes.Clear();
                buildTree();
                Show();
            };
            Hide();
        }

        private void treeSchedules_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode clickedNode = treeSchedules.GetNodeAt(p);
                ContextMenu menu = new ContextMenu(new MenuItem[]
                {
                    new MenuItem("View", treeNode_OnViewClick),
                    new MenuItem("Delete", treeNode_OnDeleteClick)
                });

                if (clickedNode.Name == "Scheduled Task")
                {
                    treeSchedules.SelectedNode = clickedNode;
                    menu.Show(sender as TreeView, p);
                }
                else
                {
                    if (clickedNode.Name == "Unassigned Task")
                    {
                        treeSchedules.SelectedNode = clickedNode;
                        menu.MenuItems.Add(new MenuItem("Schedule Task", treeNode_OnScheduleClick));
                        menu.Show(sender as TreeView, p);
                    }
                }
            }
        }

        private void frmScheduleTreeViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopThreads = true;
        }
    }
}
