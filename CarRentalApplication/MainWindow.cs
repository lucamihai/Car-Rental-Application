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
using CarRentalApplication.Enums;
using CarRentalApplication.Forms;
using CarRentalApplication.Logging;
using CarRentalApplication.Saving;
using CarRentalApplication.Translating;

namespace CarRentalApplication
{
    public partial class MainWindow : Form
    {
        private List<Vehicle> vehicles;
        private List<Rental> rentals;

        private List<RentalView> rentalViews;
        private List<VehicleView> vehicleViews;

        private Logger returnedVehiclesLogManager;

        private SqlManager sqlManager;

        private readonly List<int> indexesOfSelectedVehicleViews = new List<int>();
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

            var textId = Program.Language.Translate("ID");
            var textName = Program.Language.Translate("Name");
            var textType = Program.Language.Translate("Type");
            var textFuelPercentage   = Program.Language.Translate("Fuel percentage");
            var textDamagePercentage = Program.Language.Translate("Damage percentage");

            var selectionId   = new SortSelectionItem(textId, SortOptions.ByVehicleId);
            var selectionName = new SortSelectionItem(textName, SortOptions.ByVehicleName);
            var selectionType = new SortSelectionItem(textType, SortOptions.ByVehicleType);
            var selectionFuelPercentage   = new SortSelectionItem(textFuelPercentage, SortOptions.ByVehicleFuelPercentage);
            var selectionDamagePercentage = new SortSelectionItem(textDamagePercentage, SortOptions.ByVehicleDamagePercentage);

            sortVehicleSelectionComboBox.Items.Add(selectionId);
            sortVehicleSelectionComboBox.Items.Add(selectionName);
            sortVehicleSelectionComboBox.Items.Add(selectionType);
            sortVehicleSelectionComboBox.Items.Add(selectionFuelPercentage);
            sortVehicleSelectionComboBox.Items.Add(selectionDamagePercentage);

            sortVehicleSelectionComboBox.SelectedIndex = 0;
        }

        private void InitializeSortOptionsForRentals()
        {
            sortRentalSelectionComboBox.Items.Clear();

            var textId = Program.Language.Translate("ID");
            var textVehicleId = Program.Language.Translate("Vehicle ID");
            var textVehicleName = Program.Language.Translate("Vehicle name");
            var textVehicleType = Program.Language.Translate("Vehicle type");
            var textVehicleFuelPercentage = Program.Language.Translate("Vehicle fuel percentage");
            var textVehicleDamagePercentage = Program.Language.Translate("Vehicle damage percentage");
            var textOwnerName  = Program.Language.Translate("Owner name");
            var textOwnerPhone = Program.Language.Translate("Owner phone");
            var textReturnDate = Program.Language.Translate("Return date");

            var selectionId = new SortSelectionItem(textId, SortOptions.ByRentalId);
            var selectionVehicleId = new SortSelectionItem(textVehicleId, SortOptions.ByVehicleId);
            var selectionVehicleName = new SortSelectionItem(textVehicleName, SortOptions.ByVehicleName);
            var selectionVehicleType = new SortSelectionItem(textVehicleType, SortOptions.ByVehicleType);
            var selectionVehicleFuelPercentage = new SortSelectionItem(textVehicleFuelPercentage, SortOptions.ByVehicleFuelPercentage);
            var selectionVehicleDamagePercentage = new SortSelectionItem(textVehicleDamagePercentage, SortOptions.ByVehicleDamagePercentage);
            var selectionOwnerName = new SortSelectionItem(textOwnerName, SortOptions.ByOwnerName);
            var selectionOwnerPhone = new SortSelectionItem(textOwnerPhone, SortOptions.ByOwnerPhoneNumber);
            var selectionReturnDate = new SortSelectionItem(textReturnDate, SortOptions.ByReturnDate);

            sortRentalSelectionComboBox.Items.Add(selectionId);
            sortRentalSelectionComboBox.Items.Add(selectionVehicleId);
            sortRentalSelectionComboBox.Items.Add(selectionVehicleName);
            sortRentalSelectionComboBox.Items.Add(selectionVehicleType);
            sortRentalSelectionComboBox.Items.Add(selectionVehicleFuelPercentage);
            sortRentalSelectionComboBox.Items.Add(selectionVehicleDamagePercentage);
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

        #region Forms

        private void AddVehicleForm(object sender, EventArgs e)
        {
            var formAddVehicle = new FormAddVehicle();

            var result = formAddVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                var vehicle = formAddVehicle.Vehicle;
                vehicles.Add(vehicle);

                vehicle.Id = IDManagement.LowestAvailableVehicleID;
                IDManagement.MarkVehicleIDAsUnavailable(vehicle.Id);

                PopulateVehiclesPanel();
            }
        }

