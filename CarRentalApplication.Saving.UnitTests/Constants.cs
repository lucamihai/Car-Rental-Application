using System;
using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Saving.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        public const string VehiclesJsonString = "[{\"Id\":1,\"Name\":\"Name1\",\"Type\":null,\"FuelPercentage\":100,\"DamagePercentage\":0},{\"Id\":2,\"Name\":\"Name2\",\"Type\":null,\"FuelPercentage\":43,\"DamagePercentage\":2}]";
        public const string RentalsJsonString = "[{\"Id\":1,\"Vehicle\":{\"Id\":1,\"Name\":\"Name1\",\"Type\":null,\"FuelPercentage\":100,\"DamagePercentage\":0},\"Owner\":{\"Name\":\"Name1\",\"PhoneNumber\":\"PhoneNumber1\"},\"ReturnDate\":\"2019-07-20T00:00:00\"},{\"Id\":2,\"Vehicle\":{\"Id\":2,\"Name\":\"Name2\",\"Type\":null,\"FuelPercentage\":43,\"DamagePercentage\":2},\"Owner\":{\"Name\":\"Name2\",\"PhoneNumber\":\"PhoneNumber2\"},\"ReturnDate\":\"2019-07-21T00:00:00\"}]";

        public const short Id1 = 1;
        public const short Id2 = 2;

        public const string Name1 = "Name1";
        public const string Name2 = "Name2";

        public const short FuelPercentage1 = 100;
        public const short FuelPercentage2 = 43;

        public const short DamagePercentage1 = 0;
        public const short DamagePercentage2 = 2;

        public const string PhoneNumber1 = "PhoneNumber1";
        public const string PhoneNumber2 = "PhoneNumber2";

        public static DateTime ReturnDate1 = new DateTime(2019, 7, 20);
        public static DateTime ReturnDate2 = new DateTime(2019, 7, 21);
    }
}
