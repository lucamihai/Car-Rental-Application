using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.EntityViews
{
    partial class VehicleView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
        private void InitializeComponent()
        {
            this.labelId = new System.Windows.Forms.Label();
            this.labelIdValue = new System.Windows.Forms.Label();
            this.labelVehicleName = new System.Windows.Forms.Label();
            this.labelVehicleNameValue = new System.Windows.Forms.Label();
            this.labelVehicleType = new System.Windows.Forms.Label();
            this.labelVehicleTypeValue = new System.Windows.Forms.Label();
            this.labelFuelPercentage = new System.Windows.Forms.Label();
            this.labelFuelPercentageValue = new System.Windows.Forms.Label();
            this.labelDamagePercentage = new System.Windows.Forms.Label();
            this.labelDamagePercentageValue = new System.Windows.Forms.Label();
            this.checkboxSelect = new System.Windows.Forms.CheckBox();
            this.buttonRent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelId.Location = new System.Drawing.Point(3, 18);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(20, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID";
            // 
            // labelIdValue
            // 
            this.labelIdValue.AutoSize = true;
            this.labelIdValue.Location = new System.Drawing.Point(3, 37);
            this.labelIdValue.Name = "labelIdValue";
            this.labelIdValue.Size = new System.Drawing.Size(13, 13);
            this.labelIdValue.TabIndex = 1;
            this.labelIdValue.Text = "1";
            // 
            // labelVehicleName
            // 
            this.labelVehicleName.AutoSize = true;
            this.labelVehicleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleName.Location = new System.Drawing.Point(54, 18);
            this.labelVehicleName.Name = "labelVehicleName";
            this.labelVehicleName.Size = new System.Drawing.Size(83, 13);
            this.labelVehicleName.TabIndex = 2;
            this.labelVehicleName.Text = "Vehicle name";
            // 
            // labelVehicleNameValue
            // 
            this.labelVehicleNameValue.AutoSize = true;
            this.labelVehicleNameValue.Location = new System.Drawing.Point(54, 37);
            this.labelVehicleNameValue.Name = "labelVehicleNameValue";
            this.labelVehicleNameValue.Size = new System.Drawing.Size(63, 13);
            this.labelVehicleNameValue.TabIndex = 3;
            this.labelVehicleNameValue.Text = "Some name";
            // 
            // labelVehicleType
            // 
            this.labelVehicleType.AutoSize = true;
            this.labelVehicleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleType.Location = new System.Drawing.Point(158, 18);
            this.labelVehicleType.Name = "labelVehicleType";
            this.labelVehicleType.Size = new System.Drawing.Size(77, 13);
            this.labelVehicleType.TabIndex = 4;
            this.labelVehicleType.Text = "Vehicle type";
            // 
            // labelVehicleTypeValue
            // 
            this.labelVehicleTypeValue.AutoSize = true;
            this.labelVehicleTypeValue.Location = new System.Drawing.Point(158, 37);
            this.labelVehicleTypeValue.Name = "labelVehicleTypeValue";
            this.labelVehicleTypeValue.Size = new System.Drawing.Size(57, 13);
            this.labelVehicleTypeValue.TabIndex = 5;
            this.labelVehicleTypeValue.Text = "Some type";
            // 
            // labelFuelPercentage
            // 
            this.labelFuelPercentage.AutoSize = true;
            this.labelFuelPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFuelPercentage.Location = new System.Drawing.Point(255, 18);
            this.labelFuelPercentage.Name = "labelFuelPercentage";
            this.labelFuelPercentage.Size = new System.Drawing.Size(99, 13);
            this.labelFuelPercentage.TabIndex = 6;
            this.labelFuelPercentage.Text = "Fuel percentage";
            // 
            // labelFuelPercentageValue
            // 
            this.labelFuelPercentageValue.AutoSize = true;
            this.labelFuelPercentageValue.Location = new System.Drawing.Point(255, 37);
            this.labelFuelPercentageValue.Name = "labelFuelPercentageValue";
            this.labelFuelPercentageValue.Size = new System.Drawing.Size(45, 13);
            this.labelFuelPercentageValue.TabIndex = 7;
            this.labelFuelPercentageValue.Text = "Some %";
            // 
            // labelDamagePercentage
            // 
            this.labelDamagePercentage.AutoSize = true;
            this.labelDamagePercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDamagePercentage.Location = new System.Drawing.Point(367, 18);
            this.labelDamagePercentage.Name = "labelDamagePercentage";
            this.labelDamagePercentage.Size = new System.Drawing.Size(121, 13);
            this.labelDamagePercentage.TabIndex = 8;
            this.labelDamagePercentage.Text = "Damage percentage";
            // 
            // labelDamagePercentageValue
            // 
            this.labelDamagePercentageValue.AutoSize = true;
            this.labelDamagePercentageValue.Location = new System.Drawing.Point(367, 37);
            this.labelDamagePercentageValue.Name = "labelDamagePercentageValue";
            this.labelDamagePercentageValue.Size = new System.Drawing.Size(45, 13);
            this.labelDamagePercentageValue.TabIndex = 9;
            this.labelDamagePercentageValue.Text = "Some %";
            // 
            // checkboxSelect
            // 
            this.checkboxSelect.AutoSize = true;
            this.checkboxSelect.Location = new System.Drawing.Point(487, 20);
            this.checkboxSelect.Name = "checkboxSelect";
            this.checkboxSelect.Size = new System.Drawing.Size(56, 17);
            this.checkboxSelect.TabIndex = 10;
            this.checkboxSelect.Text = "Select";
            this.checkboxSelect.UseVisualStyleBackColor = true;
            // 
            // buttonRent
            // 
            this.buttonRent.Location = new System.Drawing.Point(472, 49);
            this.buttonRent.Name = "buttonRent";
            this.buttonRent.Size = new System.Drawing.Size(75, 23);
            this.buttonRent.TabIndex = 11;
            this.buttonRent.Text = "Rent";
            this.buttonRent.UseVisualStyleBackColor = true;
            // 
            // VehicleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.buttonRent);
            this.Controls.Add(this.checkboxSelect);
            this.Controls.Add(this.labelDamagePercentageValue);
            this.Controls.Add(this.labelDamagePercentage);
            this.Controls.Add(this.labelFuelPercentageValue);
            this.Controls.Add(this.labelFuelPercentage);
            this.Controls.Add(this.labelVehicleTypeValue);
            this.Controls.Add(this.labelVehicleType);
            this.Controls.Add(this.labelVehicleNameValue);
            this.Controls.Add(this.labelVehicleName);
            this.Controls.Add(this.labelIdValue);
            this.Controls.Add(this.labelId);
            this.Name = "VehicleView";
            this.Size = new System.Drawing.Size(550, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelIdValue;
        private System.Windows.Forms.Label labelVehicleName;
        private System.Windows.Forms.Label labelVehicleNameValue;
        private System.Windows.Forms.Label labelVehicleType;
        private System.Windows.Forms.Label labelVehicleTypeValue;
        private System.Windows.Forms.Label labelFuelPercentage;
        private System.Windows.Forms.Label labelFuelPercentageValue;
        private System.Windows.Forms.Label labelDamagePercentage;
        private System.Windows.Forms.Label labelDamagePercentageValue;
        private System.Windows.Forms.CheckBox checkboxSelect;
        private System.Windows.Forms.Button buttonRent;
    }
}
