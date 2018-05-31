using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer.Classes;
using BusinessLayer.Validators;
using BusinessLayer.Helpers;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmScheduleDetails : Form
    {
        Schedule schedule;
        Schedule oldCopy;
        List<Employee> employees;
        List<TaskWithContract> tasks;
        bool insert, edit = false;

        public frmScheduleDetails(Schedule schedule, bool insert = false)
        {
            initialise(schedule, insert);
        }

        public frmScheduleDetails(Schedule schedule, List<Employee> technicians, bool insert = false)
        {
            employees = technicians;
            initialise(schedule, insert);
        }
        
        //Update the split date time object where one variable represents data from two components
        private void setDateTime(DateTimePicker date, DateTimePicker time, DateTime dateTime)
        {
            date.Value = dateTime.Date;
            time.Value = DateTime.Today.Date.Add(dateTime.TimeOfDay);
        }

        private void initialise(Schedule schedule, bool insert)
        {
            InitializeComponent();
            nudCost.Maximum = decimal.MaxValue;
            nudCost.Minimum = decimal.MinValue;
            createDataGridColumns();
            this.insert = insert;
            this.schedule = schedule;
            schedule.DeepCopyInto(ref oldCopy);
            employees = ComplexQueryHelper.GetAllTechnicians();
            tasks = StoredProcedureHelper.GetUnassginedTasksWithContracts();
            bindFields(schedule);
            setFieldsEnable(insert);
        }

        private void createDataGridColumns()
        {
            dgvTask.AutoGenerateColumns = false;
            dgvTask.Columns.Add("ID", "ID");
            dgvTask.Columns["ID"].DataPropertyName = "Task->Id";

            dgvTask.Columns.Add("Client", "Client");
            dgvTask.Columns["Client"].DataPropertyName = "Task->FK_ClientId";

            dgvTask.Columns.Add("Contract", "Client Contract ID");
            dgvTask.Columns["Contract"].DataPropertyName = "Contract";
        }

        private void setFieldsEnable(bool state)
        {
            txtID.Enabled = state;
            dtpDuration.Enabled = state;
            dtpStartDate.Enabled = state;
            dtpStartTime.Enabled = state;
            nudCost.Enabled = state;
            lstEmployee.Enabled = state;
            dgvTask.Enabled = state;
            btnSave.Enabled = state;
            btnViewTask.Enabled = !state;

            if (insert)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            oldCopy.DeepCopyInto(ref schedule);
            setDateTime(dtpStartDate, dtpStartTime, schedule.TimeStart);
            setFieldsEnable(false);
            edit = insert = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setFieldsEnable(true);
            edit = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this schedule?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg == DialogResult.Yes)
            {
                schedule.Delete();
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            schedule.Duration = dtpDuration.Value.TimeOfDay;
            schedule.TimeStart = dtpStartDate.Value.Add(dtpStartTime.Value.TimeOfDay);
            TaskWithContract selectedTask = dgvTask.SelectedRows.Count == 1 ? (TaskWithContract)dgvTask.SelectedRows[0].DataBoundItem : null;
            schedule.FK_TaskId = selectedTask != null ? selectedTask.Task.Id : "";

            string msg = "Invalid input.  Please check the error box";
            IEnumerable<string> brokenRules;
            bool isValid = schedule.Validate(out brokenRules);

            if (isValid)
            {
                if (insert)
                {
                    schedule.Insert();
                    msg = "Schedule inserted";
                }
                else
                {
                    schedule.Update();
                    msg = "Schedule updated";
                }

                insert = edit = false;
                setFieldsEnable(false);
            }

            if (!isValid) lstError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void btnViewTask_Click(object sender, EventArgs e)
        {
            frmTaskDetails frm = new frmTaskDetails(schedule.Task);
            Utils.ShowForm(this, frm, dgvTask, () => { });
        }

        private void bindFields(Schedule schedule)
        {
            txtID.DataBindings.Add(new Binding("Text", schedule, "Id"));
            nudCost.DataBindings.Add(new Binding("Value", schedule, "Price"));

            //Display workaround because the date time picker does not support timespan datatypes
            dtpDuration.Value = DateTime.Today.Add(schedule.Duration);
            setDateTime(dtpStartDate, dtpStartTime, schedule.TimeStart);

            lstEmployee.DataBindings.Add(new Binding("SelectedValue", schedule, "FK_EmployeeId"));
            lstEmployee.DisplayMember = "EmployeeId";
            lstEmployee.ValueMember = "EmployeeId";
            lstEmployee.DataSource = employees;

            dgvTask.DataSource = new AggregatedPropertyBindingList<TaskWithContract>(tasks);
        }
    }
}
