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
using BusinessLayer.Validators;
using BusinessLayer;
using BusinessLayer.Helpers;

namespace PresentationLayer
{
    public partial class frmPersonDetails : Form
    {
        Person currentPerson;
        Person oldCopy;
        List<Location> available;
        bool insert = false;
        bool newEmployeeType = false;
        bool newNotificationType = false;
        bool editable = false;

        public frmPersonDetails(ref Employee employee, bool edit = false, bool insert = false)
        {
            InitializeComponent();
            initialise(employee, insert);
            txtID.DataBindings.Add("Text", employee, "EmployeeID");
            txtPassword.DataBindings.Add("Text", employee, "Password");

            List<EmployeeType> employeeTypes = EmployeeType.Select();
            BindingList<EmployeeType> bl = new BindingList<EmployeeType>(employeeTypes);

            bindComboBox(cbmEmployeeType, bl, "Title", "Id");
            cbmEmployeeType.DataBindings.Add("SelectedValue", employee, "FK_EmployeeTypeId");

            if (insert) cbmEmployeeType.SelectedIndex = -1;
        }

        private void initialise(Person person, bool insert)
        {
            currentPerson = person;
            initializeFields(insert);
            this.insert = insert;

            //Enable the correct components according to the type of client
            bool clientEnabled = person.GetType() == typeof(Client);
            pnlClientDetails.Visible = clientEnabled;
            pnlEmployeeDetails.Visible = !clientEnabled;
            if (!clientEnabled) tcPerson.TabPages.Remove(tabContract);

            person.DeepCopyInto(ref oldCopy);
            createLocationHeadings(dgvAvailable);
            createLocationHeadings(dgvUsed);

            if (person.GetType() == typeof(Client)) createContractColumns(dgvContracts);
        }

        private void setControlEnabled(bool state)
        {
            txtID.Enabled = state;
            txtEmail.Enabled = state;
            txtCellNumber.Enabled = state;
            txtName.Enabled = state;
            txtPassword.Enabled = state;
            txtSurname.Enabled = state;
            cbmEmployeeType.Enabled = state;
            cmbNotificationType.Enabled = state;
        }

        public frmPersonDetails(ref Client client, bool edit = false, bool insert = false)
        {
            InitializeComponent();
            initialise(client, insert);
            txtID.DataBindings.Add("Text", client, "ClientID");

            List<NotificationType> notificationTypes = NotificationType.Select();
            BindingList<NotificationType> bl = new BindingList<NotificationType>(notificationTypes);

            bindComboBox(cmbNotificationType, bl, "Title", "Id");
            cmbNotificationType.DataBindings.Add("SelectedValue", client, "FK_NotificationTypeId");

            if (insert) cmbNotificationType.SelectedIndex = -1;
        }

        private void bindComboBox<T>(ComboBox cb, BindingList<T> bindingList, string displayMember, string valueMember)
        {
            bindingList.AllowEdit = false;
            bindingList.AllowNew = true;
            bindingList.AllowRemove = false;
            cb.DisplayMember = displayMember;
            cb.ValueMember = valueMember;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb.DataSource = bindingList;
        }

        private void initializeFields(bool insert)
        {
            this.insert = insert;
            txtName.DataBindings.Add("Text", currentPerson, "Name");
            txtEmail.DataBindings.Add("Text", currentPerson, "Email");
            txtCellNumber.DataBindings.Add("Text", currentPerson, "CellNumber");
            txtSurname.DataBindings.Add("Text", currentPerson, "Surname");
            //Enable controls for edits or inserts
            setControlEnabled(insert);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "Invalid input. Please refer to the error box";
            IEnumerable<string> brokenRules;

            if (validateCurrent(out brokenRules))
            {
                if (newEmployeeType)
                {
                    EmployeeType et = new EmployeeType(0, cbmEmployeeType.Text);
                    if (et.Validate(out brokenRules))
                    {
                        et.Insert();
                        (currentPerson as Employee).FK_EmployeeTypeId = et.Id;
                    }
                    else lstError.DataSource = brokenRules;
                }

                if (newNotificationType)
                {
                    NotificationType nt = new NotificationType(0, cmbNotificationType.Text);
                    if (nt.Validate(out brokenRules))
                    {
                        nt.Insert();
                        (currentPerson as Client).FK_NotificationTypeId = nt.Id;
                    }
                    else lstError.DataSource = brokenRules;
                }

                if (insert)
                {
                    currentPerson.Insert();
                    if (currentPerson.GetType() == typeof(Client))
                    {
                        (currentPerson as Client).Insert();
                        msg = "Client inserted";
                    }
                    else
                    {
                        (currentPerson as Employee).Insert();
                        msg = "Employee inserted";
                    }
                }
                else
                {
                    currentPerson.Update();
                    if (currentPerson.GetType() == typeof(Client))
                    {
                        (currentPerson as Client).Update();
                        msg = "Client updated";
                    }
                    else
                    {
                        (currentPerson as Employee).Update();
                        msg = "Employee updated";
                    }
                }
            }
            else
            {
                lstError.DataSource = brokenRules.ToList();
            }

            MessageBox.Show(msg);
        }

