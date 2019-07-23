using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Classes
{
    [ExcludeFromCodeCoverage]
    public static class ActionMessages
    {
        public static string SaveToDatabase => Program.Language.Translate("save vehicles and rentals to the database");
        public static string LoadFromDatabase => Program.Language.Translate("load vehicles and rentals from the database");

        public static string SaveToLocalFile => Program.Language.Translate("save vehicles and rentals to local file");
        public static string LoadFromLocalFile => Program.Language.Translate("load vehicles and rentals from local file");

        public static string DeleteExistingLog => Program.Language.Translate("delete the existing log");

        public static string RemoveLastVehicle => Program.Language.Translate("remove the last vehicle");
        public static string RemoveSelectedVehicles => Program.Language.Translate("remove the selected vehicles");

        public static string RemoveLastRental => Program.Language.Translate("remove the last rental");
        public static string RemoveSelectedRentals => Program.Language.Translate("remove the selected rentals");
    }
}
