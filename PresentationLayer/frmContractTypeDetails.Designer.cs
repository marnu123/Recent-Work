namespace PresentationLayer
{
    partial class frmContractTypeDetails
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbID = new System.Windows.Forms.ComboBox();
            this.ID = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstError = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContractType = new System.Windows.Forms.TabPage();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.btnCancelUsed = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemoveUsed = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddToUsed = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvUsed = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveUsed = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabContractType.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsed)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbID);
            this.panel1.Controls.Add(this.ID);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 250);
            this.panel1.TabIndex = 3;
            // 
            // cmbID
            // 
            this.cmbID.FormattingEnabled = true;
            this.cmbID.Location = new System.Drawing.Point(17, 63);
            this.cmbID.Name = "cmbID";
            this.cmbID.Size = new System.Drawing.Size(157, 21);
            this.cmbID.TabIndex = 11;
            this.cmbID.SelectionChangeCommitted += new System.EventHandler(this.cmbID_SelectionChangeCommitted);
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(14, 47);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(18, 13);
            this.ID.TabIndex = 10;
            this.ID.Text = "ID";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(17, 106);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(157, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contract Type Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstError);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(523, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 250);
            this.panel2.TabIndex = 21;
            // 
            // lstError
            // 
            this.lstError.FormattingEnabled = true;
            this.lstError.Location = new System.Drawing.Point(15, 32);
            this.lstError.Name = "lstError";
            this.lstError.Size = new System.Drawing.Size(210, 199);
            this.lstError.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Error Box";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(5, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(5, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(254, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(184, 292);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(94, 292);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabContractType);
            this.tabControl1.Controls.Add(this.tabCategories);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1180, 528);
            this.tabControl1.TabIndex = 26;
            // 
            // tabContractType
            // 
            this.tabContractType.Controls.Add(this.panel1);
            this.tabContractType.Controls.Add(this.btnSave);
            this.tabContractType.Controls.Add(this.panel2);
            this.tabContractType.Controls.Add(this.btnCancel);
            this.tabContractType.Controls.Add(this.btnEdit);
            this.tabContractType.Controls.Add(this.btnDelete);
            this.tabContractType.Location = new System.Drawing.Point(4, 22);
            this.tabContractType.Name = "tabContractType";
            this.tabContractType.Padding = new System.Windows.Forms.Padding(3);
            this.tabContractType.Size = new System.Drawing.Size(1172, 502);
            this.tabContractType.TabIndex = 0;
            this.tabContractType.Text = "Contract Type";
            this.tabContractType.UseVisualStyleBackColor = true;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.btnCancelUsed);
            this.tabCategories.Controls.Add(this.panel3);
            this.tabCategories.Controls.Add(this.btnSaveUsed);
            this.tabCategories.Location = new System.Drawing.Point(4, 22);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(1172, 502);
            this.tabCategories.TabIndex = 1;
            this.tabCategories.Text = "Product Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            this.tabCategories.Enter += new System.EventHandler(this.tabCategories_Enter);
            // 
            // btnCancelUsed
            // 
            this.btnCancelUsed.Location = new System.Drawing.Point(178, 404);
            this.btnCancelUsed.Name = "btnCancelUsed";
            this.btnCancelUsed.Size = new System.Drawing.Size(124, 23);
            this.btnCancelUsed.TabIndex = 38;
            this.btnCancelUsed.Text = "Cancel";
            this.btnCancelUsed.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRemoveUsed);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.btnAddToUsed);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1088, 378);
            this.panel3.TabIndex = 36;
            // 
            // btnRemoveUsed
            // 
            this.btnRemoveUsed.Location = new System.Drawing.Point(503, 174);
            this.btnRemoveUsed.Name = "btnRemoveUsed";
            this.btnRemoveUsed.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveUsed.TabIndex = 31;
            this.btnRemoveUsed.Text = "Remove ->";
            this.btnRemoveUsed.UseVisualStyleBackColor = true;
            this.btnRemoveUsed.Click += new System.EventHandler(this.btnRemoveUsed_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(234, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Select an available component and click \"Add\" ";
            // 
            // btnAddToUsed
            // 
            this.btnAddToUsed.Location = new System.Drawing.Point(503, 134);
            this.btnAddToUsed.Name = "btnAddToUsed";
            this.btnAddToUsed.Size = new System.Drawing.Size(75, 23);
            this.btnAddToUsed.TabIndex = 26;
            this.btnAddToUsed.Text = "<- Add";
            this.btnAddToUsed.UseVisualStyleBackColor = true;
            this.btnAddToUsed.Click += new System.EventHandler(this.btnAddToUsed_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.dgvAvailable);
            this.panel4.Location = new System.Drawing.Point(588, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 306);
            this.panel4.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Available Categories";
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.AllowUserToAddRows = false;
            this.dgvAvailable.AllowUserToDeleteRows = false;
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.Location = new System.Drawing.Point(14, 30);
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.ReadOnly = true;
            this.dgvAvailable.Size = new System.Drawing.Size(424, 180);
            this.dgvAvailable.TabIndex = 23;
            this.dgvAvailable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellClicked);
            this.dgvAvailable.SelectionChanged += new System.EventHandler(this.dgvAvailable_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.dgvUsed);
            this.panel5.Location = new System.Drawing.Point(13, 64);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 306);
            this.panel5.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Included Product Categories";
            // 
            // dgvUsed
            // 
            this.dgvUsed.AllowUserToAddRows = false;
            this.dgvUsed.AllowUserToDeleteRows = false;
            this.dgvUsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsed.Location = new System.Drawing.Point(14, 30);
            this.dgvUsed.Name = "dgvUsed";
            this.dgvUsed.ReadOnly = true;
            this.dgvUsed.Size = new System.Drawing.Size(424, 180);
            this.dgvUsed.TabIndex = 23;
            this.dgvUsed.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellClicked);
            this.dgvUsed.SelectionChanged += new System.EventHandler(this.dgvUsed_SelectionChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(237, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Included Product Categories";
            // 
            // btnSaveUsed
            // 
            this.btnSaveUsed.Location = new System.Drawing.Point(48, 404);
            this.btnSaveUsed.Name = "btnSaveUsed";
            this.btnSaveUsed.Size = new System.Drawing.Size(124, 23);
            this.btnSaveUsed.TabIndex = 37;
            this.btnSaveUsed.Text = "Save";
            this.btnSaveUsed.UseVisualStyleBackColor = true;
            this.btnSaveUsed.Click += new System.EventHandler(this.btnSaveUsed_Click);
            // 
            // frmContractTypeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 525);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmContractTypeDetails";
            this.Text = "ContractTypeDetails";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabContractType.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
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
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabContractType;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.Button btnCancelUsed;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRemoveUsed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddToUsed;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvAvailable;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvUsed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSaveUsed;
    }
}