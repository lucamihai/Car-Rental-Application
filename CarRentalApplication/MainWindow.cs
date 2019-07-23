using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CarRentalApplication.Classes;
using CarRentalApplication.Database;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.EntityViews;
using CarRentalApplication.Enums;
using CarRentalApplication.FileSaving;
using CarRentalApplication.Forms;
using CarRentalApplication.Logging;
using CarRentalApplication.Translating;

namespace CarRentalApplication
{
    [ExcludeFromCodeCoverage]
    public partial class MainWindow : Form
    {
        private List<Vehicle> vehicles;
        private List<Rental> rentals;

        private readonly List<RentalView> rentalViews;
        private readonly List<VehicleView> vehicleViews;

        private Logger returnedVehiclesLogManager;

        private SqlManager sqlManager;

        private readonly List<int> indexesOfSelectedVehicleViews = new List<int>();
        private readonly List<int> indexesOfSelectedRentals = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            IDManagement.InitializeIndexes();
            ClearErrorMessageLabel();

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

            if (result != DialogResult.OK)
                return;

            var vehicle = formAddVehicle.Vehicle;
            vehicles.Add(vehicle);

            vehicle.Id = IDManagement.LowestAvailableVehicleID;
            IDManagement.MarkVehicleIDAsUnavailable(vehicle.Id);

            PopulateVehiclesPanel();
        }

        public void RentForm(Vehicle vehicle)
        {
            var formRentVehicle = new FormRentVehicle(vehicle);
            var result = formRentVehicle.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var rental = formRentVehicle.Rental;
            rentals.Add(rental);

            rental.Id = IDManagement.LowestAvailableRentalID;
            IDManagement.MarkRentalIDAsUnavailable(rental.Id);

            PopulateRentalsPanel();

            RemoveVehicle(vehicle, false);
            PopulateVehiclesPanel();
        }

        public void ReturnForm(Rental rental)
        {
            var formReturnVehicle = new FormReturnVehicle(rental);
            var result = formReturnVehicle.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var returnedVehicle = formReturnVehicle.ReturnedVehicle;
            var orderDetails = formReturnVehicle.OrderDetails;

            returnedVehiclesLogManager.WriteToLog(orderDetails);

            vehicles.Add(returnedVehicle);
            PopulateVehiclesPanel();

            RemoveRental(rental, true, false);
            PopulateRentalsPanel();
        }

        public void SqlConnectionForm()
        {
            var formSqlConnection = new FormSqlConnection();
            var result = formSqlConnection.ShowDialog();

            if (result != DialogResult.OK)
                return;

            MessageBox.Show(formSqlConnection.ConnectionString);
            sqlManager = new SqlManager(formSqlConnection.ConnectionString);
        }

        #endregion


        #region Toolstrip Menu

        #region Database

        private void ConnectToDatabase(object sender, EventArgs e)
        {
            SqlConnectionForm();

            if (sqlManager != null)
            {
                if (sqlManager.ConnectionIsSuccessful())
                {
                    saveToDatabaseToolStripMenuItem.Available = true;
                    loadFromDatabaseToolStripMenuItem.Available = true;
                    connectToDatabaseToolStripMenuItem.Available = false;
                }
                else
                {
                    DisplayErrorMessageForAPeriodOfTime(ErrorMessages.CouldNotConnectToDatabase);
                }
            }
        }

        private void SaveToDatabase(object sender, EventArgs e)
        {
            var formConfirmation = new FormConfirmation(ActionMessages.SaveToDatabase, ConsequenceMessages.SaveToDatabase);
            var result = formConfirmation.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            sqlManager.ClearVehiclesFromDatabase();
            sqlManager.ClearRentalsFromDatabase();

            sqlManager.SaveVehiclesToDatabase(vehicles);
            sqlManager.SaveRentalsToDatabase(rentals);
        }

        private void LoadFromDatabase(object sender, EventArgs e)
        {
            var formConfirmation = new FormConfirmation(ActionMessages.LoadFromDatabase, ConsequenceMessages.LoadFromDatabase);
            var result = formConfirmation.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            vehicles = sqlManager.GetVehiclesFromDatabase();
            rentals = sqlManager.GetRentalsFromDatabase();

            ClearVehiclesFromVehicleListThatAreFoundInRentalList();

            PopulateVehiclesPanel();
            PopulateRentalsPanel();
        }

        private void ClearVehiclesFromVehicleListThatAreFoundInRentalList()
        {
            foreach (var rental in rentals)
            {
                var rentedVehicle = rental.Vehicle;
                var vehicleFromList = vehicles.FirstOrDefault(x => x.Id == rentedVehicle.Id);

                if (vehicleFromList != null)
                    vehicles.Remove(vehicleFromList);
            }
        }

        #endregion

        #region Local file

