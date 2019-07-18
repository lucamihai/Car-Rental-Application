using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Domain.Enums;

namespace CarRentalApplication.Saving
{
    public class SqlManager
    {
        private SqlConnection sqlConnection;
        private SqlConnection SqlConnection
        {
            set
            {
                sqlConnection = value;

                if (ConnectionIsSuccessful())
                {
                    CreateTablesIfNotExisting();
                }
            }
        }

        public SqlManager(string connectionString)
        {
            SqlConnection = new SqlConnection(connectionString);
        }

        public bool ConnectionIsSuccessful()
        {
            try
            {
                sqlConnection.Open();
                sqlConnection.Close();

                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public void ClearVehiclesFromDatabase()
        {
            sqlConnection.Open();

            var query = "DELETE FROM vehicles";
            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void ClearRentalsFromDatabase()
        {
            sqlConnection.Open();

            var query = "DELETE FROM rentals";
            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void SaveVehiclesToDatabase(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                SaveVehicleToDatabase(vehicle);
            }
        }

        public void SaveRentalsToDatabase(List<Rental> rentals)
        {
            foreach (var rental in rentals)
            {
                SaveRentalToDatabase(rental);
            }
        }

        private void SaveVehicleToDatabase(Vehicle vehicle)
        {
            var query = "INSERT INTO vehicles (id, name, type, fuel_percentage, damage_percentage)";
            query += " VALUES (@id, @name, @type, @fuel, @damage)";

            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", vehicle.Id);
            sqlCommand.Parameters.AddWithValue("@type", vehicle.Type.ToString());
            sqlCommand.Parameters.AddWithValue("@name", vehicle.Name);
            sqlCommand.Parameters.AddWithValue("@fuel", vehicle.FuelPercentage);
            sqlCommand.Parameters.AddWithValue("@damage", vehicle.DamagePercentage);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void SaveRentalToDatabase(Rental rental)
        {
            SaveVehicleToDatabase(rental.Vehicle);

            var query = "INSERT INTO rentals (id, owner_name, owner_phone_number, return_date, vehicle_id)";
            query += " VALUES (@id, @owner_name, @owner_phone_number, @return_date, @vehicle_id)";

            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", rental.Id);
            sqlCommand.Parameters.AddWithValue("@owner_name", rental.Owner.Name);
            sqlCommand.Parameters.AddWithValue("@owner_phone_number", rental.Owner.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@return_date", rental.ReturnDate.ToShortDateString());
            sqlCommand.Parameters.AddWithValue("@vehicle_id", rental.Vehicle.Id);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<Vehicle> GetVehiclesFromDatabase()
        {
            var importedVehicles = new List<Vehicle>();

            var sqlQuery = "SELECT id, type, name, fuel_percentage, damage_percentage FROM vehicles";
            var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            try
            {
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    var vehicleId = (short)sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id"));
                    var vehicleName = sqlDataReader["name"].ToString();
                    var vehicleFuelPercentage = (short)sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("fuel_percentage"));
                    var vehicleDamagePercentage = (short)sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("damage_percentage"));

                    Enum.TryParse<VehicleType>(sqlDataReader["type"].ToString(), out var vehicleType);

                    var importedVehicle = new Vehicle
                    {
                        Id = vehicleId,
                        Type = vehicleType,
                        Name = vehicleName,
                        FuelPercentage = vehicleFuelPercentage,
                        DamagePercentage = vehicleDamagePercentage
                    };

                    importedVehicles.Add(importedVehicle);
                }

                sqlDataReader.Close();
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            finally
            {
                sqlConnection.Close();
            }

            return importedVehicles;
        }

        public List<Rental> GetRentalsFromDatabase()
        {
            var importedRentals = new List<Rental>();

            var sqlQuery = "SELECT id, owner_name, owner_phone_number, return_date, vehicle_id FROM rentals";
            var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            try
            {
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    var id = (short)sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id"));

                    var ownerName = sqlDataReader["owner_name"].ToString();
                    var ownerPhoneNumber = sqlDataReader["owner_phone_number"].ToString();
                    var owner = new Person(ownerName, ownerPhoneNumber);

                    var returnDateString = sqlDataReader["return_date"].ToString();
                    var returnDate = DateTime.Parse(returnDateString);

                    var vehicleId = (short)sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("vehicle_id"));

                    var importedRental = new Rental
                    {
                        Id = id,
                        Owner = owner,
                        ReturnDate = returnDate,
                        Vehicle = new Vehicle { Id = vehicleId }
                    };
                    importedRentals.Add(importedRental);
                }

                sqlDataReader.Close();

                foreach (var importedRental in importedRentals)
                {
                    importedRental.Vehicle = GetVehicleById(importedRental.Vehicle.Id);
                }

                sqlDataReader.Close();
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            finally
            {
                sqlConnection.Close();
            }

            return importedRentals;
        }

        private void CreateTablesIfNotExisting()
        {
            CreateTableVehicleIfNotExists();
            CreateTableRentalIfNotExists();
        }

        private void CreateTableVehicleIfNotExists()
        {
            var query =
                @"
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='vehicles' AND xtype='U')
    CREATE TABLE vehicles(
        id int NOT NULL,
        name VARCHAR(64) NOT NULL,
        type VARCHAR(25),
        fuel_percentage int,
        damage_percentage int
)";

            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private void CreateTableRentalIfNotExists()
        {
            var query =
                @"
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='rentals' AND xtype='U')
    CREATE TABLE rentals(
        id int NOT NULL,
        owner_name VARCHAR(64) NOT NULL,
        owner_phone_number VARCHAR(20),
        return_date datetime NOT NULL,
        vehicle_id int
    )";

            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        private Vehicle GetVehicleById(short vehicleId)
        {
            var sqlQuery = $"SELECT id, type, name, fuel_percentage, damage_percentage FROM vehicles WHERE id = {vehicleId}";
            var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            var sqlDataReader = sqlCommand.ExecuteReader();

            if (!sqlDataReader.Read())
            {
                throw new InvalidOperationException();
            }

            var vehicleName = sqlDataReader["name"].ToString();
            var vehicleFuelPercentage = (short)sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("fuel_percentage"));
            var vehicleDamagePercentage = (short)sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("damage_percentage"));

            Enum.TryParse<VehicleType>(sqlDataReader["type"].ToString(), out var vehicleType);

            var vehicle = new Vehicle
            {
                Id = vehicleId,
                Name = vehicleName,
                Type = vehicleType,
                FuelPercentage = vehicleFuelPercentage,
                DamagePercentage = vehicleDamagePercentage
            };

            return vehicle;
        }
    }
}
