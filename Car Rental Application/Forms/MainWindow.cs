using Car_Rental_Application.Classes;
using Car_Rental_Application.User_Controls;
using Car_Rental_Application.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace Car_Rental_Application
{
    public partial class MainWindow : Form
    {
        List <VehicleUserControl> availableVehicles;
        List<VehicleUserControl> rentedVehicles;

        AvailableCarsSorter availableCarsSorter;
        RentedCarsSorter rentedCarsSorter;

        DateTime programTime;

        ReturnedVehiclesLogManager returnedVehiclesLogManager;

        List<int> indexesOfSelectedAvailableCars = new List<int>();
        List<int> indexesOfSelectedRentedCars = new List<int>();
            
        public MainWindow()
        {
            InitializeComponent();

            errorLabel.Text = "";
            
            returnedVehiclesLogManager = new ReturnedVehiclesLogManager();
            returnedVehiclesLogManager.Path = "log.txt";

            availableVehicles = new List<VehicleUserControl>();
            rentedVehicles = new List<VehicleUserControl>();

            availableCarsSorter = new AvailableCarsSorter();
            rentedCarsSorter = new RentedCarsSorter();

            saveToDatabaseToolStripMenuItem.Available = false;
            loadFromDatabaseToolStripMenuItem.Available = false;

            InitializeSortByComboBoxesSelection();

            timerProgramDateUpdater.Start();

            IDManagement.InitializeIndexes();          
        }

        void InitializeSortByComboBoxesSelection()
        {
            sortAvailableSelectionComboBox.SelectedIndex = 0;
            sortRentedSelectionComboBox.SelectedIndex = 0;
        }

        public void AddToRentedCarsList(VehicleUserControl vehicle)
        {
            rentedVehicles.Add(vehicle);
        }

        public int GetAvailableVehicleIndex(VehicleUserControl vehicle)
        {
            return availableVehicles.IndexOf(vehicle);
        }

        public int GetRentedVehicleIndex(VehicleUserControl vehicle)
        {
            return rentedVehicles.IndexOf(vehicle);
        }

        public void AddAvailableVehicle(VehicleUserControl vehicle)
        {
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            availableVehicles.Add(vehicle);
            PopulateAvailableVehiclesPanel();
        }

        public void RentVehicle(VehicleUserControl vehicle)
        {
            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            AddToRentedCarsList(vehicle);
            PopulateRentedVehiclesPanel();
        }

        private void AddVehicle(object sender, EventArgs e)
        {
            FormAddVehicle formAddVehicle = new FormAddVehicle();

            var result = formAddVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                VehicleUserControl vehicleToBeAdded = formAddVehicle.Vehicle;
                AddAvailableVehicle(vehicleToBeAdded);
            }
        }

        public void RentForm(VehicleUserControl vehicle)
        {
            FormRentVehicle formRentVehicle = new FormRentVehicle(vehicle);

            var result = formRentVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                VehicleUserControl vehicleToBeRented = formRentVehicle.VehicleToBeRented;
                RentVehicle(vehicleToBeRented);

                RemoveAvailableCarFromList(vehicle);
            }
        }

        public void ReturnForm(VehicleUserControl vehicle)
        {
            FormReturnVehicle formReturnVehicle = new FormReturnVehicle(vehicle);

            var result = formReturnVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                VehicleUserControl returnedVehicle = formReturnVehicle.ReturnedVehicle;
                string orderDetails = formReturnVehicle.OrderDetails;

                returnedVehiclesLogManager.WriteToLog(orderDetails);

                ReturnVehicleFromRent(returnedVehicle);
                RemoveRentedCarFromList(vehicle);
            }
        }


        #region Toolstrip Menu

        #region Database

        private void connectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectToSQL();
        }

        private void loadFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "load vehicles from the database";
            string consequence = "existing vehicles in the program will be removed";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            GetAvailableVehiclesFromSQLDatabase();
            GetRentedVehiclesFromSQLDatabase();
        }

        private void saveToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "save vehicles to the database";
            string consequence = "existing vehicles in the database will be removed";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            ClearAvailableVehiclesDatabase();
            ClearRentedVehiclesDatabase();

            foreach (VehicleUserControl vehicle in availableVehicles)
                SaveAvailableVehicleToSQLDatabase(vehicle);

            foreach (VehicleUserControl vehicle in rentedVehicles)
                SaveRentedVehicleToSQLDatabase(vehicle);
        }

        #endregion

        #region Local file

        private void saveToLocalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "save vehicles to local file";
            string consequence = "existing local file will be deleted";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            StoreVehiclesToXMLFile(availableVehicles, "availableVehiclesList.xml");
            StoreVehiclesToXMLFile(rentedVehicles, "rentedVehiclesList.xml");
        }

        private void loadFromLocalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "load vehicles from local file";
            string consequence = "existing vehicles in the program will be removed";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            availableVehicles.Clear();
            rentedVehicles.Clear();

            List<VehicleUserControl> listOfImportedAvailableVehicles = ReadVehiclesFromXMLFile("availableVehiclesList.xml");
            List<VehicleUserControl> listOfImportedRentedVehicles = ReadVehiclesFromXMLFile("rentedVehiclesList.xml");

            foreach (VehicleUserControl vehicle in listOfImportedAvailableVehicles)
            {
                if (vehicle.Name == "AvailableSedanUserControl")
                    availableVehicles.Add(new AvailableSedanUserControl(vehicle));

                if (vehicle.Name == "AvailableMinivanUserControl")
                    availableVehicles.Add(new AvailableMinivanUserControl(vehicle));
            }

            foreach (VehicleUserControl vehicle in listOfImportedRentedVehicles)
            {
                if (vehicle.Name == "RentedSedanUserControl")
                    rentedVehicles.Add(new RentedSedanUserControl(vehicle));

                if (vehicle.Name == "RentedMinivanUserControl")
                    rentedVehicles.Add(new RentedMinivanUserControl(vehicle));
            }

            foreach (VehicleUserControl vehicle in rentedVehicles)
            {
                //vehicle.configureRentedVehicle(RentVehicleConfiguration.GetRentConfiguration());
                IDManagement.MarkRentIDAsUnavailable(vehicle.RentID);
            }

            PopulateAvailableVehiclesPanel();
            PopulateRentedVehiclesPanel();
        }

        #endregion

        #region Order logs

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(returnedVehiclesLogManager.Path) || new FileInfo(returnedVehiclesLogManager.Path).Length == 0)
            {
                errorLabel.Text = "There is no log created";
                timerClearErrors.Start();

                return;
            }

            errorLabel.Text = "";
            Process.Start(returnedVehiclesLogManager.Path);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(returnedVehiclesLogManager.Path) || new FileInfo(returnedVehiclesLogManager.Path).Length == 0)
            {
                return;
            }

            string action = "delete the existing log";
            FormConfirmation formConfirmation = new FormConfirmation(action);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            string oldLogManagerPath = returnedVehiclesLogManager.Path;
            returnedVehiclesLogManager = new ReturnedVehiclesLogManager();
            returnedVehiclesLogManager.Path = oldLogManagerPath;

            if (File.Exists(returnedVehiclesLogManager.Path))
            {
                File.Delete(returnedVehiclesLogManager.Path);
            }
        }

        #endregion

        #region Language

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLanguages formLanguages = new FormLanguages();

            var result = formLanguages.ShowDialog();
            if (result == DialogResult.OK)
            {
                Language chosenLanguage = formLanguages.ChosenLanguage;
                UpdateLanguage(chosenLanguage);
                Program.Language = chosenLanguage;
            }
        }

        #endregion

        #endregion


        #region SQL Server

        SqlConnection sqlConnection;

        void ConnectToSQL()
        {
            try
            {
                Console.WriteLine("Connecting to SQL SERVER");
                sqlConnection = new SqlConnection(SQLConnectionString());
                sqlConnection.Open();
                Console.WriteLine("Connected!");
                sqlConnection.Close();

                saveToDatabaseToolStripMenuItem.Available = true;
                loadFromDatabaseToolStripMenuItem.Available = true;
                connectToDatabaseToolStripMenuItem.Available = false;
            }
            catch (SqlException s)
            {
                if (s.Number == 40615)
                {
                    errorLabel.Text = "Error 40615" + Environment.NewLine + "This IP isn't allowed to access the database." +
                        Environment.NewLine + "Contact the database owner";
                }
                else
                {
                    errorLabel.Text = "Error " + s.Number.ToString();
                }
                timerClearErrors.Start();
            }
        }

        public string SQLConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "tcp:carrentals.database.windows.net,1433";
            builder.UserID = "mihai";
            builder.Password = "Luca123456789";
            builder.InitialCatalog = "carrentals";

            return builder.ConnectionString;
        }

        void ClearAvailableVehiclesDatabase()
        {
            sqlConnection.Open();

            string query = "DELETE FROM availableVehicles";
            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        void ClearRentedVehiclesDatabase()
        {
            sqlConnection.Open();

            string query = "DELETE FROM rentedVehicles";
            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        void SaveAvailableVehicleToSQLDatabase(VehicleUserControl vehicle)
        {
            string vehicleType = "";
            if (vehicle.GetType() == Constants.TYPE_AVAILABLE_SEDAN)
                vehicleType = "sedan";
            if (vehicle.GetType() == Constants.TYPE_AVAILABLE_MINIVAN)
                vehicleType = "minivan";

            string query = "INSERT INTO availableVehicles (id, name, type, fuel, damage)";
            query += " VALUES (@id, @name, @type, @fuel, @damage)";

            sqlConnection.Open();

            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", vehicle.ID);
            myCommand.Parameters.AddWithValue("@name", vehicle.VehicleName);
            myCommand.Parameters.AddWithValue("@type", vehicleType);
            myCommand.Parameters.AddWithValue("@fuel", vehicle.FuelPercentage);
            myCommand.Parameters.AddWithValue("@damage", vehicle.DamagePercentage);
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        void SaveRentedVehicleToSQLDatabase(VehicleUserControl vehicle)
        {
            string vehicleType = "";
            if (vehicle.GetType() == Constants.TYPE_RENTED_SEDAN)
                vehicleType = "sedan";
            if (vehicle.GetType() == Constants.TYPE_RENTED_MINIVAN)
                vehicleType = "minivan";


            string query = "INSERT INTO rentedVehicles (id, name, type, fuel, damage, rentID, ownerName, ownerPhone, returnDate)";
            query += " VALUES (@id, @name, @type, @fuel, @damage, @rentID, @ownerName, @ownerPhone, @returnDate)";

            sqlConnection.Open();

            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", vehicle.ID);
            myCommand.Parameters.AddWithValue("@name", vehicle.VehicleName);
            myCommand.Parameters.AddWithValue("@type", vehicleType);
            myCommand.Parameters.AddWithValue("@fuel", vehicle.FuelPercentage);
            myCommand.Parameters.AddWithValue("@damage", vehicle.DamagePercentage);
            myCommand.Parameters.AddWithValue("@rentID", vehicle.RentID);
            myCommand.Parameters.AddWithValue("@ownerName", vehicle.Owner.Name);
            myCommand.Parameters.AddWithValue("@ownerPhone", vehicle.Owner.PhoneNumber);
            myCommand.Parameters.AddWithValue("@returnDate", vehicle.ReturnDate.ToShortDateString());
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        void GetAvailableVehiclesFromSQLDatabase()
        {
            string sqlQuery = "SELECT id, name, type, fuel, damage FROM availableVehicles";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                availableVehicles.Clear();

                while (sqlDataReader.Read())
                {
                    short vehicleID = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("id"));
                    string vehicleName = sqlDataReader["name"].ToString();
                    string vehicleType = sqlDataReader["type"].ToString();
                    short vehicleFuelPercentage = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("fuel"));
                    short vehicleDamagePercentage = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("damage"));

                    if (vehicleType == "sedan")
                    {
                        AvailableSedanUserControl sedan = new AvailableSedanUserControl();
                        sedan.FromDatabase(vehicleID, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                        availableVehicles.Add(sedan);
                    }

                    if (vehicleType == "minivan")
                    {
                        AvailableMinivanUserControl minivan = new AvailableMinivanUserControl();
                        minivan.FromDatabase(vehicleID, vehicleName, vehicleFuelPercentage, vehicleDamagePercentage);
                        availableVehicles.Add(minivan);
                    }
                }

                sqlDataReader.Close();
                PopulateAvailableVehiclesPanel();
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            finally
            {
                sqlConnection.Close();
            }
        }

        void GetRentedVehiclesFromSQLDatabase()
        {
            string sqlQuery = "SELECT id, name, type, fuel, damage, rentID, ownerName, ownerPhone, returnDate FROM rentedVehicles";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                rentedVehicles.Clear();
                while (sqlDataReader.Read())
                {
                    short id = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("id"));
                    string name = sqlDataReader["name"].ToString();
                    string type = sqlDataReader["type"].ToString();
                    short fuel = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("fuel"));
                    short damage = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("damage"));
                    short rentID = sqlDataReader.GetInt16(sqlDataReader.GetOrdinal("rentID"));
                    string returnDateString = sqlDataReader["returnDate"].ToString();
                    DateTime returnDate = DateTime.Parse(returnDateString);

                    string ownerName = sqlDataReader["ownerName"].ToString();
                    string ownerPhone = sqlDataReader["ownerPhone"].ToString();
                    Person owner = new Person(ownerName, ownerPhone);

                    if (type == "sedan")
                    {
                        RentedSedanUserControl sedan = new RentedSedanUserControl(id, name, fuel, damage, rentID, owner, returnDate);
                        rentedVehicles.Add(sedan);
                    }

                    if (type == "minivan")
                    {
                        RentedMinivanUserControl minivan = new RentedMinivanUserControl(id, name, fuel, damage, rentID, owner, returnDate);
                        rentedVehicles.Add(minivan);
                    }
                }

                sqlDataReader.Close();
                PopulateRentedVehiclesPanel();
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            finally
            {
                sqlConnection.Close();
            }
        }

        #endregion


        #region XML save and load

        public void StoreVehiclesToXMLFile(List<VehicleUserControl> vehicles, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<VehicleUserControl>));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream stream = File.OpenWrite(filePath))
            {
                serializer.Serialize(stream, vehicles);
            }
        }

        public List<VehicleUserControl> ReadVehiclesFromXMLFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<VehicleUserControl>();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<VehicleUserControl>));
            using (FileStream stream = File.OpenRead(filePath))
            {
                List<VehicleUserControl> deserializedList = (List<VehicleUserControl>)serializer.Deserialize(stream);
                return deserializedList;
            }
        }

        #endregion


        #region Language changing

        void UpdateLanguage(Language language)
        {
            buttonAddAvailableVehicle.Text = language.Translate("Add vehicle");
            buttonSelectAllAvailable.Text = language.Translate("Select all");
            buttonSelectAllRented.Text = language.Translate("Select all");
            buttonRemoveLastAvailableVehicle.Text = language.Translate("Remove last");
            buttonRemoveLastRentedCar.Text = language.Translate("Remove last");
            buttonRemoveSelectedAvailableCars.Text = language.Translate("Remove selected");
            buttonRemoveSelectedRentedCars.Text = language.Translate("Remove selected");
            buttonSortAvailableVehicles.Text = language.Translate("Sort");
            buttonSortRentedVehicles.Text = language.Translate("Sort");

            labelAvailableVehicles.Text = language.Translate("Available cars");
            labelRentedVehicles.Text = language.Translate("Rented cars");

            connectToDatabaseToolStripMenuItem.Text = language.Translate("Connect to database");
            loadFromDatabaseToolStripMenuItem.Text = language.Translate("Load from database");
            saveToDatabaseToolStripMenuItem.Text = language.Translate("Save to database");
            loadFromLocalFileToolStripMenuItem.Text = language.Translate("Load from local file");
            saveToLocalFileToolStripMenuItem.Text = language.Translate("Save to local file");
            orderLogsToolStripMenuItem.Text = language.Translate("Order logs");
            openToolStripMenuItem.Text = language.Translate("Open");
            deleteToolStripMenuItem.Text = language.Translate("Delete");
            languageToolStripMenuItem.Text = language.Translate("Language");

            UpdateLanguageForExistingVehicles(language);
        }

        void UpdateLanguageForExistingVehicles(Language language)
        {
            UpdateLanguageForExistingAvailableVehicles(language);
            UpdateLanguageForExistingRentedVehicles(language);
        }

        void UpdateLanguageForExistingAvailableVehicles(Language language)
        {
            foreach (VehicleUserControl vehicle in availableVehicles)
            {
                vehicle.UpdateLanguage(language);
            }
        }

        void UpdateLanguageForExistingRentedVehicles(Language language)
        {
            foreach (VehicleUserControl vehicle in rentedVehicles)
            {
                vehicle.UpdateLanguage(language);
            }
        }

        #endregion


        #region Vehicle selection / deselection

        #region Select / deselect single vehicle

        public void SelectAvailableVehicle(int indexOfAvailableVehicle)
        {
            indexesOfSelectedAvailableCars.Add(indexOfAvailableVehicle);
        }

        public void DeselectAvailableVehicle(int indexOfAvailableVehicle)
        {
            indexesOfSelectedAvailableCars.Remove(indexOfAvailableVehicle);
        }

        public void SelectRentedVehicle(int indexOfAvailableVehicle)
        {
            indexesOfSelectedRentedCars.Add(indexOfAvailableVehicle);
        }

        public void DeselectRentedVehicle(int indexOfAvailableVehicle)
        {
            indexesOfSelectedRentedCars.Remove(indexOfAvailableVehicle);
        }

        #endregion

        #region Select / deselect all vehicles

        private void buttonSelectAllAvailable_Click(object sender, EventArgs e)
        {
            if (availableVehicles.Count < 1)
            {
                errorLabel.Text = "There are no available vehicles to select";
                timerClearErrors.Start();
                return;
            }

            bool areAllSelected = true;
            foreach (VehicleUserControl vehicle in availableVehicles)
            {
                if (!vehicle.Selected)
                {
                    areAllSelected = false;
                }
                vehicle.Selected = true;
            }

            // If all available vehicles are already selected, deselect them
            if (areAllSelected)
            {
                foreach (VehicleUserControl vehicle in availableVehicles)
                    vehicle.Selected = false;
            }
            errorLabel.Text = "";
        }

        private void buttonSelectAllRented_Click(object sender, EventArgs e)
        {
            if (rentedVehicles.Count < 1)
            {
                errorLabel.Text = "There are no rented vehicles to select";
                timerClearErrors.Start();
                return;
            }

            bool areAllSelected = true;
            foreach (VehicleUserControl vehicle in rentedVehicles)
            {
                if (!vehicle.Selected)
                {
                    areAllSelected = false;
                }
                vehicle.Selected = true;
            }

            // If all rented vehicles are already selected, deselect them
            if (areAllSelected)
            {
                foreach (VehicleUserControl vehicle in rentedVehicles)
                    vehicle.Selected = false;
            }
            errorLabel.Text = "";
        }

        #endregion

        #endregion


        #region Vehicle removal

        private void RemoveLastAvailableVehicle(object sender, EventArgs e)
        {
            string action = "remove the last available vehicle";
            FormConfirmation formConfirmation = new FormConfirmation(action);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            if (availableVehicles.Count < 1)
            {
                errorLabel.Text = "There's nothing" + Environment.NewLine + " to remove";
                timerClearErrors.Stop();
                timerClearErrors.Start();

                return;
            }

            VehicleUserControl lastVehicle = availableVehicles[availableVehicles.Count - 1];
            IDManagement.MarkIDAsAvailable(lastVehicle.ID);

            lastVehicle.Selected = false;
            availableVehicles.Remove(lastVehicle);

            availableCarsElementsPanel.VerticalScroll.Value = 0;
            availableCarsElementsPanel.Controls.Clear();

            foreach (VehicleUserControl vehicle in availableVehicles)
                availableCarsElementsPanel.Controls.Add(vehicle);

            errorLabel.Text = "";
        }

        private void RemoveLastRentedVehicle(object sender, EventArgs e)
        {
            string action = "remove the last rented vehicle";
            FormConfirmation formConfirmation = new FormConfirmation(action);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            if (rentedVehicles.Count < 1)
            {
                errorLabel.Text = "There's nothing" + Environment.NewLine + " to remove";
                timerClearErrors.Stop();
                timerClearErrors.Start();

                return;
            }

            VehicleUserControl lastVehicle = rentedVehicles[rentedVehicles.Count - 1];
            lastVehicle.Selected = false;

            short idToBeMarkedAsAvailable = lastVehicle.ID;
            short rentIDToBeMarkedAsAvailable = lastVehicle.RentID;
            IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
            IDManagement.MarkRentIDAsAvailable(rentIDToBeMarkedAsAvailable);

            rentedVehicles.Remove(lastVehicle);

            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            rentedCarsElementsPanel.Controls.Clear();

            foreach (VehicleUserControl vehicle in rentedVehicles)
                rentedCarsElementsPanel.Controls.Add(vehicle);

            errorLabel.Text = "";
        }

        private void RemoveSelectedAvailableVehicles(object sender, EventArgs e)
        {
            if (indexesOfSelectedAvailableCars.Count > 0)
            {
                string action = "remove the selected available vehicles";
                FormConfirmation formConfirmation = new FormConfirmation(action);

                var result = formConfirmation.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }

                errorLabel.Text = "";

                // Store the vehicles to be removed in a temporary List
                List<VehicleUserControl> vehiclesToBeRemoved = new List<VehicleUserControl>();
                foreach (int index in indexesOfSelectedAvailableCars)
                {
                    short idToBeMarkedAsAvailable = availableVehicles[index].ID;
                    IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
                    vehiclesToBeRemoved.Add(availableVehicles.ElementAt(index));
                }

                // Remove the stored vehicles from the availableVehicles List
                foreach (VehicleUserControl vehicle in vehiclesToBeRemoved)
                {
                    availableVehicles.Remove(vehicle);
                }

                PopulateAvailableVehiclesPanel();
                indexesOfSelectedAvailableCars.Clear();
            }

            else
            {
                errorLabel.Text = "You didn't select any available vehicle to remove";
                timerClearErrors.Stop();
                timerClearErrors.Start();
            }
        }

        private void RemoveSelectedRentedVehicles(object sender, EventArgs e)
        {
            if (indexesOfSelectedRentedCars.Count > 0)
            {
                string action = "remove the selected rented vehicles";
                FormConfirmation formConfirmation = new FormConfirmation(action);

                var result = formConfirmation.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }

                errorLabel.Text = "";

                // Store the vehicles to be removed in a temporary List
                List<VehicleUserControl> vehiclesToBeRemoved = new List<VehicleUserControl>();
                foreach (int index in indexesOfSelectedRentedCars)
                {
                    short idToBeMarkedAsAvailable = rentedVehicles[index].ID;
                    IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);

                    short rentIDToBeMarkedAsAvailable = rentedVehicles[index].RentID;
                    IDManagement.MarkRentIDAsAvailable(rentIDToBeMarkedAsAvailable);

                    vehiclesToBeRemoved.Add( rentedVehicles.ElementAt(index) );
                }

                // Remove the stored vehicles from the rentedVehicles List
                foreach (VehicleUserControl vehicle in vehiclesToBeRemoved)
                {
                    rentedVehicles.Remove(vehicle);
                }
                    
                PopulateRentedVehiclesPanel();
                indexesOfSelectedRentedCars.Clear();
            }

            else
            {
                errorLabel.Text = "You didn't select any rented vehicle to remove";
                timerClearErrors.Stop();
                timerClearErrors.Start();
            }
        }

        #endregion


        #region Transition between available and rented cars zones

        public void RemoveAvailableCarFromList(VehicleUserControl vehicle)
        {
            availableVehicles.Remove(vehicle);
            PopulateAvailableVehiclesPanel();
        }
        public void RemoveRentedCarFromList(VehicleUserControl vehicle)
        {
            rentedVehicles.Remove(vehicle);
            IDManagement.MarkRentIDAsAvailable(vehicle.RentID);
            PopulateRentedVehiclesPanel();
        }

        public void ReturnVehicleFromRent(VehicleUserControl vehicle)
        {
            availableVehicles.Add(vehicle);
            PopulateAvailableVehiclesPanel();
        }

        #endregion


        #region Available and rented vehicles list update

        public void PopulateAvailableVehiclesPanel()
        {
            availableCarsElementsPanel.Controls.Clear();
            short counter = 0;

            foreach (VehicleUserControl vehicle in availableVehicles)
            {
                vehicle.LinkToMainWindow(this);
                availableCarsElementsPanel.Controls.Add(vehicle);
                vehicle.Location = new Point(0, counter++ * 100);
            }
        }

        public void PopulateRentedVehiclesPanel()
        {
            rentedCarsElementsPanel.Controls.Clear();
            short counter = 0;

            foreach (VehicleUserControl vehicle in rentedVehicles)
            {
                vehicle.LinkToMainWindow(this);
                rentedCarsElementsPanel.Controls.Add(vehicle);
                vehicle.Location = new Point(0, counter++ * 100);
            }
        }

        #endregion


        #region Sorting

        private void SortAvailableVehicles(object sender, EventArgs e)
        {
            int sortSelection = sortAvailableSelectionComboBox.SelectedIndex;

            if (sortSelection == Constants.SORT_BY_VEHICLE_ID)
            {
                availableVehicles = availableCarsSorter.SortListByID(availableVehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_NAME)
            {
                availableVehicles = availableCarsSorter.SortListByName(availableVehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_TYPE)
            {
                availableVehicles = availableCarsSorter.SortListByType(availableVehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_FUEL_PERCENTAGE)
            {
                availableVehicles = availableCarsSorter.SortListByFuelPercent(availableVehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_DAMAGE_PERCENTAGE)
            {
                availableVehicles = availableCarsSorter.SortListByDamagePercent(availableVehicles);
            }

            PopulateAvailableVehiclesPanel();
        }

        private void SortRentedVehicles(object sender, EventArgs e)
        {
            int sortSelection = sortRentedSelectionComboBox.SelectedIndex;

            if (sortSelection == Constants.SORT_BY_VEHICLE_ID)
            {
                rentedVehicles = rentedCarsSorter.SortListByID(rentedVehicles);
            } 

            if (sortSelection == Constants.SORT_BY_VEHICLE_NAME)
            {
                rentedVehicles = rentedCarsSorter.SortListByName(rentedVehicles);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_TYPE)
            {
                rentedVehicles = rentedCarsSorter.SortListByType(rentedVehicles);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_OWNER_NAME)
            {
                rentedVehicles = rentedCarsSorter.SortListByOwnerName(rentedVehicles);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_OWNER_PHONE_NUMBER)
            {
                rentedVehicles = rentedCarsSorter.SortListByOwnerPhoneNumber(rentedVehicles);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_RETURN_DATE)
            {
                rentedVehicles = rentedCarsSorter.SortListByReturnDate(rentedVehicles);
            }
            
            PopulateRentedVehiclesPanel();
        }

        #endregion


        #region Timers

        private void ClearErrorsTick(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            timerClearErrors.Stop();
        }

        private void ProgramDateTick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            programTime = currentTime;

            string currentTimeString = "";
            currentTimeString += currentTime.Day.ToString() + "/";
            currentTimeString += currentTime.Month.ToString() + "/";
            currentTimeString += currentTime.Year.ToString() + " ";
            currentTimeString += currentTime.ToShortTimeString();

            labelProgramDate.Text = currentTimeString;
        }

        #endregion
    }
}
