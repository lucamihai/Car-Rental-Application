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
using System.Xml.Serialization;
using System.Xml;

namespace Car_Rental_Application.User_Controls
{
    public partial class VehicleUserControl : UserControl, IXmlSerializable
    {
        protected ReturnFromRentUserControl returnFromRentUserControl;
        protected MainWindow mainWindow;
        protected short specialRentID;

        public VehicleUserControl()
        {
            InitializeComponent();
        }

        public virtual string Details
        {
            get;
        }

        public virtual bool Selected
        {
            get; set;
        }

        public virtual string VehicleName
        {
            get;
            protected set;
        }

        public virtual short DamagePercentage
        {
            get;
            set;
        }

        public virtual short FuelPercentage
        {
            get;
            set;
        }

        public virtual short ID
        {
            get;
            protected set;
        }

        public virtual void configureRentedVehicle(string config) { }

        #region Methods from IXmlSerializable

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(System.Xml.XmlWriter xmlWriter)
        {
            xmlWriter.WriteAttributeString("Name", Name);
            xmlWriter.WriteElementString("id", ID.ToString() );
            xmlWriter.WriteElementString("vehicleName", VehicleName);
            xmlWriter.WriteElementString("damagePercent", DamagePercentage.ToString() );
            xmlWriter.WriteElementString("fuelPercentage", FuelPercentage.ToString() );

            short rentID = GetRentID();
            if (rentID > -1)
            {
                xmlWriter.WriteElementString("rentID", rentID.ToString() );

                Customer owner = GetOwner();
                xmlWriter.WriteElementString("ownerName", owner.GetName() );
                xmlWriter.WriteElementString("ownerPhone", owner.GetPhoneNumber() );
                
                DateTime returnDate = GetReturnDate();
                xmlWriter.WriteElementString("returnDate", returnDate.ToString());
            }
        }

        public void ReadXml(System.Xml.XmlReader xmlReader)
        {
            xmlReader.MoveToContent();
            Name = xmlReader.GetAttribute("Name");
            
            Boolean isEmptyElement = xmlReader.IsEmptyElement;
            xmlReader.ReadStartElement();
            
            if ( !isEmptyElement ) 
            {
                if (Name == "AvailableSedanUserControl" || Name == "AvailableMinivanUserControl")
                {
                    int intID = Convert.ToInt32(xmlReader.ReadElementString("id"));
                    ID = (short)intID;
                    VehicleName = xmlReader.ReadElementString("vehicleName");

                    int intDamage = Convert.ToInt32(xmlReader.ReadElementString("damagePercent"));
                    DamagePercentage = (short)intDamage;

                    int intFuel = Convert.ToInt32(xmlReader.ReadElementString("fuelPercentage"));
                    FuelPercentage = (short)intFuel;

                    xmlReader.ReadEndElement();
                }

                if (Name == "RentedSedanUserControl" || Name == "RentedMinivanUserControl")
                {
                    int intID = Convert.ToInt32(xmlReader.ReadElementString("id"));
                    int intDamage = Convert.ToInt32(xmlReader.ReadElementString("damagePercent"));
                    int intFuel = Convert.ToInt32(xmlReader.ReadElementString("fuelPercentage"));
                    int rentIDInt = Convert.ToInt32(xmlReader.ReadElementString("rentID"));

                    string vehicleName = xmlReader.ReadElementString("vehicleName");
                    string ownerName = xmlReader.ReadElementString("ownerName");
                    string ownerPhone = xmlReader.ReadElementString("ownerPhone");
                    string returnDateString = xmlReader.ReadElementString("returnDate");

                    string rentConfiguration = "";
                    rentConfiguration += intID + "#";
                    rentConfiguration += vehicleName + "#";
                    rentConfiguration += intDamage + "#";
                    rentConfiguration += intFuel + "#";
                    rentConfiguration += rentIDInt + "#";
                    rentConfiguration += ownerName + "#";
                    rentConfiguration += ownerPhone + "#";
                    rentConfiguration += returnDateString;

                    RentVehicleConfiguration.AddRentConfiguration(rentConfiguration);

                    xmlReader.ReadEndElement();
                }
            }
        }

        #endregion

        #region Linking to menus

        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void LinkToReturnMenu(ReturnFromRentUserControl returnFromRentUserControl)
        {
            this.returnFromRentUserControl = returnFromRentUserControl;
        }

        #endregion

        #region Methods for rented vehicles

        public virtual void SetRentID(short id)
        {
            specialRentID = id;
        }

        public virtual short GetSpecialRentID()
        {
            return specialRentID;
        }

        public virtual void SetOwner(Customer owner) { }

        public virtual void SetReturnDate(DateTime returnDate) { }

        public virtual short GetRentID()
        {
            return -1;
        }

        public virtual Customer GetOwner()
        {
            return new Customer("-", "-");
        }

        public virtual DateTime GetReturnDate()
        {
            return new DateTime(1, 1, 1);
        }

        #endregion

    }
}
