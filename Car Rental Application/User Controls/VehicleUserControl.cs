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
        public virtual void GetDetails() { }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            //writer.WriteAttributeString("Type", GetType().ToString());
            writer.WriteElementString("id", id.ToString());
            writer.WriteElementString("vehicleName", vehicleName);
            writer.WriteElementString("damagePercent", damagePercent.ToString());
            writer.WriteElementString("fuelPercentage", fuelPercentage.ToString());
        }
        public System.Xml.Schema.XmlSchema GetSchema() { return null; }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();
            Name = reader.GetAttribute("Name");
            
            Boolean isEmptyElement = reader.IsEmptyElement; // (1)
            reader.ReadStartElement();
            if (!isEmptyElement) // (1)
            {
                int intID = Convert.ToInt32(reader.ReadElementString("id"));
                id = (short)intID;
                vehicleName = reader.ReadElementString("vehicleName");

                int intDamage = Convert.ToInt32(reader.ReadElementString("damagePercent"));
                damagePercent = (short)intDamage;
                int intFuel = Convert.ToInt32(reader.ReadElementString("fuelPercentage"));
                fuelPercentage = (short)intFuel;
                reader.ReadEndElement();
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

        public virtual void SetVehicleFuelPercentage(short fuelPercentage) { this.fuelPercentage = fuelPercentage; }
        public virtual void SetVehicleDamagePercentage(short damagePercent) { this.damagePercent = damagePercent; }
        public string GetVehicleName() { return vehicleName; }
        public short GetFuelPercentage() { return fuelPercentage; }
        public short GetDamagePercentage() { return damagePercent; }
        public short GetVehicleID() { return id; }

    }
}
