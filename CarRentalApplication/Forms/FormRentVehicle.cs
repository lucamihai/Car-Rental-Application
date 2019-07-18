using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using CarRentalApplication.Classes;
using CarRentalApplication.Domain.Entities;

namespace CarRentalApplication.Forms
{
    public partial class FormRentVehicle : Form
    {
        [ExcludeFromCodeCoverage]
        public Vehicle VehicleToBeRented { get; set; }

        [ExcludeFromCodeCoverage]
        public Rental Rental { get; set; }

        public FormRentVehicle(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);

            InitializeComponent();

            VehicleToBeRented = vehicle;

            labelOwnerName.Text = Program.Language.Translate("Owner name");
            labelOwnerPhoneNumber.Text = Program.Language.Translate("Owner phone number");
            labelReturnDate.Text = Program.Language.Translate("Return date");

            buttonRent.Text = Program.Language.Translate("Rent");
            buttonCancel.Text = Program.Language.Translate("Cancel");
        }

        private void ValidateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException($"{nameof(vehicle)} must be provided");
            }

            vehicle.ValidateAndThrow();
        }

        [ExcludeFromCodeCoverage]
        private void Rent(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOwnerName.Text))
            {
                errorLabel.Text = ErrorMessages.OwnerNameNotProvided;
                return;
            }

            if (string.IsNullOrEmpty(textBoxOwnerPhoneNumber.Text))
            {
                errorLabel.Text = ErrorMessages.OwnerPhoneNotProvided;
                return;
            }

            var ownerName = textBoxOwnerName.Text;
            var ownerPhoneNumber = textBoxOwnerPhoneNumber.Text;
            var owner = new Person(ownerName, ownerPhoneNumber);

            Rental = new Rental
            {
                Vehicle = VehicleToBeRented,
                Owner = owner,
                ReturnDate = dateTimePickerReturnDate.Value
            };

            this.DialogResult = Rental != null ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        [ExcludeFromCodeCoverage]
        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
