using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Application.Forms
{
    public partial class FormConfirmation : Form
    {
        public FormConfirmation(string message = null)
        {
            InitializeComponent();

            if (message != null)
            {
                labelAreYouSure.Text = string.Format("Are you sure you want to {0}?", message);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
