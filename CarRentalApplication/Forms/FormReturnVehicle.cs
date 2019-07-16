using System;
using System.Windows.Forms;
using CarRentalApplication.User_Controls;

namespace CarRentalApplication.Forms
{
    public partial class FormReturnVehicle : Form
    {
        private readonly Rental rental;

        public string OrderDetails { get; set; }
        public Vehicle ReturnedVehicle { get; set; }

        public FormReturnVehicle()
        {
            InitializeComponent();
        }

        public FormReturnVehicle(Rental rental)
        {
            InitializeComponent();
            this.rental = rental;

            labelDescription.Text = Program.Language.Translate("Fill in the details of the vehicle at return");
            labelFuelPercentage.Text = Program.Language.Translate("Fuel percentage");
            labelDamagePercentage.Text = Program.Language.Translate("Damage percentage");
            labelReturnedDate.Text = Program.Language.Translate("Returned on");

            buttonReturn.Text = Program.Language.Translate("Return vehicle");
            buttonCancel.Text = Program.Language.Translate("Cancel");
        }

        private void ReturnFromRent(object sender, EventArgs e)
        {
            if (rental != null)
            {
                var fuelPercentageAtReturn = (short)fuelPercentageNumericUpDown.Value;
                var damagePercentageAtReturn = (short)damagePercentageNumericUpDown.Value;

                ReturnedVehicle = rental.Vehicle;
                ReturnedVehicle.InputsEnabled = true;

                ReturnedVehicle.FuelPercentage = fuelPercentageAtReturn;
                ReturnedVehicle.DamagePercentage = damagePercentageAtReturn;

                OrderDetails = "";
                OrderDetails += ReturnedVehicle.Details;
                OrderDetails += ". Was returned with ";
                OrderDetails += ReturnedVehicle.FuelPercentage + "% fuel and ";
                OrderDetails += ReturnedVehicle.DamagePercentage + "% damage, on ";
                OrderDetails += returnDateDateTimePicker.Value.ToShortDateString();
                
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
