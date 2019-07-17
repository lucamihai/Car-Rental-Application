using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Minivan : Vehicle
    {
        public Minivan()
        {
            Type = "Minivan";
        }
    }
}
