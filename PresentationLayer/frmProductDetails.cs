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
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmProductDetails : Form
    {
        Location location;
        Product product;
        Product oldCopy;
        bool insert = false, edit = false, newCategory = false, newManufacturer = false;
        List<Manufacturer> manufacturers;
        List<ProductCategory> productCategories;

        public frmProductDetails(ref Location location, ref Product product, bool insert = false)
        {
            InitializeComponent();
            this.location = location;
            product.DeepCopyInto(ref oldCopy);
            this.product = product;
            this.insert = insert;
            setControlEnabled(false);
            manufacturers = Manufacturer.Select();
            productCategories = ProductCategory.Select();
        }

        private void bindFields(Product product)
        {
            dtpDateAdded.DataBindings.Add(new Binding("Value", product, "DateAdded"));
            txtName.DataBindings.Add(new Binding("Text", product, "Name"));
            txtDescription.DataBindings.Add(new Binding("Text", product, "Description"));
            txtSerial.DataBindings.Add(new Binding("Text", product, "Id"));

            cmbManufacturer.DataSource = manufacturers;
            cmbManufacturer.ValueMember = "Id";
            cmbManufacturer.DisplayMember = "Name";
            cmbCategory.DataSource = productCategories;
            cmbCategory.ValueMember = "Title";
            cmbCategory.DisplayMember = "Title";
        }

        private void setControlEnabled(bool state)
        {
            txtDescription.Enabled = state;
            txtName.Enabled = state;
            txtSerial.Enabled = state;
            cmbCategory.Enabled = state;
            cmbManufacturer.Enabled = state;
            dtpDateAdded.Enabled = state;
            nudPrice.Enabled = state;
        }

        private void b_Click(object sender, EventArgs e)
        {
            edit = true;
            setControlEnabled(true);
        }

        private void cmbManufacturer_TextChanged(object sender, EventArgs e)
        {
            newManufacturer = true;
        }

        private void cmbCategory_TextChanged(object sender, EventArgs e)
        {
            newCategory = true;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            newCategory = false;
        }

        private void cmbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            newManufacturer = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this product?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg == DialogResult.Yes)
            {
                product.Delete();
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            oldCopy.DeepCopyInto(ref product);
            bindFields(product);
            setControlEnabled(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
