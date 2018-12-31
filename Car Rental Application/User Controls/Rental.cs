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
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.User_Controls
{
    public partial class Rental : UserControl
    {
        Vehicle _Vehicle;
        Person _Owner;
        DateTime _ReturnDate;

        public Rental()
        {
            InitializeComponent();
        }

        public Rental(Vehicle vehicle, Person owner, DateTime returnDate)
        {
            InitializeComponent();

            ID = IDManagement.GetLowestAvailableRentedID();
            IDManagement.MarkRentIDAsUnavailable(ID);

            Vehicle = vehicle;
            Owner = owner;
            ReturnDate = returnDate;

            UpdateLanguage(Program.Language);
        }


        #region Properties

        public Vehicle Vehicle
        {
            get
            {
                return _Vehicle;
            }
            private set
            {
                _Vehicle = Vehicle;
                panelVehicle.Controls.Add(_Vehicle);
            }
        }

        public string Details
        {
            get
            {
                string details = "";
                details += "Sedan, id " + ID + ", ";
                details += "has " + Vehicle.FuelPercentage + "% fuel, ";
                details += "is " + Vehicle.DamagePercentage + " % damaged, ";
                details += "owned by: " + Owner.Name + ", ";
                details += "phone number: " + Owner.PhoneNumber + ", ";
                details += "return date: " + ReturnDate.ToShortDateString();

                return details;
            }
        }

        public bool Selected
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

        public short ID
        {
            protected set
            {
                labelIDValue.Text = value.ToString();
                IDManagement.MarkIDAsUnavailable(value);
            }
            get
            {
                return Convert.ToInt16(labelIDValue.Text);
            }
        }

        public Person Owner
        {
            get
            {
                return _Owner;
            }
            protected set
            {
                _Owner = value;
                labelOwnerName.Text = _Owner.Name;
                labelOwnerPhoneValue.Text = _Owner.PhoneNumber;
            }
        }

        public DateTime ReturnDate
        {
            get
            {
                return _ReturnDate;
            }
            protected set
            {
                _ReturnDate = value;
                labelReturnDateValue.Text = _ReturnDate.ToShortDateString();
            }
        }

        #endregion

        public void UpdateLanguage(Language language)
        {

        }
    }
}
