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
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmPersonDetails : Form
    {
        Person currentPerson;
        bool insert = false;
        public frmPersonDetails(ref Person person, bool insert = false)
        {
            InitializeComponent();
            this.insert = insert;
            currentPerson = person;
            txtName.DataBindings.Add("Text", currentPerson, "Name");
            txtEmail.DataBindings.Add("Text", currentPerson, "Email");
            txtCellNumber.DataBindings.Add("Text", currentPerson, "CellNumber");
            txtSurname.DataBindings.Add("Text", currentPerson, "Surname");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (insert)
            {
                currentPerson.Insert();
                MessageBox.Show("Person Inserted");
            }
            else
            {
                currentPerson.Update();
                MessageBox.Show("Person Updated");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            currentPerson.Delete();
            MessageBox.Show("Person deleted");
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmPersonLocation frm = new frmPersonLocation(currentPerson.Locations);
            frm.Show();
            frm.FormClosed += (Sender, E) =>
            {
                Show();
            };
            Hide();
        }
    }
}
