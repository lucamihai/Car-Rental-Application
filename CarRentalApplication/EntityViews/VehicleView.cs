using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using CarRentalApplication.Classes;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Translating;

namespace CarRentalApplication.EntityViews
{
    public partial class VehicleView : UserControl, IXmlSerializable, ICloneable
    {
        protected Label labelId, labelVehicleName, labelVehicleType, labelFuelPercentage, labelDamagePercentage;
        protected Label labelIdValue, labelVehicleNameValue, labelVehicleTypeValue, labelFuelPercentageValue, labelDamagePercentageValue;
        protected CheckBox checkboxSelect;
        protected Button buttonRent;

        private MainWindow mainWindow;

        public Vehicle Vehicle { get; private set; }

        public VehicleView()
        {
            InitializeComponent();
            PrepareComponents();
        }

        public VehicleView(Vehicle vehicle)
        {
            InitializeComponent();
            PrepareComponents();

            Id = IDManagement.LowestAvailableVehicleID;
            IDManagement.MarkVehicleIDAsUnavailable(Id);

            VehicleName = vehicle.Name;
            labelVehicleTypeValue.Text = vehicle.Type;
            FuelPercentage = vehicle.FuelPercentage;
            DamagePercentage = vehicle.DamagePercentage;

            Vehicle = vehicle;
        }

        public VehicleView(string vehicleName, short fuelPercent = 0, short damagePercent = 0)
        {
            InitializeComponent();
            PrepareComponents();

            Id = IDManagement.LowestAvailableVehicleID;
            IDManagement.MarkVehicleIDAsUnavailable(Id);

            VehicleName = vehicleName;
            FuelPercentage = fuelPercent;
            DamagePercentage = damagePercent;
            
            UpdateLanguage(Program.Language);
        }

        public VehicleView(short id, string vehicleName, short fuelPercent = 0, short damagePercent = 0)
        {
            InitializeComponent();
            PrepareComponents();

            Id = id;
            IDManagement.MarkVehicleIDAsUnavailable(id);

            VehicleName = vehicleName;
            FuelPercentage = fuelPercent;
            DamagePercentage = damagePercent;

            UpdateLanguage(Program.Language);
        }

        public VehicleView(VehicleView vehicle)
        {
            InitializeComponent();
            PrepareComponents();

            Id = vehicle.Id;
            IDManagement.MarkVehicleIDAsUnavailable(Id);

            VehicleName = vehicle.VehicleName;
            FuelPercentage = vehicle.FuelPercentage;
            DamagePercentage = vehicle.DamagePercentage;
            
            UpdateLanguage(Program.Language);
        }

