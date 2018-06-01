namespace PresentationLayer
{
    partial class frmPerson
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClientsEmpty = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Employees = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEmployeeEmpty = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchterm = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmployeeSearch = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabClients.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.Employees.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabClients);
            this.tabControl1.Controls.Add(this.Employees);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 453);
            this.tabControl1.TabIndex = 22;
            // 
            // tabClients
            // 
            this.tabClients.Controls.Add(this.panel1);
            this.tabClients.Location = new System.Drawing.Point(4, 22);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(793, 427);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Clients";
            this.tabClients.UseVisualStyleBackColor = true;
            this.tabClients.FontChanged += new System.EventHandler(this.tabClients_FontChanged);
            this.tabClients.Enter += new System.EventHandler(this.tabClients_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblClientsEmpty);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvClients);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 365);
            this.panel1.TabIndex = 5;
            // 
            // lblClientsEmpty
            // 
            this.lblClientsEmpty.AutoSize = true;
            this.lblClientsEmpty.Location = new System.Drawing.Point(335, 189);
            this.lblClientsEmpty.Name = "lblClientsEmpty";
            this.lblClientsEmpty.Size = new System.Drawing.Size(92, 13);
            this.lblClientsEmpty.TabIndex = 22;
            this.lblClientsEmpty.Text = "No Results Found";
            this.lblClientsEmpty.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Add Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Click on a row\'s \"View\" button to edit/update its details";
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AllowUserToOrderColumns = true;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(17, 115);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.Size = new System.Drawing.Size(742, 172);
            this.dgvClients.TabIndex = 2;
            this.dgvClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clients";
            // 
            // Employees
            // 
            this.Employees.Controls.Add(this.panel2);
            this.Employees.Location = new System.Drawing.Point(4, 22);
            this.Employees.Name = "Employees";
            this.Employees.Padding = new System.Windows.Forms.Padding(3);
            this.Employees.Size = new System.Drawing.Size(793, 427);
            this.Employees.TabIndex = 1;
            this.Employees.Text = "Employees";
            this.Employees.UseVisualStyleBackColor = true;
            this.Employees.Enter += new System.EventHandler(this.Employees_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lblEmployeeEmpty);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnAddEmployee);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvEmployees);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 380);
            this.panel2.TabIndex = 6;
            // 
            // lblEmployeeEmpty
            // 
            this.lblEmployeeEmpty.AutoSize = true;
            this.lblEmployeeEmpty.Location = new System.Drawing.Point(347, 205);
            this.lblEmployeeEmpty.Name = "lblEmployeeEmpty";
            this.lblEmployeeEmpty.Size = new System.Drawing.Size(92, 13);
            this.lblEmployeeEmpty.TabIndex = 21;
            this.lblEmployeeEmpty.Text = "No Results Found";
            this.lblEmployeeEmpty.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(125, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(17, 318);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(102, 23);
            this.btnAddEmployee.TabIndex = 19;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Click on a row\'s \"View\" button to edit/update its details";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToOrderColumns = true;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(17, 131);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(742, 181);
            this.dgvEmployees.TabIndex = 2;
            this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Employees";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtSearchterm);
            this.panel3.Location = new System.Drawing.Point(17, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(464, 59);
            this.panel3.TabIndex = 26;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(310, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 23);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Search by Email";
            // 
            // txtSearchterm
            // 
            this.txtSearchterm.Location = new System.Drawing.Point(110, 17);
            this.txtSearchterm.Name = "txtSearchterm";
            this.txtSearchterm.Size = new System.Drawing.Size(184, 20);
            this.txtSearchterm.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSearchEmployee);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtEmployeeSearch);
            this.panel4.Location = new System.Drawing.Point(17, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(464, 59);
            this.panel4.TabIndex = 27;
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.Location = new System.Drawing.Point(310, 15);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(102, 23);
            this.btnSearchEmployee.TabIndex = 28;
            this.btnSearchEmployee.Text = "Search";
            this.btnSearchEmployee.UseVisualStyleBackColor = true;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Search by Email";
            // 
            // txtEmployeeSearch
            // 
            this.txtEmployeeSearch.Location = new System.Drawing.Point(110, 17);
            this.txtEmployeeSearch.Name = "txtEmployeeSearch";
            this.txtEmployeeSearch.Size = new System.Drawing.Size(184, 20);
            this.txtEmployeeSearch.TabIndex = 26;
            // 
            // frmPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmPerson";
            this.Text = "frmPerson";
            this.tabControl1.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.Employees.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Employees;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblClientsEmpty;
        private System.Windows.Forms.Label lblEmployeeEmpty;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchterm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmployeeSearch;
    }
}