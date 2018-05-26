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
using Loc = BusinessLayer.Classes.Location;

namespace PresentationLayer
{
    public partial class frmLocation : Form
    {
        List<Loc> locations;
        AggregatedPropertyBindingList<Location> loc;

        public frmLocation()
        {
            InitializeComponent();
            this.locations = Loc.Select();
            dgvLocation.AutoGenerateColumns = false;
            //BindingList<Location> list = new BindingList<Location>(tempLocation);
            dgvLocation.Columns.Add("Id", "Id");
            dgvLocation.Columns["Id"].DataPropertyName = "Id";

            dgvLocation.Columns.Add("HouseNumber", "House Number");
            dgvLocation.Columns["HouseNumber"].DataPropertyName = "HouseNumber";

            dgvLocation.Columns.Add("StreetName", "Street Name");
            dgvLocation.Columns["StreetName"].DataPropertyName = "Street->Name";

            dgvLocation.Columns.Add("CityName", "City");
            dgvLocation.Columns["CityName"].DataPropertyName = "Street->City->Name";

             loc = new AggregatedPropertyBindingList<Location>(locations);

            dgvLocation.DataSource = loc;
        }

        private void dgvLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int) dgvLocation.Rows[e.RowIndex].Cells["Id"].Value;
            Location temp = null;
            var q = from c in locations where c.Id == id select c;
            temp = q.First();

            frmLocationDetails frm = new frmLocationDetails(ref temp);
            Utils.ShowForm(this, frm, dgvLocation, () =>
            {
                //Refresh list
                locations = Loc.Select();
                loc = new AggregatedPropertyBindingList<Location>(locations);
                dgvLocation.DataSource = loc;
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Location temp = new Location();
            frmLocationDetails frm = new frmLocationDetails(ref temp, true);
            Utils.ShowForm(this, frm, dgvLocation, () =>
            {
                //Refresh list
                locations = Loc.Select();
                loc = new AggregatedPropertyBindingList<Location>(locations);
                dgvLocation.DataSource = loc;
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
