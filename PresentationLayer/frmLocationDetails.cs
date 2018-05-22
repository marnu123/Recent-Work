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
using BusinessLayer.Helpers;
using BusinessLayer.Classes;
using BusinessLayer.Validators;

namespace PresentationLayer
{
    public partial class frmLocationDetails : Form
    {
        Person person;
        Location location;
        Location oldCopy;
        List<City> cities;
        List<Street> streets;
        bool newStreet = false;
        bool newCity = false;
        bool edit;
        bool insert;

        public frmLocationDetails(ref Location location, bool edit = false, bool insert = false)
            :this(location, edit, insert) {}

        private frmLocationDetails(Location location, bool edit = false, bool insert = false)
        {
            InitializeComponent();
            this.location = location;
            oldCopy = new Location();
            location.DeepCopyInto(ref oldCopy);
            this.edit = edit;
            this.insert = insert;

            initializeComboBoxes();
            bindFields(location);
            toggleControlsEnable(edit || insert);
        }

        //If a person's locations are being managed, save these details to the original person object
        public frmLocationDetails(ref Person person, ref Location location, bool edit = false, bool insert = false)
            :this(location, edit, insert)
        {
            this.person = person;
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
                newStreet = false;
                Street temp = cmbStreet.SelectedItem as Street;
                location.Street = temp;
                txtAreaCode.Text = temp.AreaCode;
                cmbCity.SelectedValue = temp.FK_CityID;
            }
        }

        private void cmbStreet_TextChanged(object sender, EventArgs e)
        {
            newStreet = true;
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCity.SelectedIndex > -1)
            {
                newCity = false;
                location.Street.City = (City)cmbCity.SelectedItem;
            }
        }

        private void cmbCity_TextChanged(object sender, EventArgs e)
        {
            newCity = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<string> brokenRules;
            string msg = "Invalid input.  Please check the Error box";

            if ((newCity || location.Street.City.IsUnique())
                && location.Street.City.Validate(out brokenRules))
            {
                location.Street.City.Insert();
                location.Street.FK_CityID = location.Street.City.Id;
            }

            if ((newStreet || location.Street.IsUnique())
                && location.Street.Validate(out brokenRules))
            {
                location.Street.Insert();
                location.FK_StreetID = location.Street.Id;
            }

            if (location.Validate(out brokenRules))
            {
                if (insert)
                {
                    //Insert a new location for a person only if the person object has been set
                    if (person != null) ComplexQueryHelper.InsertLocationForPerson(ref person, location);
                    else location.Insert();
                    msg = "Location Inserted";
                }
                else
                {
                    location.Update();
                    msg = "Location Updated";
                }
            }

            MessageBox.Show(msg);
            lstError.DataSource = brokenRules.ToList();  
        }

        private void toggleControlsEnable(bool state)
        {
            cmbCity.Enabled = state;
            cmbStreet.Enabled = state;
            txtAreaCode.Enabled = state;
            txtHouseNumber.Enabled = state;
            btnSave.Enabled = state;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            toggleControlsEnable(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete this location?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                location.Delete();
                MessageBox.Show("Location Deleted");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            oldCopy.DeepCopyInto(ref location);
            refreshControls();
            bindFields(location);
            newCity = false;
            newStreet = false;
        }

        private void refreshControls()
        {
            txtAreaCode.DataBindings.Clear();
            txtHouseNumber.DataBindings.Clear();
            cmbCity.DataBindings.Clear();
            cmbStreet.DataBindings.Clear();
        }
    }
}
