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
        protected RentVehicleUserControl rentVehicleUserControl;
        protected ReturnFromRentUserControl returnFromRentUserControl;
        protected MainWindow mainWindow;
        protected string vehicleName;
        protected short damagePercent;
        protected short fuelPercentage;
        protected short id;
        protected short specialRentID;
        public virtual void GetDetails() { }
        public virtual void configureRentedVehicle(string config) { }
        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            writer.WriteElementString("id", id.ToString());
            writer.WriteElementString("vehicleName", vehicleName);
            writer.WriteElementString("damagePercent", damagePercent.ToString());
            writer.WriteElementString("fuelPercentage", fuelPercentage.ToString());
            short rentID = GetRentID();
            if (rentID > -1)
            {
                writer.WriteElementString("rentID", rentID.ToString());
                Customer owner = GetOwner();
               
                {
                    writer.WriteElementString("ownerName", owner.GetName());
                    writer.WriteElementString("ownerPhone", owner.GetPhoneNumber());
                }
                DateTime returnDate = GetReturnDate();
                
                    writer.WriteElementString("returnDate", returnDate.ToString());
            }
        }

        public System.Xml.Schema.XmlSchema GetSchema() { return null; }

        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();
            Name = reader.GetAttribute("Name");
            
            Boolean isEmptyElement = reader.IsEmptyElement; 
            reader.ReadStartElement();           
            if (!isEmptyElement) 
            {
                if (Name == "AvailableSedanUserControl" || Name == "AvailableMinivanUserControl")
                {
                    int intID = Convert.ToInt32(reader.ReadElementString("id"));
                    id = (short)intID;
                    vehicleName = reader.ReadElementString("vehicleName");

                    int intDamage = Convert.ToInt32(reader.ReadElementString("damagePercent"));
                    damagePercent = (short)intDamage;

                    int intFuel = Convert.ToInt32(reader.ReadElementString("fuelPercentage"));
                    fuelPercentage = (short)intFuel;


                    //int rentIDInt = Convert.ToInt32(reader.ReadElementString("rentID"));+

                    reader.ReadEndElement();
                }
                if (Name == "RentedSedanUserControl" || Name == "RentedMinivanUserControl")
                {
                    int intID = Convert.ToInt32(reader.ReadElementString("id"));

                    string name = reader.ReadElementString("vehicleName");

                    int intDamage = Convert.ToInt32(reader.ReadElementString("damagePercent"));

                    int intFuel = Convert.ToInt32(reader.ReadElementString("fuelPercentage"));

                    int rentIDInt = Convert.ToInt32(reader.ReadElementString("rentID"));

                    string ownerName = reader.ReadElementString("ownerName");
                    string ownerPhone = reader.ReadElementString("ownerPhone");

                    string returnDateString = reader.ReadElementString("returnDate");
                    //SetReturnDate(DateTime.Parse(returnDateString));

                    string rentConfiguration = intID + "#" + name + "#" + intDamage + "#" + intFuel + "#" + rentIDInt + "#" + ownerName + "#" + ownerPhone + "#" + returnDateString;
                    RentedCarsManager.AddRentConfiguration(rentConfiguration);

                    reader.ReadEndElement();
                }
            }
        }
        public VehicleUserControl()
        {
            InitializeComponent();
        }
        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        public void LinkToRentMenu(RentVehicleUserControl rentVehicleUserControl) { this.rentVehicleUserControl = rentVehicleUserControl; }
        public void LinkToReturnMenu(ReturnFromRentUserControl returnFromRentUserControl) { this.returnFromRentUserControl = returnFromRentUserControl; }
        #region virtual methods to be redefined in the available cars classes in order to set the label values as well, else just set the short variables
        public virtual void SetVehicleFuelPercentage(short fuelPercentage) { this.fuelPercentage = fuelPercentage; }
        public virtual void SetVehicleDamagePercentage(short damagePercent) { this.damagePercent = damagePercent; }
        #endregion
        public string GetVehicleName() { return vehicleName; }
        public short GetFuelPercentage() { return fuelPercentage; }
        public short GetDamagePercentage() { return damagePercent; }
        public short GetVehicleID() { return id; }
        #region virtual methods to be redefined in the rented cars classes
        public virtual void SetRentID(short id) { specialRentID = id; }
        public virtual short GetSpecialRentID() { return specialRentID; }
        public virtual void SetOwner(Customer owner) { }
        public virtual void SetReturnDate(DateTime returnDate) { }
        public virtual short GetRentID() { return -1; }
        public virtual Customer GetOwner(){ return new Customer("-", ""); }
        public virtual DateTime GetReturnDate() { return new DateTime(1, 1, 1); }
        #endregion
    }
}
