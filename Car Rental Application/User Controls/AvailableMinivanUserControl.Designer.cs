namespace Car_Rental_Application.User_Controls
{
    partial class AvailableMinivanUserControl
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
            this.IDValueLabel = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.checkboxSelect = new System.Windows.Forms.CheckBox();
            this.fuelPercentValueLabel = new System.Windows.Forms.Label();
            this.damagePercentValueLabel = new System.Windows.Forms.Label();
            this.labelVehicleTypeValue = new System.Windows.Forms.Label();
            this.vehicleNameValueLabel = new System.Windows.Forms.Label();
            this.labelFuelPercentage = new System.Windows.Forms.Label();
            this.labelDamagePercentage = new System.Windows.Forms.Label();
            this.labelVehicleType = new System.Windows.Forms.Label();
            this.labelVehicleName = new System.Windows.Forms.Label();
            this.buttonRent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IDValueLabel
            // 
            this.IDValueLabel.AutoSize = true;
            this.IDValueLabel.Location = new System.Drawing.Point(4, 37);
            this.IDValueLabel.Name = "IDValueLabel";
            this.IDValueLabel.Size = new System.Drawing.Size(13, 13);
            this.IDValueLabel.TabIndex = 21;
            this.IDValueLabel.Text = "1";
            // 
            // IDLabel
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.Location = new System.Drawing.Point(3, 18);
            this.labelID.Name = "IDLabel";
            this.labelID.Size = new System.Drawing.Size(27, 19);
            this.labelID.TabIndex = 20;
            this.labelID.Text = "ID";
            // 
            // selectCheckBox
            // 
            this.checkboxSelect.AutoSize = true;
            this.checkboxSelect.Location = new System.Drawing.Point(487, 20);
            this.checkboxSelect.Name = "selectCheckBox";
            this.checkboxSelect.Size = new System.Drawing.Size(56, 17);
            this.checkboxSelect.TabIndex = 19;
            this.checkboxSelect.Text = "Select";
            this.checkboxSelect.UseVisualStyleBackColor = true;
            this.checkboxSelect.CheckedChanged += new System.EventHandler(this.selectCheckBox_CheckedChanged);
            // 
            // fuelPercentValueLabel
            // 
            this.fuelPercentValueLabel.AutoSize = true;
            this.fuelPercentValueLabel.Location = new System.Drawing.Point(407, 37);
            this.fuelPercentValueLabel.Name = "fuelPercentValueLabel";
            this.fuelPercentValueLabel.Size = new System.Drawing.Size(42, 13);
            this.fuelPercentValueLabel.TabIndex = 18;
            this.fuelPercentValueLabel.Text = "0-100%";
            // 
            // damagePercentValueLabel
            // 
            this.damagePercentValueLabel.AutoSize = true;
            this.damagePercentValueLabel.Location = new System.Drawing.Point(289, 37);
            this.damagePercentValueLabel.Name = "damagePercentValueLabel";
            this.damagePercentValueLabel.Size = new System.Drawing.Size(42, 13);
            this.damagePercentValueLabel.TabIndex = 17;
            this.damagePercentValueLabel.Text = "0-100%";
            // 
            // vehicleTypeValueLabel
            // 
            this.labelVehicleTypeValue.AutoSize = true;
            this.labelVehicleTypeValue.Location = new System.Drawing.Point(159, 37);
            this.labelVehicleTypeValue.Name = "vehicleTypeValueLabel";
            this.labelVehicleTypeValue.Size = new System.Drawing.Size(44, 13);
            this.labelVehicleTypeValue.TabIndex = 16;
            this.labelVehicleTypeValue.Text = "Minivan";
            // 
            // vehicleNameValueLabel
            // 
            this.vehicleNameValueLabel.AutoSize = true;
            this.vehicleNameValueLabel.Location = new System.Drawing.Point(55, 37);
            this.vehicleNameValueLabel.Name = "vehicleNameValueLabel";
            this.vehicleNameValueLabel.Size = new System.Drawing.Size(35, 13);
            this.vehicleNameValueLabel.TabIndex = 15;
            this.vehicleNameValueLabel.Text = "Name";
            // 
            // fuelPercentLabel
            // 
            this.labelFuelPercentage.AutoSize = true;
            this.labelFuelPercentage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFuelPercentage.Location = new System.Drawing.Point(389, 18);
            this.labelFuelPercentage.Name = "fuelPercentLabel";
            this.labelFuelPercentage.Size = new System.Drawing.Size(92, 19);
            this.labelFuelPercentage.TabIndex = 14;
            this.labelFuelPercentage.Text = "Fuel percent";
            // 
            // damagePercentLabel
            // 
            this.labelDamagePercentage.AutoSize = true;
            this.labelDamagePercentage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDamagePercentage.Location = new System.Drawing.Point(255, 18);
            this.labelDamagePercentage.Name = "damagePercentLabel";
            this.labelDamagePercentage.Size = new System.Drawing.Size(119, 19);
            this.labelDamagePercentage.TabIndex = 13;
            this.labelDamagePercentage.Text = "Damage percent";
            // 
            // vehicleTypeLabel
            // 
            this.labelVehicleType.AutoSize = true;
            this.labelVehicleType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleType.Location = new System.Drawing.Point(158, 18);
            this.labelVehicleType.Name = "vehicleTypeLabel";
            this.labelVehicleType.Size = new System.Drawing.Size(91, 19);
            this.labelVehicleType.TabIndex = 12;
            this.labelVehicleType.Text = "Vehicle type";
            // 
            // vehicleNameLabel
            // 
            this.labelVehicleName.AutoSize = true;
            this.labelVehicleName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleName.Location = new System.Drawing.Point(54, 18);
            this.labelVehicleName.Name = "vehicleNameLabel";
            this.labelVehicleName.Size = new System.Drawing.Size(98, 19);
            this.labelVehicleName.TabIndex = 11;
            this.labelVehicleName.Text = "Vehicle name";
            // 
            // buttonRent
            // 
            this.buttonRent.Location = new System.Drawing.Point(472, 49);
            this.buttonRent.Name = "buttonRent";
            this.buttonRent.Size = new System.Drawing.Size(75, 23);
            this.buttonRent.TabIndex = 22;
            this.buttonRent.Text = "Rent";
            this.buttonRent.UseVisualStyleBackColor = true;
            this.buttonRent.Click += new System.EventHandler(this.buttonRent_Click);
            // 
            // AvailableMinivanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.buttonRent);
            this.Controls.Add(this.IDValueLabel);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.checkboxSelect);
            this.Controls.Add(this.fuelPercentValueLabel);
            this.Controls.Add(this.damagePercentValueLabel);
            this.Controls.Add(this.labelVehicleTypeValue);
            this.Controls.Add(this.vehicleNameValueLabel);
            this.Controls.Add(this.labelFuelPercentage);
            this.Controls.Add(this.labelDamagePercentage);
            this.Controls.Add(this.labelVehicleType);
            this.Controls.Add(this.labelVehicleName);
            this.Name = "AvailableMinivanUserControl";
            this.Size = new System.Drawing.Size(550, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IDValueLabel;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.CheckBox checkboxSelect;
        private System.Windows.Forms.Label fuelPercentValueLabel;
        private System.Windows.Forms.Label damagePercentValueLabel;
        private System.Windows.Forms.Label labelVehicleTypeValue;
        private System.Windows.Forms.Label vehicleNameValueLabel;
        private System.Windows.Forms.Label labelFuelPercentage;
        private System.Windows.Forms.Label labelDamagePercentage;
        private System.Windows.Forms.Label labelVehicleType;
        private System.Windows.Forms.Label labelVehicleName;
        private System.Windows.Forms.Button buttonRent;
    }
}
