using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication
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
            this.components = new System.ComponentModel.Container();
            this.AvailableCarsPanel = new System.Windows.Forms.Panel();
            this.buttonSelectAllAvailable = new System.Windows.Forms.Button();
            this.sortVehicleSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.buttonSortAvailableVehicles = new System.Windows.Forms.Button();
            this.buttonRemoveSelectedAvailableCars = new System.Windows.Forms.Button();
            this.labelVehicles = new System.Windows.Forms.Label();
            this.buttonAddAvailableVehicle = new System.Windows.Forms.Button();
            this.vehiclesPanel = new System.Windows.Forms.Panel();
            this.buttonRemoveLastAvailableVehicle = new System.Windows.Forms.Button();
            this.RentedCarsPanel = new System.Windows.Forms.Panel();
            this.buttonSelectAllRented = new System.Windows.Forms.Button();
            this.buttonRemoveSelectedRentedCars = new System.Windows.Forms.Button();
            this.sortRentalSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.labelRentals = new System.Windows.Forms.Label();
            this.buttonSortRentedVehicles = new System.Windows.Forms.Button();
            this.buttonRemoveLastRentedCar = new System.Windows.Forms.Button();
            this.rentedCarsElementsPanel = new System.Windows.Forms.Panel();
            this.labelProgramDate = new System.Windows.Forms.Label();
            this.timerProgramDateUpdater = new System.Windows.Forms.Timer(this.components);
            this.errorLabel = new System.Windows.Forms.Label();
            this.timerClearErrors = new System.Windows.Forms.Timer(this.components);
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.AvailableCarsPanel.SuspendLayout();
            this.RentedCarsPanel.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableCarsPanel
            // 
            this.AvailableCarsPanel.Controls.Add(this.buttonSelectAllAvailable);
            this.AvailableCarsPanel.Controls.Add(this.sortVehicleSelectionComboBox);
            this.AvailableCarsPanel.Controls.Add(this.buttonSortAvailableVehicles);
            this.AvailableCarsPanel.Controls.Add(this.buttonRemoveSelectedAvailableCars);
            this.AvailableCarsPanel.Controls.Add(this.labelVehicles);
            this.AvailableCarsPanel.Controls.Add(this.buttonAddAvailableVehicle);
            this.AvailableCarsPanel.Controls.Add(this.vehiclesPanel);
            this.AvailableCarsPanel.Controls.Add(this.buttonRemoveLastAvailableVehicle);
            this.AvailableCarsPanel.Location = new System.Drawing.Point(32, 65);
            this.AvailableCarsPanel.Name = "AvailableCarsPanel";
            this.AvailableCarsPanel.Size = new System.Drawing.Size(573, 650);
            this.AvailableCarsPanel.TabIndex = 0;
            // 
            // buttonSelectAllAvailable
            // 
            this.buttonSelectAllAvailable.Location = new System.Drawing.Point(434, 614);
            this.buttonSelectAllAvailable.Name = "buttonSelectAllAvailable";
            this.buttonSelectAllAvailable.Size = new System.Drawing.Size(103, 25);
            this.buttonSelectAllAvailable.TabIndex = 10;
            this.buttonSelectAllAvailable.Text = "Select All";
            this.buttonSelectAllAvailable.UseVisualStyleBackColor = true;
            this.buttonSelectAllAvailable.Click += new System.EventHandler(this.SelectAllVehicles);
            // 
            // sortVehicleSelectionComboBox
            // 
            this.sortVehicleSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortVehicleSelectionComboBox.FormattingEnabled = true;
            this.sortVehicleSelectionComboBox.Location = new System.Drawing.Point(109, 68);
            this.sortVehicleSelectionComboBox.Name = "sortVehicleSelectionComboBox";
            this.sortVehicleSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.sortVehicleSelectionComboBox.TabIndex = 9;
            // 
            // buttonSortAvailableVehicles
            // 
            this.buttonSortAvailableVehicles.Location = new System.Drawing.Point(14, 66);
            this.buttonSortAvailableVehicles.Name = "buttonSortAvailableVehicles";
            this.buttonSortAvailableVehicles.Size = new System.Drawing.Size(75, 23);
            this.buttonSortAvailableVehicles.TabIndex = 8;
            this.buttonSortAvailableVehicles.Text = "Sort by";
            this.buttonSortAvailableVehicles.UseVisualStyleBackColor = true;
            this.buttonSortAvailableVehicles.Click += new System.EventHandler(this.SortAvailableVehicles);
            // 
            // buttonRemoveSelectedAvailableCars
            // 
            this.buttonRemoveSelectedAvailableCars.Location = new System.Drawing.Point(160, 614);
            this.buttonRemoveSelectedAvailableCars.Name = "buttonRemoveSelectedAvailableCars";
            this.buttonRemoveSelectedAvailableCars.Size = new System.Drawing.Size(103, 25);
            this.buttonRemoveSelectedAvailableCars.TabIndex = 7;
            this.buttonRemoveSelectedAvailableCars.Text = "Remove Selected";
            this.buttonRemoveSelectedAvailableCars.UseVisualStyleBackColor = true;
            this.buttonRemoveSelectedAvailableCars.Click += new System.EventHandler(this.RemoveSelectedVehicles);
            // 
            // labelAvailableVehicles
            // 
            this.labelVehicles.AutoSize = true;
            this.labelVehicles.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicles.Location = new System.Drawing.Point(215, 2);
            this.labelVehicles.Name = "labelAvailableVehicles";
            this.labelVehicles.Size = new System.Drawing.Size(108, 33);
            this.labelVehicles.TabIndex = 0;
            this.labelVehicles.Text = "Vehicles";
            // 
            // buttonAddAvailableVehicle
            // 
            this.buttonAddAvailableVehicle.Location = new System.Drawing.Point(25, 614);
            this.buttonAddAvailableVehicle.Name = "buttonAddAvailableVehicle";
            this.buttonAddAvailableVehicle.Size = new System.Drawing.Size(103, 25);
            this.buttonAddAvailableVehicle.TabIndex = 6;
            this.buttonAddAvailableVehicle.Text = "Add vehicle";
            this.buttonAddAvailableVehicle.UseVisualStyleBackColor = true;
            this.buttonAddAvailableVehicle.Click += new System.EventHandler(this.AddVehicleForm);
            // 
            // vehiclesPanel
            // 
            this.vehiclesPanel.AutoScroll = true;
            this.vehiclesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.vehiclesPanel.Location = new System.Drawing.Point(0, 97);
            this.vehiclesPanel.Name = "vehiclesPanel";
            this.vehiclesPanel.Size = new System.Drawing.Size(570, 502);
            this.vehiclesPanel.TabIndex = 0;
            // 
            // buttonRemoveLastAvailableVehicle
            // 
            this.buttonRemoveLastAvailableVehicle.Location = new System.Drawing.Point(296, 614);
            this.buttonRemoveLastAvailableVehicle.Name = "buttonRemoveLastAvailableVehicle";
            this.buttonRemoveLastAvailableVehicle.Size = new System.Drawing.Size(103, 25);
            this.buttonRemoveLastAvailableVehicle.TabIndex = 3;
            this.buttonRemoveLastAvailableVehicle.Text = "Remove last";
            this.buttonRemoveLastAvailableVehicle.UseVisualStyleBackColor = true;
            this.buttonRemoveLastAvailableVehicle.Click += new System.EventHandler(this.RemoveLastVehicle);
            // 
            // RentedCarsPanel
            // 
            this.RentedCarsPanel.Controls.Add(this.buttonSelectAllRented);
            this.RentedCarsPanel.Controls.Add(this.buttonRemoveSelectedRentedCars);
            this.RentedCarsPanel.Controls.Add(this.sortRentalSelectionComboBox);
            this.RentedCarsPanel.Controls.Add(this.labelRentals);
            this.RentedCarsPanel.Controls.Add(this.buttonSortRentedVehicles);
            this.RentedCarsPanel.Controls.Add(this.buttonRemoveLastRentedCar);
            this.RentedCarsPanel.Controls.Add(this.rentedCarsElementsPanel);
            this.RentedCarsPanel.Location = new System.Drawing.Point(627, 65);
            this.RentedCarsPanel.Name = "RentedCarsPanel";
            this.RentedCarsPanel.Size = new System.Drawing.Size(725, 650);
            this.RentedCarsPanel.TabIndex = 1;
            // 
            // buttonSelectAllRented
            // 
            this.buttonSelectAllRented.Location = new System.Drawing.Point(431, 615);
            this.buttonSelectAllRented.Name = "buttonSelectAllRented";
            this.buttonSelectAllRented.Size = new System.Drawing.Size(103, 23);
            this.buttonSelectAllRented.TabIndex = 11;
            this.buttonSelectAllRented.Text = "Select All";
            this.buttonSelectAllRented.UseVisualStyleBackColor = true;
            this.buttonSelectAllRented.Click += new System.EventHandler(this.buttonSelectAllRented_Click);
            // 
            // buttonRemoveSelectedRentedCars
            // 
            this.buttonRemoveSelectedRentedCars.Location = new System.Drawing.Point(148, 614);
            this.buttonRemoveSelectedRentedCars.Name = "buttonRemoveSelectedRentedCars";
            this.buttonRemoveSelectedRentedCars.Size = new System.Drawing.Size(103, 25);
            this.buttonRemoveSelectedRentedCars.TabIndex = 12;
            this.buttonRemoveSelectedRentedCars.Text = "Remove Selected";
            this.buttonRemoveSelectedRentedCars.UseVisualStyleBackColor = true;
            this.buttonRemoveSelectedRentedCars.Click += new System.EventHandler(this.RemoveSelectedRentals);
            // 
            // sortRentalSelectionComboBox
            // 
            this.sortRentalSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortRentalSelectionComboBox.FormattingEnabled = true;
            this.sortRentalSelectionComboBox.Location = new System.Drawing.Point(111, 68);
            this.sortRentalSelectionComboBox.Name = "sortRentalSelectionComboBox";
            this.sortRentalSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.sortRentalSelectionComboBox.TabIndex = 11;
            // 
            // labelRentedVehicles
            // 
            this.labelRentals.AutoSize = true;
            this.labelRentals.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRentals.Location = new System.Drawing.Point(298, 2);
            this.labelRentals.Name = "labelRentedVehicles";
            this.labelRentals.Size = new System.Drawing.Size(98, 33);
            this.labelRentals.TabIndex = 2;
            this.labelRentals.Text = "Rentals";
            // 
            // buttonSortRentedVehicles
            // 
            this.buttonSortRentedVehicles.Location = new System.Drawing.Point(17, 66);
            this.buttonSortRentedVehicles.Name = "buttonSortRentedVehicles";
            this.buttonSortRentedVehicles.Size = new System.Drawing.Size(75, 23);
            this.buttonSortRentedVehicles.TabIndex = 10;
            this.buttonSortRentedVehicles.Text = "Sort by";
            this.buttonSortRentedVehicles.UseVisualStyleBackColor = true;
            this.buttonSortRentedVehicles.Click += new System.EventHandler(this.SortRentedVehicles);
            // 
            // buttonRemoveLastRentedCar
            // 
            this.buttonRemoveLastRentedCar.Location = new System.Drawing.Point(293, 614);
            this.buttonRemoveLastRentedCar.Name = "buttonRemoveLastRentedCar";
            this.buttonRemoveLastRentedCar.Size = new System.Drawing.Size(103, 25);
            this.buttonRemoveLastRentedCar.TabIndex = 10;
            this.buttonRemoveLastRentedCar.Text = "Remove last";
            this.buttonRemoveLastRentedCar.UseVisualStyleBackColor = true;
            this.buttonRemoveLastRentedCar.Click += new System.EventHandler(this.RemoveLastRental);
            // 
            // rentedCarsElementsPanel
            // 
            this.rentedCarsElementsPanel.AutoScroll = true;
            this.rentedCarsElementsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rentedCarsElementsPanel.Location = new System.Drawing.Point(0, 97);
            this.rentedCarsElementsPanel.Name = "rentedCarsElementsPanel";
            this.rentedCarsElementsPanel.Size = new System.Drawing.Size(722, 501);
            this.rentedCarsElementsPanel.TabIndex = 1;
            // 
            // labelProgramDate
            // 
            this.labelProgramDate.AutoSize = true;
            this.labelProgramDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgramDate.Location = new System.Drawing.Point(1109, 27);
            this.labelProgramDate.Name = "labelProgramDate";
            this.labelProgramDate.Size = new System.Drawing.Size(91, 19);
            this.labelProgramDate.TabIndex = 9;
            this.labelProgramDate.Text = "Program date";
            // 
            // timerProgramDateUpdater
            // 
            this.timerProgramDateUpdater.Interval = 1000;
            this.timerProgramDateUpdater.Tick += new System.EventHandler(this.ProgramDateTick);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.Black;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(410, 46);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(81, 16);
            this.errorLabel.TabIndex = 10;
            this.errorLabel.Text = "Error label";
            // 
            // timerClearErrors
            // 
            this.timerClearErrors.Interval = 5000;
            this.timerClearErrors.Tick += new System.EventHandler(this.ClearErrorsTick);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromDatabaseToolStripMenuItem,
            this.saveToDatabaseToolStripMenuItem,
            this.connectToDatabaseToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // loadFromDatabaseToolStripMenuItem
            // 
            this.loadFromDatabaseToolStripMenuItem.Name = "loadFromDatabaseToolStripMenuItem";
            this.loadFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadFromDatabaseToolStripMenuItem.Text = "Load from database";
            this.loadFromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.loadFromDatabaseToolStripMenuItem_Click);
            // 
            // saveToDatabaseToolStripMenuItem
            // 
            this.saveToDatabaseToolStripMenuItem.Name = "saveToDatabaseToolStripMenuItem";
            this.saveToDatabaseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveToDatabaseToolStripMenuItem.Text = "Save to database";
            this.saveToDatabaseToolStripMenuItem.Click += new System.EventHandler(this.saveToDatabaseToolStripMenuItem_Click);
            // 
            // connectToDatabaseToolStripMenuItem
            // 
            this.connectToDatabaseToolStripMenuItem.Name = "connectToDatabaseToolStripMenuItem";
            this.connectToDatabaseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.connectToDatabaseToolStripMenuItem.Text = "Connect to database";
            this.connectToDatabaseToolStripMenuItem.Click += new System.EventHandler(this.connectToDatabaseToolStripMenuItem_Click);
            // 
            // localFileToolStripMenuItem
            // 
            this.localFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromLocalFileToolStripMenuItem,
            this.saveToLocalFileToolStripMenuItem});
            this.localFileToolStripMenuItem.Name = "localFileToolStripMenuItem";
            this.localFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.localFileToolStripMenuItem.Text = "Local file";
            // 
            // loadFromLocalFileToolStripMenuItem
            // 
            this.loadFromLocalFileToolStripMenuItem.Name = "loadFromLocalFileToolStripMenuItem";
            this.loadFromLocalFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.loadFromLocalFileToolStripMenuItem.Text = "Load from local file";
            this.loadFromLocalFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromLocalFileToolStripMenuItem_Click);
            // 
            // saveToLocalFileToolStripMenuItem
            // 
            this.saveToLocalFileToolStripMenuItem.Name = "saveToLocalFileToolStripMenuItem";
            this.saveToLocalFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveToLocalFileToolStripMenuItem.Text = "Save to local file";
            this.saveToLocalFileToolStripMenuItem.Click += new System.EventHandler(this.saveToLocalFileToolStripMenuItem_Click);
            // 
            // orderLogsToolStripMenuItem
            // 
            this.orderLogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.orderLogsToolStripMenuItem.Name = "orderLogsToolStripMenuItem";
            this.orderLogsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.orderLogsToolStripMenuItem.Text = "Order logs";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            this.languageToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.localFileToolStripMenuItem,
            this.orderLogsToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1392, 24);
            this.mainMenuStrip.TabIndex = 7;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1392, 753);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.labelProgramDate);
            this.Controls.Add(this.RentedCarsPanel);
            this.Controls.Add(this.AvailableCarsPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainWindow";
            this.Text = "Car rental";
            this.AvailableCarsPanel.ResumeLayout(false);
            this.AvailableCarsPanel.PerformLayout();
            this.RentedCarsPanel.ResumeLayout(false);
            this.RentedCarsPanel.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AvailableCarsPanel;
        private System.Windows.Forms.Panel RentedCarsPanel;
        private System.Windows.Forms.Label labelVehicles;
        private System.Windows.Forms.Label labelRentals;
        private System.Windows.Forms.Button buttonRemoveLastAvailableVehicle;
        private System.Windows.Forms.Panel vehiclesPanel;
        private System.Windows.Forms.Button buttonAddAvailableVehicle;
        private System.Windows.Forms.Button buttonRemoveSelectedAvailableCars;
        private System.Windows.Forms.Panel rentedCarsElementsPanel;
        private System.Windows.Forms.Button buttonSortAvailableVehicles;
        private System.Windows.Forms.ComboBox sortVehicleSelectionComboBox;
        private System.Windows.Forms.ComboBox sortRentalSelectionComboBox;
        private System.Windows.Forms.Button buttonSortRentedVehicles;
        private System.Windows.Forms.Label labelProgramDate;
        private System.Windows.Forms.Timer timerProgramDateUpdater;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Timer timerClearErrors;
        private System.Windows.Forms.Button buttonRemoveSelectedRentedCars;
        private System.Windows.Forms.Button buttonRemoveLastRentedCar;
        private System.Windows.Forms.Button buttonSelectAllAvailable;
        private System.Windows.Forms.Button buttonSelectAllRented;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromLocalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToLocalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
    }
}

