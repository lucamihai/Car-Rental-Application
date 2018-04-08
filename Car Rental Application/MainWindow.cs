using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;
using Car_Rental_Application.User_Controls;

namespace Car_Rental_Application
{
    public partial class MainWindow : Form
    {

        public static int availableCarsCounter = 0;
        List <VehicleUserControl> lista;
        List<VehicleUserControl> rentedVehicles;
        public AvailableCarsManager availableCarsManager;
        public RentedCarsManager rentedCarsManager;
        AddVehicleUserControl addVehicleUserControl;
        RentVehicleUserControl rentVehicleUserControl;
        public List<int> indexesOfSelectedAvailableCars = new List<int>();
            
        public MainWindow()
        {
            InitializeComponent();
            
            lista = new List<VehicleUserControl>();
            rentedVehicles = new List<VehicleUserControl>();
            availableCarsManager = new AvailableCarsManager(AvailableCarsPanel, availableCarsElementsPanel);
            availableCarsManager.availableCarsPanel.Controls.Add(availableCarsElementsPanel);
            availableCarsManager.Link(this);

            rentedCarsManager = new RentedCarsManager(RentedCarsPanel, rentedCarsElementsPanel);
            rentedCarsManager.rentedCarsPanel.Controls.Add(rentedCarsElementsPanel);
            rentedCarsManager.Link(this);

            addVehicleUserControl = new AddVehicleUserControl(this);
            rentVehicleUserControl = new RentVehicleUserControl(this);
            panelAddVehicles.Controls.Add(addVehicleUserControl);
            panelAddVehicles.Controls.Add(rentVehicleUserControl);
            addVehicleUserControl.Hide();
            rentVehicleUserControl.Hide();
            SortSelectionComboBox.SelectedIndex = SortSelectionComboBox.FindStringExact("By ID");

            for (int i = 0; i < IDManagement.availableIndexes.Length; i++)
                IDManagement.availableIndexes[i] = true;
            for (int i = 0; i < IDManagement.rentedIndexes.Length; i++)
                IDManagement.rentedIndexes[i] = true;
            //for (int i = 0; i < 15; i++)
            // {
            //    AvailableSedanUserControl sedan = new AvailableSedanUserControl();
            //    sedan.Location = new Point(0, i*100);
            //  lista.Add(sedan);
            //}
        }
        public void AddToAvailableCarsList(VehicleUserControl vehicle) { lista.Add(vehicle); }
        public void AddToRentedCarsList(VehicleUserControl vehicle) { rentedVehicles.Add(vehicle); }
        public void HideAddVehiclePanel()
        {
            panelAddVehicles.Hide();
        }
        public int GetIndexOfAvailableVehicle(VehicleUserControl vehicle)
        {
            return lista.IndexOf(vehicle);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region Remove Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (lista.Count < 1) { label3.Text = "There's nothing" + Environment.NewLine + " to remove"; return; }
            short idToBeMarkedAsAvailable = (short)(lista.Count - 1);
            IDManagement.MarkIDAsAvailable(idToBeMarkedAsAvailable);
            lista.RemoveAt(lista.Count-1);
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            availableCarsManager.availableCarsElementsPanel.Controls.Clear();
            foreach (VehicleUserControl sedan in lista)
                availableCarsManager.availableCarsElementsPanel.Controls.Add(sedan);
            label3.Text = lista.Count.ToString();

        }
        #endregion
        
        public void RemoveAvailableCarFromList(VehicleUserControl vehicle) { lista.Remove(vehicle); PopulateAvailableVehiclesPanel(); }
        public void RemoveRentedCarFromList(VehicleUserControl vehicle) { rentedVehicles.Remove(vehicle); PopulateRentedVehiclesPanel(); }
        public void ReturnVehicleFromRent(VehicleUserControl vehicle) { lista.Add(vehicle); PopulateAvailableVehiclesPanel(); }
        public void PopulateAvailableVehiclesPanel()
        {
            availableCarsManager.availableCarsElementsPanel.Controls.Clear();
            short counter = 0;
            foreach (VehicleUserControl vehicle in lista)
            {
                vehicle.LinkToMainWindow(this);
                vehicle.LinkToRentMenu(rentVehicleUserControl);
                availableCarsManager.availableCarsElementsPanel.Controls.Add(vehicle);
                vehicle.Location = new Point(0, counter++ * 100);
            }
            label3.Text = lista.Count.ToString();
        }
        public void PopulateRentedVehiclesPanel()
        {
            rentedCarsManager.rentedCarsElementsPanel.Controls.Clear();
            short counter = 0;
            foreach (VehicleUserControl vehicle in rentedVehicles)
            {
                vehicle.LinkToMainWindow(this);

                rentedCarsManager.rentedCarsElementsPanel.Controls.Add(vehicle);
                vehicle.Location = new Point(0, counter++ * 100);
            }
            label3.Text = lista.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            availableCarsElementsPanel.VerticalScroll.Value = 0;
            AvailableMinivanUserControl minivan = new AvailableMinivanUserControl();
            minivan.Location = new Point(0, (lista.Count) * 100);
            lista.Add(minivan);

            availableCarsManager.availableCarsElementsPanel.Controls.Clear();
            availableCarsManager.availableCarsElementsPanel.Controls.Add(new AvailableMinivanUserControl());
            foreach (VehicleUserControl sedan in lista)
                availableCarsManager.availableCarsElementsPanel.Controls.Add(sedan);
            label3.Text = lista.Count.ToString();

        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            panelAddVehicles.Show();
            addVehicleUserControl.Show();
        }
        public void RentMenu() { panelAddVehicles.Show(); rentVehicleUserControl.Show(); }

        private void buttonRemoveSelectedAvailableCars_Click(object sender, EventArgs e)
        {
            string output = "Contents of available indexes before remove: "+Environment.NewLine;
            foreach (int index in indexesOfSelectedAvailableCars) output += index.ToString() + Environment.NewLine;
            label4.Text = (output);
            label4.Text += Environment.NewLine;
            List<VehicleUserControl> vehiclesToBeRemoved = new List<VehicleUserControl>();
            foreach(int index in indexesOfSelectedAvailableCars)
            {
                IDManagement.MarkIDAsAvailable((short)index);
                label4.Text += index.ToString() + " is now available" + Environment.NewLine;
                vehiclesToBeRemoved.Add(lista.ElementAt(index));
            }
            foreach (VehicleUserControl vehicle in vehiclesToBeRemoved)
                lista.Remove(vehicle);
            PopulateAvailableVehiclesPanel();
            indexesOfSelectedAvailableCars.Clear();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (SortSelectionComboBox.SelectedIndex == 0) lista = availableCarsManager.SortListByID(lista); 
            if (SortSelectionComboBox.SelectedIndex == 1) lista = availableCarsManager.SortListByName(lista);
            if (SortSelectionComboBox.SelectedIndex == 2) lista = availableCarsManager.SortListByType(lista);
            if (SortSelectionComboBox.SelectedIndex == 3) lista = availableCarsManager.SortListByFuelPercent(lista);
            if (SortSelectionComboBox.SelectedIndex == 4) lista = availableCarsManager.SortListByDamagePercent(lista);
            PopulateAvailableVehiclesPanel();
        }
    }
}
