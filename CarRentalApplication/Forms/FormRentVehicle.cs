using System;
using System.Windows.Forms;
using Car_Rental_Application.User_Controls;
using CarRentalApplication.Classes;

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
                errorLabel.Text = ErrorMessages.OWNER_NAME_NOT_PROVIDED;
                return;
            }

            if (textBoxOwnerPhoneNumber.Text == "")
            {
                errorLabel.Text = ErrorMessages.OWNER_PHONE_NOT_PROVIDED;
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
