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
        Panel availableCarsElementsPanel;
        public AddVehicleUserControl()
        {
            InitializeComponent();
        }
        public AddVehicleUserControl(Panel availableCarsElementsPanel)
        {
            InitializeComponent();
            this.availableCarsElementsPanel = availableCarsElementsPanel;
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
        }

        private void minivanTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sedanTypeCheckBox.Checked == true && minivanTypeCheckBox.Checked == true) sedanTypeCheckBox.Checked = false;
        }

        #endregion
        #region Add and Cancel buttons

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            if (sedanTypeCheckBox.Checked == true)
            {
                AvailableSedanUserControl sedan = new AvailableSedanUserControl(vehicleNameTextBox.Text, (short)fuelPercentNumericUpDown.Value, (short)damagePercentNumericUpDown.Value);

            }

        }

        private void buttonCancelAdd_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
