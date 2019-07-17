using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CarRentalApplication.Classes;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.EntityViews;
using CarRentalApplication.Forms;
using CarRentalApplication.Logging;
using CarRentalApplication.Translating;

namespace CarRentalApplication
{
    public partial class MainWindow : Form
    {
        private List<Vehicle> vehicles;
        private List<Rental> rentals;

        private List<RentalView> rentalViews;
        private List<VehicleView> vehicleViews;

        private readonly VehicleSorter vehicleSorter;
        private readonly RentalSorter rentalSorter;

        private Logger returnedVehiclesLogManager;

        private SqlManager sqlManager;

        private readonly List<int> indexesOfSelectedVehicles = new List<int>();
        private readonly List<int> indexesOfSelectedRentals = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            errorLabel.Text = "";

            returnedVehiclesLogManager = new Logger("log.txt");

            vehicles = new List<Vehicle>();
            rentals = new List<Rental>();

            vehicleViews = new List<VehicleView>();
            rentalViews = new List<RentalView>();

            vehicleSorter = new VehicleSorter();
            rentalSorter  = new RentalSorter();

            saveToDatabaseToolStripMenuItem.Available = false;
            loadFromDatabaseToolStripMenuItem.Available = false;

            InitializeSortOptionsForVehicles();
            InitializeSortOptionsForRentals();

            timerProgramDateUpdater.Start();

            IDManagement.InitializeIndexes();
        }

        private void InitializeSortOptionsForVehicles()
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

        private void InitializeSortOptionsForRentals()
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

        public int GetVehicleIndex(VehicleView vehicle)
        {
            return vehicleViews.IndexOf(vehicle);
        }

        public int GetRentalIndex(RentalView rental)
        {
            return rentalViews.IndexOf(rental);
        }

        public void AddVehicle(VehicleView vehicle)
        {
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            vehicleViews.Add(vehicle);
            IDManagement.MarkVehicleIDAsUnavailable(vehicle.Id);
            PopulateVehiclesPanel();
        }

        private void AddRental(RentalView rental)
        {
            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            rentalViews.Add(rental);
            IDManagement.MarkRentalIDAsUnavailable(rental.Id);
            PopulateRentalsPanel();
        }

        #region Forms

