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

namespace Car_Rental_Application.User_Controls
{
    public partial class Vehicle : UserControl, IXmlSerializable
    {
        protected Label labelID, labelVehicleName, labelVehicleType, labelFuelPercentage, labelDamagePercentage;
        protected Label labelIDValue, labelVehicleNameValue, labelVehicleTypeValue, labelFuelPercentageValue, labelDamagePercentageValue;
        protected CheckBox checkboxSelect;
        protected Button buttonRent;

        protected MainWindow mainWindow;

        public Vehicle()
        {
            InitializeComponent();
            PrepareComponents();
        }

        public Vehicle(string vehicleName, short fuelPercent = 0, short damagePercent = 0)
        {
            InitializeComponent();
            PrepareComponents();

            short id = IDManagement.GetLowestAvailableID();
            ID = id;
            IDManagement.MarkIDAsUnavailable(id);

            VehicleName = vehicleName;
            FuelPercentage = fuelPercent;
            DamagePercentage = damagePercent;
            
            UpdateLanguage(Program.Language);
        }

        public Vehicle(Vehicle vehicle)
        {
            InitializeComponent();
            PrepareComponents();

            ID = vehicle.ID;
            IDManagement.MarkIDAsUnavailable(ID);
            VehicleName = vehicle.VehicleName;
            FuelPercentage = vehicle.FuelPercentage;
            DamagePercentage = vehicle.DamagePercentage;
            

            UpdateLanguage(Program.Language);
        }

        protected void PrepareComponents()
        {
            labelID = new Label();
            labelID.Text = Program.Language.Translate("ID");
            labelID.Location = new Point(3, 18);
            labelID.AutoSize = true;
            labelID.Font = new Font(labelID.Font, FontStyle.Bold);
            Controls.Add(labelID);

            labelIDValue = new Label();
            labelIDValue.Location = new Point(3, 37);
            labelIDValue.AutoSize = true;
            Controls.Add(labelIDValue);

            // -----

            labelVehicleName = new Label();
            labelVehicleName.Text = Program.Language.Translate("Vehicle name");
            labelVehicleName.Location = new Point(54, 18);
            labelVehicleName.AutoSize = true;
            labelVehicleName.Font = new Font(labelID.Font, FontStyle.Bold);
            Controls.Add(labelVehicleName);

            labelVehicleNameValue = new Label();
            labelVehicleNameValue.Location = new Point(54, 37);
            labelVehicleNameValue.AutoSize = true;
            Controls.Add(labelVehicleNameValue);

            // -----

            labelVehicleType = new Label();
            labelVehicleType.Text = Program.Language.Translate("Vehicle type");
            labelVehicleType.Location = new Point(158, 18);
            labelVehicleType.AutoSize = true;
            labelVehicleType.Font = new Font(labelID.Font, FontStyle.Bold);
            Controls.Add(labelVehicleType);

            labelVehicleTypeValue = new Label();
            labelVehicleTypeValue.Location = new Point(158, 37);
            labelVehicleTypeValue.AutoSize = true;
            Controls.Add(labelVehicleTypeValue);

            // -----

            labelDamagePercentage = new Label();
            labelDamagePercentage.Text = Program.Language.Translate("Damage percentage");
            labelDamagePercentage.Location = new Point(255, 18);
            labelDamagePercentage.AutoSize = true;
            labelDamagePercentage.Font = new Font(labelID.Font, FontStyle.Bold);
            Controls.Add(labelDamagePercentage);

            labelDamagePercentageValue = new Label();
            labelDamagePercentageValue.Location = new Point(255, 37);
            labelDamagePercentageValue.AutoSize = true;
            Controls.Add(labelDamagePercentageValue);

            // -----

            labelFuelPercentage = new Label();
            labelFuelPercentage.Text = Program.Language.Translate("Fuel percentage");
            labelFuelPercentage.Location = new Point(389, 18);
            labelFuelPercentage.AutoSize = true;
            labelFuelPercentage.Font = new Font(labelID.Font, FontStyle.Bold);
            Controls.Add(labelFuelPercentage);

            labelFuelPercentageValue = new Label();
            labelFuelPercentageValue.Location = new Point(389, 37);
            labelFuelPercentageValue.AutoSize = true;
            Controls.Add(labelFuelPercentageValue);

            // -----

            checkboxSelect = new CheckBox();
            checkboxSelect.Text = Program.Language.Translate("Select");
            checkboxSelect.Location = new Point(487, 20);
            checkboxSelect.AutoSize = true;
            checkboxSelect.Click += Select;
            Controls.Add(checkboxSelect);

            // -----

            buttonRent = new Button();
            buttonRent.Text = Program.Language.Translate("Rent");
            buttonRent.Location = new Point(472, 49);
            buttonRent.AutoSize = true;
            buttonRent.Click += Rent;
            Controls.Add(buttonRent);
        }


