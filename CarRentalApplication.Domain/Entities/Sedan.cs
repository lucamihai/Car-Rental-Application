using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Sedan : Vehicle
    {
        public Sedan()
        {
            Type = "Sedan";
        }
    }
}
