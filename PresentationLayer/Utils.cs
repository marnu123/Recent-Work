﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    static class Utils
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

        public static List<T> GetDifference<T>(List<T> array1, List<T> array2)
        {
           //return array1.Union(array2).ToList();
            return array1.Except(array2).ToList();
        }

        public static bool ConfirmDelete(string msg)
        {
            return DialogResult.Yes == MessageBox.Show(msg, "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static void Centralise(this Form frm)
        {
            System.Drawing.Rectangle windowRect = Screen.PrimaryScreen.Bounds;
            frm.Left = windowRect.Left + ((windowRect.Width - frm.Width) / 2);
            frm.Top = windowRect.Top + ((windowRect.Height - frm.Height) / 2);
        }
    }
}
