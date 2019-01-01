using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;
using Car_Rental_Application.Forms;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Forms
{
    public partial class FormReturnVehicle : Form
    {
        Rental rental;

        public string OrderDetails { get; set; }
        public Vehicle ReturnedVehicle { get; set; }

        public FormReturnVehicle()
        {
            InitializeComponent();
        }

        public FormReturnVehicle(Rental rental)
        {
            InitializeComponent();
            this.rental = new Rental(rental);

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
                short fuelPercentageAtReturn = (short)fuelPercentageNumericUpDown.Value;
                short damagePercentageAtReturn = (short)damagePercentageNumericUpDown.Value;
                ReturnedVehicle = new Vehicle(
                    rental.Vehicle.ID, 
                    rental.Vehicle.VehicleName, 
                    fuelPercentageAtReturn, 
                    damagePercentageAtReturn
                );

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
