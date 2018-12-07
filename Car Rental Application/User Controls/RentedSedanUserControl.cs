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
            ID = sedan.ID;
            VehicleName = sedan.VehicleName;
            FuelPercentage = sedan.FuelPercentage;
            DamagePercentage = sedan.DamagePercentage;
            SetRentID(sedan.GetSpecialRentID());
            SetOwner(sedan.GetOwner());
            SetReturnDate(sedan.GetReturnDate());
        }

        public RentedSedanUserControl(VehicleUserControl availableVehicle, Customer owner, DateTime returnDate)
        {
            InitializeComponent();
            SetRentID((short)IDManagement.GetLowestAvailableRentedID());
            ID = availableVehicle.ID;
            IDManagement.MarkRentIDAsUnavailable(rentID);
            string availableVehicleName = availableVehicle.VehicleName;
            short availableVehicleFuelPercentage = availableVehicle.FuelPercentage;
            short avaiableVehicleDamagePercentage = availableVehicle.DamagePercentage;
            VehicleName = availableVehicleName;
            FuelPercentage = availableVehicleFuelPercentage;
            DamagePercentage = avaiableVehicleDamagePercentage;
            this.owner = owner;
            ownerNameValueLabel.Text = owner.GetName();
            ownerPhoneNumberValueLabel.Text = owner.GetPhoneNumber();
            this.returnDate = returnDate;
            returnDateValueLabel.Text = returnDate.ToShortDateString();           
        }

        public override string Details
        {
            get
            {
                string details = "";
                details += "Sedan, id " + ID + ", has " + FuelPercentage + "% fuel, is " + DamagePercentage + "% damaged, owned by: "
                    + GetOwner().GetName() + ", phone number: " + GetOwner().GetPhoneNumber() + ", return date: " + GetReturnDate().ToShortDateString();
                return details;
            }
            
        }

        public void FromDatabase(short id, string name, short fuel, short damage, short rentID, Customer owner, string returnDate)
        {
            ID = id;
            VehicleName = name;
            FuelPercentage = fuel;
            DamagePercentage = damage;
            SetRentID(rentID);
            SetOwner(owner);
            SetReturnDate(DateTime.Parse(returnDate));
        }

        public override bool Selected
        {
            get
            {
                return selectCheckBox.Checked;
            }
            set
            {
                selectCheckBox.Checked = value;
            }
        }

        #region Set and Get methods

        public override short ID
        {
            protected set
            {
                IDManagement.MarkIDAsUnavailable(value);
            }
        }

        public override void SetRentID(short id)
        {
            rentID = id;
            rentIDValueLabel.Text = id.ToString();
            IDManagement.MarkRentIDAsUnavailable(id);
        }

        public override string VehicleName
        {
            get
            {
                return vehicleNameValueLabel.Text;
            }
            protected set
            {
                vehicleNameValueLabel.Text = value;
            }
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
        public override Customer GetOwner()
        {
            return owner;
        }

        public override DateTime GetReturnDate()
        {
            return returnDate;
        }

        public override short GetRentID()
        {
            return rentID;
        }

        #endregion

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            mainWindow.ReturnForm(this);
        }

        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int indexOfCurrentVehicle = mainWindow.GetIndexOfRentedVehicle(this);
            if (selectCheckBox.Checked == true)
            {
                mainWindow.indexesOfSelectedRentedCars.Add(indexOfCurrentVehicle);
                return;
            }
            mainWindow.indexesOfSelectedRentedCars.Remove(indexOfCurrentVehicle);
        }
    }
}
