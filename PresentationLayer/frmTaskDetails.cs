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
using BusinessLayer.Validators;

namespace PresentationLayer
{
    public partial class frmTaskDetails : Form
    {
        Task task;
        Task oldCopy;
        List<TaskStatus> taskStatuses;
        List<TaskType> taskTypes;
        Dictionary<string, string> userEmails;
        List<Location> locations;
        bool insert, edit;

        public frmTaskDetails(Task task, bool insert = false)
        {
            InitializeComponent();
            initialise(task, insert);
            setFieldsEnable(insert);
        }

        private void initialise(Task task, bool insert)
        {
            this.task = task;
            this.insert = insert;
            task.DeepCopyInto(ref oldCopy);
            taskStatuses = TaskStatus.Select();
            taskTypes = TaskType.Select();
            userEmails = StoredProcedureHelper.GetClientEmails();
            createDataGridColumns();
            bindFields(task);

            if (task.Location != null) setDataGridViewSelection(task.Location);
        }

        private void lstClients_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstClients.SelectedIndex > -1)
            {
                locations = ComplexQueryHelper.GetLocationsForPerson(lstClients.Text);
                dgvLocation.DataSource = new AggregatedPropertyBindingList<Location>(locations);
            }
        }

        private void setFieldsEnable(bool state)
        {
            txtDescription.Enabled = state;
            txtID.Enabled = state;
            cmbTaskStatus.Enabled = state;
            cmbTaskType.Enabled = state;
            lstClients.Enabled = state;
            dgvLocation.Enabled = state;
            btnSave.Enabled = state;
        }

        private void createDataGridColumns()
        {
            dgvLocation.AutoGenerateColumns = false;
            //BindingList<Location> list = new BindingList<Location>(tempLocation);
            dgvLocation.Columns.Add("Id", "Id");
            dgvLocation.Columns["Id"].DataPropertyName = "Id";

            dgvLocation.Columns.Add("HouseNumber", "House Number");
            dgvLocation.Columns["HouseNumber"].DataPropertyName = "HouseNumber";

            dgvLocation.Columns.Add("StreetName", "Street Name");
            dgvLocation.Columns["StreetName"].DataPropertyName = "Street->Name";

            dgvLocation.Columns.Add("CityName", "City");
            dgvLocation.Columns["CityName"].DataPropertyName = "Street->City->Name";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setFieldsEnable(true);
            edit = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this task?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dlg == DialogResult.Yes)
            {
                task.Delete();
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            oldCopy.DeepCopyInto(ref task);
            edit = insert = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IEnumerable<string> brokenRules;
            string msg = "Invalid configuration.  Please check the error box";
            bool isValid = task.Validate(out brokenRules);

            if (isValid)
            {
                if (insert)
                {
                    task.DateAdded = DateTime.Now;
                    task.Insert();
                    msg = "Task inserted";
                }
                else
                {
                    task.Update();
                    msg = "Task updated";
                }
            }

            if (!isValid) lstError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void dgvLocation_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLocation.SelectedRows.Count == 1)
            {
                DataGridViewRow dr = dgvLocation.SelectedRows[0];
                if (dr.Index > -1)
                {
                    task.FK_LocationId = ((Location)dr.DataBoundItem).Id;
                }
            }
        }

        private void bindFields(Task task)
        {
            txtID.DataBindings.Add(new Binding("Text", task, "Id"));
            txtDescription.DataBindings.Add(new Binding("Text", task, "TaskDescription"));

            cmbTaskStatus.DataBindings.Add(new Binding("SelectedValue", task, "FK_TaskStatusId"));
            cmbTaskStatus.ValueMember = "Id";
            cmbTaskStatus.DisplayMember = "Title";
            cmbTaskStatus.DataSource = taskStatuses;

            cmbTaskType.DataBindings.Add(new Binding("SelectedValue", task, "FK_TaskTypeId"));
            cmbTaskType.ValueMember = "Id";
            cmbTaskType.DisplayMember = "Title";
            cmbTaskType.DataSource = taskTypes;

            lstClients.DataBindings.Add(new Binding("SelectedValue", task, "FK_ClientId"));
            lstClients.ValueMember = "Key";
            lstClients.DisplayMember = "Value";
            lstClients.DataSource = new BindingSource(userEmails, null);
        }

        private void dgvLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView temp = sender as DataGridView;
            if (e.RowIndex > -1)
            {
                temp.ClearSelection();
                temp.Rows[e.RowIndex].Selected = true;
            }
        }

        private void setDataGridViewSelection(Location selectedItem)
        {
            foreach (DataGridViewRow dr in dgvLocation.Rows)
            {
                if (dr.DataBoundItem.Equals(selectedItem))
                {
                    dr.Selected = true;
                }
            }
        }
    }
}
