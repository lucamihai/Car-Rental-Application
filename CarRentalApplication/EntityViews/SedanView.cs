using CarRentalApplication.Translating;

namespace CarRentalApplication.EntityViews
{
    public partial class SedanView : VehicleView
    {
        public SedanView()
        {
            InitializeComponent();
        }

        public SedanView(string vehicleName, short fuelPercent = 0, short damagePercent = 0) : base(vehicleName, fuelPercent, damagePercent)
        {
            
        }

        public SedanView(short id, string vehicleName, short fuelPercent = 0, short damagePercent = 0) : base(id, vehicleName, fuelPercent, damagePercent)
        {

        }

        public SedanView(VehicleView vehicle) : base(vehicle)
        {
            
        }

        public override void UpdateLanguage(Language language)
        {
            labelId.Text = language.Translate("ID");
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
            return new SedanView(Id, VehicleName, FuelPercentage, DamagePercentage);
        }
    }
}
