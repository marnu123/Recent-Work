using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Classes;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmTaskDetails : Form
    {
        Task task;
        bool insert, edit;

        public frmTaskDetails(Task task, bool insert)
        {
            InitializeComponent();
            this.task = task;
            this.insert = insert;
        }
    }
}
