namespace Car_Rental_Application.Forms
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
            this.labelCheckReturnDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.returnDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.errorLabel = new System.Windows.Forms.Label();
            this.damagePercentageLabel = new System.Windows.Forms.Label();
            this.fuelPercentageLabel = new System.Windows.Forms.Label();
            this.fuelPercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.damagePercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Fill in the details of the vehicle at return";
            // 
            // returnDateDateTimePicker
            // 
            this.returnDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.returnDateDateTimePicker.Location = new System.Drawing.Point(119, 142);
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
            // damagePercentageLabel
            // 
            this.damagePercentageLabel.AutoSize = true;
            this.damagePercentageLabel.Location = new System.Drawing.Point(51, 108);
            this.damagePercentageLabel.Name = "damagePercentageLabel";
            this.damagePercentageLabel.Size = new System.Drawing.Size(64, 13);
            this.damagePercentageLabel.TabIndex = 15;
            this.damagePercentageLabel.Text = "Damage (%)";
            // 
            // fuelPercentageLabel
            // 
            this.fuelPercentageLabel.AutoSize = true;
            this.fuelPercentageLabel.Location = new System.Drawing.Point(71, 82);
            this.fuelPercentageLabel.Name = "fuelPercentageLabel";
            this.fuelPercentageLabel.Size = new System.Drawing.Size(44, 13);
            this.fuelPercentageLabel.TabIndex = 14;
            this.fuelPercentageLabel.Text = "Fuel (%)";
            // 
            // fuelPercentageNumericUpDown
            // 
            this.fuelPercentageNumericUpDown.Location = new System.Drawing.Point(119, 80);
            this.fuelPercentageNumericUpDown.Name = "fuelPercentageNumericUpDown";
            this.fuelPercentageNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.fuelPercentageNumericUpDown.TabIndex = 13;
            // 
            // damagePercentageNumericUpDown
            // 
            this.damagePercentageNumericUpDown.Location = new System.Drawing.Point(119, 106);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Returned on:";
            // 
            // FormReturnVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 211);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCheckReturnDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.returnDateDateTimePicker);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.damagePercentageLabel);
            this.Controls.Add(this.fuelPercentageLabel);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker returnDateDateTimePicker;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label damagePercentageLabel;
        private System.Windows.Forms.Label fuelPercentageLabel;
        private System.Windows.Forms.NumericUpDown fuelPercentageNumericUpDown;
        private System.Windows.Forms.NumericUpDown damagePercentageNumericUpDown;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
    }
}