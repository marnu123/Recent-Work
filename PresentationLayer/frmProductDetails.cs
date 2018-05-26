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
using BusinessLayer.Helpers;
using Comp = BusinessLayer.Classes.Component;

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
        List<Comp> availableComponents;

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
            frmComponent frm = new frmComponent();
            frm.Show();
            frm.FormClosed += (s, events) =>
            {
                Show();
            };
            Hide();
        }

        private void tabComponents_Enter(object sender, EventArgs e)
        {
            dgvUsedComponents.DataSource = new BindingList<Comp>(product.Components);
            availableComponents = getAvailableComponents(product.Components, Comp.Select());
            dgvAvailableComponents.DataSource = availableComponents;
            btnAddComponent.Enabled = false;
            btnRemoveComponent.Enabled = false;
        }

        private List<Comp> getAvailableComponents(List<Comp> existingItems, List<Comp> newItems)
        {
            var query = newItems.Where((item) => existingItems.Contains(item));
            foreach (Comp config in query.ToList())
            {
                newItems.Remove(config);
            }

            return newItems;
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            addFromTo(dgvAvailableComponents, dgvUsedComponents, availableComponents, product.Components);
        }

        private void addFromTo(DataGridView from, DataGridView to, List<Comp> fromList, List<Comp> toList)
        {
            if (from.SelectedRows.Count > 0)
            {
                Comp temp;

                foreach (DataGridViewRow dr in from.SelectedRows)
                {
                    string id = dr.Cells["Id"].Value.ToString();
                    temp = fromList.Find(c => c.Id == id);
                    toList.Add(temp);
                    fromList.Remove(temp);
                    from.DataSource = new BindingList<Comp>(fromList);
                    to.DataSource = new BindingList<Comp>(toList);
                }
            }
        }

        private void btnRemoveComponent_Click(object sender, EventArgs e)
        {
            addFromTo(dgvUsedComponents, dgvAvailableComponents, product.Components, availableComponents);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var diff = product.Components.Except(oldCopy.Components);
            ComplexQueryHelper.AddComponentsForProduct(product, diff.ToList());
            MessageBox.Show("Product Component composition updated", "Modification status");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            availableComponents = getAvailableComponents(product.Components, Comp.Select());
            dgvAvailableComponents.DataSource = availableComponents;
            dgvUsedComponents.DataSource = new BindingList<Comp>(product.Components);
        }

        private void dgvAvailableComponents_SelectionChanged(object sender, EventArgs e)
        {
            btnAddComponent.Enabled = (sender as DataGridView).SelectedRows.Count > 0;
        }

        private void dgvUsedComponents_SelectionChanged(object sender, EventArgs e)
        {
            btnRemoveComponent.Enabled = (sender as DataGridView).SelectedRows.Count > 0;
        }

        private void dgvAvailableComponents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderTemp = sender as DataGridView;
            if (e.RowIndex > -1) senderTemp.Rows[e.RowIndex].Selected = true;
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
            bool isValid = false;

            if (newCategory)
            {
                ProductCategory cat = new ProductCategory(cmbCategory.Text, "");
                if (cat.Validate(out brokenRules) && Validator.IsUnique(cat))
                {
                    cat.Insert();
                    product.ProductCategory = cat;
                    product.FK_ProductCategoryTitle = cat.Title;
                    productCategories.Add(cat);
                }
            }

            if (newManufacturer)
            {
                Manufacturer man = new Manufacturer(0, cmbManufacturer.Text);
                if (man.Validate(out brokenRules) && Validator.IsUnique(man))
                {
                    man.Insert();
                    product.Manufacturer = man;
                    product.FK_ManufacturerId = man.Id;
                    manufacturers.Add(man);
                }
            }

            if (product.Validate(out brokenRules))
            {
                isValid = true;

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

            if (!isValid) lstError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}
