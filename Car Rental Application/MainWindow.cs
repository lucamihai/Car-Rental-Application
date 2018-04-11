using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;
using Car_Rental_Application.User_Controls;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Globalization;

namespace Car_Rental_Application
{
    public partial class MainWindow : Form
    {
        List <VehicleUserControl> availableVehicles;
        List<VehicleUserControl> rentedVehicles;

        AvailableCarsSorter availableCarsSorter;
        RentedCarsSorter rentedCarsSorter;

        AddVehicleUserControl addVehicleUserControl;
        RentVehicleUserControl rentVehicleUserControl;
        ReturnFromRentUserControl returnFromRentUserControl;

        DateTime programTime;

        public List<int> indexesOfSelectedAvailableCars = new List<int>();
        public List<int> indexesOfSelectedRentedCars = new List<int>();
            
        public MainWindow()
        {
            InitializeComponent();

            availableVehicles = new List<VehicleUserControl>();
            rentedVehicles = new List<VehicleUserControl>();

            availableCarsSorter = new AvailableCarsSorter();
            rentedCarsSorter = new RentedCarsSorter();

            saveToDatabaseToolStripMenuItem.Available = false;
            loadFromDatabaseToolStripMenuItem.Available = false;

            addVehicleUserControl = new AddVehicleUserControl(this);
            rentVehicleUserControl = new RentVehicleUserControl(this);
            returnFromRentUserControl = new ReturnFromRentUserControl(this);

            panelAddVehicles.Controls.Add(addVehicleUserControl);
            panelAddVehicles.Controls.Add(rentVehicleUserControl);
            panelAddVehicles.Controls.Add(returnFromRentUserControl);

            addVehicleUserControl.Hide();

            InitializeComboBoxSelections();

            timerProgramDateUpdater.Start();

            IDManagement.InitializeIndexes();          
        }

        void InitializeComboBoxSelections()
        {
            sortAvailableSelectionComboBox.SelectedIndex = sortAvailableSelectionComboBox.FindStringExact("By ID");
            sortRentedSelectionComboBox.SelectedIndex = sortRentedSelectionComboBox.FindStringExact("By ID");
        }       

        public void AddToAvailableCarsList(VehicleUserControl vehicle) { availableVehicles.Add(vehicle); }
        public void AddToRentedCarsList(VehicleUserControl vehicle) { rentedVehicles.Add(vehicle); }
        public void HideAddVehiclePanel() { panelAddVehicles.Hide(); }
        public int GetIndexOfAvailableVehicle(VehicleUserControl vehicle) { return availableVehicles.IndexOf(vehicle); }
        public int GetIndexOfRentedVehicle(VehicleUserControl vehicle) { return rentedVehicles.IndexOf(vehicle); }

        #region SQL

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
            catch(SqlException s) { errorLabel.Text = s.Message; }
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
            sqlConnection.Open();

