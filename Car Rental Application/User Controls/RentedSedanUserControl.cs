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
        short _ID;
        Person _Owner;
        DateTime _ReturnDate;

        public RentedSedanUserControl()
        {
            InitializeComponent();

            UpdateLanguage(Program.Language);
        }

        public RentedSedanUserControl(VehicleUserControl vehicle)
        {
            InitializeComponent();

            ID = vehicle.ID;
            VehicleName = vehicle.VehicleName;
            FuelPercentage = vehicle.FuelPercentage;
            DamagePercentage = vehicle.DamagePercentage;
            RentID = vehicle.RentID;
            Owner = vehicle.Owner;
            ReturnDate = vehicle.ReturnDate;

            UpdateLanguage(Program.Language);
        }

        public RentedSedanUserControl(VehicleUserControl availableVehicle, Person owner, DateTime returnDate)
        {
            InitializeComponent();

            RentID = IDManagement.GetLowestAvailableRentedID();
            ID = availableVehicle.ID;
            IDManagement.MarkRentIDAsUnavailable(RentID);

            VehicleName = availableVehicle.VehicleName;
            FuelPercentage = availableVehicle.FuelPercentage;
            DamagePercentage = availableVehicle.DamagePercentage;

            Owner = owner;
            ReturnDate = returnDate;

            UpdateLanguage(Program.Language);
        }

        public RentedSedanUserControl(short id, string name, short fuel, short damage, short rentID, Person owner, DateTime returnDate)
        {
            InitializeComponent();

            ID = id;
            VehicleName = name;
            FuelPercentage = fuel;
            DamagePercentage = damage;
            RentID = rentID;
            Owner = owner;
            ReturnDate = returnDate;
        }


        #region Properties

        public override string Details
        {
            get
            {
                string details = "";
                details += "Sedan, id " + ID + ", ";
                details += "has " + FuelPercentage + "% fuel, ";
                details += "is " + DamagePercentage + " % damaged, ";
                details += "owned by: " + Owner.Name + ", ";
                details += "phone number: " + Owner.PhoneNumber + ", ";
                details += "return date: " + ReturnDate.ToShortDateString();

                return details;
            }
        }

        public override bool Selected
        {
            get
            {
                return checkboxSelect.Checked;
            }
            set
            {
                checkboxSelect.Checked = value;
            }
        }

        public override short ID
        {
            protected set
            {
                _ID = value;
                IDManagement.MarkIDAsUnavailable(value);
            }
            get
            {
                return _ID;
            }
        }

        public override short RentID
        {
            get
            {
                return Convert.ToInt16(rentIDValueLabel.Text);
            }
            protected set
            {
                rentIDValueLabel.Text = value.ToString();
                IDManagement.MarkRentIDAsUnavailable(value);
            }
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

        public override Person Owner
        {
            get
            {
                return _Owner;
            }
            protected set
            {
                _Owner = value;
                ownerNameValueLabel.Text = _Owner.Name;
                ownerPhoneNumberValueLabel.Text = _Owner.PhoneNumber;
            }
        }

        public override DateTime ReturnDate
        {
            get
            {
                return _ReturnDate;
            }
            protected set
            {
                _ReturnDate = value;
                returnDateValueLabel.Text = _ReturnDate.ToShortDateString();
            }
        }

        #endregion


        private void buttonReturn_Click(object sender, EventArgs e)
        {
            mainWindow.ReturnForm(this);
        }

        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int indexOfCurrentVehicle = mainWindow.GetRentedVehicleIndex(this);

            if (checkboxSelect.Checked == true)
            {
                mainWindow.SelectRentedVehicle(indexOfCurrentVehicle);
                return;
            }

            mainWindow.DeselectRentedVehicle(indexOfCurrentVehicle);
        }

        public override void UpdateLanguage(Language language)
        {
            labelRentID.Text = language.Translate("ID");
            labelVehicleName.Text = language.Translate("Vehicle name");
            labelVehicleType.Text = language.Translate("Vehicle type");
            labelVehicleTypeValue.Text = language.Translate("Sedan");
            labelOwnerName.Text = language.Translate("Owner name");
            labelOWnerPhoneNumber.Text = language.Translate("Owner phone number");
            labelReturnDate.Text = language.Translate("Return date");

            checkboxSelect.Text = language.Translate("Select");

            buttonReturn.Text = language.Translate("Return");
        }
    }
}
