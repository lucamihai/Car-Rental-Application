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
            this.sortAvailableSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.buttonSortAvailableVehicles = new System.Windows.Forms.Button();
            this.buttonRemoveSelectedAvailableCars = new System.Windows.Forms.Button();
            this.buttonAddVehicle = new System.Windows.Forms.Button();
            this.availableCarsElementsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.RentedCarsPanel = new System.Windows.Forms.Panel();
            this.sortRentedSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.buttonSortRentedVehicles = new System.Windows.Forms.Button();
            this.rentedCarsElementsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAddVehicles = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelProgramDate = new System.Windows.Forms.Label();
            this.timerProgramDateUpdater = new System.Windows.Forms.Timer(this.components);
            this.errorLabel = new System.Windows.Forms.Label();
            this.timerClearErrors = new System.Windows.Forms.Timer(this.components);
            this.buttonRemoveSelectedRentedCars = new System.Windows.Forms.Button();
            this.buttonRemoveLastRentedCar = new System.Windows.Forms.Button();
            this.AvailableCarsPanel.SuspendLayout();
            this.RentedCarsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableCarsPanel
            // 
            this.AvailableCarsPanel.Controls.Add(this.sortAvailableSelectionComboBox);
            this.AvailableCarsPanel.Controls.Add(this.buttonSortAvailableVehicles);
            this.AvailableCarsPanel.Controls.Add(this.buttonRemoveSelectedAvailableCars);
            this.AvailableCarsPanel.Controls.Add(this.buttonAddVehicle);
            this.AvailableCarsPanel.Controls.Add(this.availableCarsElementsPanel);
            this.AvailableCarsPanel.Controls.Add(this.button1);
            this.AvailableCarsPanel.Location = new System.Drawing.Point(12, 65);
            this.AvailableCarsPanel.Name = "AvailableCarsPanel";
            this.AvailableCarsPanel.Size = new System.Drawing.Size(573, 611);
            this.AvailableCarsPanel.TabIndex = 0;
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
            this.sortAvailableSelectionComboBox.Location = new System.Drawing.Point(142, 6);
            this.sortAvailableSelectionComboBox.Name = "sortAvailableSelectionComboBox";
            this.sortAvailableSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.sortAvailableSelectionComboBox.TabIndex = 9;
            // 
            // buttonSortAvailableVehicles
            // 
            this.buttonSortAvailableVehicles.Location = new System.Drawing.Point(61, 4);
            this.buttonSortAvailableVehicles.Name = "buttonSortAvailableVehicles";
            this.buttonSortAvailableVehicles.Size = new System.Drawing.Size(75, 23);
            this.buttonSortAvailableVehicles.TabIndex = 8;
            this.buttonSortAvailableVehicles.Text = "Sort";
            this.buttonSortAvailableVehicles.UseVisualStyleBackColor = true;
            this.buttonSortAvailableVehicles.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // buttonRemoveSelectedAvailableCars
            // 
            this.buttonRemoveSelectedAvailableCars.Location = new System.Drawing.Point(142, 577);
            this.buttonRemoveSelectedAvailableCars.Name = "buttonRemoveSelectedAvailableCars";
            this.buttonRemoveSelectedAvailableCars.Size = new System.Drawing.Size(103, 25);
            this.buttonRemoveSelectedAvailableCars.TabIndex = 7;
            this.buttonRemoveSelectedAvailableCars.Text = "Remove Selected";
            this.buttonRemoveSelectedAvailableCars.UseVisualStyleBackColor = true;
            this.buttonRemoveSelectedAvailableCars.Click += new System.EventHandler(this.buttonRemoveSelectedAvailableCars_Click);
            // 
            // buttonAddVehicle
            // 
            this.buttonAddVehicle.Location = new System.Drawing.Point(61, 577);
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
            this.availableCarsElementsPanel.Size = new System.Drawing.Size(570, 502);
            this.availableCarsElementsPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 577);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Remove last";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RentedCarsPanel
            // 
            this.RentedCarsPanel.Controls.Add(this.buttonRemoveSelectedRentedCars);
            this.RentedCarsPanel.Controls.Add(this.sortRentedSelectionComboBox);
            this.RentedCarsPanel.Controls.Add(this.buttonSortRentedVehicles);
            this.RentedCarsPanel.Controls.Add(this.buttonRemoveLastRentedCar);
            this.RentedCarsPanel.Controls.Add(this.rentedCarsElementsPanel);
            this.RentedCarsPanel.Location = new System.Drawing.Point(607, 65);
            this.RentedCarsPanel.Name = "RentedCarsPanel";
            this.RentedCarsPanel.Size = new System.Drawing.Size(747, 611);
            this.RentedCarsPanel.TabIndex = 1;
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
            this.sortRentedSelectionComboBox.Location = new System.Drawing.Point(92, 6);
            this.sortRentedSelectionComboBox.Name = "sortRentedSelectionComboBox";
            this.sortRentedSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.sortRentedSelectionComboBox.TabIndex = 11;
            // 
            // buttonSortRentedVehicles
            // 
            this.buttonSortRentedVehicles.Location = new System.Drawing.Point(11, 4);
            this.buttonSortRentedVehicles.Name = "buttonSortRentedVehicles";
            this.buttonSortRentedVehicles.Size = new System.Drawing.Size(75, 23);
            this.buttonSortRentedVehicles.TabIndex = 10;
            this.buttonSortRentedVehicles.Text = "Sort";
            this.buttonSortRentedVehicles.UseVisualStyleBackColor = true;
            this.buttonSortRentedVehicles.Click += new System.EventHandler(this.buttonSortRentedVehicles_Click);
            // 
            // rentedCarsElementsPanel
            // 
            this.rentedCarsElementsPanel.AutoScroll = true;
            this.rentedCarsElementsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rentedCarsElementsPanel.Location = new System.Drawing.Point(0, 68);
            this.rentedCarsElementsPanel.Name = "rentedCarsElementsPanel";
            this.rentedCarsElementsPanel.Size = new System.Drawing.Size(722, 501);
            this.rentedCarsElementsPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Availbale Cars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(891, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rented cars";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.localFileToolStripMenuItem});
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
            this.saveToDatabaseToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // loadFromDatabaseToolStripMenuItem
            // 
            this.loadFromDatabaseToolStripMenuItem.Name = "loadFromDatabaseToolStripMenuItem";
            this.loadFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.loadFromDatabaseToolStripMenuItem.Text = "Load from database";
            // 
            // saveToDatabaseToolStripMenuItem
            // 
            this.saveToDatabaseToolStripMenuItem.Name = "saveToDatabaseToolStripMenuItem";
            this.saveToDatabaseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveToDatabaseToolStripMenuItem.Text = "Save to database";
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelProgramDate
            // 
            this.labelProgramDate.AutoSize = true;
            this.labelProgramDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgramDate.Location = new System.Drawing.Point(1089, 27);
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
            this.errorLabel.Location = new System.Drawing.Point(491, 38);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 16);
            this.errorLabel.TabIndex = 10;
            // 
            // timerClearErrors
            // 
            this.timerClearErrors.Interval = 3000;
            this.timerClearErrors.Tick += new System.EventHandler(this.timerClearErrors_Tick);
            // 
            // buttonRemoveSelectedRentedCars
            // 
            this.buttonRemoveSelectedRentedCars.Location = new System.Drawing.Point(141, 577);
            this.buttonRemoveSelectedRentedCars.Name = "buttonRemoveSelectedRentedCars";
            this.buttonRemoveSelectedRentedCars.Size = new System.Drawing.Size(103, 25);
            this.buttonRemoveSelectedRentedCars.TabIndex = 12;
            this.buttonRemoveSelectedRentedCars.Text = "Remove Selected";
            this.buttonRemoveSelectedRentedCars.UseVisualStyleBackColor = true;
            this.buttonRemoveSelectedRentedCars.Click += new System.EventHandler(this.buttonRemoveSelectedRentedCars_Click);
            // 
            // buttonRemoveLastRentedCar
            // 
            this.buttonRemoveLastRentedCar.Location = new System.Drawing.Point(262, 577);
            this.buttonRemoveLastRentedCar.Name = "buttonRemoveLastRentedCar";
            this.buttonRemoveLastRentedCar.Size = new System.Drawing.Size(98, 25);
            this.buttonRemoveLastRentedCar.TabIndex = 10;
            this.buttonRemoveLastRentedCar.Text = "Remove last";
            this.buttonRemoveLastRentedCar.UseVisualStyleBackColor = true;
            this.buttonRemoveLastRentedCar.Click += new System.EventHandler(this.buttonRemoveLastRentedCar_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1392, 753);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.labelProgramDate);
            this.Controls.Add(this.panelAddVehicles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RentedCarsPanel);
            this.Controls.Add(this.AvailableCarsPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Car rental";
            this.AvailableCarsPanel.ResumeLayout(false);
            this.RentedCarsPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelAddVehicles;
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox sortRentedSelectionComboBox;
        private System.Windows.Forms.Button buttonSortRentedVehicles;
        private System.Windows.Forms.Label labelProgramDate;
        private System.Windows.Forms.Timer timerProgramDateUpdater;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Timer timerClearErrors;
        private System.Windows.Forms.Button buttonRemoveSelectedRentedCars;
        private System.Windows.Forms.Button buttonRemoveLastRentedCar;
    }
}

