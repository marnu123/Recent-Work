namespace PresentationLayer
{
    partial class frmCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCall));
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlStartCall = new System.Windows.Forms.Panel();
            this.btnCallStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewNumber = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlStartCall.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnswer
            // 
            this.btnAnswer.BackColor = System.Drawing.Color.Transparent;
            this.btnAnswer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnswer.BackgroundImage")));
            this.btnAnswer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnswer.Location = new System.Drawing.Point(12, 274);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(64, 58);
            this.btnAnswer.TabIndex = 0;
            this.btnAnswer.UseVisualStyleBackColor = false;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Transparent;
            this.btnReject.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReject.BackgroundImage")));
            this.btnReject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReject.Location = new System.Drawing.Point(181, 274);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(65, 58);
            this.btnReject.TabIndex = 1;
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(65, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(136, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Call In Progress";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(77, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 148);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(87, 203);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(96, 17);
            this.lblNumber.TabIndex = 4;
            this.lblNumber.Text = "081 346 8796";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.White;
            this.lblDuration.Location = new System.Drawing.Point(111, 235);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(38, 15);
            this.lblDuration.TabIndex = 5;
            this.lblDuration.Text = "00:00";
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(321, 42);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(237, 290);
            this.txtInformation.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(318, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Call Information";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Blue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(322, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Information";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlStartCall
            // 
            this.pnlStartCall.Controls.Add(this.btnCallStart);
            this.pnlStartCall.Controls.Add(this.label2);
            this.pnlStartCall.Controls.Add(this.txtNewNumber);
            this.pnlStartCall.Location = new System.Drawing.Point(36, 253);
            this.pnlStartCall.Name = "pnlStartCall";
            this.pnlStartCall.Size = new System.Drawing.Size(200, 100);
            this.pnlStartCall.TabIndex = 0;
            // 
            // btnCallStart
            // 
            this.btnCallStart.BackColor = System.Drawing.Color.Blue;
            this.btnCallStart.FlatAppearance.BorderSize = 0;
            this.btnCallStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallStart.ForeColor = System.Drawing.Color.White;
            this.btnCallStart.Location = new System.Drawing.Point(45, 56);
            this.btnCallStart.Name = "btnCallStart";
            this.btnCallStart.Size = new System.Drawing.Size(107, 23);
            this.btnCallStart.TabIndex = 14;
            this.btnCallStart.Text = "Start Call";
            this.btnCallStart.UseVisualStyleBackColor = false;
            this.btnCallStart.Click += new System.EventHandler(this.btnCallStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Number";
            // 
            // txtNewNumber
            // 
            this.txtNewNumber.Location = new System.Drawing.Point(46, 30);
            this.txtNewNumber.Mask = "000 000 0000";
            this.txtNewNumber.Name = "txtNewNumber";
            this.txtNewNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNewNumber.TabIndex = 12;
            // 
            // frmCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(591, 394);
            this.Controls.Add(this.pnlStartCall);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInformation);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAnswer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCall";
            this.Text = "Call";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCall_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlStartCall.ResumeLayout(false);
            this.pnlStartCall.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlStartCall;
        private System.Windows.Forms.Button btnCallStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtNewNumber;
    }
}