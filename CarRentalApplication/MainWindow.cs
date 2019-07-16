using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Car_Rental_Application.User_Controls;
using CarRentalApplication.Classes;
using CarRentalApplication.Forms;
using CarRentalApplication.Logging;

namespace CarRentalApplication
{
    public partial class MainWindow : Form
    {
        List <Rental> rentals;
        List <Vehicle> vehicles;

        VehicleSorter vehicleSorter;
        RentalSorter rentalSorter;

        Logger returnedVehiclesLogManager;

        SqlManager sqlManager;

        List<int> indexesOfSelectedVehicles = new List<int>();
        List<int> indexesOfSelectedRentals = new List<int>();
            
        public MainWindow()
        {
            InitializeComponent();

            errorLabel.Text = "";
            
            returnedVehiclesLogManager = new Logger("log.txt");

            vehicles = new List<Vehicle>();
            rentals = new List<Rental>();

            vehicleSorter = new VehicleSorter();
            rentalSorter  = new RentalSorter();

            saveToDatabaseToolStripMenuItem.Available = false;
            loadFromDatabaseToolStripMenuItem.Available = false;

            InitializeSortOptionsForVehicles();
            InitializeSortOptionsForRentals();

            timerProgramDateUpdater.Start();

            IDManagement.InitializeIndexes();
        }

        void InitializeSortOptionsForVehicles()
        {
            sortVehicleSelectionComboBox.Items.Clear();

            string textID   = Program.Language.Translate("ID");
            string textName = Program.Language.Translate("Name");
            string textType = Program.Language.Translate("Type");

            string textFuelPercentage   = Program.Language.Translate("Fuel percentage");
            string textDamagePercentage = Program.Language.Translate("Damage percentage");


            SortSelectionItem selectionID   = new SortSelectionItem(textID, Constants.SORT_BY_ID);
            SortSelectionItem selectionName = new SortSelectionItem(textName, Constants.SORT_BY_VEHICLE_NAME);
            SortSelectionItem selectionType = new SortSelectionItem(textType, Constants.SORT_BY_VEHICLE_TYPE);

            SortSelectionItem selectionFuelPercentage   = new SortSelectionItem(textFuelPercentage, Constants.SORT_BY_VEHICLE_FUEL_PERCENTAGE);
            SortSelectionItem selectionDamagePercentage = new SortSelectionItem(textDamagePercentage, Constants.SORT_BY_VEHICLE_DAMAGE_PERCENTAGE);


            sortVehicleSelectionComboBox.Items.Add(selectionID);
            sortVehicleSelectionComboBox.Items.Add(selectionName);
            sortVehicleSelectionComboBox.Items.Add(selectionType);
            sortVehicleSelectionComboBox.Items.Add(selectionFuelPercentage);
            sortVehicleSelectionComboBox.Items.Add(selectionDamagePercentage);

            sortVehicleSelectionComboBox.SelectedIndex = 0;
        }

        void InitializeSortOptionsForRentals()
        {
            sortRentalSelectionComboBox.Items.Clear();

            string textID        = Program.Language.Translate("ID");
            string textVehicleID = Program.Language.Translate("Vehicle ID");
            string textName      = Program.Language.Translate("Vehicle name");
            string textType      = Program.Language.Translate("Vehicle type");
            string textFuel      = Program.Language.Translate("Vehicle fuel percentage");
            string textDamage    = Program.Language.Translate("Vehicle damage percentage");

            string textOwnerName  = Program.Language.Translate("Owner name");
            string textOwnerPhone = Program.Language.Translate("Owner phone");
            string textReturnDate = Program.Language.Translate("Return date");


            SortSelectionItem selectionID        = new SortSelectionItem(textID, Constants.SORT_BY_ID);
            SortSelectionItem selectionVehicleID = new SortSelectionItem(textVehicleID, Constants.SORT_BY_VEHICLE_ID);
            SortSelectionItem selectionName      = new SortSelectionItem(textName, Constants.SORT_BY_VEHICLE_NAME);
            SortSelectionItem selectionType      = new SortSelectionItem(textType, Constants.SORT_BY_VEHICLE_TYPE);
            SortSelectionItem selectionFuel      = new SortSelectionItem(textFuel, Constants.SORT_BY_VEHICLE_FUEL_PERCENTAGE);
            SortSelectionItem selectionDamage    = new SortSelectionItem(textDamage, Constants.SORT_BY_VEHICLE_DAMAGE_PERCENTAGE);

            SortSelectionItem selectionOwnerName  = new SortSelectionItem(textOwnerName, Constants.SORT_BY_VEHICLE_OWNER_NAME);
            SortSelectionItem selectionOwnerPhone = new SortSelectionItem(textOwnerPhone, Constants.SORT_BY_VEHICLE_OWNER_PHONE_NUMBER);
            SortSelectionItem selectionReturnDate = new SortSelectionItem(textReturnDate, Constants.SORT_BY_VEHICLE_RETURN_DATE);


            sortRentalSelectionComboBox.Items.Add(selectionID);
            sortRentalSelectionComboBox.Items.Add(selectionVehicleID);
            sortRentalSelectionComboBox.Items.Add(selectionName);
            sortRentalSelectionComboBox.Items.Add(selectionType);
            sortRentalSelectionComboBox.Items.Add(selectionFuel);
            sortRentalSelectionComboBox.Items.Add(selectionDamage);

            sortRentalSelectionComboBox.Items.Add(selectionOwnerName);
            sortRentalSelectionComboBox.Items.Add(selectionOwnerPhone);
            sortRentalSelectionComboBox.Items.Add(selectionReturnDate);

            sortRentalSelectionComboBox.SelectedIndex = 0;
        }

