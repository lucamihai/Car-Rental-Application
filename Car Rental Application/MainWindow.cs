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
            
        public MainWindow()
        {
            InitializeComponent();
            
            availableVehicles = new List<VehicleUserControl>();
            rentedVehicles = new List<VehicleUserControl>();
            availableCarsSorter = new AvailableCarsSorter();
            rentedCarsSorter = new RentedCarsSorter();


            addVehicleUserControl = new AddVehicleUserControl(this);
            rentVehicleUserControl = new RentVehicleUserControl(this);
            returnFromRentUserControl = new ReturnFromRentUserControl(this);
            panelAddVehicles.Controls.Add(addVehicleUserControl);
            panelAddVehicles.Controls.Add(rentVehicleUserControl);
            panelAddVehicles.Controls.Add(returnFromRentUserControl);
            addVehicleUserControl.Hide();
            rentVehicleUserControl.Hide();
            InitializeComboBoxSelections();
            timerProgramDateUpdater.Start();
            InitializeAvailableIndexes();          
        }
        void InitializeComboBoxSelections()
        {
            sortAvailableSelectionComboBox.SelectedIndex = sortAvailableSelectionComboBox.FindStringExact("By ID");
            sortRentedSelectionComboBox.SelectedIndex = sortRentedSelectionComboBox.FindStringExact("By ID");
        }
        void InitializeAvailableIndexes()
        {
            for (int i = 0; i < IDManagement.availableIndexes.Length; i++)
                IDManagement.availableIndexes[i] = true;
            for (int i = 0; i < IDManagement.rentedIndexes.Length; i++)
                IDManagement.rentedIndexes[i] = true;
        }
        public void AddToAvailableCarsList(VehicleUserControl vehicle) { availableVehicles.Add(vehicle); }
        public void AddToRentedCarsList(VehicleUserControl vehicle) { rentedVehicles.Add(vehicle); }
        public void HideAddVehiclePanel() { panelAddVehicles.Hide(); }
        public int GetIndexOfAvailableVehicle(VehicleUserControl vehicle) { return availableVehicles.IndexOf(vehicle); }
        

        

        #region Remove buttons

        /* Remove last element */
        private void button1_Click(object sender, EventArgs e)
        {
            if (availableVehicles.Count < 1) { errorLabel.Text = "There's nothing" + Environment.NewLine + " to remove"; timerClearErrors.Start(); return; }
            short idToBeMarkedAsAvailable = (short)(availableVehicles.Count - 1);
            IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
            availableVehicles.RemoveAt(availableVehicles.Count-1);
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            availableCarsElementsPanel.Controls.Clear();
            foreach (VehicleUserControl sedan in availableVehicles)
                availableCarsElementsPanel.Controls.Add(sedan);
            errorLabel.Text = "";
        }

        private void buttonRemoveSelectedAvailableCars_Click(object sender, EventArgs e)
        {
            string output = "Contents of available indexes before remove: " + Environment.NewLine;
            foreach (int index in indexesOfSelectedAvailableCars) output += index.ToString() + Environment.NewLine;
            List<VehicleUserControl> vehiclesToBeRemoved = new List<VehicleUserControl>();
            foreach (int index in indexesOfSelectedAvailableCars)
            {
                IDManagement.MarkIDAsAvailable((short)index);
                vehiclesToBeRemoved.Add(availableVehicles.ElementAt(index));
            }
            foreach (VehicleUserControl vehicle in vehiclesToBeRemoved)
                availableVehicles.Remove(vehicle);
            PopulateAvailableVehiclesPanel();
            indexesOfSelectedAvailableCars.Clear();
        }

        #endregion

        public void RemoveAvailableCarFromList(VehicleUserControl vehicle) { availableVehicles.Remove(vehicle); PopulateAvailableVehiclesPanel(); }
        public void RemoveRentedCarFromList(VehicleUserControl vehicle) { rentedVehicles.Remove(vehicle); PopulateRentedVehiclesPanel(); }
        public void ReturnVehicleFromRent(VehicleUserControl vehicle) { availableVehicles.Add(vehicle); PopulateAvailableVehiclesPanel(); }

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
            labelProgramDate.Text = "Program date" + Environment.NewLine + DateTime.Now.ToShortDateString();
            programTime = DateTime.Now;
        }

        private void timerClearErrors_Tick(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            timerClearErrors.Stop();
        }
    }
}
