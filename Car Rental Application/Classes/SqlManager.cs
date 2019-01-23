using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application.Classes
{
    class SqlManager
    {
        SqlConnection _sqlConnection
        {
            set
            {
                sqlConnection = value;

                if (ConnectionIsSuccesful())
                {
                    CreateTableRentalIfNotExists();
                }
            }
        }
        SqlConnection sqlConnection;

        public SqlManager(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public SqlManager(string dataSource, string userID, string password, string initialCatalog)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                UserID = userID,
                Password = password,
                InitialCatalog = initialCatalog
            };

            _sqlConnection = new SqlConnection(builder.ConnectionString);
        }

        public bool ConnectionIsSuccesful()
        {
            try
            {
                sqlConnection.Open();
                sqlConnection.Close();

                return true;
            }

            catch(Exception)
            {
                return false;
            }
            
        }

        void CreateTablesIfNotExisting()
        {
            CreateTableVehicleIfNotExists();
            CreateTableRentalIfNotExists();
        }

        void CreateTableVehicleIfNotExists()
        {
            string query =
                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='vehicles' AND xtype='U')
                    CREATE TABLE vehicles(
                        id int NOT NULL,
                        name VARCHAR(64) NOT NULL,
                        type VARCHAR(25),
                        fuel_percentage int,
                        damage_percentage int
                    )
                GO";
            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.ExecuteNonQuery();
        }

        void CreateTableRentalIfNotExists()
        {
            string query =
                @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='rentals' AND xtype='U')
                    CREATE TABLE rentals(
                        id int NOT NULL,
                        owner_name VARCHAR(64) NOT NULL,
                        owner_phone_number VARCHAR(20),
                        vehicle_id int
                    )
                GO";
            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.ExecuteNonQuery();
        }

        public void ClearVehiclesFromDatabase()
        {
            sqlConnection.Open();

            string query = "DELETE FROM vehicles";
            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void ClearRentalsFromDatabase()
        {
            sqlConnection.Open();

            string query = "DELETE FROM rentals";
            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void SaveVehicleToDatabase(Vehicle vehicle)
        {
            string query = "INSERT INTO vehicles (id, type, name, fuel_percentage, damage_percentage)";
            query += " VALUES (@id, @name, @type, @fuel, @damage)";

            sqlConnection.Open();

            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", vehicle.ID);
            myCommand.Parameters.AddWithValue("@type", vehicle.GetType().Name);
            myCommand.Parameters.AddWithValue("@name", vehicle.VehicleName);
            myCommand.Parameters.AddWithValue("@fuel", vehicle.FuelPercentage);
            myCommand.Parameters.AddWithValue("@damage", vehicle.DamagePercentage);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void SaveRentalToDatabase(Rental rental)
        {
            SaveVehicleToDatabase(rental.Vehicle);

            string query = "INSERT INTO rentals (id, owner_name, owner_phonenumber, return_date, vehicle_id)";
            query += " VALUES (@id, @owner_name, @owner_phone_number, @return_date, @vehicle_id)";

            sqlConnection.Open();

            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", rental.ID);
            myCommand.Parameters.AddWithValue("@owner_name", rental.Owner.Name);
            myCommand.Parameters.AddWithValue("@owner_phone_number", rental.Owner.PhoneNumber);
            myCommand.Parameters.AddWithValue("@return_date", rental.ReturnDate.ToShortDateString());
            myCommand.Parameters.AddWithValue("@vehicle_id", rental.Vehicle.ID);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<Vehicle> GetVehiclesFromDatabase()
        {
            List<Vehicle> importedVehicles = new List<Vehicle>();

            string sqlQuery = "SELECT id, type, name, fuel_percentage, damage_percentage FROM vehicles";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    short vehicleID = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("id"));
                    string vehicleType = sqlDataReader["type"].ToString();
                    string vehicleName = sqlDataReader["name"].ToString();
                    short vehicleFuelPercentage = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("fuel_percentage"));
                    short vehicleDamagePercentage = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("damage_percentage"));

                    if (vehicleType == "Sedan")
                    {
                        Sedan sedan = new Sedan(vehicleID, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                        importedVehicles.Add(sedan);
                    }

                    if (vehicleType == "Minivan")
                    {
                        Minivan minivan = new Minivan(vehicleID, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                        importedVehicles.Add(minivan);
                    }
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

        public List<Rental> GetRentalsFromDatabase(List<Vehicle> importedVehicles)
        {
            List<Rental> importedRentals = new List<Rental>();

            string sqlQuery = "SELECT id, owner_name, owner_phone_number, return_date, vehicle_id FROM rentals";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    short ID = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("id"));

                    string ownerName = sqlDataReader["owner_name"].ToString();
                    string ownerPhoneNumber = sqlDataReader["owner_phone_number"].ToString();
                    Person owner = new Person(ownerName, ownerPhoneNumber);

                    string returnDateString = sqlDataReader["return_date"].ToString();
                    DateTime returnDate = DateTime.Parse(returnDateString);

                    short vehicleID = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("vehicle_id"));
                    Vehicle vehicle = new Vehicle(GetVehicleWithID(importedVehicles, vehicleID));

                    Rental importedRental = new Rental(vehicle, owner, returnDate);
                    importedRentals.Add(importedRental);
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

        Vehicle GetVehicleWithID(List<Vehicle> vehicles, short vehicleID)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.ID == vehicleID)
                {
                    return vehicle;
                }
            }

            throw new Exception();
        }
    }
}
