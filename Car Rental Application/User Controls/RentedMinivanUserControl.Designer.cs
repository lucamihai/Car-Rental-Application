namespace Car_Rental_Application.User_Controls
{
    partial class RentedMinivanUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rentIDValueLabel = new System.Windows.Forms.Label();
            this.labelRentID = new System.Windows.Forms.Label();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.returnDateValueLabel = new System.Windows.Forms.Label();
            this.ownerPhoneNumberValueLabel = new System.Windows.Forms.Label();
            this.ownerNameValueLabel = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelOwnerPhoneNumber = new System.Windows.Forms.Label();
            this.labelOwnerName = new System.Windows.Forms.Label();
            this.labelVehicleTypeValue = new System.Windows.Forms.Label();
            this.vehicleNameValueLabel = new System.Windows.Forms.Label();
            this.labelVehicleType = new System.Windows.Forms.Label();
            this.labelVehicleName = new System.Windows.Forms.Label();
            this.checkboxSelect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rentIDValueLabel
            // 
            this.rentIDValueLabel.AutoSize = true;
            this.rentIDValueLabel.Location = new System.Drawing.Point(4, 37);
            this.rentIDValueLabel.Name = "rentIDValueLabel";
            this.rentIDValueLabel.Size = new System.Drawing.Size(13, 13);
            this.rentIDValueLabel.TabIndex = 39;
            this.rentIDValueLabel.Text = "1";
            // 
            // vehicleIDLabel
            // 
            this.labelRentID.AutoSize = true;
            this.labelRentID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRentID.Location = new System.Drawing.Point(3, 18);
            this.labelRentID.Name = "vehicleIDLabel";
            this.labelRentID.Size = new System.Drawing.Size(27, 19);
            this.labelRentID.TabIndex = 38;
            this.labelRentID.Text = "ID";
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(607, 49);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(75, 23);
            this.buttonReturn.TabIndex = 37;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // returnDateValueLabel
            // 
            this.returnDateValueLabel.AutoSize = true;
            this.returnDateValueLabel.Location = new System.Drawing.Point(525, 37);
            this.returnDateValueLabel.Name = "returnDateValueLabel";
            this.returnDateValueLabel.Size = new System.Drawing.Size(59, 13);
            this.returnDateValueLabel.TabIndex = 36;
            this.returnDateValueLabel.Text = "12/4/2018";
            // 
            // ownerPhoneNumberValueLabel
            // 
            this.ownerPhoneNumberValueLabel.AutoSize = true;
            this.ownerPhoneNumberValueLabel.Location = new System.Drawing.Point(357, 37);
            this.ownerPhoneNumberValueLabel.Name = "ownerPhoneNumberValueLabel";
            this.ownerPhoneNumberValueLabel.Size = new System.Drawing.Size(67, 13);
            this.ownerPhoneNumberValueLabel.TabIndex = 35;
            this.ownerPhoneNumberValueLabel.Text = "0123456789";
            // 
            // ownerNameValueLabel
            // 
            this.ownerNameValueLabel.AutoSize = true;
            this.ownerNameValueLabel.Location = new System.Drawing.Point(260, 37);
            this.ownerNameValueLabel.Name = "ownerNameValueLabel";
            this.ownerNameValueLabel.Size = new System.Drawing.Size(53, 13);
            this.ownerNameValueLabel.TabIndex = 34;
            this.ownerNameValueLabel.Text = "John Doe";
            // 
            // returnDateLabel
            // 
            this.labelReturnDate.AutoSize = true;
            this.labelReturnDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReturnDate.Location = new System.Drawing.Point(524, 18);
            this.labelReturnDate.Name = "returnDateLabel";
            this.labelReturnDate.Size = new System.Drawing.Size(89, 19);
            this.labelReturnDate.TabIndex = 33;
            this.labelReturnDate.Text = "Return date";
            // 
            // ownerPhoneNumberValue
            // 
            this.labelOwnerPhoneNumber.AutoSize = true;
            this.labelOwnerPhoneNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOwnerPhoneNumber.Location = new System.Drawing.Point(356, 18);
            this.labelOwnerPhoneNumber.Name = "ownerPhoneNumberValue";
            this.labelOwnerPhoneNumber.Size = new System.Drawing.Size(162, 19);
            this.labelOwnerPhoneNumber.TabIndex = 32;
            this.labelOwnerPhoneNumber.Text = "Owner\'s phone number";
            // 
            // ownerNameLabel
            // 
            this.labelOwnerName.AutoSize = true;
            this.labelOwnerName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOwnerName.Location = new System.Drawing.Point(259, 18);
            this.labelOwnerName.Name = "ownerNameLabel";
            this.labelOwnerName.Size = new System.Drawing.Size(93, 19);
            this.labelOwnerName.TabIndex = 31;
            this.labelOwnerName.Text = "Owner name";
            // 
            // vehicleTypeValueLabel
            // 
            this.labelVehicleTypeValue.AutoSize = true;
            this.labelVehicleTypeValue.Location = new System.Drawing.Point(163, 37);
            this.labelVehicleTypeValue.Name = "vehicleTypeValueLabel";
            this.labelVehicleTypeValue.Size = new System.Drawing.Size(44, 13);
            this.labelVehicleTypeValue.TabIndex = 30;
            this.labelVehicleTypeValue.Text = "Minivan";
            // 
            // vehicleNameValueLabel
            // 
            this.vehicleNameValueLabel.AutoSize = true;
            this.vehicleNameValueLabel.Location = new System.Drawing.Point(59, 37);
            this.vehicleNameValueLabel.Name = "vehicleNameValueLabel";
            this.vehicleNameValueLabel.Size = new System.Drawing.Size(35, 13);
            this.vehicleNameValueLabel.TabIndex = 29;
            this.vehicleNameValueLabel.Text = "Name";
            // 
            // vehicleTypeLabel
            // 
            this.labelVehicleType.AutoSize = true;
            this.labelVehicleType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleType.Location = new System.Drawing.Point(162, 18);
            this.labelVehicleType.Name = "vehicleTypeLabel";
            this.labelVehicleType.Size = new System.Drawing.Size(91, 19);
            this.labelVehicleType.TabIndex = 28;
            this.labelVehicleType.Text = "Vehicle type";
            // 
            // vehicleNameLabel
            // 
            this.labelVehicleName.AutoSize = true;
            this.labelVehicleName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleName.Location = new System.Drawing.Point(58, 18);
            this.labelVehicleName.Name = "vehicleNameLabel";
            this.labelVehicleName.Size = new System.Drawing.Size(98, 19);
            this.labelVehicleName.TabIndex = 27;
            this.labelVehicleName.Text = "Vehicle name";
            // 
            // selectCheckBox
            // 
            this.checkboxSelect.AutoSize = true;
            this.checkboxSelect.Location = new System.Drawing.Point(617, 21);
            this.checkboxSelect.Name = "selectCheckBox";
            this.checkboxSelect.Size = new System.Drawing.Size(56, 17);
            this.checkboxSelect.TabIndex = 40;
            this.checkboxSelect.Text = "Select";
            this.checkboxSelect.UseVisualStyleBackColor = true;
            this.checkboxSelect.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RentedMinivanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.checkboxSelect);
            this.Controls.Add(this.rentIDValueLabel);
            this.Controls.Add(this.labelRentID);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.returnDateValueLabel);
            this.Controls.Add(this.ownerPhoneNumberValueLabel);
            this.Controls.Add(this.ownerNameValueLabel);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelOwnerPhoneNumber);
            this.Controls.Add(this.labelOwnerName);
            this.Controls.Add(this.labelVehicleTypeValue);
            this.Controls.Add(this.vehicleNameValueLabel);
            this.Controls.Add(this.labelVehicleType);
            this.Controls.Add(this.labelVehicleName);
            this.Name = "RentedMinivanUserControl";
            this.Size = new System.Drawing.Size(700, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rentIDValueLabel;
        private System.Windows.Forms.Label labelRentID;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label returnDateValueLabel;
        private System.Windows.Forms.Label ownerPhoneNumberValueLabel;
        private System.Windows.Forms.Label ownerNameValueLabel;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelOwnerPhoneNumber;
        private System.Windows.Forms.Label labelOwnerName;
        private System.Windows.Forms.Label labelVehicleTypeValue;
        private System.Windows.Forms.Label vehicleNameValueLabel;
        private System.Windows.Forms.Label labelVehicleType;
        private System.Windows.Forms.Label labelVehicleName;
        private System.Windows.Forms.CheckBox checkboxSelect;
    }
}
