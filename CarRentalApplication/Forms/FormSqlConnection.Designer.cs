using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Forms
{
    partial class FormSqlConnection
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
            this.textBoxDataSource = new System.Windows.Forms.TextBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxInitialCatalog = new System.Windows.Forms.TextBox();
            this.labelDataSource = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelInitialCatalog = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.radioButtonProvideFields = new System.Windows.Forms.RadioButton();
            this.radioButtonProvideConnectionString = new System.Windows.Forms.RadioButton();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(28, 66);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(285, 20);
            this.textBoxDataSource.TabIndex = 0;
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(31, 104);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(121, 20);
            this.textBoxUserID.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(184, 104);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(129, 20);
            this.textBoxPassword.TabIndex = 2;
            // 
            // textBoxInitialCatalog
            // 
            this.textBoxInitialCatalog.Location = new System.Drawing.Point(31, 146);
            this.textBoxInitialCatalog.Name = "textBoxInitialCatalog";
            this.textBoxInitialCatalog.Size = new System.Drawing.Size(121, 20);
            this.textBoxInitialCatalog.TabIndex = 3;
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(28, 50);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(65, 13);
            this.labelDataSource.TabIndex = 4;
            this.labelDataSource.Text = "Data source";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(28, 88);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(40, 13);
            this.labelUserID.TabIndex = 5;
            this.labelUserID.Text = "UserID";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(181, 88);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // labelInitialCatalog
            // 
            this.labelInitialCatalog.AutoSize = true;
            this.labelInitialCatalog.Location = new System.Drawing.Point(28, 130);
            this.labelInitialCatalog.Name = "labelInitialCatalog";
            this.labelInitialCatalog.Size = new System.Drawing.Size(69, 13);
            this.labelInitialCatalog.TabIndex = 7;
            this.labelInitialCatalog.Text = "Initial catalog";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(238, 176);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 8;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.Confirm);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(351, 176);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(307, 9);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(54, 13);
            this.errorLabel.TabIndex = 24;
            this.errorLabel.Text = "Error label";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonProvideFields
            // 
            this.radioButtonProvideFields.AutoSize = true;
            this.radioButtonProvideFields.Location = new System.Drawing.Point(28, 25);
            this.radioButtonProvideFields.Name = "radioButtonProvideFields";
            this.radioButtonProvideFields.Size = new System.Drawing.Size(88, 17);
            this.radioButtonProvideFields.TabIndex = 25;
            this.radioButtonProvideFields.TabStop = true;
            this.radioButtonProvideFields.Text = "Provide fields";
            this.radioButtonProvideFields.UseVisualStyleBackColor = true;
            this.radioButtonProvideFields.CheckedChanged += new System.EventHandler(this.ProvideFieldsChangedChecked);
            // 
            // radioButtonProvideConnectionString
            // 
            this.radioButtonProvideConnectionString.AutoSize = true;
            this.radioButtonProvideConnectionString.Location = new System.Drawing.Point(340, 25);
            this.radioButtonProvideConnectionString.Name = "radioButtonProvideConnectionString";
            this.radioButtonProvideConnectionString.Size = new System.Drawing.Size(145, 17);
            this.radioButtonProvideConnectionString.TabIndex = 26;
            this.radioButtonProvideConnectionString.TabStop = true;
            this.radioButtonProvideConnectionString.Text = "Provide connection string";
            this.radioButtonProvideConnectionString.UseVisualStyleBackColor = true;
            this.radioButtonProvideConnectionString.CheckedChanged += new System.EventHandler(this.ProvideConnectionStringChangedChecked);
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(340, 66);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(362, 20);
            this.textBoxConnectionString.TabIndex = 27;
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(337, 50);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(89, 13);
            this.labelConnectionString.TabIndex = 28;
            this.labelConnectionString.Text = "Connection string";
            // 
            // FormSqlConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(714, 211);
            this.Controls.Add(this.labelConnectionString);
            this.Controls.Add(this.textBoxConnectionString);
            this.Controls.Add(this.radioButtonProvideConnectionString);
            this.Controls.Add(this.radioButtonProvideFields);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelInitialCatalog);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.labelDataSource);
            this.Controls.Add(this.textBoxInitialCatalog);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.textBoxDataSource);
            this.Name = "FormSqlConnection";
            this.Text = "FormSqlConnection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDataSource;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxInitialCatalog;
        private System.Windows.Forms.Label labelDataSource;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelInitialCatalog;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.RadioButton radioButtonProvideFields;
        private System.Windows.Forms.RadioButton radioButtonProvideConnectionString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Label labelConnectionString;
    }
}