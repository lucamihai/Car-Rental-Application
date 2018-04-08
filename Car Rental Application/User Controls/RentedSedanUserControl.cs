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
        short rentID;
        Customer owner;
        DateTime returnDate;
        public RentedSedanUserControl()
        {
            InitializeComponent();
        }

        public RentedSedanUserControl(VehicleUserControl sedan)
        {
            InitializeComponent();
            id = sedan.GetVehicleID();
            vehicleName = sedan.GetVehicleName();
            fuelPercentage = sedan.GetFuelPercentage();
            damagePercent = sedan.GetDamagePercentage();
            SetRentID(sedan.GetSpecialRentID());
            owner = sedan.GetOwner();
            returnDate = sedan.GetReturnDate();
        }
        public RentedSedanUserControl(VehicleUserControl availableVehicle, Customer owner, DateTime returnDate)
        {
            InitializeComponent();
            SetRentID((short)IDManagement.GetLowestAvailableRentedID());
            SetID(availableVehicle.GetVehicleID());
            IDManagement.MarkRentIDAsUnavailable(rentID);
            string availableVehicleName = availableVehicle.GetVehicleName();
            short availableVehicleFuelPercentage = availableVehicle.GetFuelPercentage();
            short avaiableVehicleDamagePercentage = availableVehicle.GetDamagePercentage();
            SetVehicleName(availableVehicleName);
            SetVehicleFuelPercentage(availableVehicleFuelPercentage);
            SetVehicleDamagePercentage(avaiableVehicleDamagePercentage);
            this.owner = owner;
            ownerNameValueLabel.Text = owner.GetName();
            ownerPhoneNumberValueLabel.Text = owner.GetPhoneNumber();
            this.returnDate = returnDate;
            returnDateValueLabel.Text = returnDate.ToShortDateString();           
        }

        #region Set and Get methods

        public void SetID(short id) { this.id = id; }
        public override void SetRentID(short id)
        {
            rentID = id;
            rentIDValueLabel.Text = id.ToString();
        }
        public void SetVehicleName(string vehicleName)
        {
            this.vehicleName = vehicleName;
            vehicleNameValueLabel.Text = vehicleName;
        }
        public override void SetOwner(Customer owner)
        {
            this.owner = owner;
            ownerNameValueLabel.Text = owner.GetName();
            ownerPhoneNumberValueLabel.Text = owner.GetPhoneNumber();
        }
        public override void SetReturnDate(DateTime returnDate)
        {
            this.returnDate = returnDate;
            returnDateValueLabel.Text = returnDate.ToShortDateString();
        }
        public override Customer GetOwner() { return owner; }
        public override DateTime GetReturnDate() { return returnDate; }
        public override short GetRentID() { return rentID; }

        #endregion

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            returnFromRentUserControl.SelectVehicleToBeReturned(this);
            mainWindow.ReturnMenu();
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
