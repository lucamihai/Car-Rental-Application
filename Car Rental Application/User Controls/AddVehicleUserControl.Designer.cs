namespace Car_Rental_Application.User_Controls
{
    partial class AddVehicleUserControl
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
            this.vehicleNameTextBox = new System.Windows.Forms.TextBox();
            this.sedanTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.minivanTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.fuelPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.damagePercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.buttonCancelAdd = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fuelPercentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagePercentNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // vehicleNameTextBox
            // 
            this.vehicleNameTextBox.Location = new System.Drawing.Point(146, 74);
            this.vehicleNameTextBox.Name = "vehicleNameTextBox";
            this.vehicleNameTextBox.Size = new System.Drawing.Size(153, 20);
            this.vehicleNameTextBox.TabIndex = 0;
            // 
            // sedanTypeCheckBox
            // 
            this.sedanTypeCheckBox.AutoSize = true;
            this.sedanTypeCheckBox.Checked = true;
            this.sedanTypeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sedanTypeCheckBox.Location = new System.Drawing.Point(146, 103);
            this.sedanTypeCheckBox.Name = "sedanTypeCheckBox";
            this.sedanTypeCheckBox.Size = new System.Drawing.Size(57, 17);
            this.sedanTypeCheckBox.TabIndex = 1;
            this.sedanTypeCheckBox.Text = "Sedan";
            this.sedanTypeCheckBox.UseVisualStyleBackColor = true;
            this.sedanTypeCheckBox.CheckedChanged += new System.EventHandler(this.sedanTypeCheckBox_CheckedChanged);
            // 
            // minivanTypeCheckBox
            // 
            this.minivanTypeCheckBox.AutoSize = true;
            this.minivanTypeCheckBox.Location = new System.Drawing.Point(209, 103);
            this.minivanTypeCheckBox.Name = "minivanTypeCheckBox";
            this.minivanTypeCheckBox.Size = new System.Drawing.Size(63, 17);
            this.minivanTypeCheckBox.TabIndex = 2;
            this.minivanTypeCheckBox.Text = "Minivan";
            this.minivanTypeCheckBox.UseVisualStyleBackColor = true;
            this.minivanTypeCheckBox.CheckedChanged += new System.EventHandler(this.minivanTypeCheckBox_CheckedChanged);
            // 
            // fuelPercentNumericUpDown
            // 
            this.fuelPercentNumericUpDown.Location = new System.Drawing.Point(146, 126);
            this.fuelPercentNumericUpDown.Name = "fuelPercentNumericUpDown";
            this.fuelPercentNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.fuelPercentNumericUpDown.TabIndex = 3;
            this.fuelPercentNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.fuelPercentNumericUpDown.ValueChanged += new System.EventHandler(this.fuelPercentNumericUpDown_ValueChanged);
            // 
            // damagePercentNumericUpDown
            // 
            this.damagePercentNumericUpDown.Location = new System.Drawing.Point(146, 152);
            this.damagePercentNumericUpDown.Name = "damagePercentNumericUpDown";
            this.damagePercentNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.damagePercentNumericUpDown.TabIndex = 4;
            this.damagePercentNumericUpDown.ValueChanged += new System.EventHandler(this.damagePercentNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name of the vehicle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vehicle type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fuel percentage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Damage percentage";
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(61, 211);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVehicle.TabIndex = 9;
            this.buttonAddVehicle.Text = "Add vehicle";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.buttonAddVehicle_Click);
            // 
            // buttonCancelAdd
            // 
            this.buttonCancelAdd.Location = new System.Drawing.Point(172, 211);
            this.buttonCancelAdd.Name = "buttonCancelAdd";
            this.buttonCancelAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelAdd.TabIndex = 10;
            this.buttonCancelAdd.Text = "Cancel";
            this.buttonCancelAdd.UseVisualStyleBackColor = true;
            this.buttonCancelAdd.Click += new System.EventHandler(this.buttonCancelAdd_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(121, 46);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 11;
            // 
            // AddVehicleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.buttonCancelAdd);
            this.Controls.Add(this.buttonAddVehicle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.damagePercentNumericUpDown);
            this.Controls.Add(this.fuelPercentNumericUpDown);
            this.Controls.Add(this.minivanTypeCheckBox);
            this.Controls.Add(this.sedanTypeCheckBox);
            this.Controls.Add(this.vehicleNameTextBox);
            this.Name = "AddVehicleUserControl";
            this.Size = new System.Drawing.Size(325, 250);
            ((System.ComponentModel.ISupportInitialize)(this.fuelPercentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damagePercentNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox vehicleNameTextBox;
        private System.Windows.Forms.CheckBox sedanTypeCheckBox;
        private System.Windows.Forms.CheckBox minivanTypeCheckBox;
        private System.Windows.Forms.NumericUpDown fuelPercentNumericUpDown;
        private System.Windows.Forms.NumericUpDown damagePercentNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Button buttonCancelAdd;
        private System.Windows.Forms.Label errorLabel;
    }
}
