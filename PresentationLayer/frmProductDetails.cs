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
using BusinessLayer.Validators;

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
            nudPrice.Minimum = decimal.MinValue;
            nudPrice.Maximum = decimal.MaxValue;
            this.location = location;
            product.DeepCopyInto(ref oldCopy);
            this.product = product;
            this.insert = insert;
            setControlEnabled(false);
            manufacturers = Manufacturer.Select();
            productCategories = ProductCategory.Select();
            bindFields(product);
        }

        private void bindFields(Product product)
        {
            dtpDateAdded.DataBindings.Add(new Binding("Value", product, "DateAdded"));
            txtName.DataBindings.Add(new Binding("Text", product, "Name"));
            txtDescription.DataBindings.Add(new Binding("Text", product, "Description"));
            txtSerial.DataBindings.Add(new Binding("Text", product, "Id"));
            nudPrice.DataBindings.Add(new Binding("Value", product, "Price"));

            cmbManufacturer.ValueMember = "Id";
            cmbManufacturer.DisplayMember = "Name";
            cmbManufacturer.DataBindings.Add(new Binding("SelectedValue", product, "FK_ManufacturerID"));
            cmbManufacturer.DataSource = manufacturers;
            cmbCategory.ValueMember = "Title";
            cmbCategory.DisplayMember = "Title";
            cmbCategory.DataBindings.Add(new Binding("SelectedValue", product, "FK_ProductCategoryTitle"));
            cmbCategory.DataSource = productCategories;
        }

        private void clearBindings()
        {
            txtName.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            txtSerial.DataBindings.Clear();
            cmbCategory.DataBindings.Clear();
            cmbManufacturer.DataBindings.Clear();
            nudPrice.DataBindings.Clear();
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

        private void btnManageComponents_Click(object sender, EventArgs e)
        {
            frmComponent frm = new frmComponent(product, product.Components);
            frm.Show();
            frm.FormClosed += (s, events) =>
            {
                Show();
            };
            Hide();
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
            clearBindings();
            bindFields(product);
            setControlEnabled(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "Invalid configuration.  Please check the error box";
            IEnumerable<string> brokenRules;

            if (newCategory)
            {
                ProductCategory cat = new ProductCategory(cmbCategory.Text, "");
                if (cat.Validate(out brokenRules) && Validator.IsUnique(cat))
                    cat.Insert();
            }

            if (newManufacturer)
            {
                Manufacturer man = new Manufacturer(0, cmbManufacturer.Text);
                if (man.Validate(out brokenRules) && Validator.IsUnique(man))
                    man.Insert();
            }

            if (product.Validate(out brokenRules))
            {
                if (insert)
                {
                    product.Insert();
                    msg = "Product Inserted";
                }
                else
                {
                    product.Update();
                    msg = "Product Updated";
                }
            }

            lstError.DataSource = brokenRules;
            MessageBox.Show(msg);
        }
    }
}
