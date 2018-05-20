using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using BusinessLayer.Classes;
using BusinessLayer.Validators;

namespace PresentationLayer
{
    public partial class frmLocationDetails : Form
    {
        Location location;
        List<City> cities;
        List<Street> streets;

        public frmLocationDetails(ref Location location, bool edit = false, bool insert = false)
        {
            InitializeComponent();
            initializeComboBoxes();
            bindFields(location);
        }

        private void initializeComboBoxes()
        {
            cities = City.Select();
            streets = Street.Select();
            bindComboBox(cmbCity, new BindingList<City>(cities), "Name", "Id");
            bindComboBox(cmbStreet, new BindingList<Street>(streets), "Name", "Id");
            cmbStreet.SelectedIndex = -1;
            cmbCity.SelectedIndex = -1;
        }

        private void bindFields(Location location)
        {
            txtAreaCode.DataBindings.Add("Text", location.Street, "AreaCode");
            txtHouseNumber.DataBindings.Add("Text", location, "HouseNumber");
            cmbStreet.DataBindings.Add("SelectedValue", location, "FK_StreetID");
            cmbCity.DataBindings.Add("SelectedValue", location.Street, "FK_CityID");
        }

        private void bindComboBox<T>(ComboBox cb, BindingList<T> bindingList, string displayMember, string valueMember)
        {
            bindingList.AllowEdit = false;
            bindingList.AllowNew = true;
            bindingList.AllowRemove = false;
            cb.DisplayMember = displayMember;
            cb.ValueMember = valueMember;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb.DataSource = bindingList;
        }

        private void cmbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStreet.SelectedIndex > -1)
            {
                Street temp = cmbStreet.SelectedItem as Street;
                cmbCity.SelectedValue = temp.FK_CityID;
                txtAreaCode.Text = temp.AreaCode;
            }
        }
    }
}
