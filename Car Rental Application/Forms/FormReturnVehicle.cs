using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Forms;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Forms
{
    public partial class FormReturnVehicle : Form
    {
        string vehicleDetails;
        public VehicleUserControl RentedVehicle
        {
            set
            {
                VehicleUserControl vehicle = value;

                if (vehicle.GetType() == (new RentedSedanUserControl()).GetType())
                {
                    ReturnedVehicle = new AvailableSedanUserControl((RentedSedanUserControl)vehicle);
                    fuelPercentageNumericUpDown.Value = ReturnedVehicle.FuelPercentage;
                    damagePercentageNumericUpDown.Value = ReturnedVehicle.DamagePercentage;
                }

                if (vehicle.GetType() == (new RentedMinivanUserControl()).GetType())
                {
                    ReturnedVehicle = new AvailableMinivanUserControl((RentedMinivanUserControl)vehicle);
                    fuelPercentageNumericUpDown.Value = ReturnedVehicle.FuelPercentage;
                    damagePercentageNumericUpDown.Value = ReturnedVehicle.DamagePercentage;
                }

                vehicleDetails = vehicle.Details;
            }
        }

        public string OrderDetails { get; set; }

        public VehicleUserControl ReturnedVehicle { get; set; }

        public FormReturnVehicle()
        {
            InitializeComponent();
        }

        public FormReturnVehicle(VehicleUserControl vehicle)
        {
            InitializeComponent();
            RentedVehicle = vehicle;

            labelDescription.Text = Program.Language.Translate("Fill in the details of the vehicle at return");
            labelFuelPercentage.Text = Program.Language.Translate("Fuel percentage");
            labelDamagePercentage.Text = Program.Language.Translate("Damage percentage");
            labelReturnedDate.Text = Program.Language.Translate("Returned on");

            buttonReturn.Text = Program.Language.Translate("Return vehicle");
            buttonCancel.Text = Program.Language.Translate("Cancel");
        }

        private void ReturnFromRent(object sender, EventArgs e)
        {
            ReturnedVehicle.FuelPercentage = (short)fuelPercentageNumericUpDown.Value;
            ReturnedVehicle.DamagePercentage = (short)damagePercentageNumericUpDown.Value;

            string order = "";
            order += vehicleDetails;
            order += ". Was returned with ";
            order += ReturnedVehicle.FuelPercentage + "% fuel and ";
            order += ReturnedVehicle.DamagePercentage + "% damage, on ";
            order += returnDateDateTimePicker.Value.ToShortDateString();

            OrderDetails = order;

            if (ReturnedVehicle != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
