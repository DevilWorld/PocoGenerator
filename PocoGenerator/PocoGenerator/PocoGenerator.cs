using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PocoGenerator.DatabaseConnection;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Services;
using Autofac;
using PocoGenerator.StartUp;
using PocoGenerator.Common;

namespace PocoGenerator
{
    public partial class PocoGenerator : Form
    {   
        public static ILifetimeScope scope { get; set; }

        //private readonly IDataTypeService _dataTypeService;
        private readonly IRetrieveDbObjectsService _retrieveDbObjectsService;        

        public PocoGenerator(IRetrieveDbObjectsService retrieveDbObjectsService/*IDataTypeService dataTypeService*/)
        {
            InitializeComponent();

            //_dataTypeService = dataTypeService;
            _retrieveDbObjectsService = retrieveDbObjectsService;

            DisplayConnectToDatabase();

            GetTables();
        }

        private void DisplayConnectToDatabase()
        {
            using (var scope = Global.Container.BeginLifetimeScope())
            {
                var objConnectToDB = new ConnectToDatabase(scope.Resolve<IDbConnectService>(), scope.Resolve<IConnectionStringService>(), scope.Resolve<IDataTypeService>());
                objConnectToDB.MdiParent = this;
                objConnectToDB.Show();
            }
        }

        private void GetTables()
        {
            var tables = _retrieveDbObjectsService.GetDbObjects("Tables");
        }
    }
}
