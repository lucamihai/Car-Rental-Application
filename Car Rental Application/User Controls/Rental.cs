using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Car_Rental_Application.Classes;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.User_Controls
{
    public partial class Rental : UserControl, IXmlSerializable
    {
        MainWindow mainWindow;
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

        public Rental(Rental rental)
        {
            InitializeComponent();

            ID = rental.ID;
            IDManagement.MarkRentIDAsUnavailable(ID);

            Vehicle = new Vehicle(rental.Vehicle);
            Owner = rental.Owner;
            ReturnDate = rental.ReturnDate;

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
                _Vehicle = new Vehicle(value);
                _Vehicle.InputsEnabled = false;
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

                if (mainWindow != null)
                {
                    int rentalIndex = mainWindow.GetRentalIndex(this);

                    if (checkboxSelect.Checked == true)
                    {
                        
                        mainWindow.SelectRental(rentalIndex);
                    }
                    else
                    {
                        mainWindow.DeselectRental(rentalIndex);
                    }
                }
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
                labelOwnerNameValue.Text = _Owner.Name;
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

        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void UpdateLanguage(Language language)
        {

        }

        private void Return(object sender, EventArgs e)
        {

        }

        private void Select(object sender, EventArgs e)
        {
            int rentalIndex = mainWindow.GetRentalIndex(this);

            if (checkboxSelect.Checked == true)
            {
                mainWindow.SelectRental(rentalIndex);
            }
            else
            {
                mainWindow.DeselectRental(rentalIndex);
            }
        }

        #region IXmlSerializable methods

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(System.Xml.XmlWriter xmlWriter)
        {
            xmlWriter.WriteElementString("id", ID.ToString());
            xmlWriter.WriteElementString("ownerName", Owner.Name.ToString());
            xmlWriter.WriteElementString("ownerPhone", Owner.PhoneNumber.ToString());
            xmlWriter.WriteElementString("returnDate", ReturnDate.ToShortDateString());
            xmlWriter.WriteElementString("vehicleID", Vehicle.ID.ToString());
            xmlWriter.WriteElementString("vehicleName", Vehicle.VehicleName);
            xmlWriter.WriteElementString("vehicleFuelPercentage", Vehicle.FuelPercentage.ToString());
            xmlWriter.WriteElementString("vehicleDamagePercentage", Vehicle.DamagePercentage.ToString());
        }

        public void ReadXml(System.Xml.XmlReader xmlReader)
        {
            xmlReader.MoveToContent();
            bool isEmptyElement = xmlReader.IsEmptyElement;
            xmlReader.ReadStartElement();

            if (!isEmptyElement)
            {
                int intID = Convert.ToInt32(xmlReader.ReadElementString("id"));
                ID = (short)intID;

                string ownerName = xmlReader.ReadElementString("ownerName");
                string ownerPhone = xmlReader.ReadElementString("ownerPhone");
                Owner = new Person(ownerName, ownerPhone);

                string returnDateString = xmlReader.ReadElementString("returnDate");
                ReturnDate = DateTime.Parse(returnDateString);

                short vehicleID = (short)Convert.ToInt32(xmlReader.ReadElementString("vehicleID"));
                string vehicleName = xmlReader.ReadElementString("vehicleName");
                short vehicleFuelPercentage = (short)Convert.ToInt32(xmlReader.ReadElementString("vehicleFuelPercentage"));
                short vehicleDamagePercentage = (short)Convert.ToInt32(xmlReader.ReadElementString("vehicleDamagePercentage"));
                Vehicle = new Vehicle(vehicleID, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);

                xmlReader.ReadEndElement();
            }
        }

        #endregion
    }
}
