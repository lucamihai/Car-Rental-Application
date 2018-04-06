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
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.availableCarsElementsPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RentedCarsPanel = new System.Windows.Forms.Panel();
            this.rentedCarsGridView = new System.Windows.Forms.DataGridView();
            this.RentedVehicleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentedVehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AvailableCarsPanel.SuspendLayout();
            this.RentedCarsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rentedCarsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AvailableCarsPanel
            // 
            this.AvailableCarsPanel.Controls.Add(this.buttonAddVehicle);
            this.AvailableCarsPanel.Controls.Add(this.availableCarsElementsPanel);
            this.AvailableCarsPanel.Controls.Add(this.button2);
            this.AvailableCarsPanel.Controls.Add(this.button1);
            this.AvailableCarsPanel.Location = new System.Drawing.Point(12, 25);
            this.AvailableCarsPanel.Name = "AvailableCarsPanel";
            this.AvailableCarsPanel.Size = new System.Drawing.Size(521, 632);
            this.AvailableCarsPanel.TabIndex = 0;
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(111, 587);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVehicle.TabIndex = 6;
            this.buttonAddVehicle.Text = "Add...";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            // 
            // availableCarsElementsPanel
            // 
            this.availableCarsElementsPanel.AutoScroll = true;
            this.availableCarsElementsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.availableCarsElementsPanel.Location = new System.Drawing.Point(0, 31);
            this.availableCarsElementsPanel.Name = "availableCarsElementsPanel";
            this.availableCarsElementsPanel.Size = new System.Drawing.Size(512, 529);
            this.availableCarsElementsPanel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 585);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add Minivan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 584);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RentedCarsPanel
            // 
            this.RentedCarsPanel.Controls.Add(this.rentedCarsGridView);
            this.RentedCarsPanel.Location = new System.Drawing.Point(617, 25);
            this.RentedCarsPanel.Name = "RentedCarsPanel";
            this.RentedCarsPanel.Size = new System.Drawing.Size(635, 611);
            this.RentedCarsPanel.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Availbale Cars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(890, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rented cars";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "debugging label";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RentedCarsPanel);
            this.Controls.Add(this.AvailableCarsPanel);
            this.Name = "MainWindow";
            this.Text = "Car rental";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AvailableCarsPanel.ResumeLayout(false);
            this.RentedCarsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rentedCarsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AvailableCarsPanel;
        private System.Windows.Forms.Panel RentedCarsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView rentedCarsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentedVehicleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentedVehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel availableCarsElementsPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAddVehicle;
    }
}

