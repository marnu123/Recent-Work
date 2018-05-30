using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            showForm(new frmPerson());
        }

        private void showForm(Form toShow)
        {
            toShow.Show();
            toShow.Closed += (s, events) =>
            {
                Show();
            };
            Hide();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            showForm(new frmProduct());
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            showForm(new frmLocation());
        }

        private void btnComponents_Click(object sender, EventArgs e)
        {
            showForm(new frmComponent());
        }

        private void btnContractTypes_Click(object sender, EventArgs e)
        {
            showForm(new frmContractType());
        }

        private void btnCaller_Click(object sender, EventArgs e)
        {
            showForm(new frmCall(new BusinessLayer.Classes.Call(0, DateTime.Now.AddSeconds(-10), DateTime.Now, "123", "0123456798", ""), true));
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            showForm(new frmTask());
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            showForm(new frmScheduleTreeViewForm());
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            showForm(new frmSchedule());
        }
    }
}
