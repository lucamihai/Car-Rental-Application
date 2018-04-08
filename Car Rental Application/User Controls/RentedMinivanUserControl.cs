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
    public partial class RentedMinivanUserControl : MinivanUserControl
    {
        short rentID;
        Customer owner;
        DateTime returnDate;
        public RentedMinivanUserControl()
        {
            InitializeComponent();
        }
        public RentedMinivanUserControl(VehicleUserControl availableVehicle, Customer owner, DateTime returnDate)
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
        public void SetRentID(short id)
        {
            rentID = id;
            rentIDValueLabel.Text = id.ToString();
        }
        public void SetVehicleName(string vehicleName)
        {
            this.vehicleName = vehicleName;
            vehicleNameValueLabel.Text = vehicleName;
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
        public Customer GetOwner() { return owner; }
        public DateTime GetReturnDate() { return returnDate; }

        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (selectCheckBox.Checked == true)
            {
                mainWindow.indexesOfSelectedAvailableCars.Add(id);
                return;
            }
            mainWindow.indexesOfSelectedAvailableCars.Remove(id);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            returnFromRentUserControl.SelectVehicleToBeReturned(this);
            mainWindow.ReturnMenu();
        }
    }
}
