using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Car_Rental_Application.User_Controls;

namespace CarRentalApplication.Classes
{
    static class XmlManager
    {
        public static void StoreVehiclesToXMLFile(List<Vehicle> vehicles, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Vehicle>));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream stream = File.OpenWrite(filePath))
            {
                serializer.Serialize(stream, vehicles);
            }
        }

        public static List<Vehicle> ReadVehiclesFromXMLFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Vehicle>();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Vehicle>));
            using (FileStream stream = File.OpenRead(filePath))
            {
                List<Vehicle> deserializedList = (List<Vehicle>)serializer.Deserialize(stream);
                return deserializedList;
            }
        }

        public static void StoreRentalsToXMLFile(List<Rental> rentals, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Rental>));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream stream = File.OpenWrite(filePath))
            {
                serializer.Serialize(stream, rentals);
            }
        }

        public static List<Rental> ReadRentalsFromXMLFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Rental>();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Rental>));
            using (FileStream stream = File.OpenRead(filePath))
            {
                List<Rental> deserializedList = (List<Rental>)serializer.Deserialize(stream);
                return deserializedList;
            }
        }
    }
}
