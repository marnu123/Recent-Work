using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Helpers;
using BusinessLayer.Classes;

namespace PresentationLayer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("The email and password fields may not be empy", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else            
            {
                Employee result = ComplexQueryHelper.ValidLogin(txtEmail.Text, txtPassword.Text);

                if (result != null)
                {
                    frmMenu frm = new frmMenu(result);
                    frm.Show();
                    frm.FormClosed += (s, events) => Show();
                    Hide();
                }
                else MessageBox.Show("Invalid credentials", "Invalid login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
