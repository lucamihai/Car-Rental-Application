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

        public RentedMinivanUserControl(VehicleUserControl minivan)
        {
            InitializeComponent();
            SetID(id = minivan.GetVehicleID());
            SetVehicleName(minivan.GetVehicleName());
            SetVehicleFuelPercentage(minivan.GetFuelPercentage());
            SetVehicleDamagePercentage(minivan.GetDamagePercentage());
            SetRentID(minivan.GetSpecialRentID());
            SetOwner(minivan.GetOwner());
            SetReturnDate(minivan.GetReturnDate());
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

        public void FromDatabase(short id, string name, short fuel, short damage, short rentID, Customer owner, string returnDate)
        {
            SetID(id);
            SetVehicleName(name);
            SetVehicleFuelPercentage(fuel);
            SetVehicleDamagePercentage(damage);
            SetRentID(rentID);
            SetOwner(owner);
            SetReturnDate(DateTime.Parse(returnDate));
        }

        public override void configureRentedVehicle(string config)
        {
            //rentConfiguration = intID + "#" + vehicleName + "#" + intDamage + "#" + intFuel + "#" + rentIDInt + "#" + ownerName + "#" + ownerPhone + "#" + returnDateString;
            string[] configurations = new string[8];
            configurations = config.Split('#');
            foreach (string a in configurations) Console.WriteLine(a);

            int IDInt = Convert.ToInt32(configurations[0]);
            SetID((short)IDInt);
            IDManagement.MarkIDAsUnavailable(id);

            string name = configurations[1];
            SetVehicleName(name);

            int damageInt = Convert.ToInt32(configurations[2]);
            SetVehicleDamagePercentage((short)damageInt);

            int fuelInt = Convert.ToInt32(configurations[3]);
            SetVehicleFuelPercentage((short)fuelInt);

            int rentIDInt = Convert.ToInt32(configurations[4]);
            SetRentID((short)rentIDInt);

            string ownerName = configurations[5]; string ownerPhone = configurations[6];
            Customer newOwner = new Customer(ownerName, ownerPhone);
            SetOwner(newOwner);

            string returnDateString = configurations[7];
            SetReturnDate(DateTime.Parse(returnDateString));
        }

        #region Set and Get methods

        public void SetID(short id) { this.id = id; IDManagement.MarkIDAsUnavailable(id); }
        public override void SetRentID(short id)
        {
            rentID = id;
            rentIDValueLabel.Text = id.ToString();
            IDManagement.MarkRentIDAsUnavailable(rentID);
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


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (selectCheckBox.Checked == true)
            {
                mainWindow.indexesOfSelectedRentedCars.Add(id);
                return;
            }
            mainWindow.indexesOfSelectedRentedCars.Remove(id);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            returnFromRentUserControl.SelectVehicleToBeReturned(this);
            mainWindow.ReturnMenu();
        }
    }
}
