﻿using System;
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
        List<EmployeeType> employeeTypes;
        List<NotificationType> notificationTypes;
        bool insert = false;
        bool newEmployeeType = false;
        bool newNotificationType = false;
        bool editable = false;

        public frmPersonDetails(ref Employee employee, bool edit = false, bool insert = false)
        {
            initialise(employee, insert);
            txtID.DataBindings.Add("Text", employee, "EmployeeID");
            txtPassword.DataBindings.Add("Text", employee, "Password");

            employeeTypes = EmployeeType.Select();
            BindingList<EmployeeType> bl = new BindingList<EmployeeType>(employeeTypes);

            bindComboBox(cbmEmployeeType, bl, "Title", "Id");
            cbmEmployeeType.DataBindings.Add("SelectedValue", employee, "FK_EmployeeTypeId");

            if (insert) cbmEmployeeType.SelectedIndex = -1;
        }

        private void initialise(Person person, bool insert)
        {
            InitializeComponent();
            CenterToScreen();
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
            enableTabs(!insert);
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
            initialise(client, insert);
            txtID.DataBindings.Add("Text", client, "ClientID");

            notificationTypes = NotificationType.Select();
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

        //Enable tabs only if a user already exists in the database
        private void enableTabs(bool enabled)
        {
            if (!enabled)
            {
                tabContract.Hide();
                tabLocations.Hide();
            }
            else
            {
                tabContract.Show();
                tabLocations.Show();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "Invalid input. Please refer to the error box";
            IEnumerable<string> brokenRules = null;
            bool isValid = true;

            if (newEmployeeType)
            {
                EmployeeType et = new EmployeeType(0, cbmEmployeeType.Text);
                isValid = et.Validate(out brokenRules);
                if (isValid)
                {
                    et.Insert();
                    employeeTypes.Add(et);
                    cbmEmployeeType.DataSource = employeeTypes;
                    cbmEmployeeType.SelectedItem = et;
                }
            }

            if (newNotificationType)
            {
                NotificationType nt = new NotificationType(0, cmbNotificationType.Text);
                isValid = nt.Validate(out brokenRules);
                if (isValid)
                {
                    nt.Insert();
                    notificationTypes.Add(nt);
                    cmbNotificationType.DataSource = notificationTypes;
                    cmbNotificationType.SelectedItem = nt;
                }
            }

            if (isValid)
            {
                isValid = validateCurrent(out brokenRules);
                if (isValid)
                {
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
                    insert = editable = false;
                    enableTabs(!insert);
                    setControlEnabled(false);
                }
            }

            lstError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification Status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
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
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string msg = "";
                    ((Person)currentPerson).Delete();

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
            catch (Exception ex)
            {
                MessageBox.Show("A server error occurred.  Please contact the administrator", "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void refreshLocations()
        {
            currentPerson.Locations = ComplexQueryHelper.GetLocationsForPerson(currentPerson.Email);
            available = BusinessLayer.Classes.Location.Select().Except(currentPerson.Locations).ToList();
            dgvAvailable.DataSource = new AggregatedPropertyBindingList<Location>(available);
            dgvUsed.DataSource = new AggregatedPropertyBindingList<Location>(currentPerson.Locations);
        }

        private void btnManageLocations_Click(object sender, EventArgs e)
        {
            frmLocation frm = new frmLocation();
            frm.Show();
            frm.FormClosed += (s, events) =>
            {
                refreshLocations();
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
            dgv.Columns["ContractType"].DataPropertyName = "FK_ContractTypeId";

            dgv.Columns.Add("ServiceLevel", "Service Level");
            dgv.Columns["ServiceLevel"].DataPropertyName = "FK_ServiceLevelId";
        }

        Contract currentContract = new Contract("", "", DateTime.Now, DateTime.Now, ' ', new ContractType(' ', ""));
        Contract oldContract;
        List<ContractType> contractTypes;
        List<ServiceLevel> serviceLevels;

        bool contractEdit = false, contractInsert = false;

        private void tabContract_Enter(object sender, EventArgs e)
        {
            refreshContracts();
            contractTypes = ContractType.Select();
            serviceLevels = ServiceLevel.Select();
            contractEdit = false;
            bindContractFields(currentContract);
            dgvContracts.DataSource = (currentPerson as Client).Contracts;
            setEnableContractFields(false);
        }

        private void setEnableContractFields(bool state)
        {
            dtpEndDate.Enabled = state;
            dtpStartDate.Enabled = state;
            cmbContractType.Enabled = state;
            btnSave.Enabled = state;
            cmbCustomerImportance.Enabled = state;
        }

        private void bindContractFields(Contract contract)
        {
            txtContractID.DataBindings.Clear();
            dtpEndDate.DataBindings.Clear();
            dtpStartDate.DataBindings.Clear();
            cmbContractType.DataBindings.Clear();
            cmbCustomerImportance.DataBindings.Clear();

            txtContractID.DataBindings.Add(new Binding("Text", contract, "Id"));
            dtpEndDate.DataBindings.Add(new Binding("Value", contract, "EndDate"));
            dtpStartDate.DataBindings.Add(new Binding("Value", contract, "StartDate"));
            cmbContractType.ValueMember = "Id";
            cmbContractType.DisplayMember = "Id";
            cmbContractType.DataBindings.Add(new Binding("SelectedValue", contract, "FK_ContractTypeID"));
            cmbContractType.DataSource = contractTypes;

            cmbCustomerImportance.DataBindings.Add(new Binding("SelectedValue", contract, "FK_ServiceLevelId"));
            cmbCustomerImportance.DisplayMember = "Id";
            cmbCustomerImportance.ValueMember = "Id";
            cmbCustomerImportance.DataSource = serviceLevels;
        }

        private void dgvContracts_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView temp = sender as DataGridView;
            if (temp.SelectedRows.Count == 1)
            {
                currentContract = (Contract) temp.SelectedRows[0].DataBoundItem;
                contractEdit = false;
                setEnableContractFields(false);
                bindContractFields(currentContract);
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
            if (Utils.ConfirmDelete("Are you sure you want to delete this contract?"))
            {
                currentContract.Delete();
                (currentPerson as Client).Contracts.Remove(currentContract);
                refreshContracts();
            }
        }

        private void refreshContracts()
        {
            dgvContracts.DataSource = new AggregatedPropertyBindingList<Contract>((currentPerson as Client).Contracts);
        }

        private void btnCancelContract_Click(object sender, EventArgs e)
        {
            oldContract.DeepCopyInto(ref currentContract);
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            currentContract = new Contract("", (currentPerson as Client).ClientId, DateTime.Now, DateTime.Now, ' ', new ContractType(' ', ""));
            bindContractFields(currentContract);
            contractInsert = true;
            setEnableContractFields(true);
        }
       
        private void refetchClientContracts()
        {
            string clientID = (currentPerson as Client).ClientId;
            (currentPerson as Client).Contracts = Contract.Select(c => c.FK_ClientId == clientID);
            refreshContracts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmContractType frm = new frmContractType();
            frm.Show();
            frm.FormClosed += (s, events) =>
            {
                contractTypes = ContractType.Select();
                cmbContractType.DataSource = contractTypes;
                refetchClientContracts();
                Show();
            };
            Hide();
        }

        private void tcPerson_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (insert)
            {
                MessageBox.Show("A user must be saved in the database before location or contract information can be viewed", "Invalid operation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveContract_Click(object sender, EventArgs e)
        {
            IEnumerable<string> brokenRules;
            ContractID id = new ContractID(currentContract.StartDate.Year, currentContract.FK_ContractTypeId, currentContract.FK_ServiceLevelId);
            currentContract.Id = id.ToString();
            bool isValid = currentContract.Validate(out brokenRules);
            string msg = "Invalid input.  Please check the error box";

            if (isValid)
            {
                if (contractInsert)
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
                refreshContracts();
            }

            lstContractError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification Status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}