        private void AddVehicleForm(object sender, EventArgs e)
        {
            var formAddVehicle = new FormAddVehicle();

            var result = formAddVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                vehicles.Add(formAddVehicle.Vehicle);

                var vehicleView = new VehicleView(formAddVehicle.Vehicle);
                AddVehicle(vehicleView);
            }
        }

        public void RentForm(VehicleView vehicle)
        {
            FormRentVehicle formRentVehicle = new FormRentVehicle(vehicle);

            var result = formRentVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                RentalView rental = formRentVehicle.Rental;
                AddRental(rental);
                RemoveVehicle(vehicle, false);
            }
        }

        public void ReturnForm(RentalView rental)
        {
            FormReturnVehicle formReturnVehicle = new FormReturnVehicle(rental);

            var result = formReturnVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                VehicleView returnedVehicle = formReturnVehicle.ReturnedVehicle;
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

            vehicleViews = sqlManager.GetVehiclesFromDatabase();
            rentalViews = sqlManager.GetRentalsFromDatabase(vehicleViews);

            foreach (RentalView rental in rentalViews)
            {
                vehicleViews.Remove(rental.Vehicle);
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

            foreach (VehicleView vehicle in vehicleViews)
                sqlManager.SaveVehicleToDatabase(vehicle);

            foreach (RentalView rental in rentalViews)
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

            XmlManager.WriteVehiclesToXmlFile(vehicleViews, "vehicles.xml");
            XmlManager.WriteRentalsToXmlFile(rentalViews, "rentals.xml");
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

            vehicleViews.Clear();
            rentalViews.Clear();

            List<VehicleView> importedVehicles = XmlManager.ReadVehiclesFromXmlFile("vehicles.xml");
            List<RentalView> importedRentals = XmlManager.ReadRentalsFromXmlFile("rentals.xml");

            foreach (VehicleView vehicle in importedVehicles)
            {
                if (vehicle.Name == "Sedan")
                    vehicleViews.Add(new SedanView(vehicle));

                if (vehicle.Name == "Minivan")
                    vehicleViews.Add(new MinivanView(vehicle));
            }

            foreach (RentalView rental in importedRentals)
            {
                rentalViews.Add(new RentalView(rental));
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
                errorLabel.Text = ErrorMessages.NoLogCreated;
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

        private void UpdateLanguage(Language language)
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

        private void UpdateLanguageForExistingVehicles(Language language)
        {
            foreach (var vehicle in vehicleViews)
            {
                vehicle.UpdateLanguage(language);
            }
        }

        private void UpdateLanguageForExistingRentals(Language language)
        {
            foreach (var rental in rentalViews)
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
            if (vehicleViews.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NoVehiclesToSelect;
                timerClearErrors.Start();
                return;
            }

            bool areAllSelected = true;
            foreach (VehicleView vehicle in vehicleViews)
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
                foreach (VehicleView vehicle in vehicleViews)
                    vehicle.Selected = false;
            }

            errorLabel.Text = "";
        }

        private void buttonSelectAllRented_Click(object sender, EventArgs e)
        {
            if (rentalViews.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NoRentalsToSelect;
                timerClearErrors.Start();
                return;
            }

            bool areAllSelected = true;
            foreach (RentalView vehicle in rentalViews)
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
                foreach (RentalView rental in rentalViews)
                    rental.Selected = false;
            }

            errorLabel.Text = "";
        }

        #endregion

        #endregion


        #region Vehicle removal

        void RemoveVehicle(VehicleView vehicle, bool makeIDAvailable = true)
        {
            if (makeIDAvailable)
            {
                IDManagement.MarkVehicleIDAsAvailable(vehicle.Id);
            }

            availableCarsElementsPanel.VerticalScroll.Value = 0;
            vehicleViews.Remove(vehicle);
            PopulateVehiclesPanel();
        }

        private void RemoveLastVehicle(object sender, EventArgs e)
        {
            if (vehicleViews.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NoVehiclesToRemove;
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

            VehicleView lastVehicle = vehicleViews[vehicleViews.Count - 1];
            IDManagement.MarkVehicleIDAsAvailable(lastVehicle.Id);

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
                List<VehicleView> vehiclesToBeRemoved = new List<VehicleView>();
                foreach (int index in indexesOfSelectedVehicles)
                {
                    short idToBeMarkedAsAvailable = vehicleViews[index].Id;
                    IDManagement.MarkVehicleIDAsAvailable(idToBeMarkedAsAvailable);
                    vehiclesToBeRemoved.Add(vehicleViews.ElementAt(index));
                }

                // Remove the stored vehicles from the vehicles List
                foreach (VehicleView vehicle in vehiclesToBeRemoved)
                {
                    vehicleViews.Remove(vehicle);
                }

                PopulateVehiclesPanel();
                indexesOfSelectedVehicles.Clear();
            }

            else
            {
                errorLabel.Text = ErrorMessages.NoVehiclesSelected;
                timerClearErrors.Stop();
                timerClearErrors.Start();
            }
        }

        #endregion


        #region Rental removal

        public void RemoveRental(RentalView rental, bool makeRentalIDAvailable = true, bool makeVehicleIDAvailable = true)
        {
            if (makeRentalIDAvailable)
            {
                IDManagement.MarkRentalIDAsAvailable(rental.Id);
            }

            if (makeVehicleIDAvailable)
            {
                IDManagement.MarkVehicleIDAsAvailable(rental.Vehicle.Id);
            }

            rentedCarsElementsPanel.VerticalScroll.Value = 0;
            rentalViews.Remove(rental);
            PopulateRentalsPanel();
        }

        private void RemoveLastRental(object sender, EventArgs e)
        {
            if (rentalViews.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NoRentalsToRemove;
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

            RentalView lastRental = rentalViews[rentalViews.Count - 1];
            IDManagement.MarkRentalIDAsAvailable(lastRental.Id);

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
                List<RentalView> rentalsToBeRemoved = new List<RentalView>();
                foreach (int index in indexesOfSelectedRentals)
                {
                    short idToBeMarkedAsAvailable = rentalViews[index].Id;
                    IDManagement.MarkRentalIDAsAvailable(idToBeMarkedAsAvailable);
                    rentalsToBeRemoved.Add(rentalViews.ElementAt(index));
                }

                // Remove the stored vehicles from the vehicles List
                foreach (RentalView rental in rentalsToBeRemoved)
                {
                    rentalViews.Remove(rental);
                }

                PopulateRentalsPanel();
                indexesOfSelectedRentals.Clear();
            }

            else
            {
                errorLabel.Text = ErrorMessages.NoRentalsSelected;
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

            foreach (VehicleView vehicle in vehicleViews)
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

            foreach (RentalView rental in rentalViews)
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
                vehicleViews = vehicleSorter.SortListByID(vehicleViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_NAME)
            {
                vehicleViews = vehicleSorter.SortListByName(vehicleViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_TYPE)
            {
                vehicleViews = vehicleSorter.SortListByType(vehicleViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_FUEL_PERCENTAGE)
            {
                vehicleViews = vehicleSorter.SortListByFuelPercent(vehicleViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_DAMAGE_PERCENTAGE)
            {
                vehicleViews = vehicleSorter.SortListByDamagePercent(vehicleViews);
            }

            PopulateVehiclesPanel();
            
        }

        private void SortRentedVehicles(object sender, EventArgs e)
        {
            int sortSelection = ((SortSelectionItem)sortRentalSelectionComboBox.SelectedItem).Value;

            if (sortSelection == Constants.SORT_BY_ID)
            {
                rentalViews = rentalSorter.SortListByID(rentalViews);
            } 

            if (sortSelection == Constants.SORT_BY_VEHICLE_ID)
            {
                rentalViews = rentalSorter.SortListByVehicleID(rentalViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_NAME)
            {
                rentalViews = rentalSorter.SortListByVehicleName(rentalViews);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_TYPE)
            {
                rentalViews = rentalSorter.SortListByVehicleType(rentalViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_FUEL_PERCENTAGE)
            {
                rentalViews = rentalSorter.SortListByVehicleFuelPercentage(rentalViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_DAMAGE_PERCENTAGE)
            {
                rentalViews = rentalSorter.SortListByVehicleDamagePercentage(rentalViews);
            }

            if (sortSelection == Constants.SORT_BY_VEHICLE_OWNER_NAME)
            {
                rentalViews = rentalSorter.SortListByOwnerName(rentalViews);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_OWNER_PHONE_NUMBER)
            {
                rentalViews = rentalSorter.SortListByOwnerPhoneNumber(rentalViews);
            }
            
            if (sortSelection == Constants.SORT_BY_VEHICLE_RETURN_DATE)
            {
                rentalViews = rentalSorter.SortListByReturnDate(rentalViews);
            }
            
            PopulateRentalsPanel();
        }

        #endregion


        #region Timers

        private void ClearErrorsTick(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
            timerClearErrors.Stop();
        }

        private void ProgramDateTick(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now;
            labelProgramDate.Text = $"{currentTime.Day}/{currentTime.Month}/{currentTime.Year} {currentTime.ToShortTimeString()}";
        }

        #endregion
    }
}
