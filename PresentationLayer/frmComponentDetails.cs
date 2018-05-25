using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comp = BusinessLayer.Classes;
using BusinessLayer;
using BusinessLayer.Validators;
using BusinessLayer.Classes;
using BusinessLayer.Helpers;

namespace PresentationLayer
{
    public partial class frmComponentDetails : Form
    {
        Comp.Component component;
        Comp.Component oldCopy;
        bool insert = false, edit = false;
        List<Configuration> availableConfigurations;
        Product product;

        public frmComponentDetails(ref Comp.Component component, bool insert = false)
        {
            initialise(component, insert);
        }

        public frmComponentDetails(ref Product product, ref Comp.Component component, bool insert = false)
        {
            this.product = product;
            initialise(component, insert);
        }

        private void initialise(Comp.Component component, bool insert)
        {
            InitializeComponent();
            txtPrice.Minimum = decimal.MinValue;
            txtPrice.Maximum = decimal.MaxValue;
            this.insert = insert;
            this.component = component;
            component.DeepCopyInto(ref oldCopy);
            bindFieldsComponent(component);
        }

        private void bindFieldsComponent(Comp.Component component)
        {
            txtDescription.DataBindings.Add(new Binding("Text", component, "Description"));
            txtPrice.DataBindings.Add(new Binding("Value", component, "Price"));
            txtTitle.DataBindings.Add(new Binding("Text", component, "Title"));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (insert)
            {
                MessageBox.Show("A component has to be inserted before its configuration can be changed");
                tcComponent.SelectedIndex = 0;
            }
        }

        private void tabComponent_Enter(object sender, EventArgs e)
        {
            dgvCurrentConfigurations.DataSource = component.Configurations;
            dgvCurrentConfigurations.AutoGenerateColumns = true;
            availableConfigurations = getAvailableConfigurations(component.Configurations, Configuration.Select());
            dgvAvailableConfigurations.DataSource = availableConfigurations;
            dgvAvailableConfigurations.AutoGenerateColumns = true;
        }

        private List<Configuration> getAvailableConfigurations(List<Configuration> existingItems, List<Configuration> newItems)
        {
            foreach (Configuration config in
                newItems.Where((item) => existingItems.Contains(item)))
            {
                newItems.Remove(config);
            }

            return newItems;
        }

        private void btnComponentCancel_Click(object sender, EventArgs e)
        {
            oldCopy.DeepCopyInto(ref component);
        }

        private void btnComponentDelete_Click(object sender, EventArgs e)
        {

        }

        private void setFieldEnable(bool state)
        {
            txtDescription.Enabled = state;
            txtPrice.Enabled = state;
            txtTitle.Enabled = state;
        }

        private void btnComponentSave_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            btnViewConfiguration.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dgvAvailableConfigurations.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dgvAvailableConfigurations.SelectedRows)
                {
                    dgvCurrentConfigurations.Rows.Add(dr);
                    dgvAvailableConfigurations.Rows.Remove(dr);
                }
            }

        }

        private void btnAddConfigToDB_Click(object sender, EventArgs e)
        {
        }

        private void btnComponentDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void btnInsertConfiguration_Click(object sender, EventArgs e)
        {
            Configuration temp = new Configuration("", "", "");
            frmConfigurationDetails frm = new frmConfigurationDetails(ref temp, true);
            Utils.ShowForm(this, frm, dgvAvailableConfigurations, () =>
            {
                availableConfigurations = getAvailableConfigurations(component.Configurations, Configuration.Select());
            });
        }

        private void btnViewConfiguration_Click(object sender, EventArgs e)
        {
            if (dgvAvailableConfigurations.SelectedRows.Count == 1)
            {
                DataGridViewRow dr = dgvAvailableConfigurations.SelectedRows[0];
                var q = from config
                        in availableConfigurations
                        where config.PK_ConfigurationID == dr.Cells["PK_ConfigurationID"].Value.ToString()
                        select config;
                List<Configuration> queryResult = q.ToList();
                Configuration temp = queryResult.Count == 1 ? queryResult[0] : new Configuration();

                frmConfigurationDetails frm = new frmConfigurationDetails(ref temp);
                Utils.ShowForm(this, frm, dgvAvailableConfigurations, () =>
                {
                    //availableConfigurations = getAvailableConfigurations(component.Configurations, Configuration.Select());
                });
            }
        }

        private void dgvAvailableConfigurations_SelectionChanged(object sender, EventArgs e)
        {
            btnViewConfiguration.Enabled = (sender as DataGridView).SelectedRows.Count == 1;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            var diff = component.Configurations.Except(oldCopy.Configurations);
            ComplexQueryHelper.AddConfigurationsForComponent(component, diff.ToList());
            MessageBox.Show("Component configuration updated", "Modification status");
        }

        private void btnComponentEdit_Click(object sender, EventArgs e)
        {
            setFieldEnable(false);
            edit = false;
        }
    }
}
