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

            UpdateLanguage(Program.Language);
        }

        public RentedSedanUserControl(VehicleUserControl vehicle)
        {
            InitializeComponent();

            ID = vehicle.ID;
            VehicleName = vehicle.VehicleName;
            FuelPercentage = vehicle.FuelPercentage;
            DamagePercentage = vehicle.DamagePercentage;
            SetRentID( vehicle.GetSpecialRentID()) ;
            SetOwner( vehicle.GetOwner() );
            SetReturnDate( vehicle.GetReturnDate() );

            UpdateLanguage(Program.Language);
        }

        public RentedSedanUserControl(VehicleUserControl availableVehicle, Customer owner, DateTime returnDate)
        {
            InitializeComponent();

            SetRentID( IDManagement.GetLowestAvailableRentedID() );
            ID = availableVehicle.ID;
            IDManagement.MarkRentIDAsUnavailable(rentID);

            VehicleName = availableVehicle.VehicleName;
            FuelPercentage = availableVehicle.FuelPercentage;
            DamagePercentage = availableVehicle.DamagePercentage;

            this.owner = owner;
            ownerNameValueLabel.Text = owner.GetName();
            ownerPhoneNumberValueLabel.Text = owner.GetPhoneNumber();

            this.returnDate = returnDate;
            returnDateValueLabel.Text = returnDate.ToShortDateString();

            UpdateLanguage(Program.Language);
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

        #region Properties

        public override string Details
        {
            get
            {
                string details = "";
                details += "Sedan, id " + ID + ", ";
                details += "has " + FuelPercentage + "% fuel, ";
                details += "is " + DamagePercentage + " % damaged, ";
                details += "owned by: " + GetOwner().GetName() + ", ";
                details += "phone number: " + GetOwner().GetPhoneNumber() + ", ";
                details += "return date: " + GetReturnDate().ToShortDateString();

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
                IDManagement.MarkIDAsUnavailable(value);
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

        #endregion

        #region Set and Get methods

        public override void SetRentID(short id)
        {
            rentID = id;
            rentIDValueLabel.Text = id.ToString();
            IDManagement.MarkRentIDAsUnavailable(id);
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