            string query = "INSERT INTO availableVehicles (id, name, type, fuel, damage)";
            query += " VALUES (@id, @name, @type, @fuel, @damage)";
            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", vehicle.GetVehicleID());
            myCommand.Parameters.AddWithValue("@name", vehicle.GetVehicleName());
            string type = "";
            if (vehicle.GetType() == (new AvailableSedanUserControl()).GetType())
                type = "sedan";
            if (vehicle.GetType() == (new AvailableMinivanUserControl()).GetType())
                type = "minivan";
            myCommand.Parameters.AddWithValue("@type", type);
            myCommand.Parameters.AddWithValue("@fuel", vehicle.GetFuelPercentage());
            myCommand.Parameters.AddWithValue("@damage", vehicle.GetDamagePercentage());
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        void SaveRentedVehicleToSQLDatabase(VehicleUserControl vehicle)
        {
            sqlConnection.Open();

            string query = "INSERT INTO rentedVehicles (id, name, type, fuel, damage, rentID, ownerName, ownerPhone, returnDate)";
            query += " VALUES (@id, @name, @type, @fuel, @damage, @rentID, @ownerName, @ownerPhone, @returnDate)";

            string type = "";
            if (vehicle.GetType() == (new RentedSedanUserControl()).GetType())
                type = "sedan";
            if (vehicle.GetType() == (new RentedMinivanUserControl()).GetType())
                type = "minivan";

            SqlCommand myCommand = new SqlCommand(query, sqlConnection);
            myCommand.Parameters.AddWithValue("@id", vehicle.GetVehicleID());
            myCommand.Parameters.AddWithValue("@name", vehicle.GetVehicleName());
            myCommand.Parameters.AddWithValue("@type", type);
            myCommand.Parameters.AddWithValue("@fuel", vehicle.GetFuelPercentage());
            myCommand.Parameters.AddWithValue("@damage", vehicle.GetDamagePercentage());
            myCommand.Parameters.AddWithValue("@rentID", vehicle.GetRentID());
            myCommand.Parameters.AddWithValue("@ownerName", vehicle.GetOwner().GetName());
            myCommand.Parameters.AddWithValue("@ownerPhone", vehicle.GetOwner().GetPhoneNumber());
            myCommand.Parameters.AddWithValue("@returnDate", vehicle.GetReturnDate().ToShortDateString());
            myCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        void GetAvailableVehiclesFromSQLDatabase()
        {
            string sqlQuery = "SELECT id, name, type, fuel, damage FROM availableVehicles";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                short id; string name = ""; string type = ""; short fuel; short damage;
                availableVehicles.Clear();
                while (reader.Read())
                {
                    id = reader.GetInt16(reader.GetOrdinal("id"));
                    name = reader["name"].ToString();
                    type = reader["type"].ToString();
                    fuel = reader.GetInt16(reader.GetOrdinal("fuel"));
                    damage = reader.GetInt16(reader.GetOrdinal("damage"));
                    if (type == "sedan")
                    {
                        AvailableSedanUserControl sedan = new AvailableSedanUserControl();
                        sedan.FromDatabase(id, name, fuel, damage);
                        availableVehicles.Add(sedan);
                    }
                    if (type == "minivan")
                    {
                        AvailableMinivanUserControl minivan = new AvailableMinivanUserControl();
                        minivan.FromDatabase(id, name, fuel, damage);
                        availableVehicles.Add(minivan);
                    }
                }
                reader.Close();
                PopulateAvailableVehiclesPanel();
            }
            catch (Exception ex)
            {
                //If an exception occurs, write it to the console
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        void GetRentedVehiclesFromSQLDatabase()
        {
            string sqlQuery = "SELECT id, name, type, fuel, damage, rentID, ownerName, ownerPhone, returnDate FROM rentedVehicles";
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                short id; string name = ""; string type = ""; short fuel; short damage; short rentID; string ownerName=""; string ownerPhone=""; string returnDate="";
                rentedVehicles.Clear();
                while (reader.Read())
                {
                    id = reader.GetInt16(reader.GetOrdinal("id"));
                    name = reader["name"].ToString();
                    type = reader["type"].ToString();
                    fuel = reader.GetInt16(reader.GetOrdinal("fuel"));
                    damage = reader.GetInt16(reader.GetOrdinal("damage"));
                    rentID = reader.GetInt16(reader.GetOrdinal("rentID"));
                    ownerName = reader["ownerName"].ToString();
                    ownerPhone = reader["ownerPhone"].ToString();
                    returnDate = reader["returnDate"].ToString();

                    Customer owner = new Customer(ownerName, ownerPhone);
                    Console.WriteLine(type);
                    if (type == "sedan")
                    {
                        RentedSedanUserControl sedan = new RentedSedanUserControl();
                        sedan.FromDatabase(id, name, fuel, damage, rentID, owner, returnDate);
                        rentedVehicles.Add(sedan);
                    }
                    if (type == "minivan")
                    {
                        RentedMinivanUserControl minivan = new RentedMinivanUserControl();
                        minivan.FromDatabase(id, name, fuel, damage, rentID, owner, returnDate);
                        rentedVehicles.Add(minivan);
                    }
                }
                reader.Close();
                PopulateAvailableVehiclesPanel();
                PopulateRentedVehiclesPanel();
            }
            catch (Exception ex)
            {
                //If an exception occurs, write it to the console
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public String SQLConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "tcp:carrentals.database.windows.net,1433";
            builder.UserID = "mihai";
            builder.Password = "Luca123456789";
            builder.InitialCatalog = "carrentals";

            Console.WriteLine("Conecting to SQL server.....");
            return builder.ConnectionString;
        }

        #endregion

        #region SQL ToolStripMenu

        private void connectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e) { ConnectToSQL(); }

        private void loadFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAvailableVehiclesFromSQLDatabase();
            GetRentedVehiclesFromSQLDatabase();
        }

        private void saveToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAvailableVehiclesDatabase();
            ClearRentedVehiclesDatabase();
            foreach (VehicleUserControl vehicle in availableVehicles)
                SaveAvailableVehicleToSQLDatabase(vehicle);
            foreach (VehicleUserControl vehicle in rentedVehicles)
                SaveRentedVehicleToSQLDatabase(vehicle);
        }

        #endregion

