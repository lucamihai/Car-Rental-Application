using System;
using System.Collections.Generic;
using System.IO;
using CarRentalApplication.Domain.Entities;
using Newtonsoft.Json;

namespace CarRentalApplication.Classes
{
    public static class JsonManager
    {
        public static void WriteVehiclesToJsonFile(List<Vehicle> vehicles, string filePath)
        {
            var serializedVehicles = JsonConvert.SerializeObject(vehicles);
            File.WriteAllText(filePath, serializedVehicles);
        }

        public static void WriteRentalsToJsonFile(List<Rental> rentals, string filePath)
        {
            var serializedRentals = JsonConvert.SerializeObject(rentals);
            File.WriteAllText(filePath, serializedRentals); 
        }

        public static List<Vehicle> ReadVehiclesFromJsonFile(string filePath)
        {
            ThrowIfFileDoesNotExist(filePath);

            var fileContents = File.ReadAllText(filePath);
            var deserializedVehicles = JsonConvert.DeserializeObject<List<Vehicle>>(fileContents);

            return deserializedVehicles;
        }

        public static List<Rental> ReadRentalsFromJsonFile(string filePath)
        {
            ThrowIfFileDoesNotExist(filePath);

            var fileContents = File.ReadAllText(filePath);
            var deserializedVehicles = JsonConvert.DeserializeObject<List<Rental>>(fileContents);

            return deserializedVehicles;
        }

        private static void ThrowIfFileDoesNotExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"{filePath} does not exist");
            }
        }
    }
}
