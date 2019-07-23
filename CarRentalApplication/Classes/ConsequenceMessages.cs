using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Classes
{
    [ExcludeFromCodeCoverage]
    public static class ConsequenceMessages
    {
        public static string SaveToDatabase => Program.Language.Translate("existing vehicles and rentals in the database will be removed");
        public static string LoadFromDatabase => Program.Language.Translate("existing vehicles and rentals in the program will be removed");

        public static string SaveToLocalFile => Program.Language.Translate("existing local file will be deleted");
        public static string LoadFromLocalFile => Program.Language.Translate("existing vehicles and rentals in the program will be removed");
    }
}
