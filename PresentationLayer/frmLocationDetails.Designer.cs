namespace PresentationLayer
{
    partial class frmLocationDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstError = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbStreet = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAreaCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHouseNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLocation = new System.Windows.Forms.TabPage();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnCancelLists = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemoveUsed = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddAvailable = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvUsed = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSaveLists = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLocation.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsed)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cmbCity);
            this.panel1.Controls.Add(this.cmbStreet);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAreaCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtHouseNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 260);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstError);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(453, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 248);
            this.panel2.TabIndex = 21;
            // 
            // lstError
            // 
            this.lstError.FormattingEnabled = true;
            this.lstError.HorizontalScrollbar = true;
            this.lstError.Location = new System.Drawing.Point(15, 32);
            this.lstError.Name = "lstError";
            this.lstError.Size = new System.Drawing.Size(276, 199);
            this.lstError.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Error Box";
            // 
            // cmbCity
            // 
            this.cmbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(17, 201);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(202, 21);
            this.cmbCity.TabIndex = 11;
            this.cmbCity.SelectionChangeCommitted += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            this.cmbCity.TextChanged += new System.EventHandler(this.cmbCity_TextChanged);
            // 
            // cmbStreet
            // 
            this.cmbStreet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbStreet.FormattingEnabled = true;
            this.cmbStreet.Location = new System.Drawing.Point(17, 111);
            this.cmbStreet.Name = "cmbStreet";
            this.cmbStreet.Size = new System.Drawing.Size(202, 21);
            this.cmbStreet.TabIndex = 10;
            this.cmbStreet.SelectionChangeCommitted += new System.EventHandler(this.cmbStreet_SelectedIndexChanged);
            this.cmbStreet.TextChanged += new System.EventHandler(this.cmbStreet_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "City";
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(17, 156);
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(202, 20);
            this.txtAreaCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Area Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Street";
            // 
            // txtHouseNumber
            // 
            this.txtHouseNumber.Location = new System.Drawing.Point(17, 66);
            this.txtHouseNumber.Name = "txtHouseNumber";
            this.txtHouseNumber.Size = new System.Drawing.Size(202, 20);
            this.txtHouseNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "House Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location Details";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Blue;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(23, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(254, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Blue;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(112, 283);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Blue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(202, 283);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Blue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(23, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLocation);
            this.tabControl1.Controls.Add(this.tabProducts);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1134, 519);
            this.tabControl1.TabIndex = 23;
            // 
            // tabLocation
            // 
            this.tabLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabLocation.Controls.Add(this.panel1);
            this.tabLocation.Controls.Add(this.btnSave);
            this.tabLocation.Controls.Add(this.btnCancel);
            this.tabLocation.Controls.Add(this.btnDelete);
            this.tabLocation.Controls.Add(this.btnEdit);
            this.tabLocation.Location = new System.Drawing.Point(4, 22);
            this.tabLocation.Name = "tabLocation";
            this.tabLocation.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocation.Size = new System.Drawing.Size(1126, 493);
            this.tabLocation.TabIndex = 0;
            this.tabLocation.Text = "Location";
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabProducts.Controls.Add(this.btnManageProducts);
            this.tabProducts.Controls.Add(this.btnCancelLists);
            this.tabProducts.Controls.Add(this.panel3);
            this.tabProducts.Controls.Add(this.btnSaveLists);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(1126, 493);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Text = "Products";
            this.tabProducts.Enter += new System.EventHandler(this.tabProducts_Enter);
            // 
            // btnManageProducts
            // 
            this.btnManageProducts.BackColor = System.Drawing.Color.Blue;
            this.btnManageProducts.FlatAppearance.BorderSize = 0;
            this.btnManageProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageProducts.ForeColor = System.Drawing.Color.White;
            this.btnManageProducts.Location = new System.Drawing.Point(21, 419);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(254, 23);
            this.btnManageProducts.TabIndex = 39;
            this.btnManageProducts.Text = "Manage Products";
            this.btnManageProducts.UseVisualStyleBackColor = false;
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);
            // 
            // btnCancelLists
            // 
            this.btnCancelLists.BackColor = System.Drawing.Color.Blue;
            this.btnCancelLists.FlatAppearance.BorderSize = 0;
            this.btnCancelLists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelLists.ForeColor = System.Drawing.Color.White;
            this.btnCancelLists.Location = new System.Drawing.Point(150, 390);
            this.btnCancelLists.Name = "btnCancelLists";
            this.btnCancelLists.Size = new System.Drawing.Size(125, 23);
            this.btnCancelLists.TabIndex = 38;
            this.btnCancelLists.Text = "Cancel";
            this.btnCancelLists.UseVisualStyleBackColor = false;
            this.btnCancelLists.Click += new System.EventHandler(this.btnCancelLists_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRemoveUsed);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnAddAvailable);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Location = new System.Drawing.Point(8, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1088, 378);
            this.panel3.TabIndex = 36;
            // 
            // btnRemoveUsed
            // 
            this.btnRemoveUsed.BackColor = System.Drawing.Color.Blue;
            this.btnRemoveUsed.FlatAppearance.BorderSize = 0;
            this.btnRemoveUsed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUsed.ForeColor = System.Drawing.Color.White;
            this.btnRemoveUsed.Location = new System.Drawing.Point(503, 174);
            this.btnRemoveUsed.Name = "btnRemoveUsed";
            this.btnRemoveUsed.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveUsed.TabIndex = 31;
            this.btnRemoveUsed.Text = "Remove ->";
            this.btnRemoveUsed.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(13, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Select an available location and click \"Add\" ";
            // 
            // btnAddAvailable
            // 
            this.btnAddAvailable.BackColor = System.Drawing.Color.Blue;
            this.btnAddAvailable.FlatAppearance.BorderSize = 0;
            this.btnAddAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAvailable.ForeColor = System.Drawing.Color.White;
            this.btnAddAvailable.Location = new System.Drawing.Point(503, 134);
            this.btnAddAvailable.Name = "btnAddAvailable";
            this.btnAddAvailable.Size = new System.Drawing.Size(75, 23);
            this.btnAddAvailable.TabIndex = 26;
            this.btnAddAvailable.Text = "<- Add";
            this.btnAddAvailable.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.dgvAvailable);
            this.panel4.Location = new System.Drawing.Point(588, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 306);
            this.panel4.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(11, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 17);
            this.label14.TabIndex = 24;
            this.label14.Text = "Available Products";
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.Location = new System.Drawing.Point(14, 30);
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.Size = new System.Drawing.Size(424, 180);
            this.dgvAvailable.TabIndex = 23;
            this.dgvAvailable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsed_CellClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.dgvUsed);
            this.panel5.Location = new System.Drawing.Point(13, 64);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 306);
            this.panel5.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(11, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "Used Products";
            // 
            // dgvUsed
            // 
            this.dgvUsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsed.Location = new System.Drawing.Point(14, 30);
            this.dgvUsed.Name = "dgvUsed";
            this.dgvUsed.Size = new System.Drawing.Size(424, 180);
            this.dgvUsed.TabIndex = 23;
            this.dgvUsed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsed_CellClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(9, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(175, 20);
            this.label16.TabIndex = 23;
            this.label16.Text = "Products at Location";
            // 
            // btnSaveLists
            // 
            this.btnSaveLists.BackColor = System.Drawing.Color.Blue;
            this.btnSaveLists.FlatAppearance.BorderSize = 0;
            this.btnSaveLists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLists.ForeColor = System.Drawing.Color.White;
            this.btnSaveLists.Location = new System.Drawing.Point(21, 390);
            this.btnSaveLists.Name = "btnSaveLists";
            this.btnSaveLists.Size = new System.Drawing.Size(123, 23);
            this.btnSaveLists.TabIndex = 37;
            this.btnSaveLists.Text = "Save";
            this.btnSaveLists.UseVisualStyleBackColor = false;
            this.btnSaveLists.Click += new System.EventHandler(this.btnSaveLists_Click);
            // 
            // frmLocationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 515);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocationDetails";
            this.Text = "Location";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabLocation.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAreaCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHouseNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbStreet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLocation;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.Button btnCancelLists;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRemoveUsed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddAvailable;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvAvailable;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvUsed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSaveLists;
        private System.Windows.Forms.Button btnManageProducts;
    }
}