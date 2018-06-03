namespace PresentationLayer
{
    partial class frmTaskDetails
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlLocation = new System.Windows.Forms.Panel();
            this.dgvLocation = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbTaskStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.cmbTaskType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstError = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.pnlLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.cmbTaskStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.cmbTaskType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 728);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlClient);
            this.flowLayoutPanel1.Controls.Add(this.pnlLocation);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 317);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 408);
            this.flowLayoutPanel1.TabIndex = 40;
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.lstClients);
            this.pnlClient.Controls.Add(this.label9);
            this.pnlClient.Location = new System.Drawing.Point(3, 3);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(275, 228);
            this.pnlClient.TabIndex = 25;
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.Location = new System.Drawing.Point(11, 31);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(243, 186);
            this.lstClients.TabIndex = 23;
            this.lstClients.SelectedValueChanged += new System.EventHandler(this.lstClients_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Select a Client";
            // 
            // pnlLocation
            // 
            this.pnlLocation.Controls.Add(this.dgvLocation);
            this.pnlLocation.Controls.Add(this.label10);
            this.pnlLocation.Location = new System.Drawing.Point(284, 3);
            this.pnlLocation.Name = "pnlLocation";
            this.pnlLocation.Size = new System.Drawing.Size(489, 228);
            this.pnlLocation.TabIndex = 27;
            // 
            // dgvLocation
            // 
            this.dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocation.Location = new System.Drawing.Point(11, 31);
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.Size = new System.Drawing.Size(464, 186);
            this.dgvLocation.TabIndex = 23;
            this.dgvLocation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocation_CellClick);
            this.dgvLocation.SelectionChanged += new System.EventHandler(this.dgvLocation_SelectionChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Select a Location for the Client";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(3, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 100);
            this.panel2.TabIndex = 27;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(14, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(254, 23);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(103, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 40;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(193, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbTaskStatus
            // 
            this.cmbTaskStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskStatus.FormattingEnabled = true;
            this.cmbTaskStatus.Location = new System.Drawing.Point(17, 166);
            this.cmbTaskStatus.Name = "cmbTaskStatus";
            this.cmbTaskStatus.Size = new System.Drawing.Size(157, 21);
            this.cmbTaskStatus.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Task Status";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(17, 215);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(428, 96);
            this.txtDescription.TabIndex = 17;
            this.txtDescription.Text = "";
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Location = new System.Drawing.Point(17, 114);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(157, 21);
            this.cmbTaskType.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Task Type";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(17, 66);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(157, 20);
            this.txtID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task Details";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lstError);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(878, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 250);
            this.panel3.TabIndex = 21;
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
            // frmTaskDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1208, 752);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmTaskDetails";
            this.Text = "frmTaskDetails";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            this.pnlLocation.ResumeLayout(false);
            this.pnlLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbTaskType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbTaskStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlLocation;
        private System.Windows.Forms.DataGridView dgvLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstError;
        private System.Windows.Forms.Label label6;
    }
}