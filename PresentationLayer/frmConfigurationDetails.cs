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
    public partial class frmConfigurationDetails : Form
    {
        Configuration configuration;
        Configuration oldCopy;
        bool insert = false, edit = false;

        public frmConfigurationDetails(ref Configuration configuration, bool insert = false)
        {
            InitializeComponent();
            CenterToScreen();
            this.configuration = configuration;
            configuration.DeepCopyInto(ref oldCopy);
            bindFields(this.configuration);
            this.insert = insert;
        }

        private void bindFields(Configuration configuration)
        {
            txtConfigID.DataBindings.Add(new Binding("Text", configuration, "PK_ConfigurationID"));
            txtConfigTitle.DataBindings.Add(new Binding("Text", configuration, "Title"));
            txtConfigValue.DataBindings.Add(new Binding("Text", configuration, "Value"));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to delete this configuration?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg == DialogResult.Yes)
            {
                configuration.Delete();
                Close();
            }
        }

        private void setEnableFields(bool state)
        {
            txtConfigID.Enabled = state;
            txtConfigTitle.Enabled = state;
            txtConfigValue.Enabled = state;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            setEnableFields(true);
            edit = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            edit = false;
            setEnableFields(false);
            oldCopy.DeepCopyInto(ref configuration);
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            string msg = "Invalid configuration.  Check the error box";
            IEnumerable<string> brokenRules;
            bool isValid = false;

            if (configuration.Validate(out brokenRules))
            {
                isValid = true;
                if (insert)
                {
                    configuration.Insert();
                    msg = "Configuration inserted";
                }
                else
                {
                    configuration.Update();
                    msg = "Configuration updated";
                }
            }

            lstError.DataSource = brokenRules;
            MessageBox.Show(msg, "Modification status", MessageBoxButtons.OKCancel, isValid ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
    }
}
