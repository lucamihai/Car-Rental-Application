using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Car_Rental_Application.User_Controls;

namespace CarRentalApplication.Classes
{
    public static class XmlManager
    {
        public static void WriteVehiclesToXmlFile(List<Vehicle> vehicles, string filePath)
        {
            DeleteFileIfExists(filePath);

            using (var fileStream = File.OpenWrite(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));
                xmlSerializer.Serialize(fileStream, vehicles);
            }
        }

        public static void WriteRentalsToXmlFile(List<Rental> rentals, string filePath)
        {
            DeleteFileIfExists(filePath);

            using (var fileStream = File.OpenWrite(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Rental>));
                xmlSerializer.Serialize(fileStream, rentals);
            }
        }

        public static List<Vehicle> ReadVehiclesFromXmlFile(string filePath)
        {
            ThrowIfFileDoesNotExist(filePath);

            using (var fileStream = File.OpenRead(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Vehicle>));
                var deserializedList = (List<Vehicle>)xmlSerializer.Deserialize(fileStream);

                return deserializedList;
            }
        }

        public static List<Rental> ReadRentalsFromXmlFile(string filePath)
        {
            ThrowIfFileDoesNotExist(filePath);

            using (var fileStream = File.OpenRead(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<Rental>));
                var deserializedList = (List<Rental>)xmlSerializer.Deserialize(fileStream);

                return deserializedList;
            }
        }

        private static void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
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
