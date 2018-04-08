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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToLocalFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelProgramDate = new System.Windows.Forms.Label();
            this.AvailableCarsPanel.SuspendLayout();
            this.RentedCarsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.AvailableCarsPanel.Location = new System.Drawing.Point(12, 65);
            this.AvailableCarsPanel.Name = "AvailableCarsPanel";
            this.AvailableCarsPanel.Size = new System.Drawing.Size(573, 611);
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
            this.button1.Location = new System.Drawing.Point(438, 577);
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
            this.RentedCarsPanel.Location = new System.Drawing.Point(607, 65);
            this.RentedCarsPanel.Name = "RentedCarsPanel";
            this.RentedCarsPanel.Size = new System.Drawing.Size(668, 611);
            this.RentedCarsPanel.TabIndex = 1;
            // 
            // rentedCarsElementsPanel
            // 
            this.rentedCarsElementsPanel.AutoScroll = true;
            this.rentedCarsElementsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.rentedCarsElementsPanel.Location = new System.Drawing.Point(0, 68);
            this.rentedCarsElementsPanel.Name = "rentedCarsElementsPanel";
            this.rentedCarsElementsPanel.Size = new System.Drawing.Size(654, 501);
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
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.localFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
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
            this.loadFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadFromDatabaseToolStripMenuItem.Text = "Load from database";
            // 
            // saveToDatabaseToolStripMenuItem
            // 
            this.saveToDatabaseToolStripMenuItem.Name = "saveToDatabaseToolStripMenuItem";
            this.saveToDatabaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // 
            // saveToLocalFileToolStripMenuItem
            // 
            this.saveToLocalFileToolStripMenuItem.Name = "saveToLocalFileToolStripMenuItem";
            this.saveToLocalFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveToLocalFileToolStripMenuItem.Text = "Save to local file";
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.labelProgramDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelAddVehicles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RentedCarsPanel);
            this.Controls.Add(this.AvailableCarsPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Car rental";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel availableCarsElementsPanel;
        private System.Windows.Forms.Button buttonAddVehicle;
        private System.Windows.Forms.Panel panelAddVehicles;
        private System.Windows.Forms.Button buttonRemoveSelectedAvailableCars;
        private System.Windows.Forms.Panel rentedCarsElementsPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ComboBox SortSelectionComboBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromLocalFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToLocalFileToolStripMenuItem;
        private System.Windows.Forms.Label labelProgramDate;
    }
}

