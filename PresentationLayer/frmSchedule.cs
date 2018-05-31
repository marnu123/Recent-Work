using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Classes;
using BusinessLayer.Helpers;

namespace PresentationLayer
{
    public partial class frmSchedule : Form
    {
        List<Employee> employees;
        List<Schedule> schedules;

        public frmSchedule()
        {
            InitializeComponent();
            createDataGridViewColumns();
            employees = ComplexQueryHelper.GetAllTechnicians();
            bindFields();
        }

        private void bindFields()
        {
            lstEmployee.DisplayMember = "EmployeeId";
            lstEmployee.DataSource = employees;
        }

        private void createDataGridViewColumns()
        {
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.Columns.Add("Id", "ID");
            dgvSchedule.Columns["Id"].DataPropertyName = "Id";

            dgvSchedule.Columns.Add("TimeStart", "Time Start");
            dgvSchedule.Columns["TimeStart"].DataPropertyName = "TimeStart";

            dgvSchedule.Columns.Add("Price", "Price");
            dgvSchedule.Columns["Price"].DataPropertyName = "Price";

            dgvSchedule.Columns.Add("Duration", "Duration");
            dgvSchedule.Columns["Duration"].DataPropertyName = "Duration";

            dgvSchedule.Columns.Add("TaskID", "Task ID");
            dgvSchedule.Columns["TaskID"].DataPropertyName = "FK_TaskID";

            dgvSchedule.Columns.Add("ClientID", "Client ID");
            dgvSchedule.Columns["ClientID"].DataPropertyName = "Task->FK_ClientID";
        }

        private void lstEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            updateSchedules(((Employee)lstEmployee.SelectedItem));
        }

        private void updateSchedules(Employee selectedEmployee)
        {
            string employeeID = selectedEmployee.EmployeeId;
            schedules = new List<Schedule>(Schedule.Select(s => s.FK_EmployeeId == employeeID));
            dgvSchedule.DataSource = new AggregatedPropertyBindingList<Schedule>(schedules);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmScheduleDetails frm = new frmScheduleDetails(new Schedule("", DateTime.Today.Date, 0, new TimeSpan(0,0,0), "", ""), true);
            Utils.ShowForm(this, frm, dgvSchedule, () => 
            {
                updateSchedules((Employee)lstEmployee.SelectedItem);
            });

        }

        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView temp = sender as DataGridView;

            if (e.RowIndex > -1)
            {
                temp.ClearSelection();
                temp.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView temp = sender as DataGridView;

            if (temp.SelectedRows.Count == 1)
            {
                frmScheduleDetails frm = new frmScheduleDetails((Schedule)temp.SelectedRows[0].DataBoundItem);
                Utils.ShowForm(this, frm, dgvSchedule, () =>
                {
                    updateSchedules((Employee)lstEmployee.SelectedItem);
                });
            }
        }
    }
}
