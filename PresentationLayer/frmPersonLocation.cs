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
    public partial class frmPersonLocation : Form
    {
        List<Location> tempLocation;
        public frmPersonLocation(List<Location> locations)
        {
            InitializeComponent();
            tempLocation = locations;
            dgvLocation.AutoGenerateColumns = false;
            //BindingList<Location> list = new BindingList<Location>(tempLocation);

            dgvLocation.Columns.Add("HouseNumber", "House Number");
            dgvLocation.Columns["HouseNumber"].DataPropertyName = "HouseNumber";

            dgvLocation.Columns.Add("StreetName", "Street Name");
            dgvLocation.Columns["StreetName"].DataPropertyName = "Street->Name";

            dgvLocation.Columns.Add("CityName", "City");
            dgvLocation.Columns["CityName"].DataPropertyName = "Street->City->Name";

            AggregatedPropertyBindingList<Location> loc = new AggregatedPropertyBindingList<Location>(locations);

            dgvLocation.DataSource = loc;

            
        }


    }
}
