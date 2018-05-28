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
using Task = BusinessLayer.Classes.Task;

namespace PresentationLayer
{
    public partial class frmTask : Form
    {
        List<Task> tasks;

        public frmTask()
        {
            InitializeComponent();
            tasks = Task.Select();
        }

        private void createColumnHeadings()
        {
            dgvTasks.AutoGenerateColumns = false;
            dgvTasks.Columns.Add("ID", "ID");
            dgvTasks.Columns["ID"].DataPropertyName = "Id";

            dgvTasks.Columns.Add("Location", "Location");
            dgvTasks.Columns["Location"].DataPropertyName = "Location";

            dgvTasks.Columns.Add("Client", "Client");
            dgvTasks.Columns["Client"].DataPropertyName = "Location->Person->Name";

            dgvTasks.Columns.Add("Status", "Status");
            dgvTasks.Columns["Status"].DataPropertyName = "Status->Title";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTaskDetails frm = new frmTaskDetails();
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
                frmTaskDetails frm = new frmTaskDetails();
            }

        }
    }
}
