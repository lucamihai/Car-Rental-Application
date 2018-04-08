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
            this.SortSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonRemoveSelectedAvailableCars = new System.Windows.Forms.Button();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.availableCarsElementsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.RentedCarsPanel = new System.Windows.Forms.Panel();
            this.rentedCarsElementsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelAddVehicles = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.AvailableCarsPanel.SuspendLayout();
            this.RentedCarsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableCarsPanel
            // 
            this.AvailableCarsPanel.Controls.Add(this.SortSelectionComboBox);
            this.AvailableCarsPanel.Controls.Add(this.buttonSort);
            this.AvailableCarsPanel.Controls.Add(this.buttonRemoveSelectedAvailableCars);
            this.AvailableCarsPanel.Controls.Add(this.buttonAddVehicle);
            this.AvailableCarsPanel.Controls.Add(this.availableCarsElementsPanel);
            this.AvailableCarsPanel.Controls.Add(this.button1);
            this.AvailableCarsPanel.Location = new System.Drawing.Point(12, 44);
            this.AvailableCarsPanel.Name = "AvailableCarsPanel";
            this.AvailableCarsPanel.Size = new System.Drawing.Size(573, 632);
            this.AvailableCarsPanel.TabIndex = 0;
            // 
            // SortSelectionComboBox
            // 
            this.SortSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortSelectionComboBox.FormattingEnabled = true;
            this.SortSelectionComboBox.Items.AddRange(new object[] {
            "By ID",
            "By name",
            "By type",
            "By fuel percentage",
            "By damage percentage"});
            this.SortSelectionComboBox.Location = new System.Drawing.Point(142, 6);
            this.SortSelectionComboBox.Name = "SortSelectionComboBox";
            this.SortSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.SortSelectionComboBox.TabIndex = 9;
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(61, 4);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 8;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // buttonRemoveSelectedAvailableCars
            // 
            this.buttonRemoveSelectedAvailableCars.Location = new System.Drawing.Point(142, 600);
            this.buttonRemoveSelectedAvailableCars.Name = "buttonRemoveSelectedAvailableCars";
            this.buttonRemoveSelectedAvailableCars.Size = new System.Drawing.Size(103, 25);
            this.buttonRemoveSelectedAvailableCars.TabIndex = 7;
            this.buttonRemoveSelectedAvailableCars.Text = "Remove Selected";
            this.buttonRemoveSelectedAvailableCars.UseVisualStyleBackColor = true;
            this.buttonRemoveSelectedAvailableCars.Click += new System.EventHandler(this.buttonRemoveSelectedAvailableCars_Click);
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(61, 600);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(56, 25);
            this.buttonAddVehicle.TabIndex = 6;
            this.buttonAddVehicle.Text = "Add...";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.buttonAddVehicle_Click);
            // 
            // availableCarsElementsPanel
            // 
            this.availableCarsElementsPanel.AutoScroll = true;
            this.availableCarsElementsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.availableCarsElementsPanel.Location = new System.Drawing.Point(0, 67);
            this.availableCarsElementsPanel.Name = "availableCarsElementsPanel";
            this.availableCarsElementsPanel.Size = new System.Drawing.Size(570, 529);
            this.availableCarsElementsPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 600);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RentedCarsPanel
            // 
            this.RentedCarsPanel.Controls.Add(this.rentedCarsElementsPanel);
            this.RentedCarsPanel.Location = new System.Drawing.Point(607, 44);
            this.RentedCarsPanel.Name = "RentedCarsPanel";
            this.RentedCarsPanel.Size = new System.Drawing.Size(668, 632);
            this.RentedCarsPanel.TabIndex = 1;
            // 
            // rentedCarsElementsPanel
            // 
            this.rentedCarsElementsPanel.AutoScroll = true;
            this.rentedCarsElementsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rentedCarsElementsPanel.Location = new System.Drawing.Point(0, 68);
            this.rentedCarsElementsPanel.Name = "rentedCarsElementsPanel";
            this.rentedCarsElementsPanel.Size = new System.Drawing.Size(654, 529);
            this.rentedCarsElementsPanel.TabIndex = 1;
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
            this.label3.Location = new System.Drawing.Point(571, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "debugging label";
            // 
            // panelAddVehicles
            // 
            this.panelAddVehicles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAddVehicles.Location = new System.Drawing.Point(450, 235);
            this.panelAddVehicles.Name = "panelAddVehicles";
            this.panelAddVehicles.Size = new System.Drawing.Size(325, 250);
            this.panelAddVehicles.TabIndex = 5;
            this.panelAddVehicles.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "debugging label";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelAddVehicles);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AvailableCarsPanel;
        private System.Windows.Forms.Panel RentedCarsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel availableCarsElementsPanel;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Panel panelAddVehicles;
        private System.Windows.Forms.Button buttonRemoveSelectedAvailableCars;
        private System.Windows.Forms.Panel rentedCarsElementsPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ComboBox SortSelectionComboBox;
    }
}

