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
    public partial class RentedSedanUserControl : SedanUserControl
    {
        Customer owner;
        DateTime returnDate;
        public RentedSedanUserControl()
        {
            InitializeComponent();
        }

        public RentedSedanUserControl(VehicleUserControl availableVehicle, Customer owner, DateTime returnDate)
        {
            InitializeComponent();
            string availableVehicleName = availableVehicle.GetVehicleName();
            short availableVehicleFuelPercentage = availableVehicle.GetFuelPercentage();
            short avaiableVehicleDamagePercentage = availableVehicle.GetDamagePercentage();
            SetVehicleName(availableVehicleName);
            SetVehicleFuelPercentage(availableVehicleFuelPercentage);
            SetVehicleDamagePercentage(avaiableVehicleDamagePercentage);
            this.owner = owner;
            this.returnDate = returnDate;
        }

        #region Set and Get methods

        public void SetVehicleName(string vehicleName)
        {
            this.vehicleName = vehicleName;
            vehicleNameValueLabel.Text = vehicleName;
        }
        public void SetVehicleFuelPercentage(short fuelPercentage)
        {
            this.fuelPercentage = fuelPercentage;           
        }
        public void SetVehicleDamagePercentage(short damagePercentage)
        {
            this.damagePercent = damagePercentage;
        }
        public void SetOwner(Customer owner)
        {
            this.owner = owner;
            ownerNameValueLabel.Text = owner.GetName();
            ownerPhoneNumberValueLabel.Text = owner.GetPhoneNumber();
        }
        public void SetDateTime(DateTime returnDate)
        {
            this.returnDate = returnDate;
            returnDateValueLabel.Text = returnDate.ToShortDateString();
        }

        #endregion

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            
        }

        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectCheckBox.Checked == true)
            {
                mainWindow.indexesOfSelectedAvailableCars.Add(id);
                return;
            }
            mainWindow.indexesOfSelectedAvailableCars.Remove(id);
        }
    }
}
