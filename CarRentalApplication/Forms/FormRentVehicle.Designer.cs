namespace CarRentalApplication.Forms
{
    partial class FormRentVehicle
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelOwnerPhoneNumber = new System.Windows.Forms.Label();
            this.labelOwnerName = new System.Windows.Forms.Label();
            this.dateTimePickerReturnDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxOwnerPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxOwnerName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(43, 22);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 17;
            // 
            // labelReturnDate
            // 
            this.labelReturnDate.Location = new System.Drawing.Point(12, 101);
            this.labelReturnDate.Name = "labelReturnDate";
            this.labelReturnDate.Size = new System.Drawing.Size(122, 20);
            this.labelReturnDate.TabIndex = 16;
            this.labelReturnDate.Text = "Return date";
            this.labelReturnDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelOwnerPhoneNumber
            // 
            this.labelOwnerPhoneNumber.Location = new System.Drawing.Point(12, 75);
            this.labelOwnerPhoneNumber.Name = "labelOwnerPhoneNumber";
            this.labelOwnerPhoneNumber.Size = new System.Drawing.Size(122, 20);
            this.labelOwnerPhoneNumber.TabIndex = 15;
            this.labelOwnerPhoneNumber.Text = "Owner\'s phone number";
            this.labelOwnerPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelOwnerName
            // 
            this.labelOwnerName.Location = new System.Drawing.Point(15, 52);
            this.labelOwnerName.Name = "labelOwnerName";
            this.labelOwnerName.Size = new System.Drawing.Size(119, 17);
            this.labelOwnerName.TabIndex = 14;
            this.labelOwnerName.Text = "Owner\'s name";
            this.labelOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePickerReturnDate
            // 
            this.dateTimePickerReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerReturnDate.Location = new System.Drawing.Point(144, 101);
            this.dateTimePickerReturnDate.Name = "dateTimePickerReturnDate";
            this.dateTimePickerReturnDate.Size = new System.Drawing.Size(143, 20);
            this.dateTimePickerReturnDate.TabIndex = 13;
            // 
            // textBoxOwnerPhoneNumber
            // 
            this.textBoxOwnerPhoneNumber.Location = new System.Drawing.Point(144, 75);
            this.textBoxOwnerPhoneNumber.Name = "textBoxOwnerPhoneNumber";
            this.textBoxOwnerPhoneNumber.Size = new System.Drawing.Size(143, 20);
            this.textBoxOwnerPhoneNumber.TabIndex = 12;
            // 
            // textBoxOwnerName
            // 
            this.textBoxOwnerName.Location = new System.Drawing.Point(144, 49);
            this.textBoxOwnerName.Name = "textBoxOwnerName";
            this.textBoxOwnerName.Size = new System.Drawing.Size(143, 20);
            this.textBoxOwnerName.TabIndex = 11;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(156, 165);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // buttonRent
            // 
            this.buttonRent.Location = new System.Drawing.Point(63, 165);
            this.buttonRent.Name = "buttonRent";
            this.buttonRent.Size = new System.Drawing.Size(75, 23);
            this.buttonRent.TabIndex = 9;
            this.buttonRent.Text = "Rent";
            this.buttonRent.UseVisualStyleBackColor = true;
            this.buttonRent.Click += new System.EventHandler(this.Rent);
            // 
            // FormRentVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 211);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelOwnerPhoneNumber);
            this.Controls.Add(this.labelOwnerName);
            this.Controls.Add(this.dateTimePickerReturnDate);
            this.Controls.Add(this.textBoxOwnerPhoneNumber);
            this.Controls.Add(this.textBoxOwnerName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRent);
            this.Name = "FormRentVehicle";
            this.Text = "Rent vehicle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelOwnerPhoneNumber;
        private System.Windows.Forms.Label labelOwnerName;
        private System.Windows.Forms.DateTimePicker dateTimePickerReturnDate;
        private System.Windows.Forms.TextBox textBoxOwnerPhoneNumber;
        private System.Windows.Forms.TextBox textBoxOwnerName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRent;
    }
}