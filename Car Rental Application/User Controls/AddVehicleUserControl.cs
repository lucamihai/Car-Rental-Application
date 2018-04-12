using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Application.User_Controls
{
    public partial class AddVehicleUserControl : UserControl
    {
        MainWindow mainWindow;
        public AddVehicleUserControl()
        {
            InitializeComponent();
        }
        public AddVehicleUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        #region Fuel and damage percentage control

        private void fuelPercentNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Value < 0) ((NumericUpDown)sender).Value = 0;
            if (((NumericUpDown)sender).Value > 100) ((NumericUpDown)sender).Value = 100;
        }

        private void damagePercentNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Value < 0) ((NumericUpDown)sender).Value = 0;
            if (((NumericUpDown)sender).Value > 100) ((NumericUpDown)sender).Value = 100;
        }

        #endregion
        #region Vehicle type control

        private void sedanTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sedanTypeCheckBox.Checked == true && minivanTypeCheckBox.Checked == true) minivanTypeCheckBox.Checked = false;
            if (sedanTypeCheckBox.Checked == false && minivanTypeCheckBox.Checked == false) sedanTypeCheckBox.Checked = true;
        }

        private void minivanTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sedanTypeCheckBox.Checked == true && minivanTypeCheckBox.Checked == true) sedanTypeCheckBox.Checked = false;
            if (sedanTypeCheckBox.Checked == false && minivanTypeCheckBox.Checked == false) minivanTypeCheckBox.Checked = true;
        }

        #endregion
        #region Add and Cancel buttons

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            if (vehicleNameTextBox.Text == "") { errorLabel.Text = "Insert vehicle name"; return; }
            if (sedanTypeCheckBox.Checked)
            {
                AvailableSedanUserControl sedan = new AvailableSedanUserControl(vehicleNameTextBox.Text, (short)fuelPercentNumericUpDown.Value, (short)damagePercentNumericUpDown.Value);
                mainWindow.AddAvailableVehicle(sedan);
                errorLabel.Text = "";               
            }
            if (minivanTypeCheckBox.Checked)
            {
                AvailableMinivanUserControl minivan = new AvailableMinivanUserControl(vehicleNameTextBox.Text, (short)fuelPercentNumericUpDown.Value, (short)damagePercentNumericUpDown.Value);
                mainWindow.AddAvailableVehicle(minivan);
                errorLabel.Text = "";
            }
            mainWindow.HideAddVehiclePanel();
            Hide();
        }

        private void buttonCancelAdd_Click(object sender, EventArgs e)
        {
            mainWindow.HideAddVehiclePanel();
            Hide();
        }

        #endregion
    }
}
