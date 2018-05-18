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
        List<Person> people;
        Person temp;
        public frmPerson()
        {
            InitializeComponent();
            people = Person.Select();
            BindingList<Person> bindList = new BindingList<Person>(people);
            dgvPerson.DataSource = bindList;
        }

        private void dgvPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int) dgvPerson.Rows[e.RowIndex].Cells["Id"].Value;
            Person temp = null;

            foreach (Person p in people)
            {
                if (p.Id == id)
                {
                    temp = p;
                    frmPersonDetails frm = new frmPersonDetails(ref temp);
                    frm.Show();
                    frm.FormClosed += (Sender, E) => 
                    {
                        Show();
                        dgvPerson.Refresh();
                    };
                    Hide();
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp = new Person(0,"","","","");
            frmPersonDetails frm = new frmPersonDetails(ref temp, true);
            frm.Show();
        }
    }
}