        private bool validateCurrent(out IEnumerable<string> brokenRules)
        {
            if (currentPerson.GetType() == typeof(Client))
            {
                return (currentPerson as Client).Validate(out brokenRules);
            }
            else
            {
                return (currentPerson as Employee).Validate(out brokenRules);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editable = true;
            setControlEnabled(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string msg = "";

                if (currentPerson.GetType() == typeof(Client))
                {
                    (currentPerson as Client).Delete();
                    msg = "Client deleted";
                }
                else
                {
                    (currentPerson as Employee).Delete();
                    msg = "Employee deleted";
                }

                MessageBox.Show(msg);
                currentPerson = null;
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmLocation frm = new frmLocation();
            frm.Show();
            frm.FormClosed += (Sender, E) =>
            {
                Show();
            };
            Hide();
        }

        private void cbmEmployeeType_TextUpdate(object sender, EventArgs e)
        {
            newEmployeeType = true;
        }

        private void cbmEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            newEmployeeType = false;
        }

        private void cmbNotificationType_TextChanged(object sender, EventArgs e)
        {
            newNotificationType = true;
        }

        private void cmbNotificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            newNotificationType = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void createLocationHeadings(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            //BindingList<Location> list = new BindingList<Location>(tempLocation);
            dgv.Columns.Add("Id", "Id");
            dgv.Columns["Id"].DataPropertyName = "Id";

            dgv.Columns.Add("HouseNumber", "House Number");
            dgv.Columns["HouseNumber"].DataPropertyName = "HouseNumber";

            dgv.Columns.Add("StreetName", "Street Name");
            dgv.Columns["StreetName"].DataPropertyName = "Street->Name";

            dgv.Columns.Add("CityName", "City");
            dgv.Columns["CityName"].DataPropertyName = "Street->City->Name";
        }

        private void bindList<T>(DataGridView dgv, List<T> list)
        {
            AggregatedPropertyBindingList<T> temp = new AggregatedPropertyBindingList<T>(list);
            dgv.DataSource = temp;
        }

        private void tabLocations_Enter(object sender, EventArgs e)
        {
            available = BusinessLayer.Classes.Location.Select().Except(currentPerson.Locations).ToList();
            bindList(dgvAvailable, available);
            bindList(dgvUsed, currentPerson.Locations);
            btnAddAvailable.Enabled = false;
            btnRemoveUsed.Enabled = false;
        }

        private void dgvUsed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView temp = sender as DataGridView;
            if (e.RowIndex > -1)
            {
                temp.ClearSelection();
                temp.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvUsed_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count > 0) btnRemoveUsed.Enabled = true;
        }

