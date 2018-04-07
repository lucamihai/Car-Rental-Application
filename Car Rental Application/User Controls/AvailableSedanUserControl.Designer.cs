namespace Car_Rental_Application.User_Controls
{
    partial class AvailableSedanUserControl
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
            this.vehicleNameLabel = new System.Windows.Forms.Label();
            this.vehicleTypeLabel = new System.Windows.Forms.Label();
            this.damagePercentLabel = new System.Windows.Forms.Label();
            this.fuelPercentLabel = new System.Windows.Forms.Label();
            this.fuelPercentValueLabel = new System.Windows.Forms.Label();
            this.damagePercentValueLabel = new System.Windows.Forms.Label();
            this.vehicleTypeValueLabel = new System.Windows.Forms.Label();
            this.vehicleNameValueLabel = new System.Windows.Forms.Label();
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // vehicleNameLabel
            // 
            this.vehicleNameLabel.AutoSize = true;
            this.vehicleNameLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleNameLabel.Location = new System.Drawing.Point(12, 18);
            this.vehicleNameLabel.Name = "vehicleNameLabel";
            this.vehicleNameLabel.Size = new System.Drawing.Size(98, 19);
            this.vehicleNameLabel.TabIndex = 0;
            this.vehicleNameLabel.Text = "Vehicle name";
            // 
            // vehicleTypeLabel
            // 
            this.vehicleTypeLabel.AutoSize = true;
            this.vehicleTypeLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleTypeLabel.Location = new System.Drawing.Point(116, 18);
            this.vehicleTypeLabel.Name = "vehicleTypeLabel";
            this.vehicleTypeLabel.Size = new System.Drawing.Size(91, 19);
            this.vehicleTypeLabel.TabIndex = 1;
            this.vehicleTypeLabel.Text = "Vehicle type";
            // 
            // damagePercentLabel
            // 
            this.damagePercentLabel.AutoSize = true;
            this.damagePercentLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.damagePercentLabel.Location = new System.Drawing.Point(213, 18);
            this.damagePercentLabel.Name = "damagePercentLabel";
            this.damagePercentLabel.Size = new System.Drawing.Size(119, 19);
            this.damagePercentLabel.TabIndex = 2;
            this.damagePercentLabel.Text = "Damage percent";
            // 
            // fuelPercentLabel
            // 
            this.fuelPercentLabel.AutoSize = true;
            this.fuelPercentLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fuelPercentLabel.Location = new System.Drawing.Point(347, 18);
            this.fuelPercentLabel.Name = "fuelPercentLabel";
            this.fuelPercentLabel.Size = new System.Drawing.Size(92, 19);
            this.fuelPercentLabel.TabIndex = 3;
            this.fuelPercentLabel.Text = "Fuel percent";
            // 
            // fuelPercentValueLabel
            // 
            this.fuelPercentValueLabel.AutoSize = true;
            this.fuelPercentValueLabel.Location = new System.Drawing.Point(365, 37);
            this.fuelPercentValueLabel.Name = "fuelPercentValueLabel";
            this.fuelPercentValueLabel.Size = new System.Drawing.Size(42, 13);
            this.fuelPercentValueLabel.TabIndex = 7;
            this.fuelPercentValueLabel.Text = "0-100%";
            // 
            // damagePercentValueLabel
            // 
            this.damagePercentValueLabel.AutoSize = true;
            this.damagePercentValueLabel.Location = new System.Drawing.Point(247, 37);
            this.damagePercentValueLabel.Name = "damagePercentValueLabel";
            this.damagePercentValueLabel.Size = new System.Drawing.Size(42, 13);
            this.damagePercentValueLabel.TabIndex = 6;
            this.damagePercentValueLabel.Text = "0-100%";
            // 
            // vehicleTypeValueLabel
            // 
            this.vehicleTypeValueLabel.AutoSize = true;
            this.vehicleTypeValueLabel.Location = new System.Drawing.Point(117, 37);
            this.vehicleTypeValueLabel.Name = "vehicleTypeValueLabel";
            this.vehicleTypeValueLabel.Size = new System.Drawing.Size(38, 13);
            this.vehicleTypeValueLabel.TabIndex = 5;
            this.vehicleTypeValueLabel.Text = "Sedan";
            // 
            // vehicleNameValueLabel
            // 
            this.vehicleNameValueLabel.AutoSize = true;
            this.vehicleNameValueLabel.Location = new System.Drawing.Point(13, 37);
            this.vehicleNameValueLabel.Name = "vehicleNameValueLabel";
            this.vehicleNameValueLabel.Size = new System.Drawing.Size(35, 13);
            this.vehicleNameValueLabel.TabIndex = 4;
            this.vehicleNameValueLabel.Text = "Name";
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.AutoSize = true;
            this.selectCheckBox.Location = new System.Drawing.Point(449, 33);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Size = new System.Drawing.Size(56, 17);
            this.selectCheckBox.TabIndex = 8;
            this.selectCheckBox.Text = "Select";
            this.selectCheckBox.UseVisualStyleBackColor = true;
            this.selectCheckBox.CheckedChanged += new System.EventHandler(this.selectCheckBox_CheckedChanged);
            // 
            // AvailableSedanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.selectCheckBox);
            this.Controls.Add(this.fuelPercentValueLabel);
            this.Controls.Add(this.damagePercentValueLabel);
            this.Controls.Add(this.vehicleTypeValueLabel);
            this.Controls.Add(this.vehicleNameValueLabel);
            this.Controls.Add(this.fuelPercentLabel);
            this.Controls.Add(this.damagePercentLabel);
            this.Controls.Add(this.vehicleTypeLabel);
            this.Controls.Add(this.vehicleNameLabel);
            this.Name = "AvailableSedanUserControl";
            this.Size = new System.Drawing.Size(505, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label vehicleNameLabel;
        private System.Windows.Forms.Label vehicleTypeLabel;
        private System.Windows.Forms.Label damagePercentLabel;
        private System.Windows.Forms.Label fuelPercentLabel;
        private System.Windows.Forms.Label fuelPercentValueLabel;
        private System.Windows.Forms.Label damagePercentValueLabel;
        private System.Windows.Forms.Label vehicleTypeValueLabel;
        private System.Windows.Forms.Label vehicleNameValueLabel;
        private System.Windows.Forms.CheckBox selectCheckBox;
    }
}