        private void SaveToLocalFile(object sender, EventArgs e)
        {
            var formConfirmation = new FormConfirmation(ActionMessages.SaveToLocalFile, ConsequenceMessages.SaveToLocalFile);
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
            var formConfirmation = new FormConfirmation(ActionMessages.LoadFromLocalFile, ConsequenceMessages.LoadFromLocalFile);
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

        private void OpenLog(object sender, EventArgs e)
        {
            if (!File.Exists(returnedVehiclesLogManager.LogPath) || new FileInfo(returnedVehiclesLogManager.LogPath).Length == 0)
            {
                DisplayErrorMessageForAPeriodOfTime(ErrorMessages.NoLogCreated);
                return;
            }

            ClearErrorMessageLabel();
            Process.Start(returnedVehiclesLogManager.LogPath);
        }

        private void DeleteLog(object sender, EventArgs e)
        {
            if (!File.Exists(returnedVehiclesLogManager.LogPath) || new FileInfo(returnedVehiclesLogManager.LogPath).Length == 0)
            {
                return;
            }

            var formConfirmation = new FormConfirmation(ActionMessages.DeleteExistingLog);
            var result = formConfirmation.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            var oldLogManagerPath = returnedVehiclesLogManager.LogPath;
            returnedVehiclesLogManager = new Logger(oldLogManagerPath);

            if (File.Exists(returnedVehiclesLogManager.LogPath))
            {
                File.Delete(returnedVehiclesLogManager.LogPath);
            }
        }

        #endregion

        #region Language

        private void LanguageMenu(object sender, EventArgs e)
        {
            var formLanguages = new FormLanguages();
            var result = formLanguages.ShowDialog();

            if (result != DialogResult.OK)
                return;

            UpdateLanguage(formLanguages.ChosenLanguage);
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

            UpdateLanguageForExistingVehicleViews(language);
            UpdateLanguageForExistingRentalViews(language);

            InitializeSortOptionsForVehicles();
            InitializeSortOptionsForRentals();
        }

        private void UpdateLanguageForExistingVehicleViews(Language language)
        {
            foreach (var vehicleView in vehicleViews)
            {
                vehicleView.UpdateLanguage(language);
            }
        }

        private void UpdateLanguageForExistingRentalViews(Language language)
        {
            foreach (var rentalView in rentalViews)
            {
                rentalView.UpdateLanguage(language);
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

        private void SelectAllVehicleViews(object sender, EventArgs e)
        {
            if (vehicleViews.Count < 1)
            {
                DisplayErrorMessageForAPeriodOfTime(ErrorMessages.NoVehiclesToSelect);
                return;
            }

            var areAllSelected = true;
            foreach (var vehicle in vehicleViews)
            {
                if (!vehicle.Selected)
                {
                    areAllSelected = false;
                }

                vehicle.Selected = true;
            }

            if (areAllSelected)
            {
                foreach (var vehicleView in vehicleViews)
                    vehicleView.Selected = false;
            }

            ClearErrorMessageLabel();
        }

        private void SelectAllRentalViews(object sender, EventArgs e)
        {
            if (rentalViews.Count < 1)
            {
                DisplayErrorMessageForAPeriodOfTime(ErrorMessages.NoRentalsToSelect);
                return;
            }

            var areAllSelected = true;
            foreach (var rentalView in rentalViews)
            {
                if (!rentalView.Selected)
                {
                    areAllSelected = false;
                }

                rentalView.Selected = true;
            }

            if (areAllSelected)
            {
                foreach (var rentalView in rentalViews)
                    rentalView.Selected = false;
            }

            ClearErrorMessageLabel();
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
                DisplayErrorMessageForAPeriodOfTime(ErrorMessages.NoVehiclesToRemove);
                return;
            }

            var formConfirmation = new FormConfirmation(ActionMessages.RemoveLastVehicle);
            var result = formConfirmation.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            var lastVehicleView = vehicleViews[vehicleViews.Count - 1];
            lastVehicleView.Selected = false;
            RemoveVehicle(lastVehicleView.Vehicle);

            PopulateVehiclesPanel();

            ClearErrorMessageLabel();
        }

        private void RemoveSelectedVehicles(object sender, EventArgs e)
        {
            if (indexesOfSelectedVehicleViews.Count > 0)
            {
                var formConfirmation = new FormConfirmation(ActionMessages.RemoveSelectedVehicles);
                var result = formConfirmation.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }

                ClearErrorMessageLabel();

                foreach (var index in indexesOfSelectedVehicleViews)
                {
                    RemoveVehicle(vehicleViews[index].Vehicle);
                }

                PopulateVehiclesPanel();
                indexesOfSelectedVehicleViews.Clear();
            }

            else
            {
                DisplayErrorMessageForAPeriodOfTime(ErrorMessages.NoVehiclesSelected);
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
        }

        private void RemoveLastRental(object sender, EventArgs e)
        {
            if (rentals.Count < 1)
            {
                DisplayErrorMessageForAPeriodOfTime(ErrorMessages.NoRentalsToRemove);
                return;
            }

            var formConfirmation = new FormConfirmation(ActionMessages.RemoveLastRental);
            var result = formConfirmation.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            var lastRental = rentals[rentals.Count - 1];
            RemoveRental(lastRental);

            PopulateRentalsPanel();

            ClearErrorMessageLabel();
        }

        private void RemoveSelectedRentals(object sender, EventArgs e)
        {
            if (indexesOfSelectedRentals.Count > 0)
            {
                var formConfirmation = new FormConfirmation(ActionMessages.RemoveSelectedRentals);
                var result = formConfirmation.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }

                ClearErrorMessageLabel();

                foreach (var index in indexesOfSelectedRentals)
                {
                    RemoveRental(rentalViews[index].Rental);
                }

                PopulateRentalsPanel();
                indexesOfSelectedRentals.Clear();
            }

            else
            {
                DisplayErrorMessageForAPeriodOfTime(ErrorMessages.NoRentalsSelected);
            }
        }

        #endregion


        #region Vehicle and rental panels update

        private void PopulateVehiclesPanel()
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

        private void PopulateRentalsPanel()
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
            ClearErrorMessageLabel();
            timerClearErrors.Stop();
        }

        private void ProgramDateTick(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now;
            labelProgramDate.Text = $"{currentTime.Day}/{currentTime.Month}/{currentTime.Year} {currentTime.ToShortTimeString()}";
        }

        #endregion

        private void DisplayErrorMessageForAPeriodOfTime(string message)
        {
            errorLabel.Text = message;

            timerClearErrors.Stop();
            timerClearErrors.Start();
        }

        private void ClearErrorMessageLabel()
        {
            errorLabel.Text = string.Empty;
        }
    }
}
