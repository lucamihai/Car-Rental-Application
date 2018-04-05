namespace Car_Rental_Application
{
    partial class MainWindow
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
            this.AvailableCarsPanel = new System.Windows.Forms.Panel();
            this.RentedCarsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.availableCarsGridView = new System.Windows.Forms.DataGridView();
            this.VehicleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentedCarsGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.RentedVehicleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentedVehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableCarsPanel.SuspendLayout();
            this.RentedCarsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableCarsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentedCarsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AvailableCarsPanel
            // 
            this.AvailableCarsPanel.Controls.Add(this.availableCarsGridView);
            this.AvailableCarsPanel.Location = new System.Drawing.Point(46, 40);
            this.AvailableCarsPanel.Name = "AvailableCarsPanel";
            this.AvailableCarsPanel.Size = new System.Drawing.Size(444, 611);
            this.AvailableCarsPanel.TabIndex = 0;
            // 
            // RentedCarsPanel
            // 
            this.RentedCarsPanel.Controls.Add(this.rentedCarsGridView);
            this.RentedCarsPanel.Location = new System.Drawing.Point(617, 40);
            this.RentedCarsPanel.Name = "RentedCarsPanel";
            this.RentedCarsPanel.Size = new System.Drawing.Size(635, 611);
            this.RentedCarsPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Availbale Cars";
            // 
            // availableCarsGridView
            // 
            this.availableCarsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableCarsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VehicleName,
            this.VehicleType,
            this.Damage,
            this.FuelLevel});
            this.availableCarsGridView.Location = new System.Drawing.Point(3, 51);
            this.availableCarsGridView.Name = "availableCarsGridView";
            this.availableCarsGridView.Size = new System.Drawing.Size(438, 560);
            this.availableCarsGridView.TabIndex = 0;
            // 
            // VehicleName
            // 
            this.VehicleName.HeaderText = "Vehicle Name";
            this.VehicleName.Name = "VehicleName";
            // 
            // VehicleType
            // 
            this.VehicleType.HeaderText = "Vehicle Type";
            this.VehicleType.Name = "VehicleType";
            // 
            // Damage
            // 
            this.Damage.HeaderText = "Damage";
            this.Damage.Name = "Damage";
            // 
            // FuelLevel
            // 
            this.FuelLevel.HeaderText = "Fuel level";
            this.FuelLevel.Name = "FuelLevel";
            // 
            // rentedCarsGridView
            // 
            this.rentedCarsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentedCarsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RentedVehicleName,
            this.RentedVehicleType,
            this.Owner,
            this.OwnerPhoneNumber,
            this.ReturnDate});
            this.rentedCarsGridView.Location = new System.Drawing.Point(4, 51);
            this.rentedCarsGridView.Name = "rentedCarsGridView";
            this.rentedCarsGridView.Size = new System.Drawing.Size(542, 560);
            this.rentedCarsGridView.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(888, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rented cars";
            // 
            // RentedVehicleName
            // 
            this.RentedVehicleName.HeaderText = "Vehicle Name";
            this.RentedVehicleName.Name = "RentedVehicleName";
            // 
            // RentedVehicleType
            // 
            this.RentedVehicleType.HeaderText = "Vehicle Type";
            this.RentedVehicleType.Name = "RentedVehicleType";
            // 
            // Owner
            // 
            this.Owner.HeaderText = "Owner";
            this.Owner.Name = "Owner";
            // 
            // OwnerPhoneNumber
            // 
            this.OwnerPhoneNumber.HeaderText = "Owner\'s phone number";
            this.OwnerPhoneNumber.Name = "OwnerPhoneNumber";
            // 
            // ReturnDate
            // 
            this.ReturnDate.HeaderText = "Return date";
            this.ReturnDate.Name = "ReturnDate";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RentedCarsPanel);
            this.Controls.Add(this.AvailableCarsPanel);
            this.Name = "MainWindow";
            this.Text = "Car rental";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AvailableCarsPanel.ResumeLayout(false);
            this.RentedCarsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.availableCarsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentedCarsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AvailableCarsPanel;
        private System.Windows.Forms.Panel RentedCarsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView availableCarsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelLevel;
        private System.Windows.Forms.DataGridView rentedCarsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentedVehicleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentedVehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDate;
        private System.Windows.Forms.Label label2;
    }
}

