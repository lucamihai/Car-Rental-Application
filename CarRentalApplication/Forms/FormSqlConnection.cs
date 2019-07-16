using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CarRentalApplication.Classes;

namespace CarRentalApplication.Forms
{
    public partial class FormSqlConnection : Form
    {
        public string ConnectionString { get; private set; }
        public FormSqlConnection()
        {
            InitializeComponent();

            errorLabel.Text = "";

            labelDataSource.Text = Program.Language.Translate("Data source");
            labelUserID.Text = Program.Language.Translate("UserID");
            labelPassword.Text = Program.Language.Translate("Password");
            labelInitialCatalog.Text = Program.Language.Translate("Initial catalog");
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxDataSource.Text == "")
            {
                errorLabel.Text = ErrorMessages.DATA_SOURCE_NOT_PROVIDED;
                return;
            }

            if (textBoxUserID.Text == "")
            {
                errorLabel.Text = ErrorMessages.USER_ID_NOT_PROVIDED;
                return;
            }

            if (textBoxPassword.Text == "")
            {
                errorLabel.Text = ErrorMessages.PASSWORD_NOT_PROVIDED;
                return;
            }

            if (textBoxInitialCatalog.Text == "")
            {
                errorLabel.Text = ErrorMessages.INITIAL_CATALOG_NOT_PROVIDED;
                return;
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = textBoxDataSource.Text,
                UserID = textBoxUserID.Text,
                Password = textBoxPassword.Text,
                InitialCatalog = textBoxInitialCatalog.Text
            };

            ConnectionString = builder.ConnectionString;

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
