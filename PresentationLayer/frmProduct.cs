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

namespace PresentationLayer
{
    public partial class frmProduct : Form
    {
        Location location;
        List<Product> products;
        AggregatedPropertyBindingList<Product> bindingList;

        public frmProduct(ref Location location, ref List<Product> products)
        {
            InitializeComponent();
            CenterToScreen();
            this.products = products;
            this.location = location;
            bindFields(products);
        }

        public frmProduct()
        {
            InitializeComponent();
            CenterToScreen();
            products = Product.Select();
            bindFields(products);
        }

        private void bindFields(List<Product> products)
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Add("Id", "Id");
            dgvProducts.Columns["Id"].DataPropertyName = "Id";
            //dgvLocation.Columns["Id"].DataPropertyName = "Street->Name";
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns["Name"].DataPropertyName = "Name";

            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns["Price"].DataPropertyName = "Price";

            dgvProducts.Columns.Add("DateAdded", "Date Added");
            dgvProducts.Columns["DateAdded"].DataPropertyName = "DateAdded";

            dgvProducts.Columns.Add("ProductCategory", "Category");
            dgvProducts.Columns["ProductCategory"].DataPropertyName = "ProductCategory->Title";

            dgvProducts.Columns.Add("Manufacturer", "Manufacturer");
            dgvProducts.Columns["Manufacturer"].DataPropertyName = "Manufacturer->Name";

            dgvProducts.Columns.Add("Model", "Model");
            dgvProducts.Columns["Model"].DataPropertyName = "Model";

            bindingList = new AggregatedPropertyBindingList<Product>(products);
            dgvProducts.DataSource = bindingList;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ensure that the click was not on the title cells
            if (e.RowIndex > -1)
            {
                string id = (sender as DataGridView).Rows[e.RowIndex].Cells["Id"].Value.ToString();

                Product clickedItem = products.Find(p => p.Id == id);
                if (clickedItem != null)
                {
                    frmProductDetails frm = new frmProductDetails(ref location, ref clickedItem);
                    Utils.ShowForm(this, frm, dgvProducts, () =>
                    {
                        if (location == null)
                            products = Product.Select();
                        else
                            products = ComplexQueryHelper.GetProductsForLocation(location);
                        dgvProducts.DataSource = products;
                    });
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchProducts("%" + txtSearchterm.Text + "%");
        }

        private void searchProducts(string searchterm)
        {
            if (searchterm != "") products = Product.Select(p => p.Name != searchterm);
            else products = Product.Select();
            dgvProducts.DataSource = new AggregatedPropertyBindingList<Product>(products);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmProductDetails frm = new frmProductDetails(new Product("", "", "", 0, DateTime.Now, ""), true);
            Utils.ShowForm(this, frm, dgvProducts, () =>
            {
                searchProducts("%" + txtSearchterm.Text + "%");
            });
        }
    }
}
