using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Rental_Application.Classes;

namespace Car_Rental_Application.User_Controls
{
    public partial class VehicleUserControl : UserControl
    {
        protected MainWindow mainWindow;
        protected string vehicleName;
        protected short damagePercent;
        protected short fuelPercentage;
        protected Customer owner;
        public virtual void GetDetails() { }
        public VehicleUserControl()
        {
            InitializeComponent();
        }
        public void LinkToMainWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
    }
}
