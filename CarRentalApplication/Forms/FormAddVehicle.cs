using System;
using System.Windows.Forms;
using CarRentalApplication.Classes;
using CarRentalApplication.User_Controls;

namespace CarRentalApplication.Forms
{
    public partial class FormAddVehicle : Form
    {
        public Vehicle Vehicle { get; set; }

        public FormAddVehicle()
        {
            InitializeComponent();

            errorLabel.Text = string.Empty;

            labelVehicleName.Text = Program.Language.Translate("Vehicle name");
            labelVehicleType.Text = Program.Language.Translate("Vehicle type");
            labelFuelPercentage.Text = Program.Language.Translate("Fuel percentage");
            labelDamagePercentage.Text = Program.Language.Translate("Damage percentage");

            radioButtonSedan.Text = Program.Language.Translate("Sedan");
            radioButtonMinivan.Text = Program.Language.Translate("Minivan");

            buttonAddVehicle.Text = Program.Language.Translate("Add vehicle");
            buttonCancel.Text = Program.Language.Translate("Cancel");
        }

        private void AddVehicle(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxVehicleName.Text))
            {
                errorLabel.Text = ErrorMessages.VehicleNameNotProvided;
                return;
            }

            var fuelPercentage = (short)numericUpDownFuelPercentage.Value;
            var damagePercentage = (short)numericUpDownDamagePercentage.Value;

            if (radioButtonSedan.Checked)
            {
                Vehicle = new Sedan(textBoxVehicleName.Text, fuelPercentage, damagePercentage);
            }

            if (radioButtonMinivan.Checked)
            {
                Vehicle = new Minivan(textBoxVehicleName.Text, fuelPercentage, damagePercentage);
            }

            if (Vehicle != null)
            {
                errorLabel.Text = string.Empty;

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
