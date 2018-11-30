using Car_Rental_Application.Classes;
using System;
using System.Windows.Forms;

namespace Car_Rental_Application.User_Controls
{
    public partial class RentVehicleUserControl : UserControl
    {
        MainWindow mainWindow;
        VehicleUserControl availableVehicle;

        public RentVehicleUserControl()
        {
            InitializeComponent();
        }

        public RentVehicleUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void SelectVehicleToBeRent(VehicleUserControl availableVehicle)
        {
            this.availableVehicle = availableVehicle;
        }

        private void buttonRent_Click(object sender, EventArgs e)
        {
            if (ownerNameTextBox.Text == "" || ownerPhoneNumberTextBox.Text == "")
            {
                errorLabel.Text = "Owner's name must be provided";
                return;
            }

            if (ownerPhoneNumberTextBox.Text == "")
            {
                errorLabel.Text = "Owner's phone must be provided";
                return;
            }

            string ownerName = ownerNameTextBox.Text;
            string ownerPhoneNumber = ownerPhoneNumberTextBox.Text;
            Customer owner = new Customer(ownerName, ownerPhoneNumber);

            if ( availableVehicle.GetType() == ( new AvailableSedanUserControl() ).GetType() )
            {
                RentedSedanUserControl sedan = new RentedSedanUserControl(availableVehicle, owner, returnDateDateTimePicker.Value);
                mainWindow.RentVehicle(sedan);
                mainWindow.RemoveAvailableCarFromList(availableVehicle);

                Hide();
                mainWindow.HideAddVehiclePanel();
                errorLabel.Text = "";

                return;
            }
            if ( availableVehicle.GetType() == ( new AvailableMinivanUserControl() ).GetType() )
            {
                RentedMinivanUserControl minivan = new RentedMinivanUserControl(availableVehicle, owner, returnDateDateTimePicker.Value);
                mainWindow.RentVehicle(minivan);
                mainWindow.RemoveAvailableCarFromList(availableVehicle);

                Hide();
                mainWindow.HideAddVehiclePanel();
                errorLabel.Text = "";

                return;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
            mainWindow.HideAddVehiclePanel();
        }
    }
}
