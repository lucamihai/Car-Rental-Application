namespace Car_Rental_Application.Forms
{
    partial class FormAddVehicle
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownDamagePercentage = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFuelPercentage = new System.Windows.Forms.NumericUpDown();
            this.textBoxVehicleName = new System.Windows.Forms.TextBox();
            this.radioButtonSedan = new System.Windows.Forms.RadioButton();
            this.radioButtonMinivan = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDamagePercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(109, 11);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 23;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(160, 176);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(49, 176);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVehicle.TabIndex = 21;
            this.buttonAddVehicle.Text = "Add vehicle";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.buttonAddVehicle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Damage percentage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Fuel percentage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Vehicle type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name of the vehicle";
            // 
            // numericUpDownDamagePercentage
            // 
            this.numericUpDownDamagePercentage.Location = new System.Drawing.Point(134, 117);
            this.numericUpDownDamagePercentage.Name = "numericUpDownDamagePercentage";
            this.numericUpDownDamagePercentage.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownDamagePercentage.TabIndex = 16;
            // 
            // numericUpDownFuelPercentage
            // 
            this.numericUpDownFuelPercentage.Location = new System.Drawing.Point(134, 91);
            this.numericUpDownFuelPercentage.Name = "numericUpDownFuelPercentage";
            this.numericUpDownFuelPercentage.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownFuelPercentage.TabIndex = 15;
            this.numericUpDownFuelPercentage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBoxVehicleName
            // 
            this.textBoxVehicleName.Location = new System.Drawing.Point(134, 39);
            this.textBoxVehicleName.Name = "textBoxVehicleName";
            this.textBoxVehicleName.Size = new System.Drawing.Size(153, 20);
            this.textBoxVehicleName.TabIndex = 12;
            // 
            // radioButtonSedan
            // 
            this.radioButtonSedan.AutoSize = true;
            this.radioButtonSedan.Checked = true;
            this.radioButtonSedan.Location = new System.Drawing.Point(134, 69);
            this.radioButtonSedan.Name = "radioButtonSedan";
            this.radioButtonSedan.Size = new System.Drawing.Size(56, 17);
            this.radioButtonSedan.TabIndex = 24;
            this.radioButtonSedan.TabStop = true;
            this.radioButtonSedan.Text = "Sedan";
            this.radioButtonSedan.UseVisualStyleBackColor = true;
            // 
            // radioButtonMinivan
            // 
            this.radioButtonMinivan.AutoSize = true;
            this.radioButtonMinivan.Location = new System.Drawing.Point(196, 69);
            this.radioButtonMinivan.Name = "radioButtonMinivan";
            this.radioButtonMinivan.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMinivan.TabIndex = 25;
            this.radioButtonMinivan.Text = "Minivan";
            this.radioButtonMinivan.UseVisualStyleBackColor = true;
            // 
            // FormAddVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 211);
            this.Controls.Add(this.radioButtonMinivan);
            this.Controls.Add(this.radioButtonSedan);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddVehicle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownDamagePercentage);
            this.Controls.Add(this.numericUpDownFuelPercentage);
            this.Controls.Add(this.textBoxVehicleName);
            this.Name = "FormAddVehicle";
            this.Text = "Add vehicle";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDamagePercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuelPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownDamagePercentage;
        private System.Windows.Forms.NumericUpDown numericUpDownFuelPercentage;
        private System.Windows.Forms.TextBox textBoxVehicleName;
        private System.Windows.Forms.RadioButton radioButtonSedan;
        private System.Windows.Forms.RadioButton radioButtonMinivan;
    }
}