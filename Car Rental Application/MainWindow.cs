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
        List<VehicleUserControl> lista;
        AvailableCars pr;
        public MainWindow()
        {
            InitializeComponent();
            lista = new List<VehicleUserControl>();
            pr = new AvailableCars(AvailableCarsPanel, availableCarsElementsPanel);
            pr.availableCarsPanel.Controls.Add(availableCarsElementsPanel);
            //for (int i = 0; i < 15; i++)
           // {
            //    AvailableSedanUserControl sedan = new AvailableSedanUserControl();
            //    sedan.Location = new Point(0, i*100);
              //  lista.Add(sedan);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lista.Count < 1) { label3.Text = "There's nothing" + Environment.NewLine + " to remove"; return; }
            //list = list.OrderBy(o => o.vehicleName).ToList();  <- used to order objects by a property
            lista.RemoveAt(lista.Count-1);
            availableCarsElementsPanel.VerticalScroll.Value = 0;
            pr.availableCarsPanelElements.Controls.Clear();
            foreach (VehicleUserControl sedan in lista)
                pr.availableCarsPanelElements.Controls.Add(sedan);
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


    }
}
