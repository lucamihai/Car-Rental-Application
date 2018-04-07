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
        AvailableCars pr;

        AddVehicleUserControl addVehicleUserControl;
        public List<int> indexesOfSelectedAvailableCars = new List<int>();
            
        public MainWindow()
        {
            InitializeComponent();
            
            lista = new List<VehicleUserControl>();
            pr = new AvailableCars(AvailableCarsPanel, availableCarsElementsPanel);
            pr.availableCarsPanel.Controls.Add(availableCarsElementsPanel);
            addVehicleUserControl = new AddVehicleUserControl(this);
            panelAddVehicles.Controls.Add(addVehicleUserControl);
            SortSelectionComboBox.SelectedIndex = SortSelectionComboBox.FindStringExact("By ID");

            for (int i = 0; i < IDManagement.availableIndexes.Length; i++) IDManagement.availableIndexes[i] = true;

            //for (int i = 0; i < 15; i++)
            // {
            //    AvailableSedanUserControl sedan = new AvailableSedanUserControl();
            //    sedan.Location = new Point(0, i*100);
            //  lista.Add(sedan);
            //}
        }

        public void HideAddVehiclePanel()
        {
            panelAddVehicles.Hide();
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
            pr.availableCarsPanelElements.Controls.Clear();
            foreach (VehicleUserControl sedan in lista)
                pr.availableCarsPanelElements.Controls.Add(sedan);
            label3.Text = lista.Count.ToString();

        }
        #endregion
        public void AddAvailableVehicle(VehicleUserControl vehicle)
        {
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            lista.Add(vehicle);
            PopulateAvailableVehiclesPanel();
        }

        public void PopulateAvailableVehiclesPanel()
        {
            pr.availableCarsPanelElements.Controls.Clear();
            short counter = 0;
            foreach (VehicleUserControl vehicle in lista)
            {
                vehicle.LinkToMainWindow(this);
                pr.availableCarsPanelElements.Controls.Add(vehicle);
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

            pr.availableCarsPanelElements.Controls.Clear();
            pr.availableCarsPanelElements.Controls.Add(new AvailableMinivanUserControl());
            foreach (VehicleUserControl sedan in lista)
                pr.availableCarsPanelElements.Controls.Add(sedan);
            label3.Text = lista.Count.ToString();

        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            panelAddVehicles.Show();
        }


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
            if (SortSelectionComboBox.SelectedIndex == 0) lista = pr.SortListByID(lista); 
            if (SortSelectionComboBox.SelectedIndex == 1) lista = pr.SortListByName(lista);
            if (SortSelectionComboBox.SelectedIndex == 2) lista = pr.SortListByType(lista);
            if (SortSelectionComboBox.SelectedIndex == 3) lista = pr.SortListByFuelPercent(lista);
            if (SortSelectionComboBox.SelectedIndex == 4) lista = pr.SortListByDamagePercent(lista);
            PopulateAvailableVehiclesPanel();
        }
    }
}