        public int GetVehicleIndex(Vehicle vehicle)
        {
            return vehicles.IndexOf(vehicle);
        }

        public int GetRentalIndex(Rental rental)
        {
            return rentals.IndexOf(rental);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            vehicles.Add(vehicle);
            IDManagement.MarkVehicleIDAsUnavailable(vehicle.ID);
            PopulateVehiclesPanel();
        }

        void AddRental(Rental rental)
        {
            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            rentals.Add(rental);
            IDManagement.MarkRentalIDAsUnavailable(rental.ID);
            PopulateRentalsPanel();
        }

        #region Forms

        private void AddVehicleForm(object sender, EventArgs e)
        {
            FormAddVehicle formAddVehicle = new FormAddVehicle();

            var result = formAddVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                Vehicle vehicleToBeAdded = formAddVehicle.Vehicle;
                AddVehicle(vehicleToBeAdded);
            }
        }

        public void RentForm(Vehicle vehicle)
        {
            FormRentVehicle formRentVehicle = new FormRentVehicle(vehicle);

            var result = formRentVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                Rental rental = formRentVehicle.Rental;
                AddRental(rental);
                RemoveVehicle(vehicle, false);
            }
        }

        public void ReturnForm(Rental rental)
        {
            FormReturnVehicle formReturnVehicle = new FormReturnVehicle(rental);

            var result = formReturnVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                Vehicle returnedVehicle = formReturnVehicle.ReturnedVehicle;
                string orderDetails = formReturnVehicle.OrderDetails;

                returnedVehiclesLogManager.WriteToLog(orderDetails);

                AddVehicle(returnedVehicle);
                RemoveRental(rental, true, false);
            }
        }

        public void SqlConnectionForm()
        {
            FormSqlConnection formSqlConnection = new FormSqlConnection();

            var result = formSqlConnection.ShowDialog();
            if (result == DialogResult.OK)
            {
                MessageBox.Show(formSqlConnection.ConnectionString);
                sqlManager = new SqlManager(formSqlConnection.ConnectionString);
            }
        }

        #endregion


        #region Toolstrip Menu

        #region Database

        private void connectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnectionForm();

            if (sqlManager != null)
            {
                bool isConnected = sqlManager.ConnectionIsSuccesful();
                if (isConnected)
                {
                    saveToDatabaseToolStripMenuItem.Available = true;
                    loadFromDatabaseToolStripMenuItem.Available = true;
                    connectToDatabaseToolStripMenuItem.Available = false;
                }
                else
                {
                    errorLabel.Text = "Couldn't connect to database";
                    timerClearErrors.Start();
                }
            }
            
        }

        private void loadFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "load vehicles from the database";
            string consequence = "existing vehicles and rentals in the program will be removed";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            vehicles = sqlManager.GetVehiclesFromDatabase();
            rentals = sqlManager.GetRentalsFromDatabase(vehicles);

            foreach (Rental rental in rentals)
            {
                vehicles.Remove(rental.Vehicle);
            }
        }

        private void saveToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "save vehicles to the database";
            string consequence = "existing vehicles and rentals in the database will be removed";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            sqlManager.ClearVehiclesFromDatabase();
            sqlManager.ClearRentalsFromDatabase();

            foreach (Vehicle vehicle in vehicles)
                sqlManager.SaveVehicleToDatabase(vehicle);

            foreach (Rental rental in rentals)
                sqlManager.SaveRentalToDatabase(rental);
        }

        #endregion

        #region Local file

        private void saveToLocalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "save vehicles and rentals to local file";
            string consequence = "existing local file will be deleted";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            XmlManager.WriteVehiclesToXmlFile(vehicles, "vehicles.xml");
            XmlManager.WriteRentalsToXmlFile(rentals, "rentals.xml");
        }

        private void loadFromLocalFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string action = "load vehicles and rentals from local file";
            string consequence = "existing vehicles and rentals in the program will be removed";
            FormConfirmation formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            vehicles.Clear();
            rentals.Clear();

            List<Vehicle> importedVehicles = XmlManager.ReadVehiclesFromXmlFile("vehicles.xml");
            List<Rental> importedRentals = XmlManager.ReadRentalsFromXmlFile("rentals.xml");

            foreach (Vehicle vehicle in importedVehicles)
            {
                if (vehicle.Name == "Sedan")
                    vehicles.Add(new Sedan(vehicle));

                if (vehicle.Name == "Minivan")
                    vehicles.Add(new Minivan(vehicle));
            }

            foreach (Rental rental in importedRentals)
            {
                rentals.Add(new Rental(rental));
            }

            PopulateVehiclesPanel();
            PopulateRentalsPanel();
        }

        #endregion

        #region Order logs

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(returnedVehiclesLogManager.LogPath) || new FileInfo(returnedVehiclesLogManager.LogPath).Length == 0)
            {
                errorLabel.Text = ErrorMessages.NO_LOG_CREATED;
                timerClearErrors.Start();

                return;
            }

            errorLabel.Text = "";
            Process.Start(returnedVehiclesLogManager.LogPath);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(returnedVehiclesLogManager.LogPath) || new FileInfo(returnedVehiclesLogManager.LogPath).Length == 0)
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

            string oldLogManagerPath = returnedVehiclesLogManager.LogPath;
            returnedVehiclesLogManager = new Logger(oldLogManagerPath);

            if (File.Exists(returnedVehiclesLogManager.LogPath))
            {
                File.Delete(returnedVehiclesLogManager.LogPath);
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


        #region Language changing

        void UpdateLanguage(Language language)
        {
            Program.Language = language;

            buttonAddAvailableVehicle.Text = language.Translate("Add vehicle");
            buttonSelectAllAvailable.Text = language.Translate("Select all");
            buttonSelectAllRented.Text = language.Translate("Select all");
            buttonRemoveLastAvailableVehicle.Text = language.Translate("Remove last");
            buttonRemoveLastRentedCar.Text = language.Translate("Remove last");
            buttonRemoveSelectedAvailableCars.Text = language.Translate("Remove selected");
            buttonRemoveSelectedRentedCars.Text = language.Translate("Remove selected");
            buttonSortAvailableVehicles.Text = language.Translate("Sort");
            buttonSortRentedVehicles.Text = language.Translate("Sort");

            labelVehicles.Text = language.Translate("Vehicles");
            labelRentals.Text = language.Translate("Rentals");

            databaseToolStripMenuItem.Text = language.Translate("Database");
            connectToDatabaseToolStripMenuItem.Text = language.Translate("Connect to database");
            loadFromDatabaseToolStripMenuItem.Text = language.Translate("Load from database");
            saveToDatabaseToolStripMenuItem.Text = language.Translate("Save to database");
            localFileToolStripMenuItem.Text = language.Translate("Local file");
            loadFromLocalFileToolStripMenuItem.Text = language.Translate("Load from local file");
            saveToLocalFileToolStripMenuItem.Text = language.Translate("Save to local file");
            orderLogsToolStripMenuItem.Text = language.Translate("Order logs");
            openToolStripMenuItem.Text = language.Translate("Open");
            deleteToolStripMenuItem.Text = language.Translate("Delete");
            languageToolStripMenuItem.Text = language.Translate("Language");

            UpdateLanguageForExistingVehicles(language);
            UpdateLanguageForExistingRentals(language);

            InitializeSortOptionsForVehicles();
            InitializeSortOptionsForRentals();

            ErrorMessages.UpdateLanguage(language);
        }

        void UpdateLanguageForExistingVehicles(Language language)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.UpdateLanguage(language);
            }
        }

        void UpdateLanguageForExistingRentals(Language language)
        {
            foreach (Rental rental in rentals)
            {
                rental.UpdateLanguage(language);
            }
        }

        #endregion


        #region Selection / deselection

        #region Select / deselect single vehicle / rental

        public void SelectVehicle(int vehicleIndex)
        {
            if (!indexesOfSelectedVehicles.Contains(vehicleIndex))
                indexesOfSelectedVehicles.Add(vehicleIndex);
        }

        public void DeselectVehicle(int vehicleIndex)
        {
            indexesOfSelectedVehicles.Remove(vehicleIndex);
        }

        public void SelectRental(int rentalIndex)
        {
            if (!indexesOfSelectedRentals.Contains(rentalIndex))
                indexesOfSelectedRentals.Add(rentalIndex);
        }

        public void DeselectRental(int rentalIndex)
        {
            indexesOfSelectedRentals.Remove(rentalIndex);
        }

        #endregion

        #region Select / deselect all

        private void SelectAllVehicles(object sender, EventArgs e)
        {
            if (vehicles.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NO_VEHICLES_TO_SELECT;
                timerClearErrors.Start();
                return;
            }

            bool areAllSelected = true;
            foreach (Vehicle vehicle in vehicles)
            {
                if (!vehicle.Selected)
                {
                    areAllSelected = false;
                }
                vehicle.Selected = true;
            }

            // If all vehicles are already selected, deselect them
            if (areAllSelected)
            {
                foreach (Vehicle vehicle in vehicles)
                    vehicle.Selected = false;
            }

            errorLabel.Text = "";
        }

        private void buttonSelectAllRented_Click(object sender, EventArgs e)
        {
            if (rentals.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NO_RENTALS_TO_SELECT;
                timerClearErrors.Start();
                return;
            }

            bool areAllSelected = true;
            foreach (Rental vehicle in rentals)
            {
                if (!vehicle.Selected)
                {
                    areAllSelected = false;
                }
                vehicle.Selected = true;
            }

            // If all rentals are already selected, deselect them
            if (areAllSelected)
            {
                foreach (Rental rental in rentals)
                    rental.Selected = false;
            }

            errorLabel.Text = "";
        }

        #endregion

        #endregion


        #region Vehicle removal

        void RemoveVehicle(Vehicle vehicle, bool makeIDAvailable = true)
        {
            if (makeIDAvailable)
            {
                IDManagement.MarkVehicleIDAsAvailable(vehicle.ID);
            }

            availableCarsElementsPanel.VerticalScroll.Value = 0;
            vehicles.Remove(vehicle);
            PopulateVehiclesPanel();
        }

        private void RemoveLastVehicle(object sender, EventArgs e)
        {
            if (vehicles.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NO_VEHICLES_TO_REMOVE;
                timerClearErrors.Stop();
                timerClearErrors.Start();

                return;
            }

            string action = "remove the last vehicle";
            FormConfirmation formConfirmation = new FormConfirmation(action);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            Vehicle lastVehicle = vehicles[vehicles.Count - 1];
            IDManagement.MarkVehicleIDAsAvailable(lastVehicle.ID);

            lastVehicle.Selected = false;
            RemoveVehicle(lastVehicle);

            errorLabel.Text = "";
        }

        private void RemoveSelectedVehicles(object sender, EventArgs e)
        {
            if (indexesOfSelectedVehicles.Count > 0)
            {
                string action = "remove the selected vehicles";
                FormConfirmation formConfirmation = new FormConfirmation(action);

                var result = formConfirmation.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }

                errorLabel.Text = "";

                // Store the vehicles to be removed in a temporary List
                List<Vehicle> vehiclesToBeRemoved = new List<Vehicle>();
                foreach (int index in indexesOfSelectedVehicles)
                {
                    short idToBeMarkedAsAvailable = vehicles[index].ID;
                    IDManagement.MarkVehicleIDAsAvailable(idToBeMarkedAsAvailable);
                    vehiclesToBeRemoved.Add(vehicles.ElementAt(index));
                }

                // Remove the stored vehicles from the vehicles List
                foreach (Vehicle vehicle in vehiclesToBeRemoved)
                {
                    vehicles.Remove(vehicle);
                }

                PopulateVehiclesPanel();
                indexesOfSelectedVehicles.Clear();
            }

            else
            {
                errorLabel.Text = ErrorMessages.NO_VEHICLES_SELECTED;
                timerClearErrors.Stop();
                timerClearErrors.Start();
            }
        }

        #endregion


        #region Rental removal

        public void RemoveRental(Rental rental, bool makeRentalIDAvailable = true, bool makeVehicleIDAvailable = true)
        {
            if (makeRentalIDAvailable)
            {
                IDManagement.MarkRentalIDAsAvailable(rental.ID);
            }

            if (makeVehicleIDAvailable)
            {
                IDManagement.MarkVehicleIDAsAvailable(rental.Vehicle.ID);
            }

            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            rentals.Remove(rental);
            PopulateRentalsPanel();
        }

        private void RemoveLastRental(object sender, EventArgs e)
        {
            if (rentals.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NO_RENTALS_TO_REMOVE;
                timerClearErrors.Stop();
                timerClearErrors.Start();

                return;
            }

            string action = "remove the last rental";
            FormConfirmation formConfirmation = new FormConfirmation(action);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            Rental lastRental = rentals[rentals.Count - 1];
            IDManagement.MarkRentalIDAsAvailable(lastRental.ID);

            lastRental.Selected = false;
            RemoveRental(lastRental);

            errorLabel.Text = "";
        }

        private void RemoveSelectedRentals(object sender, EventArgs e)
        {
            if (indexesOfSelectedRentals.Count > 0)
            {
                string action = "remove the selected rentals";
                FormConfirmation formConfirmation = new FormConfirmation(action);

                var result = formConfirmation.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }

                errorLabel.Text = "";

                // Store the rentals to be removed in a temporary List
                List<Rental> rentalsToBeRemoved = new List<Rental>();
                foreach (int index in indexesOfSelectedRentals)
                {
                    short idToBeMarkedAsAvailable = rentals[index].ID;
                    IDManagement.MarkRentalIDAsAvailable(idToBeMarkedAsAvailable);
                    rentalsToBeRemoved.Add(rentals.ElementAt(index));
                }

                // Remove the stored vehicles from the vehicles List
                foreach (Rental rental in rentalsToBeRemoved)
                {
                    rentals.Remove(rental);
                }

                PopulateRentalsPanel();
                indexesOfSelectedRentals.Clear();
            }

            else
            {
                errorLabel.Text = ErrorMessages.NO_RENTALS_SELECTED;
                timerClearErrors.Stop();
                timerClearErrors.Start();
            }
        }

        #endregion


        #region Vehicle and rental panels update


        public void PopulateVehiclesPanel()
        {
            availableCarsElementsPanel.Controls.Clear();
            short counter = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.LinkToMainWindow(this);
                availableCarsElementsPanel.Controls.Add(vehicle);
                vehicle.Location = new Point(0, counter++ * 100);
            }
        }

        public void PopulateRentalsPanel()
        {
            rentedCarsElementsPanel.Controls.Clear();
            short counter = 0;

            foreach (Rental rental in rentals)
            {
                rental.LinkToMainWindow(this);
                rentedCarsElementsPanel.Controls.Add(rental);
                rental.Location = new Point(0, counter++ * 150);
            }
        }

        #endregion


        #region Sorting
        
        private void SortAvailableVehicles(object sender, EventArgs e)
        {
            
            int sortSelection = ((SortSelectionItem)sortVehicleSelectionComboBox.SelectedItem).Value;

            if (sortSelection == Constants.SORT_BY_ID)
            {
                vehicles = vehicleSorter.SortListByID(vehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_NAME)
            {
                vehicles = vehicleSorter.SortListByName(vehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_TYPE)
            {
                vehicles = vehicleSorter.SortListByType(vehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_FUEL_PERCENTAGE)
            {
                vehicles = vehicleSorter.SortListByFuelPercent(vehicles);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_DAMAGE_PERCENTAGE)
            {
                vehicles = vehicleSorter.SortListByDamagePercent(vehicles);
            }

            PopulateVehiclesPanel();
            
        }

        private void SortRentedVehicles(object sender, EventArgs e)
        {
            int sortSelection = ((SortSelectionItem)sortRentalSelectionComboBox.SelectedItem).Value;

            if (sortSelection == Constants.SORT_BY_ID)
            {
                rentals = rentalSorter.SortListByID(rentals);
            } 

            if (sortSelection == Constants.SORT_BY_VEHICLE_ID)
            {
                rentals = rentalSorter.SortListByVehicleID(rentals);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_NAME)
            {
                rentals = rentalSorter.SortListByVehicleName(rentals);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_TYPE)
            {
                rentals = rentalSorter.SortListByVehicleType(rentals);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_FUEL_PERCENTAGE)
            {
                rentals = rentalSorter.SortListByVehicleFuelPercentage(rentals);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_DAMAGE_PERCENTAGE)
            {
                rentals = rentalSorter.SortListByVehicleDamagePercentage(rentals);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_OWNER_NAME)
            {
                rentals = rentalSorter.SortListByOwnerName(rentals);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_OWNER_PHONE_NUMBER)
            {
                rentals = rentalSorter.SortListByOwnerPhoneNumber(rentals);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_RETURN_DATE)
            {
                rentals = rentalSorter.SortListByReturnDate(rentals);
            }
            
            PopulateRentalsPanel();
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
