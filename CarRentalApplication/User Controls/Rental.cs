using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using CarRentalApplication.Classes;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Translating;

namespace CarRentalApplication.User_Controls
{
    public partial class Rental : UserControl, IXmlSerializable
    {
        private MainWindow mainWindow;
        private Vehicle vehicle;
        private Person owner;
        private DateTime returnDate;

        public Rental()
        {
            InitializeComponent();
        }

        public Rental(Vehicle vehicle, Person owner, DateTime returnDate)
        {
            InitializeComponent();

            Id = IDManagement.LowestAvailableRentalID;
            IDManagement.MarkRentalIDAsUnavailable(Id);

            Vehicle = vehicle;
            Owner = owner;
            ReturnDate = returnDate;

            UpdateLanguage(Program.Language);
        }

        public Rental(Rental rental)
        {
            InitializeComponent();

            Id = rental.Id;
            IDManagement.MarkRentalIDAsUnavailable(Id);

            Vehicle = rental.Vehicle;
            Owner = rental.Owner;
            ReturnDate = rental.ReturnDate;

            UpdateLanguage(Program.Language);
        }


        #region Properties

        public Vehicle Vehicle
        {
            get => vehicle;
            private set
            {
                var vehicleClone = value.Clone();
                var type = vehicleClone.GetType().Name;

                if (type == "Sedan")
                {
                    vehicle = (Sedan)vehicleClone;
                }
                
                if (type == "Minivan")
                {
                    vehicle = (Minivan)vehicleClone;
                }

                if (vehicle != null)
                {
                    vehicle.InputsEnabled = false;
                    panelVehicle.Controls.Add(vehicle);
                }
                
            }
        }

        public string Details
        {
            get
            {
                var details = string.Empty;
                details += "Sedan, id " + Id + ", ";
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
            get => checkboxSelect.Checked;
            set
            {
                checkboxSelect.Checked = value;

                if (mainWindow != null)
                {
                    var rentalIndex = mainWindow.GetRentalIndex(this);

                    if (checkboxSelect.Checked)
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

        public short Id
        {
            get => Convert.ToInt16(labelIDValue.Text);
            private set
            {
                labelIDValue.Text = value.ToString();
                IDManagement.MarkVehicleIDAsUnavailable(value);
            }
        }

        public Person Owner
        {
            get => owner;
            private set
            {
                owner = value;
                labelOwnerNameValue.Text = owner.Name;
                labelOwnerPhoneValue.Text = owner.PhoneNumber;
            }
        }

        public DateTime ReturnDate
        {
            get => returnDate;
            private set
            {
                returnDate = value;
                labelReturnDateValue.Text = returnDate.ToShortDateString();
            }
        }

        #endregion

        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void UpdateLanguage(Language language)
        {
            labelID.Text = language.Translate("ID");
            labelOwnerName.Text = language.Translate("Owner name");
            labelOwnerPhone.Text = language.Translate("Owner phone");
            labelReturnDate.Text = language.Translate("Return date");
            labelVehicle.Text = language.Translate("Vehicle");
            checkboxSelect.Text = language.Translate("Select");
            buttonReturn.Text = language.Translate("Return");

            Vehicle.UpdateLanguage(language);
        }

        private void Return(object sender, EventArgs e)
        {
            mainWindow.ReturnForm(this);
        }

        private void Select(object sender, EventArgs e)
        {
            var rentalIndex = mainWindow.GetRentalIndex(this);

            if (checkboxSelect.Checked)
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
            xmlWriter.WriteElementString("id", Id.ToString());
            xmlWriter.WriteElementString("ownerName", Owner.Name);
            xmlWriter.WriteElementString("ownerPhone", Owner.PhoneNumber);
            xmlWriter.WriteElementString("returnDate", ReturnDate.ToShortDateString());
            xmlWriter.WriteElementString("vehicleID", Vehicle.Id.ToString());
            xmlWriter.WriteElementString("vehicleName", Vehicle.VehicleName);
            xmlWriter.WriteElementString("vehicleType", Vehicle.GetType().Name);
            xmlWriter.WriteElementString("vehicleFuelPercentage", Vehicle.FuelPercentage.ToString());
            xmlWriter.WriteElementString("vehicleDamagePercentage", Vehicle.DamagePercentage.ToString());
        }

        public void ReadXml(System.Xml.XmlReader xmlReader)
        {
            xmlReader.MoveToContent();
            var isEmptyElement = xmlReader.IsEmptyElement;
            xmlReader.ReadStartElement();

            if (!isEmptyElement)
            {
                Id = Convert.ToInt16(xmlReader.ReadElementString("id"));

                var ownerName = xmlReader.ReadElementString("ownerName");
                var ownerPhone = xmlReader.ReadElementString("ownerPhone");
                Owner = new Person(ownerName, ownerPhone);

                var returnDateString = xmlReader.ReadElementString("returnDate");
                ReturnDate = DateTime.Parse(returnDateString);

                var vehicleId = Convert.ToInt16(xmlReader.ReadElementString("vehicleID"));
                var vehicleName = xmlReader.ReadElementString("vehicleName");
                var vehicleType = xmlReader.ReadElementString("vehicleType");
                var vehicleFuelPercentage = Convert.ToInt16(xmlReader.ReadElementString("vehicleFuelPercentage"));
                var vehicleDamagePercentage = Convert.ToInt16(xmlReader.ReadElementString("vehicleDamagePercentage"));

                if (vehicleType == "Sedan")
                {
                    Vehicle = new Sedan(vehicleId, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                }

                if (vehicleType == "Minivan")
                {
                    Vehicle = new Minivan(vehicleId, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                }

                xmlReader.ReadEndElement();
            }
        }

        #endregion
    }
}
