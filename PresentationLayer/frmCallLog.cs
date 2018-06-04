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
    public partial class frmCallLog : Form
    {
        List<Call> calls;
        public frmCallLog()
        {
            InitializeComponent();
            CenterToScreen();
            calls = Call.Select();
            dgvCalls.DataSource = calls;
        }

        private void dgvCalls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView temp = sender as DataGridView;
            if (e.RowIndex > -1)
            {
                Call call = (Call) temp.Rows[e.RowIndex].DataBoundItem;
                frmCallDetails frm = new frmCallDetails(call);
                frm.Show();
                frm.FormClosed += (s, events) => Show();
                Hide();
            }
        }
    }
}