        public void RentForm(Vehicle vehicle)
        {
            var formRentVehicle = new FormRentVehicle(vehicle);

            var result = formRentVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                var rental = formRentVehicle.Rental;
                rentals.Add(rental);

                rental.Id = IDManagement.LowestAvailableRentalID;
                IDManagement.MarkRentalIDAsUnavailable(rental.Id);

                PopulateRentalsPanel();

                RemoveVehicle(vehicle, false);
                PopulateVehiclesPanel();
            }
        }

        public void ReturnForm(Rental rental)
        {
            var formReturnVehicle = new FormReturnVehicle(rental);

            var result = formReturnVehicle.ShowDialog();
            if (result == DialogResult.OK)
            {
                var returnedVehicle = formReturnVehicle.ReturnedVehicle;
                var orderDetails = formReturnVehicle.OrderDetails;

                returnedVehiclesLogManager.WriteToLog(orderDetails);

                vehicles.Add(returnedVehicle);
                PopulateVehiclesPanel();

                RemoveRental(rental, true, false);
                PopulateRentalsPanel();
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
                //vehicleViews.Remove(rental.Vehicleee);
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

        private void SaveToLocalFile(object sender, EventArgs e)
        {
            var action = "save vehicles and rentals to local file";
            var consequence = "existing local file will be deleted";
            var formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            JsonManager.WriteVehiclesToJsonFile(vehicles, "vehicles.json");
            JsonManager.WriteRentalsToJsonFile(rentals, "rentals.json");
        }

        private void LoadFromLocalFile(object sender, EventArgs e)
        {
            var action = "load vehicles and rentals from local file";
            var consequence = "existing vehicles and rentals in the program will be removed";
            var formConfirmation = new FormConfirmation(action, consequence);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            vehicles.Clear();
            rentals.Clear();

            var importedVehicles = JsonManager.ReadVehiclesFromJsonFile("vehicles.json");
            var importedRentals = JsonManager.ReadRentalsFromJsonFile("rentals.json");

            vehicles.AddRange(importedVehicles);
            rentals.AddRange(importedRentals);

            PopulateVehiclesPanel();
            PopulateRentalsPanel();

            IDManagement.InitializeIndexes();

            foreach (var vehicle in vehicles)
            {
                IDManagement.MarkVehicleIDAsUnavailable(vehicle.Id);
            }

            foreach (var rental in rentals)
            {
                IDManagement.MarkRentalIDAsUnavailable(rental.Id);
                IDManagement.MarkVehicleIDAsUnavailable(rental.Vehicle.Id);
            }
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
            if (!indexesOfSelectedVehicleViews.Contains(vehicleIndex))
                indexesOfSelectedVehicleViews.Add(vehicleIndex);
        }

        public void DeselectVehicle(int vehicleIndex)
        {
            indexesOfSelectedVehicleViews.Remove(vehicleIndex);
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

        private void RemoveVehicle(Vehicle vehicle, bool makeIdAvailable = true)
        {
            if (makeIdAvailable)
            {
                IDManagement.MarkVehicleIDAsAvailable(vehicle.Id);
            }

            vehicles.Remove(vehicle);
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

            var action = "remove the last vehicle";
            var formConfirmation = new FormConfirmation(action);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var lastVehicleView = vehicleViews[vehicleViews.Count - 1];
            lastVehicleView.Selected = false;
            RemoveVehicle(lastVehicleView.Vehicle);

            PopulateVehiclesPanel();

            errorLabel.Text = string.Empty;
        }

        private void RemoveSelectedVehicles(object sender, EventArgs e)
        {
            if (indexesOfSelectedVehicleViews.Count > 0)
            {
                var action = "remove the selected vehicles";
                var formConfirmation = new FormConfirmation(action);

                var result = formConfirmation.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }

                errorLabel.Text = string.Empty;

                // Store the vehicles to be removed in a temporary List
                var vehiclesToBeRemoved = new List<VehicleView>();
                foreach (var index in indexesOfSelectedVehicleViews)
                {
                    vehiclesToBeRemoved.Add(vehicleViews.ElementAt(index));
                }

                // Remove the stored vehicles from the vehicles List
                foreach (var vehicleView in vehiclesToBeRemoved)
                {
                    RemoveVehicle(vehicleView.Vehicle);
                }

                PopulateVehiclesPanel();
                indexesOfSelectedVehicleViews.Clear();
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

        public void RemoveRental(Rental rental, bool makeRentalIdAvailable = true, bool makeVehicleIdAvailable = true)
        {
            if (makeRentalIdAvailable)
            {
                IDManagement.MarkRentalIDAsAvailable(rental.Id);
            }

            if (makeVehicleIdAvailable)
            {
                IDManagement.MarkVehicleIDAsAvailable(rental.Vehicle.Id);
            }

            rentals.Remove(rental);
            PopulateRentalsPanel();
        }

        private void RemoveLastRental(object sender, EventArgs e)
        {
            if (rentals.Count < 1)
            {
                errorLabel.Text = ErrorMessages.NoRentalsToRemove;
                timerClearErrors.Stop();
                timerClearErrors.Start();

                return;
            }

            var action = "remove the last rental";
            var formConfirmation = new FormConfirmation(action);

            var result = formConfirmation.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            var lastRental = rentals[rentals.Count - 1];
            RemoveRental(lastRental);

            PopulateRentalsPanel();

            errorLabel.Text = string.Empty;
        }

        private void RemoveSelectedRentals(object sender, EventArgs e)
        {
            if (indexesOfSelectedRentals.Count > 0)
            {
                var action = "remove the selected rentals";
                var formConfirmation = new FormConfirmation(action);

                var result = formConfirmation.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }

                errorLabel.Text = string.Empty;

                // Store the rentals to be removed in a temporary List
                var rentalsToBeRemoved = new List<RentalView>();
                foreach (var index in indexesOfSelectedRentals)
                {
                    rentalsToBeRemoved.Add(rentalViews.ElementAt(index));
                }

                // Remove the stored vehicles from the vehicles List
                foreach (var rentalView in rentalsToBeRemoved)
                {
                    RemoveRental(rentalView.Rental);
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
            PopulateVehicleViewListBasedOnVehicles();

            vehiclesPanel.Controls.Clear();
            short counter = 0;

            foreach (var vehicleView in vehicleViews)
            {
                vehicleView.LinkToMainWindow(this);
                vehicleView.Location = new Point(0, counter++ * 100);
                vehiclesPanel.Controls.Add(vehicleView);
            }
        }

        private void PopulateVehicleViewListBasedOnVehicles()
        {
            vehicleViews.Clear();

            foreach (var vehicle in vehicles)
            {
                var vehicleView = new VehicleView(vehicle);
                vehicleViews.Add(vehicleView);
            }
        }

        public void PopulateRentalsPanel()
        {
            PopulateRentalViewListBasedOnRentals();

            rentalsPanel.Controls.Clear();
            short counter = 0;

            foreach (var rental in rentalViews)
            {
                rental.LinkToMainWindow(this);
                rental.Location = new Point(0, counter++ * 150);
                rentalsPanel.Controls.Add(rental);
            }
        }

        private void PopulateRentalViewListBasedOnRentals()
        {
            rentalViews.Clear();

            foreach (var rental in rentals)
            {
                var rentalView = new RentalView(rental);
                rentalViews.Add(rentalView);
            }
        }

        #endregion


        #region Sorting

        private void SortAvailableVehicles(object sender, EventArgs e)
        {
            var sortSelection = ((SortSelectionItem)sortVehicleSelectionComboBox.SelectedItem).SortOptions;

            if (sortSelection == SortOptions.ByVehicleId)
            {
                vehicles = vehicles.OrderBy(x => x.Id).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleName)
            {
                vehicles = vehicles.OrderBy(x => x.Name).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleType)
            {
                vehicles = vehicles.OrderBy(x => x.Type).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleFuelPercentage)
            {
                vehicles = vehicles.OrderBy(x => x.FuelPercentage).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleDamagePercentage)
            {
                vehicles = vehicles.OrderBy(x => x.DamagePercentage).ToList();
            }

            PopulateVehiclesPanel();
        }

        private void SortRentedVehicles(object sender, EventArgs e)
        {
            var sortSelection = ((SortSelectionItem)sortRentalSelectionComboBox.SelectedItem).SortOptions;

            if (sortSelection == SortOptions.ByRentalId)
            {
                rentals = rentals.OrderBy(x => x.Id).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleId)
            {
                rentals = rentals.OrderBy(x => x.Vehicle.Id).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleId)
            {
                rentals = rentals.OrderBy(x => x.Vehicle.Name).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleType)
            {
                rentals = rentals.OrderBy(x => x.Vehicle.Type).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleFuelPercentage)
            {
                rentals = rentals.OrderBy(x => x.Vehicle.FuelPercentage).ToList();
            }

            if (sortSelection == SortOptions.ByVehicleDamagePercentage)
            {
                rentals = rentals.OrderBy(x => x.Vehicle.DamagePercentage).ToList();
            }

            if (sortSelection == SortOptions.ByOwnerName)
            {
                rentals = rentals.OrderBy(x => x.Owner.Name).ToList();
            }

            if (sortSelection == SortOptions.ByOwnerPhoneNumber)
            {
                rentals = rentals.OrderBy(x => x.Owner.PhoneNumber).ToList();
            }

            if (sortSelection == SortOptions.ByReturnDate)
            {
                rentals = rentals.OrderBy(x => x.ReturnDate).ToList();
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
