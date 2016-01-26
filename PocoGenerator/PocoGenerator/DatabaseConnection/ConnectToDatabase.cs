using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.ExtensionMethods;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain;

namespace PocoGenerator.DatabaseConnection
{
    public partial class ConnectToDatabase : Form
    {
        private readonly IDbConnectService _dbConnectService;
        private readonly IConnectionStringService _connectionStringService;
        private readonly IDataTypeService _dataTypeService;

        public ConnectToDatabase(IDbConnectService dbConnectService, IConnectionStringService connectionStringService, IDataTypeService dataTypeService)
        {
            InitializeComponent();

            _dbConnectService = dbConnectService;
            _connectionStringService = connectionStringService;
            _dataTypeService = dataTypeService;

            LoadAuthenticationTypes();
        }

        #region Events

        private void lblServerName_Click(object sender, EventArgs e)
        {
            txtServerName.Focus();
        }

        private void lblAuthenticationType_Click(object sender, EventArgs e)
        {
            cmbAuthenticationType.Focus();
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void lblSelectDatabase_Click(object sender, EventArgs e)
        {
            cmbSelectDatabase.Focus();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput() && ValidateDatabaseSelection())
            {
                ConnectionStringProperties objConnectionString = new ConnectionStringProperties();

                objConnectionString.DataSource = txtServerName.Text.Trim();
                objConnectionString.InitialCatalog = ((DatabaseName)cmbSelectDatabase.SelectedItem).DbName;
                objConnectionString.UserId = txtUserName.Text.Trim();
                objConnectionString.Password = txtPassword.Text.Trim();

                var connectionString = _connectionStringService.BuildConnectionString(objConnectionString, true);

                if (_dbConnectService.TestConnection(connectionString))
                {
                    Global.ConnectionString = connectionString;

                    LoadDataTypeMappings();

                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.MdiParent.Close();
        }

        private void cmbAuthenticationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleUserCredentials();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput())
            {
                ConnectionStringProperties objConnectionString = new ConnectionStringProperties();

                objConnectionString.DataSource = txtServerName.Text.Trim();
                objConnectionString.InitialCatalog = cmbSelectDatabase.SelectedText;
                objConnectionString.UserId = txtUserName.Text.Trim();
                objConnectionString.Password = txtPassword.Text.Trim();

                var connectionString = _connectionStringService.BuildConnectionString(objConnectionString, true);

                if (_dbConnectService.TestConnection(connectionString))
                {
                    Global.ConnectionString = connectionString;

                    var lstDatabases = _dbConnectService.GetDatabases().ToList();

                    if (lstDatabases.Count > 0)
                    {
                        cmbSelectDatabase.DataSource = lstDatabases;
                        cmbSelectDatabase.DisplayMember = "DbName";
                        cmbSelectDatabase.ValueMember = "DbId";                        
                    }
                }
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (ValidateUserInput() && ValidateDatabaseSelection())
            {
                ConnectionStringProperties objConnectionString = new ConnectionStringProperties();

                objConnectionString.DataSource = txtServerName.Text.Trim();
                objConnectionString.InitialCatalog = cmbSelectDatabase.SelectedText;
                objConnectionString.UserId = txtUserName.Text.Trim();
                objConnectionString.Password = txtPassword.Text.Trim();

                var connectionString = _connectionStringService.BuildConnectionString(objConnectionString, false);

                if (_dbConnectService.TestConnection(connectionString))
                {
                    Global.ConnectionString = connectionString;                    

                    MessageBox.Show("Test Connection Succeeded", "Poco Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ConnectToDatabase_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        #endregion

        #region Methods

        private void LoadAuthenticationTypes()
        {
            cmbAuthenticationType.Items.Add("----- Select -----");
            cmbAuthenticationType.Items.Add(AuthenticationTypes.SQLServerAuthentication.GetAuthenticationTypesDescription());
            cmbAuthenticationType.Items.Add(AuthenticationTypes.WindowsAuthentication.GetAuthenticationTypesDescription());

            cmbAuthenticationType.SelectedIndex = 0;
        }

        private bool ValidateUserInput()
        {
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                MessageBox.Show("Please enter Server Name", "Poco Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbAuthenticationType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Authentication Type", "Poco Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbAuthenticationType.SelectedItem.ToString() == AuthenticationTypes.SQLServerAuthentication.GetAuthenticationTypesDescription())
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Please enter User Name", "Poco Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please enter Password", "Poco Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //if (cmbSelectDatabase.Items.Count > 0)
            //{
            //    if (cmbSelectDatabase.SelectedIndex > 0)
            //    {
            //        MessageBox.Show("Please select Database", "PocoGenerator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}

            return true;
        }

        private bool ValidateDatabaseSelection()
        {
            if (cmbSelectDatabase.Items.Count == 0)
            {
                MessageBox.Show("Please select Database", "Poco Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ToggleUserCredentials()
        {
            if (cmbAuthenticationType.SelectedItem.ToString() == AuthenticationTypes.SQLServerAuthentication.GetAuthenticationTypesDescription())
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
            else if (cmbAuthenticationType.SelectedItem.ToString() == AuthenticationTypes.WindowsAuthentication.GetAuthenticationTypesDescription())
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
        }

        private void LoadDataTypeMappings()
        {
            Global.DataTypeMapper = _dataTypeService.GetDataTypeMappings();
        }

        #endregion        
    }
}