        #region Properties

        public string Details
        {
            get
            {
                string details = "";
                details += "Sedan " + VehicleName + ", ";
                details += "registered with the id " + ID.ToString() + ", ";
                details += "has " + FuelPercentage.ToString() + " % fuel and ";
                details += "and is " + DamagePercentage.ToString() + " % damaged";

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

                int indexOfCurrentVehicle = mainWindow.GetVehicleIndex(this);

                if (checkboxSelect.Checked == true)
                {
                    mainWindow.SelectVehicle(indexOfCurrentVehicle);
                    return;
                }

                mainWindow.DeselectVehicle(indexOfCurrentVehicle);
            }
        }

        public short ID
        {
            get
            {
                return Convert.ToInt16(labelIDValue.Text);
            }
            protected set
            {
                labelIDValue.Text = value.ToString();
                IDManagement.MarkIDAsUnavailable(value);
            }
        }

        public string VehicleName
        {
            get
            {
                return labelVehicleNameValue.Text;
            }
            protected set
            {
                labelVehicleNameValue.Text = value;
            }
        }

        public short FuelPercentage
        {
            get
            {
                return Convert.ToInt16(labelFuelPercentageValue.Text);
            }
            protected set
            {
                labelFuelPercentageValue.Text = value.ToString();
            }
        }

        public short DamagePercentage
        {
            get
            {
                return Convert.ToInt16(labelDamagePercentageValue.Text);
            }
            protected set
            {
                labelDamagePercentageValue.Text = value.ToString();
            }
        }

        #endregion


        #region IXmlSerializable methods

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(System.Xml.XmlWriter xmlWriter)
        {
            xmlWriter.WriteAttributeString("Name", GetType().Name);
            xmlWriter.WriteElementString("id", ID.ToString());
            xmlWriter.WriteElementString("vehicleName", VehicleName);
            xmlWriter.WriteElementString("damagePercentage", DamagePercentage.ToString());
            xmlWriter.WriteElementString("fuelPercentage", FuelPercentage.ToString());
        }

        public void ReadXml(System.Xml.XmlReader xmlReader)
        {
            xmlReader.MoveToContent();
            string VehicleType = xmlReader.GetAttribute("Name");
            Name = VehicleType;

            bool isEmptyElement = xmlReader.IsEmptyElement;
            xmlReader.ReadStartElement();

            if (!isEmptyElement)
            {
                if (VehicleType == "Sedan")
                {
                    int intID = Convert.ToInt32(xmlReader.ReadElementString("id"));
                    ID = (short)intID;

                    VehicleName = xmlReader.ReadElementString("vehicleName");

                    int intDamage = Convert.ToInt32(xmlReader.ReadElementString("damagePercentage"));
                    DamagePercentage = (short)intDamage;

                    int intFuel = Convert.ToInt32(xmlReader.ReadElementString("fuelPercentage"));
                    FuelPercentage = (short)intFuel;

                    xmlReader.ReadEndElement();
                }

                if (VehicleType == "Minivan")
                {
                    int intID = Convert.ToInt32(xmlReader.ReadElementString("id"));
                    ID = (short)intID;

                    VehicleName = xmlReader.ReadElementString("vehicleName");

                    int intDamage = Convert.ToInt32(xmlReader.ReadElementString("damagePercentage"));
                    DamagePercentage = (short)intDamage;

                    int intFuel = Convert.ToInt32(xmlReader.ReadElementString("fuelPercentage"));
                    FuelPercentage = (short)intFuel;

                    xmlReader.ReadEndElement();
                }
            }
        }

        #endregion


        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void Rent(object sender, EventArgs e)
        {

        }

        private void Select(object sender, EventArgs e)
        {
            int indexOfCurrentVehicle = mainWindow.GetVehicleIndex(this);

            if (checkboxSelect.Checked == true)
            {
                mainWindow.SelectVehicle(indexOfCurrentVehicle);
                return;
            }

            mainWindow.DeselectVehicle(indexOfCurrentVehicle);
        }

        public virtual void UpdateLanguage(Language language)
        {
            labelID.Text = language.Translate("ID");
            labelVehicleName.Text = language.Translate("Vehicle name");
            labelVehicleType.Text = language.Translate("Vehicle type");
            labelVehicleTypeValue.Text = language.Translate(Name);
            labelDamagePercentage.Text = language.Translate("Damage percentage");
            labelFuelPercentage.Text = language.Translate("Fuel percentage");

            checkboxSelect.Text = language.Translate("Select");

            buttonRent.Text = language.Translate("Rent");
        }
    }
}
