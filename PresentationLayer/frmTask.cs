using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Classes;
using BusinessLayer;
using BusinessLayer.Helpers;
using Task = BusinessLayer.Classes.Task;

namespace PresentationLayer
{
    public partial class frmTask : Form
    {
        List<Task> tasks;
        AggregatedPropertyBindingList<Task> dataSource;

        public frmTask()
        {
            InitializeComponent();
            tasks = ComplexQueryHelper.GetCompleteTaskDetails();
            createColumnHeadings();
            bindDataGridView();
        }

        private void bindDataGridView()
        {
            dataSource = new AggregatedPropertyBindingList<Task>(tasks);
            dgvTasks.DataSource = dataSource;
        }

        private void createColumnHeadings()
        {
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.Columns.Add("ID", "ID");
            dgvTasks.Columns["ID"].DataPropertyName = "Id";

            dgvTasks.Columns.Add("Location", "Location");
            dgvTasks.Columns["Location"].DataPropertyName = "Location";

            dgvTasks.Columns.Add("Client", "Client");
            dgvTasks.Columns["Client"].DataPropertyName = "Client->Email";

            dgvTasks.Columns.Add("Status", "Status");
            dgvTasks.Columns["Status"].DataPropertyName = "TaskStatus->Title";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTaskDetails frm = new frmTaskDetails(new Task("", 0, 0,"", 0), true);
            Utils.ShowForm(this, frm, dgvTasks, () =>
            {
                tasks = Task.Select();
                dataSource = new AggregatedPropertyBindingList<Task>(tasks);
                dgvTasks.DataSource = dataSource;
            });
        }

        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvTasks.ClearSelection();
                dgvTasks.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 1)
            {
                Task selectedTask = (Task) dgvTasks.SelectedRows[0].DataBoundItem;
                frmTaskDetails frm = new frmTaskDetails((Task)dgvTasks.SelectedRows[0].DataBoundItem);
                Utils.ShowForm(this, frm, dgvTasks, () =>
                {
                    tasks = Task.Select();
                    dataSource = new AggregatedPropertyBindingList<Task>(tasks);
                    dgvTasks.DataSource = dataSource;
                });
            }

        }
    }
}
