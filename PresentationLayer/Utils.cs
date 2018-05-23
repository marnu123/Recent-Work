using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    class Utils
    {
        public static void ShowForm(Form sender, Form form, DataGridView dgvToRefresh, Action refreshMethod)
        {
            form.Show();
            form.FormClosed += (Sender, E) =>
            {
                sender.Show();
                refreshMethod();
                dgvToRefresh.Refresh();
            };
            sender.Hide();
        }
    }
}