        #region Remove buttons

        private void button1_Click(object sender, EventArgs e)
        {
            if (availableVehicles.Count < 1) { errorLabel.Text = "There's nothing" + Environment.NewLine + " to remove"; timerClearErrors.Start(); return; }
            short idToBeMarkedAsAvailable = availableVehicles[availableVehicles.Count - 1].GetVehicleID();
            IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
            availableVehicles.RemoveAt(availableVehicles.Count-1);
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            availableCarsElementsPanel.Controls.Clear();
            foreach (VehicleUserControl sedan in availableVehicles)
                availableCarsElementsPanel.Controls.Add(sedan);
            errorLabel.Text = "";
        }        /* Remove last available car */

        private void buttonRemoveSelectedAvailableCars_Click(object sender, EventArgs e)
        {
            List<VehicleUserControl> vehiclesToBeRemoved = new List<VehicleUserControl>();
            foreach (int index in indexesOfSelectedAvailableCars)
            {
                short idToBeMarkedAsAvailable = availableVehicles[index].GetVehicleID();
                IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
                vehiclesToBeRemoved.Add(availableVehicles.ElementAt(index));
            }
            foreach (VehicleUserControl vehicle in vehiclesToBeRemoved)
                availableVehicles.Remove(vehicle);
            PopulateAvailableVehiclesPanel();
            indexesOfSelectedAvailableCars.Clear();
        }

        private void buttonRemoveSelectedRentedCars_Click(object sender, EventArgs e)
        {
            List<VehicleUserControl> vehiclesToBeRemoved = new List<VehicleUserControl>();
            foreach (int index in indexesOfSelectedRentedCars)
            {
                short idToBeMarkedAsAvailable = rentedVehicles[index].GetVehicleID();
                IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
                short rentIDToBeMarkedAsAvailable = rentedVehicles[index].GetRentID();
                IDManagement.MarkRentIDAsAvailable(rentIDToBeMarkedAsAvailable);
                vehiclesToBeRemoved.Add(rentedVehicles.ElementAt(index));
            }
            foreach (VehicleUserControl vehicle in vehiclesToBeRemoved)
                rentedVehicles.Remove(vehicle);
            PopulateRentedVehiclesPanel();
            indexesOfSelectedRentedCars.Clear();
        }

        private void buttonRemoveLastRentedCar_Click(object sender, EventArgs e)
        {
            if (rentedVehicles.Count < 1) { errorLabel.Text = "There's nothing" + Environment.NewLine + " to remove"; timerClearErrors.Start(); return; }
            short idToBeMarkedAsAvailable = rentedVehicles[rentedVehicles.Count - 1].GetVehicleID();
            short rentIDToBeMarkedAsAvailable = rentedVehicles[rentedVehicles.Count - 1].GetRentID();
            IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
            IDManagement.MarkRentIDAsAvailable(rentIDToBeMarkedAsAvailable);
            rentedVehicles.RemoveAt(rentedVehicles.Count - 1);
            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            rentedCarsElementsPanel.Controls.Clear();
            foreach (VehicleUserControl vehicle in rentedVehicles)
                rentedCarsElementsPanel.Controls.Add(vehicle);
            errorLabel.Text = "";
        }

        #endregion

        #region Transition between available and rented cars zones

        public void RemoveAvailableCarFromList(VehicleUserControl vehicle) { availableVehicles.Remove(vehicle); PopulateAvailableVehiclesPanel(); }
        public void RemoveRentedCarFromList(VehicleUserControl vehicle) { rentedVehicles.Remove(vehicle); IDManagement.MarkRentIDAsAvailable(vehicle.GetRentID()); PopulateRentedVehiclesPanel(); }
        public void ReturnVehicleFromRent(VehicleUserControl vehicle) { availableVehicles.Add(vehicle); PopulateAvailableVehiclesPanel(); }

        #endregion

        #region Available and rented vehicles list update

        public void PopulateAvailableVehiclesPanel()
        {
            availableCarsElementsPanel.Controls.Clear();
            short counter = 0;
            foreach (VehicleUserControl vehicle in availableVehicles)
            {
                vehicle.LinkToMainWindow(this);
                vehicle.LinkToRentMenu(rentVehicleUserControl);
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
                vehicle.LinkToReturnMenu(returnFromRentUserControl);
                rentedCarsElementsPanel.Controls.Add(vehicle);
                vehicle.Location = new Point(0, counter++ * 100);
            }
        }

        #endregion
        

        public void AddAvailableVehicle(VehicleUserControl vehicle)
        {
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            AddToAvailableCarsList(vehicle);
            PopulateAvailableVehiclesPanel();
        }

