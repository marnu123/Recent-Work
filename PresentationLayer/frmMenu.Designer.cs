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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.notifyIncomingCall = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPersonel = new System.Windows.Forms.Button();
            this.pnlPersonel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPeople = new System.Windows.Forms.Button();
            this.btnLocations = new System.Windows.Forms.Button();
            this.btnContractTypes = new System.Windows.Forms.Button();
            this.btnProductCategory = new System.Windows.Forms.Button();
            this.pnlProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnComponents = new System.Windows.Forms.Button();
            this.btnServiceCategory = new System.Windows.Forms.Button();
            this.pnlService = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnTaskTreeView = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnCallCentre = new System.Windows.Forms.Button();
            this.pnlCallCentre = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCallLog = new System.Windows.Forms.Button();
            this.btnCaller = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlPersonel.SuspendLayout();
            this.pnlProduct.SuspendLayout();
            this.pnlService.SuspendLayout();
            this.pnlCallCentre.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIncomingCall
            // 
            this.notifyIncomingCall.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIncomingCall.BalloonTipText = "Call Incoming";
            this.notifyIncomingCall.BalloonTipTitle = "Call Incoming";
            this.notifyIncomingCall.Text = "Call Incoming";
            this.notifyIncomingCall.Visible = true;
            this.notifyIncomingCall.BalloonTipClicked += new System.EventHandler(this.notifyIncomingCall_BalloonTipClicked);
            this.notifyIncomingCall.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIncomingCall_MouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnPersonel);
            this.flowLayoutPanel1.Controls.Add(this.pnlPersonel);
            this.flowLayoutPanel1.Controls.Add(this.btnProductCategory);
            this.flowLayoutPanel1.Controls.Add(this.pnlProduct);
            this.flowLayoutPanel1.Controls.Add(this.btnServiceCategory);
            this.flowLayoutPanel1.Controls.Add(this.pnlService);
            this.flowLayoutPanel1.Controls.Add(this.btnCallCentre);
            this.flowLayoutPanel1.Controls.Add(this.pnlCallCentre);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 61);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 431);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnPersonel
            // 
            this.btnPersonel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPersonel.FlatAppearance.BorderSize = 0;
            this.btnPersonel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonel.ForeColor = System.Drawing.Color.White;
            this.btnPersonel.Location = new System.Drawing.Point(3, 3);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.Size = new System.Drawing.Size(220, 23);
            this.btnPersonel.TabIndex = 13;
            this.btnPersonel.Text = "Personel, Clients and Locations";
            this.btnPersonel.UseVisualStyleBackColor = false;
            this.btnPersonel.Click += new System.EventHandler(this.btnPersonel_Click);
            // 
            // pnlPersonel
            // 
            this.pnlPersonel.AutoSize = true;
            this.pnlPersonel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPersonel.Controls.Add(this.btnPeople);
            this.pnlPersonel.Controls.Add(this.btnLocations);
            this.pnlPersonel.Controls.Add(this.btnContractTypes);
            this.pnlPersonel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlPersonel.Location = new System.Drawing.Point(3, 32);
            this.pnlPersonel.Name = "pnlPersonel";
            this.pnlPersonel.Size = new System.Drawing.Size(130, 87);
            this.pnlPersonel.TabIndex = 12;
            this.pnlPersonel.Visible = false;
            // 
            // btnPeople
            // 
            this.btnPeople.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPeople.FlatAppearance.BorderSize = 0;
            this.btnPeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeople.ForeColor = System.Drawing.Color.White;
            this.btnPeople.Location = new System.Drawing.Point(3, 3);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(124, 23);
            this.btnPeople.TabIndex = 1;
            this.btnPeople.Text = "People";
            this.btnPeople.UseVisualStyleBackColor = false;
            this.btnPeople.Click += new System.EventHandler(this.btnPeople_Click);
            // 
            // btnLocations
            // 
            this.btnLocations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLocations.FlatAppearance.BorderSize = 0;
            this.btnLocations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocations.ForeColor = System.Drawing.Color.White;
            this.btnLocations.Location = new System.Drawing.Point(3, 32);
            this.btnLocations.Name = "btnLocations";
            this.btnLocations.Size = new System.Drawing.Size(124, 23);
            this.btnLocations.TabIndex = 3;
            this.btnLocations.Text = "Locations";
            this.btnLocations.UseVisualStyleBackColor = false;
            this.btnLocations.Click += new System.EventHandler(this.btnLocations_Click);
            // 
            // btnContractTypes
            // 
            this.btnContractTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnContractTypes.FlatAppearance.BorderSize = 0;
            this.btnContractTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContractTypes.ForeColor = System.Drawing.Color.White;
            this.btnContractTypes.Location = new System.Drawing.Point(3, 61);
            this.btnContractTypes.Name = "btnContractTypes";
            this.btnContractTypes.Size = new System.Drawing.Size(124, 23);
            this.btnContractTypes.TabIndex = 6;
            this.btnContractTypes.Text = "Contract Types";
            this.btnContractTypes.UseVisualStyleBackColor = false;
            this.btnContractTypes.Click += new System.EventHandler(this.btnContractTypes_Click);
            // 
            // btnProductCategory
            // 
            this.btnProductCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnProductCategory.FlatAppearance.BorderSize = 0;
            this.btnProductCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductCategory.ForeColor = System.Drawing.Color.White;
            this.btnProductCategory.Location = new System.Drawing.Point(3, 125);
            this.btnProductCategory.Name = "btnProductCategory";
            this.btnProductCategory.Size = new System.Drawing.Size(220, 23);
            this.btnProductCategory.TabIndex = 14;
            this.btnProductCategory.Text = "Product Management";
            this.btnProductCategory.UseVisualStyleBackColor = false;
            this.btnProductCategory.Click += new System.EventHandler(this.btnProductCategory_Click);
            // 
            // pnlProduct
            // 
            this.pnlProduct.AutoSize = true;
            this.pnlProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlProduct.Controls.Add(this.btnProducts);
            this.pnlProduct.Controls.Add(this.btnComponents);
            this.pnlProduct.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlProduct.Location = new System.Drawing.Point(3, 154);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(130, 58);
            this.pnlProduct.TabIndex = 17;
            this.pnlProduct.Visible = false;
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(3, 3);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(124, 23);
            this.btnProducts.TabIndex = 6;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnComponents
            // 
            this.btnComponents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnComponents.FlatAppearance.BorderSize = 0;
            this.btnComponents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComponents.ForeColor = System.Drawing.Color.White;
            this.btnComponents.Location = new System.Drawing.Point(3, 32);
            this.btnComponents.Name = "btnComponents";
            this.btnComponents.Size = new System.Drawing.Size(124, 23);
            this.btnComponents.TabIndex = 5;
            this.btnComponents.Text = "Components";
            this.btnComponents.UseVisualStyleBackColor = false;
            this.btnComponents.Click += new System.EventHandler(this.btnComponents_Click);
            // 
            // btnServiceCategory
            // 
            this.btnServiceCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnServiceCategory.FlatAppearance.BorderSize = 0;
            this.btnServiceCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceCategory.ForeColor = System.Drawing.Color.White;
            this.btnServiceCategory.Location = new System.Drawing.Point(3, 218);
            this.btnServiceCategory.Name = "btnServiceCategory";
            this.btnServiceCategory.Size = new System.Drawing.Size(220, 23);
            this.btnServiceCategory.TabIndex = 15;
            this.btnServiceCategory.Text = "Service Management";
            this.btnServiceCategory.UseVisualStyleBackColor = false;
            this.btnServiceCategory.Click += new System.EventHandler(this.btnServiceCategory_Click);
            // 
            // pnlService
            // 
            this.pnlService.AutoSize = true;
            this.pnlService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlService.Controls.Add(this.btnSchedule);
            this.pnlService.Controls.Add(this.btnTaskTreeView);
            this.pnlService.Controls.Add(this.btnTasks);
            this.pnlService.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlService.Location = new System.Drawing.Point(3, 247);
            this.pnlService.Name = "pnlService";
            this.pnlService.Size = new System.Drawing.Size(130, 87);
            this.pnlService.TabIndex = 18;
            this.pnlService.Visible = false;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Location = new System.Drawing.Point(3, 3);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(124, 23);
            this.btnSchedule.TabIndex = 12;
            this.btnSchedule.Text = "Schedules";
            this.btnSchedule.UseVisualStyleBackColor = false;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnTaskTreeView
            // 
            this.btnTaskTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTaskTreeView.FlatAppearance.BorderSize = 0;
            this.btnTaskTreeView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskTreeView.ForeColor = System.Drawing.Color.White;
            this.btnTaskTreeView.Location = new System.Drawing.Point(3, 32);
            this.btnTaskTreeView.Name = "btnTaskTreeView";
            this.btnTaskTreeView.Size = new System.Drawing.Size(124, 23);
            this.btnTaskTreeView.TabIndex = 11;
            this.btnTaskTreeView.Text = "Task Tree View";
            this.btnTaskTreeView.UseVisualStyleBackColor = false;
            this.btnTaskTreeView.Click += new System.EventHandler(this.btnTaskTreeView_Click);
            // 
            // btnTasks
            // 
            this.btnTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTasks.FlatAppearance.BorderSize = 0;
            this.btnTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTasks.ForeColor = System.Drawing.Color.White;
            this.btnTasks.Location = new System.Drawing.Point(3, 61);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(124, 23);
            this.btnTasks.TabIndex = 10;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = false;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnCallCentre
            // 
            this.btnCallCentre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCallCentre.FlatAppearance.BorderSize = 0;
            this.btnCallCentre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallCentre.ForeColor = System.Drawing.Color.White;
            this.btnCallCentre.Location = new System.Drawing.Point(3, 340);
            this.btnCallCentre.Name = "btnCallCentre";
            this.btnCallCentre.Size = new System.Drawing.Size(220, 23);
            this.btnCallCentre.TabIndex = 16;
            this.btnCallCentre.Text = "Call Centre Management";
            this.btnCallCentre.UseVisualStyleBackColor = false;
            this.btnCallCentre.Click += new System.EventHandler(this.btnCallCentre_Click);
            // 
            // pnlCallCentre
            // 
            this.pnlCallCentre.AutoSize = true;
            this.pnlCallCentre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlCallCentre.Controls.Add(this.btnCallLog);
            this.pnlCallCentre.Controls.Add(this.btnCaller);
            this.pnlCallCentre.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlCallCentre.Location = new System.Drawing.Point(3, 369);
            this.pnlCallCentre.Name = "pnlCallCentre";
            this.pnlCallCentre.Size = new System.Drawing.Size(130, 58);
            this.pnlCallCentre.TabIndex = 19;
            this.pnlCallCentre.Visible = false;
            // 
            // btnCallLog
            // 
            this.btnCallLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCallLog.FlatAppearance.BorderSize = 0;
            this.btnCallLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallLog.ForeColor = System.Drawing.Color.White;
            this.btnCallLog.Location = new System.Drawing.Point(3, 3);
            this.btnCallLog.Name = "btnCallLog";
            this.btnCallLog.Size = new System.Drawing.Size(124, 23);
            this.btnCallLog.TabIndex = 12;
            this.btnCallLog.Text = "Call Log";
            this.btnCallLog.UseVisualStyleBackColor = false;
            this.btnCallLog.Click += new System.EventHandler(this.btnCallLog_Click);
            // 
            // btnCaller
            // 
            this.btnCaller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCaller.FlatAppearance.BorderSize = 0;
            this.btnCaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaller.ForeColor = System.Drawing.Color.White;
            this.btnCaller.Location = new System.Drawing.Point(3, 32);
            this.btnCaller.Name = "btnCaller";
            this.btnCaller.Size = new System.Drawing.Size(124, 23);
            this.btnCaller.TabIndex = 11;
            this.btnCaller.Text = "Caller";
            this.btnCaller.UseVisualStyleBackColor = false;
            this.btnCaller.Click += new System.EventHandler(this.btnCaller_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Menu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Select a category";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(254, 516);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlPersonel.ResumeLayout(false);
            this.pnlProduct.ResumeLayout(false);
            this.pnlService.ResumeLayout(false);
            this.pnlCallCentre.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIncomingCall;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnPersonel;
        private System.Windows.Forms.FlowLayoutPanel pnlPersonel;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnLocations;
        private System.Windows.Forms.Button btnContractTypes;
        private System.Windows.Forms.Button btnProductCategory;
        private System.Windows.Forms.Button btnServiceCategory;
        private System.Windows.Forms.Button btnCallCentre;
        private System.Windows.Forms.FlowLayoutPanel pnlProduct;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnComponents;
        private System.Windows.Forms.FlowLayoutPanel pnlService;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnTaskTreeView;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.FlowLayoutPanel pnlCallCentre;
        private System.Windows.Forms.Button btnCallLog;
        private System.Windows.Forms.Button btnCaller;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}