        private void dgvAvailable_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count > 0) btnAddAvailable.Enabled = true;
        }

        private void btnAddAvailable_Click(object sender, EventArgs e)
        {
            addFromTo(dgvAvailable, dgvUsed, available, currentPerson.Locations);
        }

        private void addFromTo(DataGridView from, DataGridView to, List<Location> fromList, List<Location> toList)
        {
            if (from.SelectedRows.Count > 0)
            {
                Location temp;

                foreach (DataGridViewRow dr in from.SelectedRows)
                {
                    int id = Convert.ToInt32(dr.Cells["Id"].Value);
                    temp = fromList.Find(c => c.Id == id);
                    toList.Add(temp);
                    fromList.Remove(temp);

                    bindList(from, fromList);
                    bindList(to, toList);
                }
            }
        }

        private void btnRemoveUsed_Click(object sender, EventArgs e)
        {
            addFromTo(dgvUsed, dgvAvailable, currentPerson.Locations, available);
        }

        private void btnSaveLists_Click(object sender, EventArgs e)
        {
            List<Location> itemsToAdd = currentPerson.Locations.Except(oldCopy.Locations).ToList();
            List<Location> itemsToDelete = oldCopy.Locations.Except(currentPerson.Locations).ToList();
            ComplexQueryHelper.UpdateLocationsForPerson(currentPerson, itemsToAdd, itemsToDelete);
            MessageBox.Show("Locations Updated", "Modification status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelLists_Click(object sender, EventArgs e)
        {
            List<Location> currentLocations = currentPerson.Locations;
            oldCopy.Locations.DeepCopyInto(ref currentLocations);
            available = BusinessLayer.Classes.Location.Select();
            dgvAvailable.DataSource = available;
            dgvUsed.DataSource = currentPerson.Locations;
        }

        private void btnManageLocations_Click(object sender, EventArgs e)
        {
            frmLocation frm = new frmLocation();
            frm.Show();
            frm.FormClosed += (s, events) =>
            {
                Show();
            };
            Hide();
        }

        private void createContractColumns(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Add("ID", "ID");
            dgv.Columns["ID"].DataPropertyName = "Id";

            dgv.Columns.Add("StartDate", "Start Date");
            dgv.Columns["StartDate"].DataPropertyName = "StartDate";

            dgv.Columns.Add("EndDate", "End Date");
            dgv.Columns["EndDate"].DataPropertyName = "EndDate";

            dgv.Columns.Add("ContractType", "Contract Type");
            dgv.Columns["ContractType"].DataPropertyName = "ContractType->Title";

            dgv.Columns.Add("ServiceLevel", "Service Level");
            dgv.Columns["ServiceLevel"].DataPropertyName = "ContractType.ServiceLevel.Title";
        }

        Contract currentContract = new Contract("", "", DateTime.Now, DateTime.Now, ' ', new ContractType(' ', "", ' ', new ServiceLevel(' ')));
        Contract oldContract;

        bool contractEdit = false, contractInsert = false;

        private void tabContract_Enter(object sender, EventArgs e)
        {
            dgvContracts.DataSource = new AggregatedPropertyBindingList<Contract>(((Client)currentPerson).Contracts);
            contractEdit = false;
        }

        private void setEnableContractFields(bool state)
        {
            txtContractID.Enabled = state;
            dtpEndDate.Enabled = state;
            dtpStartDate.Enabled = state;
            cmbContractType.Enabled = state;
            btnSave.Enabled = state;
        }

        private void bindContractFields(Contract contract)
        {
            txtContractID.DataBindings.Add(new Binding("Text", contract, "Id"));
            dtpEndDate.DataBindings.Add(new Binding("Value", contract, "EndDate"));
            dtpStartDate.DataBindings.Add(new Binding("Value", contract, "StartDate"));
            cmbContractType.ValueMember = "Id";
            cmbContractType.DisplayMember = "Id";
            cmbContractType.DataBindings.Add(new Binding("SelectedValue", contract.ContractType, "Id"));
            cmbContractType.DataSource = contract.ContractType;
        }

        private void dgvContracts_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView temp = sender as DataGridView;
            if (temp.SelectedRows.Count == 1)
            {
                currentContract = (Contract) temp.SelectedRows[0].DataBoundItem;
                contractEdit = false;
                setEnableContractFields(false);
            }
        }

        private void btnEditContract_Click(object sender, EventArgs e)
        {
            contractEdit = true;
            setEnableContractFields(true);
            currentContract.DeepCopyInto(ref oldContract);
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            currentContract.Delete();
        }

        private void btnCancelContract_Click(object sender, EventArgs e)
        {
            oldContract.DeepCopyInto(ref currentContract);
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            currentContract = new Contract("", "", DateTime.Now, DateTime.Now, ' ', new ContractType(' ', "", ' ', new ServiceLevel(' ')));
            contractInsert = contractEdit = true;
            setEnableContractFields(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmContractType frm = new frmContractType();
            frm.Show();
            frm.FormClosed += (s, events) =>
            {
                Show();
            };
            Hide();
        }

        private void btnSaveContract_Click(object sender, EventArgs e)
        {
            IEnumerable<string> brokenRules;
            bool isValid = currentContract.Validate(out brokenRules);
            string msg = "Invalid input.  Please check the error box";

            if (isValid)
            {
                if (insert)
                {
                    currentContract.Insert();
                    msg = "Contract inserted";
                    ((Client)currentPerson).Contracts.Add(currentContract);
                }
                else
                {
                    currentContract.Update();
                    msg = "Contract updated";
                }

                contractInsert = contractEdit = false;
            }

            if (isValid) lstContractError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification Status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}