        [ExcludeFromCodeCoverage]
        private void PrepareComponents()
        {
            labelId = new Label();
            labelId.Text = Program.Language.Translate("ID");
            labelId.Location = new Point(3, 18);
            labelId.AutoSize = true;
            labelId.Font = new Font(labelId.Font, FontStyle.Bold);
            Controls.Add(labelId);

            labelIdValue = new Label();
            labelIdValue.Location = new Point(3, 37);
            labelIdValue.AutoSize = true;
            Controls.Add(labelIdValue);

            // -----

            labelVehicleName = new Label();
            labelVehicleName.Text = Program.Language.Translate("Vehicle name");
            labelVehicleName.Location = new Point(54, 18);
            labelVehicleName.AutoSize = true;
            labelVehicleName.Font = new Font(labelId.Font, FontStyle.Bold);
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
            labelVehicleType.Font = new Font(labelId.Font, FontStyle.Bold);
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
            labelDamagePercentage.Font = new Font(labelId.Font, FontStyle.Bold);
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
            labelFuelPercentage.Font = new Font(labelId.Font, FontStyle.Bold);
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
                var details = string.Empty;
                details += "Sedan " + VehicleName + ", ";
                details += "registered with the id " + Id.ToString() + ", ";
                details += "has " + FuelPercentage.ToString() + " % fuel and ";
                details += "and is " + DamagePercentage.ToString() + " % damaged";

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
                    var indexOfCurrentVehicle = mainWindow.GetVehicleIndex(this);

                    if (checkboxSelect.Checked)
                    {
                        mainWindow.SelectVehicle(indexOfCurrentVehicle);
                    }
                    else
                    {
                        mainWindow.DeselectVehicle(indexOfCurrentVehicle);
                    }
                }
            }
        }

        public short Id
        {
            get => Convert.ToInt16(labelIdValue.Text);
            private set
            {
                labelIdValue.Text = value.ToString();
                IDManagement.MarkVehicleIDAsUnavailable(value);
            }
        }

        public string VehicleName
        {
            get => labelVehicleNameValue.Text;
            private set => labelVehicleNameValue.Text = value;
        }

        public short FuelPercentage
        {
            get => Convert.ToInt16(labelFuelPercentageValue.Text);
            set => labelFuelPercentageValue.Text = value.ToString();
        }

        public short DamagePercentage
        {
            get => Convert.ToInt16(labelDamagePercentageValue.Text);
            set => labelDamagePercentageValue.Text = value.ToString();
        }

        public bool InputsEnabled
        {
            set
            {
                checkboxSelect.Visible = value;
                buttonRent.Visible = value;
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
            xmlWriter.WriteElementString("id", Id.ToString());
            xmlWriter.WriteElementString("vehicleName", VehicleName);
            xmlWriter.WriteElementString("damagePercentage", DamagePercentage.ToString());
            xmlWriter.WriteElementString("fuelPercentage", FuelPercentage.ToString());
        }

        public void ReadXml(System.Xml.XmlReader xmlReader)
        {
            xmlReader.MoveToContent();
            var vehicleType = xmlReader.GetAttribute("Name");
            Name = vehicleType;

            var isEmptyElement = xmlReader.IsEmptyElement;
            xmlReader.ReadStartElement();

            if (!isEmptyElement)
            {
                if (vehicleType == "Sedan")
                {
                    Id = Convert.ToInt16(xmlReader.ReadElementString("id"));
                    VehicleName = xmlReader.ReadElementString("vehicleName");
                    DamagePercentage = Convert.ToInt16(xmlReader.ReadElementString("damagePercentage"));
                    FuelPercentage = Convert.ToInt16(xmlReader.ReadElementString("fuelPercentage"));

                    xmlReader.ReadEndElement();
                }

                if (vehicleType == "Minivan")
                {
                    Id = Convert.ToInt16(xmlReader.ReadElementString("id"));
                    VehicleName = xmlReader.ReadElementString("vehicleName");
                    DamagePercentage = Convert.ToInt16(xmlReader.ReadElementString("damagePercentage"));
                    FuelPercentage = Convert.ToInt16(xmlReader.ReadElementString("fuelPercentage"));

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
            mainWindow.RentForm(this.Vehicle);
        }

        private void Select(object sender, EventArgs e)
        {
            var indexOfCurrentVehicle = mainWindow.GetVehicleIndex(this);

            if (checkboxSelect.Checked)
            {
                mainWindow.SelectVehicle(indexOfCurrentVehicle);
                return;
            }

            mainWindow.DeselectVehicle(indexOfCurrentVehicle);
        }

        public virtual void UpdateLanguage(Language language)
        {
            labelId.Text = language.Translate("ID");
            labelVehicleName.Text = language.Translate("Vehicle name");
            labelVehicleType.Text = language.Translate("Vehicle type");
            labelVehicleTypeValue.Text = language.Translate(Name);
            labelDamagePercentage.Text = language.Translate("Damage percentage");
            labelFuelPercentage.Text = language.Translate("Fuel percentage");

            checkboxSelect.Text = language.Translate("Select");

            buttonRent.Text = language.Translate("Rent");
        }

        public virtual object Clone()
        {
            return new VehicleView(Id, VehicleName, FuelPercentage, DamagePercentage);
        }
    }
}