        public void RentVehicle(VehicleUserControl vehicle)
        {
            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            AddToRentedCarsList(vehicle);
            PopulateRentedVehiclesPanel();
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            panelAddVehicles.Show();
            addVehicleUserControl.Show();
        }

        public void RentMenu() { panelAddVehicles.Show(); rentVehicleUserControl.Show(); }

        public void ReturnMenu() { panelAddVehicles.Show(); returnFromRentUserControl.Show(); }

        #region XML save and load

        public void ToXML(List<VehicleUserControl> list, string filePath)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<VehicleUserControl>));
            if (File.Exists(filePath)) File.Delete(filePath);

            using (FileStream stream = File.OpenWrite(filePath))
            {

                serializer.Serialize(stream, list);
            }
        }

        public List<VehicleUserControl> Read(string filePath)
        {
            if (!File.Exists(filePath)) { return new List<VehicleUserControl>(); }
            XmlSerializer serializer = new XmlSerializer(typeof(List<VehicleUserControl>));
            using (FileStream stream = File.OpenRead(filePath))
            {
                List<VehicleUserControl> dezerializedList = (List<VehicleUserControl>)serializer.Deserialize(stream);
                return dezerializedList;
            }
        }

        private void saveToLocalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToXML(availableVehicles, "availableVehiclesList.xml");
            ToXML(rentedVehicles, "rentedVehiclesList.xml");
        }

        private void loadFromLocalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            availableVehicles.Clear();
            rentedVehicles.Clear();
            List<VehicleUserControl> listOfImportedVehicles = Read("availableVehiclesList.xml");
            List<VehicleUserControl> listOfImportedRentedVehicles = Read("rentedVehiclesList.xml");
            foreach (VehicleUserControl vehicle in listOfImportedVehicles)
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
            foreach(VehicleUserControl vehicle in rentedVehicles)
            {               
                vehicle.configureRentedVehicle(RentVehicleConfiguration.GetRentConfiguration());
                IDManagement.MarkRentIDAsUnavailable(vehicle.GetRentID());
            }
            PopulateAvailableVehiclesPanel();
            PopulateRentedVehiclesPanel();
        }
        #endregion

        #region Sorting
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (sortAvailableSelectionComboBox.SelectedIndex == 0) availableVehicles = availableCarsSorter.SortListByID(availableVehicles);
            if (sortAvailableSelectionComboBox.SelectedIndex == 1) availableVehicles = availableCarsSorter.SortListByName(availableVehicles);
            if (sortAvailableSelectionComboBox.SelectedIndex == 2) availableVehicles = availableCarsSorter.SortListByType(availableVehicles);
            if (sortAvailableSelectionComboBox.SelectedIndex == 3) availableVehicles = availableCarsSorter.SortListByFuelPercent(availableVehicles);
            if (sortAvailableSelectionComboBox.SelectedIndex == 4) availableVehicles = availableCarsSorter.SortListByDamagePercent(availableVehicles);
            PopulateAvailableVehiclesPanel();
        }
        private void buttonSortRentedVehicles_Click(object sender, EventArgs e)
        {
            if (sortRentedSelectionComboBox.SelectedIndex == 0) rentedVehicles = rentedCarsSorter.SortListByID(rentedVehicles);
            if (sortRentedSelectionComboBox.SelectedIndex == 1) rentedVehicles = rentedCarsSorter.SortListByName(rentedVehicles);
            if (sortRentedSelectionComboBox.SelectedIndex == 2) rentedVehicles = rentedCarsSorter.SortListByType(rentedVehicles);
            if (sortRentedSelectionComboBox.SelectedIndex == 3) rentedVehicles = rentedCarsSorter.SortListByOwnerName(rentedVehicles);
            if (sortRentedSelectionComboBox.SelectedIndex == 4) rentedVehicles = rentedCarsSorter.SortListByOwnerPhoneNumber(rentedVehicles);
            if (sortRentedSelectionComboBox.SelectedIndex == 5) rentedVehicles = rentedCarsSorter.SortListByReturnDate(rentedVehicles);
            PopulateRentedVehiclesPanel();
        }
        #endregion

        private void timerProgramDateUpdater_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.Day.ToString() + "/" + currentTime.Month.ToString() + "/" + currentTime.Year.ToString() +
                 " " + currentTime.ToShortTimeString();
            labelProgramDate.Text = "Program date" + Environment.NewLine + currentTimeString;
            programTime = DateTime.Now;
        }

        private void timerClearErrors_Tick(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            timerClearErrors.Stop();
        }



    }
}
