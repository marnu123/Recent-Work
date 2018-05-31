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

namespace PresentationLayer
{
    public partial class frmContractTypeDetails : Form
    {
        List<ServiceLevel> serviceLevels;
        ContractType contractType;
        ContractType oldCopy;
        BindingSource bindedContractType;
        bool insert = false, edit = false;

        public frmContractTypeDetails(ContractType contractType, bool insert = false)
        {
            InitializeComponent();
            initialise(contractType, insert);
        }

        private void initialise(ContractType contractType, bool insert)
        {
            this.contractType = contractType;
            contractType.DeepCopyInto(ref oldCopy);
            bindedContractType = new BindingSource();
            bindedContractType.DataSource = contractType;
            this.insert = insert;
            setFieldsEnable(insert);
            serviceLevels = ServiceLevel.Select();
            bindFields();
            cmbID.SelectedIndex = -1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit = true;
            setFieldsEnable(true);
        }

        private void bindFields()
        {
            cmbID.DataBindings.Clear();
            cmbID.DataBindings.Add(new Binding("SelectedItem", bindedContractType, "Id"));
            cmbID.DataSource = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

            txtTitle.DataBindings.Clear();
            txtTitle.DataBindings.Add(new Binding("Text", bindedContractType, "Title"));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            oldCopy.DeepCopyInto(ref contractType);
            bindedContractType.DataSource = contractType;
            bindedContractType.ResetBindings(true);
            edit = insert = false;
            setFieldsEnable(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this contract type?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg == DialogResult.Yes)
            {
                contractType.Delete();
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IEnumerable<string> brokenRules;
            string msg = "Invalid input. Please check the error box";
            bool isValid = contractType.Validate(out brokenRules);

            if (isValid)
            {
                if (insert)
                {
                    contractType.Insert();
                    msg = "Contract Type inserted";
                }
                else
                {
                    contractType.Update();
                    msg = "Contract Type updated";
                }

                insert = edit = false;
                setFieldsEnable(false);
            }

            if (!isValid) lstError.DataSource = brokenRules.ToList();
            MessageBox.Show(msg, "Modification Status", MessageBoxButtons.OK, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void cmbID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            contractType.Id = Convert.ToChar(cmbID.SelectedItem.ToString().Substring(0,1));
        }

        List<ProductCategory> available;

        private void tabCategories_Enter(object sender, EventArgs e)
        {
            available = ProductCategory.Select().Except(contractType.ProductCategories).ToList();
            dgvAvailable.DataSource = new BindingList<ProductCategory>(available);
            dgvUsed.DataSource = new BindingList<ProductCategory>(contractType.ProductCategories);
            btnAddToUsed.Enabled = false;
            btnRemoveUsed.Enabled = false;
        }

        private void dgvCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView temp = sender as DataGridView;

            if (e.RowIndex > -1)
            {
                temp.ClearSelection();
                temp.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvAvailable_SelectionChanged(object sender, EventArgs e)
        {
            btnAddToUsed.Enabled = true;
        }

        private void addFromTo<T>(DataGridView from, DataGridView to, List<T> fromList, List<T> toList)
        {
            if (from.SelectedRows.Count > 0)
            {
                T temp;

                foreach (DataGridViewRow dr in from.SelectedRows)
                {
                    temp = (T)dr.DataBoundItem;
                    toList.Add(temp);
                    fromList.Remove(temp);

                    bindList(from, fromList);
                    bindList(to, toList);
                }
            }
        }

        private void bindList<T>(DataGridView dgv, List<T> items)
        {
            dgv.DataSource = new BindingList<T>(items);
        }

        private void btnAddToUsed_Click(object sender, EventArgs e)
        {
            addFromTo(dgvAvailable, dgvUsed, available, contractType.ProductCategories);
        }

        private void btnRemoveUsed_Click(object sender, EventArgs e)
        {
            addFromTo(dgvUsed, dgvAvailable, contractType.ProductCategories, available);
        }

        private void btnSaveUsed_Click(object sender, EventArgs e)
        {
            List<ProductCategory> newItems = contractType.ProductCategories.Except(oldCopy.ProductCategories).ToList();
            List<ProductCategory> deletedItems = oldCopy.ProductCategories.Except(contractType.ProductCategories).ToList();
            
            ComplexQueryHelper.UpdateProductCategoriesForContractType(contractType, newItems, deletedItems);
            MessageBox.Show("Product Categories updated");
        }

        private void dgvUsed_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count > 0) btnRemoveUsed.Enabled = true;
        }

        private void DgvAvailable_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count > 0) btnAddToUsed.Enabled = true;
        }

        private void setFieldsEnable(bool state)
        {
            txtTitle.Enabled = state;
            cmbID.Enabled = state;
            btnSave.Enabled = state;
        }

    }
}
