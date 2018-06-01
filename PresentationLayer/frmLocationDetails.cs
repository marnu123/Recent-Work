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
        List<Product> available;
        bool newStreet = false;
        bool newCity = false;
        bool edit;
        bool insert;

        public frmLocationDetails(ref Location location, bool insert = false)
            :this(location, insert) {}

        private frmLocationDetails(Location location, bool insert = false)
        {
            InitializeComponent();
            this.location = location;
            location.DeepCopyInto(ref oldCopy);
            this.edit = insert;
            this.insert = insert;

            initializeComboBoxes();
            bindFields(location);
            toggleControlsEnable(insert);
            addProductColumns(dgvAvailable);
            addProductColumns(dgvUsed);
        }

        //If a person's locations are being managed, save these details to the original person object
        public frmLocationDetails(ref Person person, ref Location location, bool edit = false, bool insert = false)
            :this(location, insert)
        {
            this.person = person;
        }

        private void initializeComboBoxes()
        {
            cities = City.Select();
            streets = Street.Select();
            bindComboBox(cmbCity, new BindingList<City>(cities), "Name", "Id");
            bindComboBox(cmbStreet, new BindingList<Street>(streets), "Name", "Id");
            if (!insert)
            {
                cmbStreet.SelectedIndex = -1;
                cmbCity.SelectedIndex = -1;
            }
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
            cmbCity_SelectedIndexChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<string> brokenRules;
            string msg = "Invalid input.  Please check the Error box";
            bool isValid = false;

            if (newCity)
            {
                City c = new City(0, cmbCity.Text);
                if (c.IsUnique() && c.Validate(out brokenRules))
                {
                    c.Insert();
                    location.Street.City = c;
                    location.Street.FK_CityID = c.Id;
                }
            }

            if (newStreet)
            {
                Street s = new Street(0, cmbStreet.Text, txtAreaCode.Text, location.Street.City);
                s.FK_CityID = location.Street.City.Id;

                if (s.IsUnique() && s.Validate(out brokenRules))
                {
                    s.Insert();
                    location.Street = s;
                    location.FK_StreetID = s.Id;
                }
            }

            if (location.Validate(out brokenRules))
            {
                isValid = true;
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

            if (!isValid) lstError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification Status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
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
                Close();
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

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            List<Product> products = ComplexQueryHelper.GetProductsForLocation(location);
            frmProduct frm = new frmProduct();
            frm.FormClosed += (s, eventArgs) =>
            {
                Show();
            };
            frm.Show();
            Hide();
        }

        private void dgvUsed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView temp = sender as DataGridView;
            temp.ClearSelection();
            temp.Rows[e.RowIndex].Selected = true;
        }

        private void tabProducts_Enter(object sender, EventArgs e)
        {
            if (available == null) available = Product.Select();
            bindList(dgvAvailable, available);
            bindList(dgvUsed, location.Products);
            btnAddAvailable.Enabled = false;
            btnRemoveUsed.Enabled = false;
        }

        private void bindList<T>(DataGridView dgv, List<T> list)
        {
            dgv.DataSource = new AggregatedPropertyBindingList<T>(list);
        }

        private void addProductColumns(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns["Id"].DataPropertyName = "Id";
            //dgvLocation.Columns["Id"].DataPropertyName = "Street->Name";
            dataGridView.Columns.Add("Name", "Name");
            dataGridView.Columns["Name"].DataPropertyName = "Name";

            dataGridView.Columns.Add("Price", "Price");
            dataGridView.Columns["Price"].DataPropertyName = "Price";

            dataGridView.Columns.Add("DateAdded", "Date Added");
            dataGridView.Columns["DateAdded"].DataPropertyName = "DateAdded";

            dataGridView.Columns.Add("ProductCategory", "Category");
            dataGridView.Columns["ProductCategory"].DataPropertyName = "ProductCategory->Title";

            dataGridView.Columns.Add("Manufacturer", "Manufacturer");
            dataGridView.Columns["Manufacturer"].DataPropertyName = "Manufacturer->Name";

            dataGridView.Columns.Add("Model", "Model");
            dataGridView.Columns["Model"].DataPropertyName = "Model";
        }

        private void btnCancelLists_Click(object sender, EventArgs e)
        {
            List<Product> temp = location.Products;
            location.Products.DeepCopyInto(ref temp);
            available = Product.Select();
            bindList(dgvAvailable, available);
            bindList(dgvUsed, location.Products);
        }

        private void btnSaveLists_Click(object sender, EventArgs e)
        {
            List<Product> itemsToAdd = location.Products.Except(oldCopy.Products).ToList();
            List<Product> itemsToDelete = oldCopy.Products.Except(location.Products).ToList();
            ComplexQueryHelper.UpdateProductsForLocation(location, itemsToAdd, itemsToDelete);
        }
    }
}
