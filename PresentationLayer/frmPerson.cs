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
                    dgvClients.DataSource = new BindingList<Client>(clients);
                    lblClientsEmpty.Hide();
                }
            }
        }

        private void Employees_Enter(object sender, EventArgs e)
        {
            if (employees == null)
            {
                employees = Employee.Select();
                if (employees.Count == 0) lblEmployeeEmpty.Show();
                else
                {
                    dgvEmployees.DataSource = new BindingList<Employee>(employees);
                    lblEmployeeEmpty.Hide();
                }
            }
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvClients.Rows[e.RowIndex].Cells["ClientId"].Value.ToString();
            Client temp = null;
            var q = from c in clients where c.ClientId == id select c;
            temp = q.First();

            frmPersonDetails frm = new frmPersonDetails(ref temp);
            Utils.showForm(this, frm, dgvClients, () => clients = Client.Select());
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvEmployees.Rows[e.RowIndex].Cells["Id"].Value;
            var q = from c in employees where c.Id == id select c;
            Employee temp = q.First();

            frmPersonDetails frm = new frmPersonDetails(ref temp);
            Utils.showForm(this, frm, dgvEmployees, () => employees = Employee.Select());
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            frmPersonDetails frm = new frmPersonDetails(ref emp, true, true);
            Utils.showForm(this, frm, dgvEmployees, () => Employee.Select());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Client client = new Client();
            frmPersonDetails frm = new frmPersonDetails(ref client, true, true);
            Utils.showForm(this, frm, dgvClients, () => clients = Client.Select());
        }
    }
}
