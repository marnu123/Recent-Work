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
    public partial class frmCallDetails : Form
    {
        Call call;

        public frmCallDetails(Call call)
        {
            InitializeComponent();
            this.call = call;
            bindFields();
        }

        private void bindFields()
        {
            txtCellNumber.DataBindings.Add(new Binding("Text", call, "CellNumber"));
            txtEmployeeID.DataBindings.Add(new Binding("Text", call, "FK_EmployeeID"));
            txtID.DataBindings.Add(new Binding("Text", call, "Id"));
            txtInfo.DataBindings.Add(new Binding("Text", call, "CapturedInformation"));
            txtTimeEnd.DataBindings.Add(new Binding("Text", call, "TimeEnd"));
            txtTimeStart.DataBindings.Add(new Binding("Text", call, "TimeStart"));
        }
    }
}
