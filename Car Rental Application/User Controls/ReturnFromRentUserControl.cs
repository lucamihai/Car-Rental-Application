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
    public partial class ReturnFromRentUserControl : UserControl
    {
        MainWindow mainWindow;
        VehicleUserControl rentedVehicle;
        VehicleUserControl vehicleToBeReturned;
        DateTime returnDate;

        public ReturnFromRentUserControl()
        {
            InitializeComponent();
        }
        public ReturnFromRentUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

        }

        public void SelectVehicleToBeReturned(VehicleUserControl vehicle)
        {
            if(vehicle.GetType() == (new RentedSedanUserControl()).GetType())
            {
                rentedVehicle = vehicle;
                vehicleToBeReturned = new AvailableSedanUserControl((RentedSedanUserControl)vehicle);
                fuelPercentageNumericUpDown.Value = vehicleToBeReturned.GetFuelPercentage();
                damagePercentageNumericUpDown.Value = vehicleToBeReturned.GetDamagePercentage();
            }
            if (vehicle.GetType() == (new RentedMinivanUserControl()).GetType())
            {
                rentedVehicle = vehicle;
                vehicleToBeReturned = new AvailableMinivanUserControl((RentedMinivanUserControl)vehicle);
                fuelPercentageNumericUpDown.Value = vehicleToBeReturned.GetFuelPercentage();
                damagePercentageNumericUpDown.Value = vehicleToBeReturned.GetDamagePercentage();
            }
            returnDate = returnDateDateTimePicker.Value;
        }

        #region Fuel and Damage percentages control

        private void fuelPercentageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (fuelPercentageNumericUpDown.Value > 100) fuelPercentageNumericUpDown.Value = 100;
            if (fuelPercentageNumericUpDown.Value < 0) fuelPercentageNumericUpDown.Value = 0;
        }

        private void damagePercentageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (damagePercentageNumericUpDown.Value > 100) damagePercentageNumericUpDown.Value = 100;
            if (damagePercentageNumericUpDown.Value < 0) damagePercentageNumericUpDown.Value = 0;

        }
        #endregion

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            string order = "";
            order += rentedVehicle.GetDetails();

            vehicleToBeReturned.SetVehicleFuelPercentage((short)fuelPercentageNumericUpDown.Value);
            vehicleToBeReturned.SetVehicleDamagePercentage((short)damagePercentageNumericUpDown.Value);
            order += ". Was returned with " + vehicleToBeReturned.GetFuelPercentage() + "% fuel and " + vehicleToBeReturned.GetDamagePercentage() + "% damage, on "+returnDate.ToShortDateString();
            mainWindow.SetLogID(mainWindow.GetLastLog() + 1);
            mainWindow.WriteLog(order);

            mainWindow.ReturnVehicleFromRent(vehicleToBeReturned);
            mainWindow.RemoveRentedCarFromList(rentedVehicle);
            mainWindow.HideAddVehiclePanel();
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            mainWindow.HideAddVehiclePanel();
            Hide();
        }

        private void returnDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (rentedVehicle.GetType() == (new RentedSedanUserControl()).GetType())
            {
                int difference = (returnDateDateTimePicker.Value - ((RentedSedanUserControl)rentedVehicle).GetReturnDate()).Days;
                labelCheckReturnDate.Text = difference + " days";
                if (difference > 0)
                    labelCheckReturnDate.Text = "The vehicle has been returned " + difference + " days later";
                if (difference < 0)
                    labelCheckReturnDate.Text = "The vehicle has been returned " + (-difference) + " days earlier";
                if (difference == 0)
                    labelCheckReturnDate.Text = "The vehicle has been returned just on time";
                returnDate = returnDateDateTimePicker.Value;
            }
            if (rentedVehicle.GetType() == (new RentedMinivanUserControl()).GetType())
            {
                int difference = (returnDateDateTimePicker.Value - ((RentedMinivanUserControl)rentedVehicle).GetReturnDate()).Days;
                labelCheckReturnDate.Text = difference + " days";
                if (difference > 0)
                    labelCheckReturnDate.Text = "The vehicle has been returned " + difference + " days later";
                if (difference < 0)
                    labelCheckReturnDate.Text = "The vehicle has been returned " + (-difference) + " days earlier";
                if (difference == 0)
                    labelCheckReturnDate.Text = "The vehicle has been returned just on time";
                returnDate = returnDateDateTimePicker.Value;
            }
        }
    }
}
