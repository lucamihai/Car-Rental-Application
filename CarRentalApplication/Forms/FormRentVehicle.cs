using System;
using System.Windows.Forms;
using CarRentalApplication.Classes;
using CarRentalApplication.User_Controls;

namespace CarRentalApplication.Forms
{
    public partial class FormRentVehicle : Form
    {
        public Vehicle Vehicle { get; set; }
        public Rental Rental { get; set; }

        public FormRentVehicle()
        {
            InitializeComponent();
        }

        public FormRentVehicle(Vehicle vehicle)
        {
            InitializeComponent();

            Vehicle = vehicle;

            labelOwnerName.Text = Program.Language.Translate("Owner name");
            labelOwnerPhoneNumber.Text = Program.Language.Translate("Owner phone number");
            labelReturnDate.Text = Program.Language.Translate("Return date");

            buttonRent.Text = Program.Language.Translate("Rent");
            buttonCancel.Text = Program.Language.Translate("Cancel");
        }

        private void Rent(object sender, EventArgs e)
        {
            if (textBoxOwnerName.Text == "")
            {
                errorLabel.Text = ErrorMessages.OwnerNameNotProvided;
                return;
            }

            if (textBoxOwnerPhoneNumber.Text == "")
            {
                errorLabel.Text = ErrorMessages.OwnerPhoneNotProvided;
                return;
            }

            var ownerName = textBoxOwnerName.Text;
            var ownerPhoneNumber = textBoxOwnerPhoneNumber.Text;
            var owner = new Person(ownerName, ownerPhoneNumber);

            Rental = new Rental(Vehicle, owner, dateTimePickerReturnDate.Value);

            this.DialogResult = Rental != null ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
