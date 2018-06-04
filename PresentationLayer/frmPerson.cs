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

namespace PresentationLayer
{
    public partial class frmPerson : Form
    {
        List<Client> clients;
        List<Employee> employees;
        Person temp;
        
        public frmPerson()
        {
            InitializeComponent();
            CenterToScreen();
            buildClientColumns();
            buildEmployeeColumns();
        }

        private void tabClients_FontChanged(object sender, EventArgs e)
        {
            
        }

        private void tabClients_Enter(object sender, EventArgs e)
        {
            if (clients == null)
            {
                clients = Client.Select();
                if (clients.Count == 0) lblClientsEmpty.Show();
                else
                {
                    dgvClients.DataSource = new AggregatedPropertyBindingList<Client>(clients);
                    lblClientsEmpty.Hide();
                }
            }
        }

        private void buildClientColumns()
        {
            dgvClients.AutoGenerateColumns = false;
            dgvClients.Columns.Add("ID", "ID");
            dgvClients.Columns["ID"].DataPropertyName = "ClientId";

            dgvClients.Columns.Add("Email", "Email");
            dgvClients.Columns["Email"].DataPropertyName = "Email";

            dgvClients.Columns.Add("Name", "Name");
            dgvClients.Columns["Name"].DataPropertyName = "Name";

            dgvClients.Columns.Add("Surname", "Surname");
            dgvClients.Columns["Surname"].DataPropertyName = "Surname";

            dgvClients.Columns.Add("CellNumber", "Cell Number");
            dgvClients.Columns["CellNumber"].DataPropertyName = "CellNumber";
        }

        private void buildEmployeeColumns()
        {
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.Columns.Add("ID", "ID");
            dgvEmployees.Columns["ID"].DataPropertyName = "EmployeeId";

            dgvEmployees.Columns.Add("Email", "Email");
            dgvEmployees.Columns["Email"].DataPropertyName = "Email";

            dgvEmployees.Columns.Add("Name", "Name");
            dgvEmployees.Columns["Name"].DataPropertyName = "Name";

            dgvEmployees.Columns.Add("Surname", "Surname");
            dgvEmployees.Columns["Surname"].DataPropertyName = "Surname";

            dgvEmployees.Columns.Add("CellNumber", "Cell Number");
            dgvEmployees.Columns["CellNumber"].DataPropertyName = "CellNumber";
        }

        private void Employees_Enter(object sender, EventArgs e)
        { 
            if (employees == null)
            {
                employees = Employee.Select();
                if (employees.Count == 0) lblEmployeeEmpty.Show();
                else
                {
                    dgvEmployees.DataSource = new AggregatedPropertyBindingList<Employee>(employees);
                    lblEmployeeEmpty.Hide();
                }
            }
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Client temp = (Client) dgvClients.Rows[e.RowIndex].DataBoundItem;

                frmPersonDetails frm = new frmPersonDetails(ref temp);
                Utils.ShowForm(this, frm, dgvClients, () =>
                {
                    clients = Client.Select();
                    dgvClients.DataSource = new AggregatedPropertyBindingList<Client>(clients);
                });
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Employee temp = (Employee)dgvEmployees.Rows[e.RowIndex].DataBoundItem;

                frmPersonDetails frm = new frmPersonDetails(ref temp);
                Utils.ShowForm(this, frm, dgvEmployees, () =>
                {
                    employees = Employee.Select();
                    dgvEmployees.DataSource = new AggregatedPropertyBindingList<Employee>(employees);
                });
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            frmPersonDetails frm = new frmPersonDetails(ref emp, true, true);
            Utils.ShowForm(this, frm, dgvEmployees, () => Employee.Select());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Client client = new Client();
            frmPersonDetails frm = new frmPersonDetails(ref client, true, true);
            Utils.ShowForm(this, frm, dgvClients, () => clients = Client.Select());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchterm = "%" + txtSearchterm.Text + "%";
            clients = Client.Select(c => c.FK_PersonEmail != searchterm);
            dgvClients.DataSource = new AggregatedPropertyBindingList<Client>(clients);
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            string searchterm = "%" + txtEmployeeSearch.Text + "%";
            employees = Employee.Select(c => c.FK_PersonEmail != searchterm);
            dgvEmployees.DataSource = new AggregatedPropertyBindingList<Employee>(employees);
        }
    }
}
