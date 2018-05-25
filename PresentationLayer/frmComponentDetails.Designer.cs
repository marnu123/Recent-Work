﻿namespace PresentationLayer
{
    partial class frmComponentDetails
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
            this.tcComponent = new System.Windows.Forms.TabControl();
            this.tabComponent = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lstError = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnComponentCancel = new System.Windows.Forms.Button();
            this.btnComponentEdit = new System.Windows.Forms.Button();
            this.btnComponentDelete = new System.Windows.Forms.Button();
            this.btnComponentSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.txtPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.btnCancelConfig = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnAddConfigToCurrent = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAvailableConfigurations = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCurrentConfigurations = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInsertConfiguration = new System.Windows.Forms.Button();
            this.btnViewConfiguration = new System.Windows.Forms.Button();
            this.tcComponent.SuspendLayout();
            this.tabComponent.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            this.tabConfiguration.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableConfigurations)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentConfigurations)).BeginInit();
            this.SuspendLayout();
            // 
            // tcComponent
            // 
            this.tcComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcComponent.Controls.Add(this.tabComponent);
            this.tcComponent.Controls.Add(this.tabConfiguration);
            this.tcComponent.Location = new System.Drawing.Point(0, 0);
            this.tcComponent.Name = "tcComponent";
            this.tcComponent.SelectedIndex = 0;
            this.tcComponent.Size = new System.Drawing.Size(991, 515);
            this.tcComponent.TabIndex = 34;
            this.tcComponent.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabComponent
            // 
            this.tabComponent.Controls.Add(this.panel5);
            this.tabComponent.Controls.Add(this.btnComponentCancel);
            this.tabComponent.Controls.Add(this.btnComponentEdit);
            this.tabComponent.Controls.Add(this.btnComponentDelete);
            this.tabComponent.Controls.Add(this.btnComponentSave);
            this.tabComponent.Controls.Add(this.panel1);
            this.tabComponent.Location = new System.Drawing.Point(4, 22);
            this.tabComponent.Name = "tabComponent";
            this.tabComponent.Padding = new System.Windows.Forms.Padding(3);
            this.tabComponent.Size = new System.Drawing.Size(983, 489);
            this.tabComponent.TabIndex = 0;
            this.tabComponent.Text = "Component";
            this.tabComponent.UseVisualStyleBackColor = true;
            this.tabComponent.Enter += new System.EventHandler(this.tabComponent_Enter);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lstError);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Location = new System.Drawing.Point(504, 11);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 250);
            this.panel5.TabIndex = 27;
            // 
            // lstError
            // 
            this.lstError.FormattingEnabled = true;
            this.lstError.Location = new System.Drawing.Point(15, 32);
            this.lstError.Name = "lstError";
            this.lstError.Size = new System.Drawing.Size(210, 199);
            this.lstError.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 18);
            this.label15.TabIndex = 0;
            this.label15.Text = "Error Box";
            // 
            // btnComponentCancel
            // 
            this.btnComponentCancel.Location = new System.Drawing.Point(17, 327);
            this.btnComponentCancel.Name = "btnComponentCancel";
            this.btnComponentCancel.Size = new System.Drawing.Size(254, 23);
            this.btnComponentCancel.TabIndex = 26;
            this.btnComponentCancel.Text = "Cancel";
            this.btnComponentCancel.UseVisualStyleBackColor = true;
            // 
            // btnComponentEdit
            // 
            this.btnComponentEdit.Location = new System.Drawing.Point(106, 298);
            this.btnComponentEdit.Name = "btnComponentEdit";
            this.btnComponentEdit.Size = new System.Drawing.Size(75, 23);
            this.btnComponentEdit.TabIndex = 25;
            this.btnComponentEdit.Text = "Edit";
            this.btnComponentEdit.UseVisualStyleBackColor = true;
            // 
            // btnComponentDelete
            // 
            this.btnComponentDelete.Location = new System.Drawing.Point(196, 298);
            this.btnComponentDelete.Name = "btnComponentDelete";
            this.btnComponentDelete.Size = new System.Drawing.Size(75, 23);
            this.btnComponentDelete.TabIndex = 24;
            this.btnComponentDelete.Text = "Delete";
            this.btnComponentDelete.UseVisualStyleBackColor = true;
            this.btnComponentDelete.Click += new System.EventHandler(this.btnComponentDelete_Click_1);
            // 
            // btnComponentSave
            // 
            this.btnComponentSave.Location = new System.Drawing.Point(17, 298);
            this.btnComponentSave.Name = "btnComponentSave";
            this.btnComponentSave.Size = new System.Drawing.Size(75, 23);
            this.btnComponentSave.TabIndex = 23;
            this.btnComponentSave.Text = "Save";
            this.btnComponentSave.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 275);
            this.panel1.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(17, 111);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(157, 96);
            this.txtDescription.TabIndex = 17;
            this.txtDescription.Text = "";
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 2;
            this.txtPrice.Location = new System.Drawing.Point(17, 237);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(157, 20);
            this.txtPrice.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(17, 66);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(157, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
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
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Component";
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.btnCancelConfig);
            this.tabConfiguration.Controls.Add(this.btnSaveConfig);
            this.tabConfiguration.Controls.Add(this.btnAddConfigToCurrent);
            this.tabConfiguration.Controls.Add(this.panel3);
            this.tabConfiguration.Controls.Add(this.panel2);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(983, 489);
            this.tabConfiguration.TabIndex = 1;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            this.tabConfiguration.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // btnCancelConfig
            // 
            this.btnCancelConfig.Location = new System.Drawing.Point(95, 392);
            this.btnCancelConfig.Name = "btnCancelConfig";
            this.btnCancelConfig.Size = new System.Drawing.Size(75, 23);
            this.btnCancelConfig.TabIndex = 37;
            this.btnCancelConfig.Text = "Cancel";
            this.btnCancelConfig.UseVisualStyleBackColor = true;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(14, 392);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 36;
            this.btnSaveConfig.Text = "Save";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnAddConfigToCurrent
            // 
            this.btnAddConfigToCurrent.Location = new System.Drawing.Point(435, 115);
            this.btnAddConfigToCurrent.Name = "btnAddConfigToCurrent";
            this.btnAddConfigToCurrent.Size = new System.Drawing.Size(75, 23);
            this.btnAddConfigToCurrent.TabIndex = 33;
            this.btnAddConfigToCurrent.Text = "<- Add";
            this.btnAddConfigToCurrent.UseVisualStyleBackColor = true;
            this.btnAddConfigToCurrent.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnViewConfiguration);
            this.panel3.Controls.Add(this.btnInsertConfiguration);
            this.panel3.Controls.Add(this.dgvAvailableConfigurations);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(522, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 370);
            this.panel3.TabIndex = 32;
            // 
            // dgvAvailableConfigurations
            // 
            this.dgvAvailableConfigurations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableConfigurations.Location = new System.Drawing.Point(6, 56);
            this.dgvAvailableConfigurations.Name = "dgvAvailableConfigurations";
            this.dgvAvailableConfigurations.Size = new System.Drawing.Size(400, 188);
            this.dgvAvailableConfigurations.TabIndex = 3;
            this.dgvAvailableConfigurations.SelectionChanged += new System.EventHandler(this.dgvAvailableConfigurations_SelectionChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Available Configurations";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCurrentConfigurations);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(8, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 370);
            this.panel2.TabIndex = 19;
            // 
            // dgvCurrentConfigurations
            // 
            this.dgvCurrentConfigurations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentConfigurations.Location = new System.Drawing.Point(6, 56);
            this.dgvCurrentConfigurations.Name = "dgvCurrentConfigurations";
            this.dgvCurrentConfigurations.Size = new System.Drawing.Size(386, 188);
            this.dgvCurrentConfigurations.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Current Configuration";
            // 
            // btnInsertConfiguration
            // 
            this.btnInsertConfiguration.Location = new System.Drawing.Point(6, 266);
            this.btnInsertConfiguration.Name = "btnInsertConfiguration";
            this.btnInsertConfiguration.Size = new System.Drawing.Size(181, 23);
            this.btnInsertConfiguration.TabIndex = 4;
            this.btnInsertConfiguration.Text = "Insert Configuration";
            this.btnInsertConfiguration.UseVisualStyleBackColor = true;
            this.btnInsertConfiguration.Click += new System.EventHandler(this.btnInsertConfiguration_Click);
            // 
            // btnViewConfiguration
            // 
            this.btnViewConfiguration.Location = new System.Drawing.Point(6, 295);
            this.btnViewConfiguration.Name = "btnViewConfiguration";
            this.btnViewConfiguration.Size = new System.Drawing.Size(181, 23);
            this.btnViewConfiguration.TabIndex = 5;
            this.btnViewConfiguration.Text = "View/Edit Configuration";
            this.btnViewConfiguration.UseVisualStyleBackColor = true;
            this.btnViewConfiguration.Click += new System.EventHandler(this.btnViewConfiguration_Click);
            // 
            // frmComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 506);
            this.Controls.Add(this.tcComponent);
            this.Name = "frmComponent";
            this.Text = "frmComponent";
            this.tcComponent.ResumeLayout(false);
            this.tabComponent.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            this.tabConfiguration.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableConfigurations)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentConfigurations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcComponent;
        private System.Windows.Forms.TabPage tabComponent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.NumericUpDown txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.Button btnComponentCancel;
        private System.Windows.Forms.Button btnComponentEdit;
        private System.Windows.Forms.Button btnComponentDelete;
        private System.Windows.Forms.Button btnComponentSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvAvailableConfigurations;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCurrentConfigurations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddConfigToCurrent;
        private System.Windows.Forms.Button btnCancelConfig;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox lstError;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnInsertConfiguration;
        private System.Windows.Forms.Button btnViewConfiguration;
    }
}