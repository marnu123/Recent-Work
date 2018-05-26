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
using Comp = BusinessLayer.Classes.Component;
using BusinessLayer.Helpers;

namespace PresentationLayer
{
    public partial class frmComponent : Form
    {
        List<Comp> componentList;

        public frmComponent()
        {
            componentList = Comp.Select();
            initialise();
        }

        private void initialise()
        {
            InitializeComponent();
            dgvComponents.AutoGenerateColumns = true;
            dgvComponents.DataSource = new BindingList<Comp>(componentList);
        }

        public frmComponent(List<Comp> componentList)
        {
            this.componentList = componentList;
            initialise();
        }

        private void dgvComponents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string id = dgvComponents.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var q = from c
                        in componentList
                        where c.Id == id
                        select c;

                List<Comp> tempList = q.ToList();
                Comp temp = tempList.Count == 1 ? tempList[0] : new Comp("", "", "", 0);
                frmComponentDetails frm = new frmComponentDetails(ref temp);
                Utils.ShowForm(this, frm, dgvComponents, () =>
                {
                    componentList = Comp.Select();
                    dgvComponents.DataSource = componentList;
                    showNoRows();
                });
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Comp temp = new Comp("", "", "", 0);
            frmComponentDetails frm;
            frm = new frmComponentDetails(ref temp, true);

            Utils.ShowForm(this, frm, dgvComponents, () =>
            {
                componentList = Comp.Select();
                dgvComponents.DataSource = componentList;
                showNoRows();
            });
        }

        private void showNoRows()
        {
            lblEmpty.Visible = dgvComponents.Rows.Count == 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
