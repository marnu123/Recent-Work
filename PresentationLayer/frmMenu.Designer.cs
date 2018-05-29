namespace PresentationLayer
{
    partial class frmMenu
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
            this.btnPeople = new System.Windows.Forms.Button();
            this.btnLocations = new System.Windows.Forms.Button();
            this.btnComponents = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnContractTypes = new System.Windows.Forms.Button();
            this.btnCaller = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPeople
            // 
            this.btnPeople.Location = new System.Drawing.Point(285, 121);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(124, 23);
            this.btnPeople.TabIndex = 0;
            this.btnPeople.Text = "People";
            this.btnPeople.UseVisualStyleBackColor = true;
            this.btnPeople.Click += new System.EventHandler(this.btnPeople_Click);
            // 
            // btnLocations
            // 
            this.btnLocations.Location = new System.Drawing.Point(285, 208);
            this.btnLocations.Name = "btnLocations";
            this.btnLocations.Size = new System.Drawing.Size(124, 23);
            this.btnLocations.TabIndex = 2;
            this.btnLocations.Text = "Locations";
            this.btnLocations.UseVisualStyleBackColor = true;
            this.btnLocations.Click += new System.EventHandler(this.btnLocations_Click);
            // 
            // btnComponents
            // 
            this.btnComponents.Location = new System.Drawing.Point(285, 179);
            this.btnComponents.Name = "btnComponents";
            this.btnComponents.Size = new System.Drawing.Size(124, 23);
            this.btnComponents.TabIndex = 3;
            this.btnComponents.Text = "Components";
            this.btnComponents.UseVisualStyleBackColor = true;
            this.btnComponents.Click += new System.EventHandler(this.btnComponents_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(285, 150);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(124, 23);
            this.btnProducts.TabIndex = 4;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnContractTypes
            // 
            this.btnContractTypes.Location = new System.Drawing.Point(285, 237);
            this.btnContractTypes.Name = "btnContractTypes";
            this.btnContractTypes.Size = new System.Drawing.Size(124, 23);
            this.btnContractTypes.TabIndex = 5;
            this.btnContractTypes.Text = "Contract Types";
            this.btnContractTypes.UseVisualStyleBackColor = true;
            this.btnContractTypes.Click += new System.EventHandler(this.btnContractTypes_Click);
            // 
            // btnCaller
            // 
            this.btnCaller.Location = new System.Drawing.Point(285, 266);
            this.btnCaller.Name = "btnCaller";
            this.btnCaller.Size = new System.Drawing.Size(124, 23);
            this.btnCaller.TabIndex = 6;
            this.btnCaller.Text = "Caller";
            this.btnCaller.UseVisualStyleBackColor = true;
            this.btnCaller.Click += new System.EventHandler(this.btnCaller_Click);
            // 
            // btnTasks
            // 
            this.btnTasks.Location = new System.Drawing.Point(285, 295);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(124, 23);
            this.btnTasks.TabIndex = 7;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.Location = new System.Drawing.Point(285, 324);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(124, 23);
            this.btnSchedules.TabIndex = 8;
            this.btnSchedules.Text = "Schedules";
            this.btnSchedules.UseVisualStyleBackColor = true;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSchedules);
            this.Controls.Add(this.btnTasks);
            this.Controls.Add(this.btnCaller);
            this.Controls.Add(this.btnContractTypes);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnComponents);
            this.Controls.Add(this.btnLocations);
            this.Controls.Add(this.btnPeople);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnLocations;
        private System.Windows.Forms.Button btnComponents;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnContractTypes;
        private System.Windows.Forms.Button btnCaller;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnSchedules;
    }
}