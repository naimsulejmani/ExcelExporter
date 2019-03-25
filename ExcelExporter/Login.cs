using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL = ExcelExporter.BusinessLogic.DataConnection;
using BLL = ExcelExporter.BusinessLogic.General;
using ExcelExporter.DataAccess;

namespace ExcelExporter
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        void Connect()
        {
            if (cbAuthentication.Text != @"Windows Authentication")
                BL.DefaultConnectionString =
                    $"Server={txtServerName.Text};Database={cbDatabase.Text};User Id={txtUserName.Text};Password={txtPassword.Text};Trusted_Connection=False;";
            else
                BL.DefaultConnectionString =
                    $"Server={txtServerName.Text};Database={cbDatabase.Text};Trusted_Connection=True;";

            if (chbSaveConfiguration.Checked)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings["server"].Value = txtServerName.Text;
                //config.AppSettings.Settings["database"].Value = txtDatabase.Text;
                config.AppSettings.Settings["save"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings["server"].Value = "";
                //config.AppSettings.Settings["database"].Value = "";
                config.AppSettings.Settings["save"].Value = "0";
                config.Save(ConfigurationSaveMode.Modified);
            }

            if (BL.CanConnect())
            {
                CurrentSettings.Database = cbDatabase.Text;
                CurrentSettings.ServerName = txtServerName.Text;
                var f = new ExporterForm();
                Hide();
                f.ShowDialog();
                Close();
            }
            else MessageBox.Show(@"(N)");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            txtServerName.Text = config.AppSettings.Settings["server"].Value;
            cbDatabase.Text = config.AppSettings.Settings["database"].Value;
            chbSaveConfiguration.Checked = config.AppSettings.Settings["save"].Value == "1";
            txtServerName.Focus();
            cbAuthentication.SelectedIndex = 0;
            var windowsIdentity = WindowsIdentity.GetCurrent();
            txtUserName.Text = windowsIdentity.Name;
        }



        void GetDatabases()
        {
            cbDatabase.DataSource = null;
            cbDatabase.Refresh();
            if (cbAuthentication.SelectedIndex == 1)
            {
                DataConnection.ConnectionString =
                    $@"Server={txtServerName.Text};Database=master;User Id={txtUserName.Text};Password={
                            txtPassword.Text
                        };Trusted_Connection=False;";
            }
            else if (cbAuthentication.SelectedIndex == 0)
            {
                DataConnection.ConnectionString =
                    $@"Server={txtServerName.Text};Database=master;Trusted_Connection=True;";
            }

            if (BL.CanConnect())
            {
                cbDatabase.DataSource = BLL.GetDatabases();
                cbDatabase.Refresh();
            }
        }

        private void btnRefreshDatabase_Click(object sender, EventArgs e)
        {
            GetDatabases();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void cbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAuthentication.Text == @"SQL Server Authentication")
            {
                txtUserName.ReadOnly = false;
                txtPassword.ReadOnly = false;
                txtUserName.Text = "";
                txtUserName.Focus();
            }
            else
            {
                var windowsIdentity = WindowsIdentity.GetCurrent();
                txtUserName.Text = windowsIdentity.Name;
                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
            }
        }
    }
}
