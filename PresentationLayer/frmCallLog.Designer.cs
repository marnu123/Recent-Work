namespace PresentationLayer
{
    partial class frmCallLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCallLog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClientsEmpty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCalls = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalls)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblClientsEmpty);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvCalls);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 6;
            // 
            // lblClientsEmpty
            // 
            this.lblClientsEmpty.AutoSize = true;
            this.lblClientsEmpty.Location = new System.Drawing.Point(338, 243);
            this.lblClientsEmpty.Name = "lblClientsEmpty";
            this.lblClientsEmpty.Size = new System.Drawing.Size(92, 13);
            this.lblClientsEmpty.TabIndex = 22;
            this.lblClientsEmpty.Text = "No Results Found";
            this.lblClientsEmpty.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Click on a row\'s \"View\" button to edit/update its details";
            // 
            // dgvCalls
            // 
            this.dgvCalls.AllowUserToAddRows = false;
            this.dgvCalls.AllowUserToDeleteRows = false;
            this.dgvCalls.AllowUserToOrderColumns = true;
            this.dgvCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalls.Location = new System.Drawing.Point(17, 65);
            this.dgvCalls.Name = "dgvCalls";
            this.dgvCalls.Size = new System.Drawing.Size(742, 340);
            this.dgvCalls.TabIndex = 2;
            this.dgvCalls.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalls_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Call Log";
            // 
            // frmCallLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCallLog";
            this.Text = "frmCallLog";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClientsEmpty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCalls;
        private System.Windows.Forms.Label label1;
    }
}