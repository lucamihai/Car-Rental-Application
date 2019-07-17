using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using CarRentalApplication.EntityViews;

namespace CarRentalApplication.Classes
{
    public static class XmlManager
    {
        public static void WriteVehiclesToXmlFile(List<VehicleView> vehicles, string filePath)
        {
            DeleteFileIfExists(filePath);

            using (var fileStream = File.OpenWrite(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<VehicleView>));
                xmlSerializer.Serialize(fileStream, vehicles);
            }
        }

        public static void WriteRentalsToXmlFile(List<RentalView> rentals, string filePath)
        {
            DeleteFileIfExists(filePath);

            using (var fileStream = File.OpenWrite(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<RentalView>));
                xmlSerializer.Serialize(fileStream, rentals);
            }
        }

        public static List<VehicleView> ReadVehiclesFromXmlFile(string filePath)
        {
            ThrowIfFileDoesNotExist(filePath);

            using (var fileStream = File.OpenRead(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<VehicleView>));
                var deserializedList = (List<VehicleView>)xmlSerializer.Deserialize(fileStream);

                return deserializedList;
            }
        }

        public static List<RentalView> ReadRentalsFromXmlFile(string filePath)
        {
            ThrowIfFileDoesNotExist(filePath);

            using (var fileStream = File.OpenRead(filePath))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<RentalView>));
                var deserializedList = (List<RentalView>)xmlSerializer.Deserialize(fileStream);

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
