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
        List<VehicleUserControl> lista;
        AvailableCars pr;
        public MainWindow()
        {
            InitializeComponent();
            lista = new List<VehicleUserControl>();
            pr = new AvailableCars(AvailableCarsPanel, availableCarsElementsPanel);
            pr.availableCarsPanel.Controls.Add(availableCarsElementsPanel);
            for (int i = 0; i < 15; i++)
            {
                AvailableSedanUserControl sedan = new AvailableSedanUserControl();
                sedan.Location = new Point(0, i*100);
                lista.Add(sedan);
            }
        }

        public void RentVehicle(Vehicle vehicle)
        {

        }

        public void ReturnVehicleFromRent(Vehicle vehicle)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //list = list.OrderBy(o => o.vehicleName).ToList();  <- used to order objects by a property
            foreach (AvailableSedanUserControl sedan in lista)
                pr.availableCarsPanelElements.Controls.Add(sedan);
        }
    }
}
