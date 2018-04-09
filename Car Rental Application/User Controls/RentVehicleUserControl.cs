using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;

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
            string ownerName = ownerNameTextBox.Text;
            string ownerPhoneNumber = ownerPhoneNumberTextBox.Text;
            Customer owner = new Customer(ownerName, ownerPhoneNumber);
            if(availableVehicle.GetType()==(new AvailableSedanUserControl()).GetType())
            {
                RentedSedanUserControl sedan = new RentedSedanUserControl(availableVehicle, owner, returnDateDateTimePicker.Value);
                mainWindow.RentVehicle(sedan);
                mainWindow.RemoveAvailableCarFromList(availableVehicle);
                Hide();
                mainWindow.HideAddVehiclePanel();
                return;
            }
            if (availableVehicle.GetType() == (new AvailableMinivanUserControl()).GetType())
            {
                RentedMinivanUserControl minivan = new RentedMinivanUserControl(availableVehicle, owner, returnDateDateTimePicker.Value);
                mainWindow.RentVehicle(minivan);
                mainWindow.RemoveAvailableCarFromList(availableVehicle);
                Hide();
                mainWindow.HideAddVehiclePanel();
                return;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
            mainWindow.HideAddVehiclePanel();
        }

        private void RentVehicleUserControl_Load(object sender, EventArgs e)
        {
            
        }

    }
}
