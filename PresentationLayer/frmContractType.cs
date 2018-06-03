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

namespace PresentationLayer
{
    public partial class frmContractType : Form
    {
        List<ContractType> contractTypes;
        public frmContractType()
        {
            InitializeComponent();
            contractTypes = ContractType.Select();
            dgvContractTypes.DataSource = contractTypes;
        }

        private void dgvContractTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView temp = sender as DataGridView;

            if (e.RowIndex > -1)
            {
                temp.ClearSelection();
                temp.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvContractTypes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContractTypes.SelectedRows.Count == 1)
            {
                char id = (char) dgvContractTypes.SelectedRows[0].Cells["Id"].Value;

                var query = from c
                            in contractTypes
                            where c.Id == id
                            select c;
                ContractType selected = query.ToList().First();

                frmContractTypeDetails frm = new frmContractTypeDetails(selected, contractTypes.Select(c => c.Id).ToList());
                Utils.ShowForm(this, frm, dgvContractTypes, refreshScreen);
            }
        }

        private void refreshScreen()
        {
            contractTypes = ContractType.Select();
            dgvContractTypes.DataSource = contractTypes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContractType temp = new ContractType(' ', "");
            frmContractTypeDetails frm = new frmContractTypeDetails(temp, contractTypes.Select(c => c.Id).ToList(), true);
            Utils.ShowForm(this, frm, dgvContractTypes, refreshScreen);
        }
    }
}
