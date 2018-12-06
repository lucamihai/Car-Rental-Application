using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Forms
{
    public partial class FormAddVehicle : Form
    {
        public VehicleUserControl Vehicle { get; set; }

        public FormAddVehicle()
        {
            InitializeComponent();
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            if (textBoxVehicleName.Text == "")
            {
                errorLabel.Text = "Vehicle name must be provided";
                return;
            }

            if (radioButtonSedan.Checked)
            {
                Vehicle = new AvailableSedanUserControl(
                    textBoxVehicleName.Text,
                    (short)numericUpDownFuelPercentage.Value,
                    (short)numericUpDownDamagePercentage.Value
                );

                errorLabel.Text = "";
            }

            if (radioButtonMinivan.Checked)
            {
                Vehicle = new AvailableMinivanUserControl(
                    textBoxVehicleName.Text,
                    (short)numericUpDownFuelPercentage.Value,
                    (short)numericUpDownDamagePercentage.Value
                );

                errorLabel.Text = "";
            }

            if (Vehicle != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
