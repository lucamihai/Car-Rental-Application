using CarRentalApplication.Translating;

namespace CarRentalApplication.User_Controls
{
    public partial class Sedan : Vehicle
    {
        public Sedan()
        {
            InitializeComponent();
        }

        public Sedan(string vehicleName, short fuelPercent = 0, short damagePercent = 0) : base(vehicleName, fuelPercent, damagePercent)
        {
            
        }

        public Sedan(short id, string vehicleName, short fuelPercent = 0, short damagePercent = 0) : base(id, vehicleName, fuelPercent, damagePercent)
        {

        }

        public Sedan(Vehicle vehicle) : base(vehicle)
        {
            
        }

        public override void UpdateLanguage(Language language)
        {
            labelID.Text = language.Translate("ID");
            labelVehicleName.Text = language.Translate("Vehicle name");
            labelVehicleType.Text = language.Translate("Vehicle type");
            labelVehicleTypeValue.Text = language.Translate("Sedan");
            labelDamagePercentage.Text = language.Translate("Damage percentage");
            labelFuelPercentage.Text = language.Translate("Fuel percentage");

            checkboxSelect.Text = language.Translate("Select");

            buttonRent.Text = language.Translate("Rent");
        }

        public override object Clone()
        {
            return new Sedan(ID, VehicleName, FuelPercentage, DamagePercentage);
        }
    }
}
