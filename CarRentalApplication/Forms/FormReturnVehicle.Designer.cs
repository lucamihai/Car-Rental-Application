using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Forms
{
    partial class FormReturnVehicle
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void InitializeComponent()
        {
            this.labelCheckReturnDate = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.returnDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.errorLabel = new System.Windows.Forms.Label();
            this.labelDamagePercentage = new System.Windows.Forms.Label();
            this.labelFuelPercentage = new System.Windows.Forms.Label();
            this.fuelPercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.damagePercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelReturnedDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fuelPercentageNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagePercentageNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCheckReturnDate
            // 
            this.labelCheckReturnDate.AutoSize = true;
            this.labelCheckReturnDate.Location = new System.Drawing.Point(53, 165);
            this.labelCheckReturnDate.Name = "labelCheckReturnDate";
            this.labelCheckReturnDate.Size = new System.Drawing.Size(0, 13);
            this.labelCheckReturnDate.TabIndex = 19;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(13, 6);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(284, 44);
            this.labelDescription.TabIndex = 18;
            this.labelDescription.Text = "Fill in the details of the vehicle at return";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returnDateDateTimePicker
            // 
            this.returnDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.returnDateDateTimePicker.Location = new System.Drawing.Point(135, 142);
            this.returnDateDateTimePicker.Name = "returnDateDateTimePicker";
            this.returnDateDateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.returnDateDateTimePicker.TabIndex = 17;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(80, 50);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 16;
            // 
            // labelDamagePercentage
            // 
            this.labelDamagePercentage.Location = new System.Drawing.Point(20, 108);
            this.labelDamagePercentage.Name = "labelDamagePercentage";
            this.labelDamagePercentage.Size = new System.Drawing.Size(109, 18);
            this.labelDamagePercentage.TabIndex = 15;
            this.labelDamagePercentage.Text = "Damage (%)";
            this.labelDamagePercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFuelPercentage
            // 
            this.labelFuelPercentage.Location = new System.Drawing.Point(17, 82);
            this.labelFuelPercentage.Name = "labelFuelPercentage";
            this.labelFuelPercentage.Size = new System.Drawing.Size(112, 18);
            this.labelFuelPercentage.TabIndex = 14;
            this.labelFuelPercentage.Text = "Fuel (%)";
            this.labelFuelPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fuelPercentageNumericUpDown
            // 
            this.fuelPercentageNumericUpDown.Location = new System.Drawing.Point(135, 80);
            this.fuelPercentageNumericUpDown.Name = "fuelPercentageNumericUpDown";
            this.fuelPercentageNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.fuelPercentageNumericUpDown.TabIndex = 13;
            // 
            // damagePercentageNumericUpDown
            // 
            this.damagePercentageNumericUpDown.Location = new System.Drawing.Point(135, 106);
            this.damagePercentageNumericUpDown.Name = "damagePercentageNumericUpDown";
            this.damagePercentageNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.damagePercentageNumericUpDown.TabIndex = 12;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(47, 181);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(96, 23);
            this.buttonReturn.TabIndex = 11;
            this.buttonReturn.Text = "Return vehicle";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.ReturnFromRent);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(166, 181);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // labelReturnedDate
            // 
            this.labelReturnedDate.Location = new System.Drawing.Point(17, 142);
            this.labelReturnedDate.Name = "labelReturnedDate";
            this.labelReturnedDate.Size = new System.Drawing.Size(112, 20);
            this.labelReturnedDate.TabIndex = 20;
            this.labelReturnedDate.Text = "Returned on:";
            this.labelReturnedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormReturnVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 211);
            this.Controls.Add(this.labelReturnedDate);
            this.Controls.Add(this.labelCheckReturnDate);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.returnDateDateTimePicker);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.labelDamagePercentage);
            this.Controls.Add(this.labelFuelPercentage);
            this.Controls.Add(this.fuelPercentageNumericUpDown);
            this.Controls.Add(this.damagePercentageNumericUpDown);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormReturnVehicle";
            this.Text = "Return vehicle";
            ((System.ComponentModel.ISupportInitialize)(this.fuelPercentageNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagePercentageNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCheckReturnDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.DateTimePicker returnDateDateTimePicker;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label labelDamagePercentage;
        private System.Windows.Forms.Label labelFuelPercentage;
        private System.Windows.Forms.NumericUpDown fuelPercentageNumericUpDown;
        private System.Windows.Forms.NumericUpDown damagePercentageNumericUpDown;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelReturnedDate;
    }
}