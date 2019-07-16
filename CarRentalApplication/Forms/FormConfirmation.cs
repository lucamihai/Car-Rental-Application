using System;
using System.Windows.Forms;

namespace CarRentalApplication.Forms
{
    public partial class FormConfirmation : Form
    {
        public FormConfirmation(string action = null, string consequence = null)
        {
            InitializeComponent();

            UpdateLanguage();

            if (action == null)
            {
                labelAreYouSure.Text = string.Empty;
            }

            if (action != null)
            {
                var translatedAction = Program.Language.Translate(action);
                labelAreYouSure.Text = string.Format("{0}: {1}", Program.Language.Translate("Action"), translatedAction);
            }

            if (consequence != null)
            {
                var translatedConsequence = Program.Language.Translate(consequence);
                labelAreYouSure.Text += string.Format("\r\n{0}: {1}", Program.Language.Translate("Consequence"), translatedConsequence);
            }
        }

        private void UpdateLanguage()
        {
            this.Text = string.Format("{0}?", Program.Language.Translate("Are you sure"));
            buttonConfirm.Text = Program.Language.Translate("Confirm");
            buttonCancel.Text = Program.Language.Translate("Cancel");
        }

        private void Confirm(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
