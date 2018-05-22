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

namespace PresentationLayer
{
    public partial class frmPersonDetails : Form
    {
        Person currentPerson;
        bool insert = false;
        bool newEmployeeType = false;
        bool newNotificationType = false;
        bool editable = false;

        public frmPersonDetails(ref Employee employee, bool edit = false, bool insert = false)
        {
            InitializeComponent();
            currentPerson = employee;
            initializeFields(edit, insert);
            txtID.DataBindings.Add("Text", employee, "EmployeeID");
            txtPassword.DataBindings.Add("Text", employee, "Password");
            List<EmployeeType> employeeTypes = EmployeeType.Select();
            BindingList<EmployeeType> bl = new BindingList<EmployeeType>(employeeTypes);

            bindComboBox(cbmEmployeeType, bl, "Title", "Id");
            cbmEmployeeType.DataBindings.Add("SelectedValue", employee, "FK_EmployeeTypeId");

            if (insert) cbmEmployeeType.SelectedIndex = -1;

            pnlClientDetails.Visible = false;
            pnlEmployeeDetails.Visible = true;
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
            currentPerson = client;
            initializeFields(edit, insert);
            txtID.DataBindings.Add("Text", client, "ClientID");
            pnlClientDetails.Visible = true;
            List<NotificationType> notificationTypes = NotificationType.Select();
            BindingList<NotificationType> bl = new BindingList<NotificationType>(notificationTypes);

            bindComboBox(cmbNotificationType, bl, "Title", "Id");
            cmbNotificationType.DataBindings.Add("SelectedValue", client, "FK_NotificationTypeId");

            if (insert) cmbNotificationType.SelectedIndex = -1;

            pnlEmployeeDetails.Visible = false;
            pnlClientDetails.Visible = true;
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

        private void initializeFields(bool edit, bool insert)
        {
            this.insert = insert;
            txtName.DataBindings.Add("Text", currentPerson, "Name");
            txtEmail.DataBindings.Add("Text", currentPerson, "FK_PersonEmail");
            txtCellNumber.DataBindings.Add("Text", currentPerson, "CellNumber");
            txtSurname.DataBindings.Add("Text", currentPerson, "Surname");
            editable = edit;
            //Enable controls for edits or inserts
            setControlEnabled(edit || insert);
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
            frmPersonLocation frm = new frmPersonLocation(currentPerson);
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
    }
}
