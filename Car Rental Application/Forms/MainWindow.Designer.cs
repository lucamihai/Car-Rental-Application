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
            this.components = new System.ComponentModel.Container();
            this.AvailableCarsPanel = new System.Windows.Forms.Panel();
            this.buttonSelectAllAvailable = new System.Windows.Forms.Button();
            this.sortAvailableSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.buttonSortAvailableVehicles = new System.Windows.Forms.Button();
            this.buttonRemoveSelectedAvailableCars = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.availableCarsElementsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.RentedCarsPanel = new System.Windows.Forms.Panel();
            this.buttonSelectAllRented = new System.Windows.Forms.Button();
            this.buttonRemoveSelectedRentedCars = new System.Windows.Forms.Button();
            this.sortRentedSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSortRentedVehicles = new System.Windows.Forms.Button();
            this.buttonRemoveLastRentedCar = new System.Windows.Forms.Button();
            this.rentedCarsElementsPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelProgramDate = new System.Windows.Forms.Label();
            this.timerProgramDateUpdater = new System.Windows.Forms.Timer(this.components);
            this.errorLabel = new System.Windows.Forms.Label();
            this.timerClearErrors = new System.Windows.Forms.Timer(this.components);
            this.AvailableCarsPanel.SuspendLayout();
            this.RentedCarsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableCarsPanel
            // 
            this.AvailableCarsPanel.Controls.Add(this.buttonSelectAllAvailable);
            this.AvailableCarsPanel.Controls.Add(this.sortAvailableSelectionComboBox);
            this.AvailableCarsPanel.Controls.Add(this.buttonSortAvailableVehicles);
            this.AvailableCarsPanel.Controls.Add(this.buttonRemoveSelectedAvailableCars);
            this.AvailableCarsPanel.Controls.Add(this.label1);
            this.AvailableCarsPanel.Controls.Add(this.buttonAddVehicle);
            this.AvailableCarsPanel.Controls.Add(this.availableCarsElementsPanel);
            this.AvailableCarsPanel.Controls.Add(this.button1);
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
            this.buttonSelectAllAvailable.Click += new System.EventHandler(this.buttonSelectAllAvailable_Click);
            // 
            // sortAvailableSelectionComboBox
            // 
            this.sortAvailableSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortAvailableSelectionComboBox.FormattingEnabled = true;
            this.sortAvailableSelectionComboBox.Items.AddRange(new object[] {
            "By ID",
            "By name",
            "By type",
            "By fuel percentage",
            "By damage percentage"});
            this.sortAvailableSelectionComboBox.Location = new System.Drawing.Point(109, 68);
            this.sortAvailableSelectionComboBox.Name = "sortAvailableSelectionComboBox";
            this.sortAvailableSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.sortAvailableSelectionComboBox.TabIndex = 9;
            // 
            // buttonSortAvailableVehicles
            // 
            this.buttonSortAvailableVehicles.Location = new System.Drawing.Point(14, 66);
            this.buttonSortAvailableVehicles.Name = "buttonSortAvailableVehicles";
            this.buttonSortAvailableVehicles.Size = new System.Drawing.Size(75, 23);
            this.buttonSortAvailableVehicles.TabIndex = 8;
            this.buttonSortAvailableVehicles.Text = "Sort";
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
            this.buttonRemoveSelectedAvailableCars.Click += new System.EventHandler(this.RemoveSelectedAvailableVehicles);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Availbale Cars";
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(25, 614);
            this.buttonAddVehicle.Name = "buttonAddVehicle";
            this.buttonAddVehicle.Size = new System.Drawing.Size(103, 25);
            this.buttonAddVehicle.TabIndex = 6;
            this.buttonAddVehicle.Text = "Add vehicle";
            this.buttonAddVehicle.UseVisualStyleBackColor = true;
            this.buttonAddVehicle.Click += new System.EventHandler(this.buttonAddVehicle_Click);
            // 
            // availableCarsElementsPanel
            // 
            this.availableCarsElementsPanel.AutoScroll = true;
            this.availableCarsElementsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.availableCarsElementsPanel.Location = new System.Drawing.Point(0, 97);
            this.availableCarsElementsPanel.Name = "availableCarsElementsPanel";
            this.availableCarsElementsPanel.Size = new System.Drawing.Size(570, 502);
            this.availableCarsElementsPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 614);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Remove last";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RemoveLastAvailableVehicle);
            // 
            // RentedCarsPanel
            // 
            this.RentedCarsPanel.Controls.Add(this.buttonSelectAllRented);
            this.RentedCarsPanel.Controls.Add(this.buttonRemoveSelectedRentedCars);
            this.RentedCarsPanel.Controls.Add(this.sortRentedSelectionComboBox);
            this.RentedCarsPanel.Controls.Add(this.label2);
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
            this.buttonRemoveSelectedRentedCars.Click += new System.EventHandler(this.RemoveSelectedRentedVehicles);
            // 
            // sortRentedSelectionComboBox
            // 
            this.sortRentedSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortRentedSelectionComboBox.FormattingEnabled = true;
            this.sortRentedSelectionComboBox.Items.AddRange(new object[] {
            "By ID",
            "By name",
            "By type",
            "By owner name",
            "By owner phone number",
            "By return date"});
            this.sortRentedSelectionComboBox.Location = new System.Drawing.Point(111, 68);
            this.sortRentedSelectionComboBox.Name = "sortRentedSelectionComboBox";
            this.sortRentedSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.sortRentedSelectionComboBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rented cars";
            // 
            // buttonSortRentedVehicles
            // 
            this.buttonSortRentedVehicles.Location = new System.Drawing.Point(17, 66);
            this.buttonSortRentedVehicles.Name = "buttonSortRentedVehicles";
            this.buttonSortRentedVehicles.Size = new System.Drawing.Size(75, 23);
            this.buttonSortRentedVehicles.TabIndex = 10;
            this.buttonSortRentedVehicles.Text = "Sort";
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
            this.buttonRemoveLastRentedCar.Click += new System.EventHandler(this.RemoveLastRentedVehicle);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.localFileToolStripMenuItem,
            this.orderLogsToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1392, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
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
            this.timerProgramDateUpdater.Tick += new System.EventHandler(this.timerProgramDateUpdater_Tick);
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
            this.timerClearErrors.Tick += new System.EventHandler(this.timerClearErrors_Tick);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Car rental";
            this.AvailableCarsPanel.ResumeLayout(false);
            this.AvailableCarsPanel.PerformLayout();
            this.RentedCarsPanel.ResumeLayout(false);
            this.RentedCarsPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AvailableCarsPanel;
        private System.Windows.Forms.Panel RentedCarsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel availableCarsElementsPanel;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Button buttonRemoveSelectedAvailableCars;
        private System.Windows.Forms.Panel rentedCarsElementsPanel;
        private System.Windows.Forms.Button buttonSortAvailableVehicles;
        private System.Windows.Forms.ComboBox sortAvailableSelectionComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromLocalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToLocalFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox sortRentedSelectionComboBox;
        private System.Windows.Forms.Button buttonSortRentedVehicles;
        private System.Windows.Forms.Label labelProgramDate;
        private System.Windows.Forms.Timer timerProgramDateUpdater;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Timer timerClearErrors;
        private System.Windows.Forms.Button buttonRemoveSelectedRentedCars;
        private System.Windows.Forms.Button buttonRemoveLastRentedCar;
        private System.Windows.Forms.ToolStripMenuItem connectToDatabaseToolStripMenuItem;
        private System.Windows.Forms.Button buttonSelectAllAvailable;
        private System.Windows.Forms.Button buttonSelectAllRented;
        private System.Windows.Forms.ToolStripMenuItem orderLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
    }
}

