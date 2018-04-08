namespace Car_Rental_Application.User_Controls
{
    partial class ReturnFromRentUserControl
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.damagePercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fuelPercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fuelPercentageLabel = new System.Windows.Forms.Label();
            this.damagePercentageLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.returnDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCheckReturnDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.damagePercentageNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelPercentageNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(57, 208);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(150, 208);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(96, 23);
            this.buttonReturn.TabIndex = 1;
            this.buttonReturn.Text = "Return vehicle";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // damagePercentageNumericUpDown
            // 
            this.damagePercentageNumericUpDown.Location = new System.Drawing.Point(122, 125);
            this.damagePercentageNumericUpDown.Name = "damagePercentageNumericUpDown";
            this.damagePercentageNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.damagePercentageNumericUpDown.TabIndex = 2;
            this.damagePercentageNumericUpDown.ValueChanged += new System.EventHandler(this.damagePercentageNumericUpDown_ValueChanged);
            // 
            // fuelPercentageNumericUpDown
            // 
            this.fuelPercentageNumericUpDown.Location = new System.Drawing.Point(122, 99);
            this.fuelPercentageNumericUpDown.Name = "fuelPercentageNumericUpDown";
            this.fuelPercentageNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.fuelPercentageNumericUpDown.TabIndex = 3;
            this.fuelPercentageNumericUpDown.ValueChanged += new System.EventHandler(this.fuelPercentageNumericUpDown_ValueChanged);
            // 
            // fuelPercentageLabel
            // 
            this.fuelPercentageLabel.AutoSize = true;
            this.fuelPercentageLabel.Location = new System.Drawing.Point(15, 99);
            this.fuelPercentageLabel.Name = "fuelPercentageLabel";
            this.fuelPercentageLabel.Size = new System.Drawing.Size(84, 13);
            this.fuelPercentageLabel.TabIndex = 4;
            this.fuelPercentageLabel.Text = "Fuel percentage";
            // 
            // damagePercentageLabel
            // 
            this.damagePercentageLabel.AutoSize = true;
            this.damagePercentageLabel.Location = new System.Drawing.Point(15, 132);
            this.damagePercentageLabel.Name = "damagePercentageLabel";
            this.damagePercentageLabel.Size = new System.Drawing.Size(104, 13);
            this.damagePercentageLabel.TabIndex = 5;
            this.damagePercentageLabel.Text = "Damage percentage";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(81, 69);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 6;
            // 
            // returnDateDateTimePicker
            // 
            this.returnDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.returnDateDateTimePicker.Location = new System.Drawing.Point(122, 161);
            this.returnDateDateTimePicker.Name = "returnDateDateTimePicker";
            this.returnDateDateTimePicker.Size = new System.Drawing.Size(120, 20);
            this.returnDateDateTimePicker.TabIndex = 7;
            this.returnDateDateTimePicker.ValueChanged += new System.EventHandler(this.returnDateDateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fill in the details of the vehicle at return";
            // 
            // labelCheckReturnDate
            // 
            this.labelCheckReturnDate.AutoSize = true;
            this.labelCheckReturnDate.Location = new System.Drawing.Point(54, 184);
            this.labelCheckReturnDate.Name = "labelCheckReturnDate";
            this.labelCheckReturnDate.Size = new System.Drawing.Size(0, 13);
            this.labelCheckReturnDate.TabIndex = 9;
            // 
            // ReturnFromRentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.Name = "ReturnFromRentUserControl";
            this.Size = new System.Drawing.Size(325, 250);
            ((System.ComponentModel.ISupportInitialize)(this.damagePercentageNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelPercentageNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.NumericUpDown damagePercentageNumericUpDown;
        private System.Windows.Forms.NumericUpDown fuelPercentageNumericUpDown;
        private System.Windows.Forms.Label fuelPercentageLabel;
        private System.Windows.Forms.Label damagePercentageLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.DateTimePicker returnDateDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCheckReturnDate;
    }
}
