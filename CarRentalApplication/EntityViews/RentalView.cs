using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using CarRentalApplication.Classes;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Translating;

namespace CarRentalApplication.EntityViews
{
    public partial class RentalView : UserControl, IXmlSerializable
    {
        private MainWindow mainWindow;
        private VehicleView rentedVehicleView;
        private Person owner;
        private DateTime returnDate;

        public Vehicle RentedVehicle { get; private set; }

        public RentalView()
        {
            InitializeComponent();
        }

        public RentalView(Rental rental)
        {
            InitializeComponent();

            Id = IDManagement.LowestAvailableRentalID;
            IDManagement.MarkRentalIDAsUnavailable(Id);

            RentedVehicle = rental.Vehicle;
            Owner = rental.Owner;
            ReturnDate = rental.ReturnDate;

            rentedVehicleView = new VehicleView(RentedVehicle);
            panelVehicle.Controls.Add(rentedVehicleView);
        }

        #region Properties

        public string Details
        {
            get
            {
                var details = string.Empty;
                details += "Sedan, id " + Id + ", ";
                details += "has " + rentedVehicleView.FuelPercentage + "% fuel, ";
                details += "is " + rentedVehicleView.DamagePercentage + " % damaged, ";
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

            rentedVehicleView.UpdateLanguage(language);
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
            xmlWriter.WriteElementString("vehicleID", rentedVehicleView.Id.ToString());
            xmlWriter.WriteElementString("vehicleName", rentedVehicleView.VehicleName);
            xmlWriter.WriteElementString("vehicleType", rentedVehicleView.GetType().Name);
            xmlWriter.WriteElementString("vehicleFuelPercentage", rentedVehicleView.FuelPercentage.ToString());
            xmlWriter.WriteElementString("vehicleDamagePercentage", rentedVehicleView.DamagePercentage.ToString());
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
                    var vehicle = new Sedan
                    {
                        Id = vehicleId,
                        Name = vehicleName,
                        FuelPercentage = vehicleFuelPercentage,
                        DamagePercentage = vehicleDamagePercentage
                    };
                    rentedVehicleView = new VehicleView(vehicle);
                }

                if (vehicleType == "Minivan")
                {
                    var vehicle = new Minivan
                    {
                        Id = vehicleId,
                        Name = vehicleName,
                        FuelPercentage = vehicleFuelPercentage,
                        DamagePercentage = vehicleDamagePercentage
                    };
                    rentedVehicleView = new VehicleView(vehicle);
                }

                xmlReader.ReadEndElement();
            }
        }

        #endregion
    }
}
