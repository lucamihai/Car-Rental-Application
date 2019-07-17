using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.EntityViews;

namespace CarRentalApplication.Classes
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

        public void SaveVehicleToDatabase(VehicleView vehicle)
        {
            string query = "INSERT INTO vehicles (id, type, name, fuel_percentage, damage_percentage)";
            query += " VALUES (@id, @name, @type, @fuel, @damage)";

            sqlConnection.Open();

            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", vehicle.Id);
            myCommand.Parameters.AddWithValue("@type", vehicle.GetType().Name);
            myCommand.Parameters.AddWithValue("@name", vehicle.VehicleName);
            myCommand.Parameters.AddWithValue("@fuel", vehicle.FuelPercentage);
            myCommand.Parameters.AddWithValue("@damage", vehicle.DamagePercentage);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void SaveRentalToDatabase(RentalView rental)
        {
            //TODO
            //SaveVehicleToDatabase(rental.RentedVehicle);

            string query = "INSERT INTO rentals (id, owner_name, owner_phonenumber, return_date, vehicle_id)";
            query += " VALUES (@id, @owner_name, @owner_phone_number, @return_date, @vehicle_id)";

            sqlConnection.Open();

            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", rental.Id);
            myCommand.Parameters.AddWithValue("@owner_name", rental.Owner.Name);
            myCommand.Parameters.AddWithValue("@owner_phone_number", rental.Owner.PhoneNumber);
            myCommand.Parameters.AddWithValue("@return_date", rental.ReturnDate.ToShortDateString());
            myCommand.Parameters.AddWithValue("@vehicle_id", rental.RentedVehicle.Id);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<VehicleView> GetVehiclesFromDatabase()
        {
            List<VehicleView> importedVehicles = new List<VehicleView>();

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
                        //TODO
                        //SedanView sedan = new SedanView(vehicleID, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                        //importedVehicles.Add(sedan);
                    }

                    if (vehicleType == "Minivan")
                    {
                        //TODO
                        //MinivanView minivan = new MinivanView(vehicleID, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                        //importedVehicles.Add(minivan);
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

        public List<RentalView> GetRentalsFromDatabase(List<VehicleView> importedVehicles)
        {
            List<RentalView> importedRentals = new List<RentalView>();

            string sqlQuery = "SELECT id, owner_name, owner_phone_number, return_date, vehicle_id FROM rentals";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    //TODO
                    //short ID = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("id"));

                    //string ownerName = sqlDataReader["owner_name"].ToString();
                    //string ownerPhoneNumber = sqlDataReader["owner_phone_number"].ToString();
                    //Person owner = new Person(ownerName, ownerPhoneNumber);

                    //string returnDateString = sqlDataReader["return_date"].ToString();
                    //DateTime returnDate = DateTime.Parse(returnDateString);

                    //short vehicleID = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("vehicle_id"));
                    //VehicleView vehicle = new VehicleView(GetVehicleWithID(importedVehicles, vehicleID));


                    //RentalView importedRental = new RentalView(vehicle, owner, returnDate);
                    //importedRentals.Add(importedRental);
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

        VehicleView GetVehicleWithID(List<VehicleView> vehicles, short vehicleID)
        {
            foreach (VehicleView vehicle in vehicles)
            {
                if (vehicle.Id == vehicleID)
                {
                    return vehicle;
                }
            }

            throw new Exception();
        }
    }
}
