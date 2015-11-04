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
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Common.ExtensionMethods;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.DTO;

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

            LoadDatabaseTree();

            GetTables();
        }

        private void DisplayConnectToDatabase()
        {
            using (var scope = Global.Container.BeginLifetimeScope())
            {
                var objConnectToDb = scope.Resolve<ConnectToDatabase>();
                //objConnectToDb.MdiParent = this;
                objConnectToDb.ShowDialog();
            }
        }

        private void LoadDatabaseTree()
        {
            foreach (DbObjectTypes dbObjectType in Enum.GetValues(typeof(DbObjectTypes)))
            {
                TreeNode node = new TreeNode(dbObjectType.GetDbObjectTypesDescription(), GetChildNodes(dbObjectType));                

                tvDatabase.Nodes.Add(node);
            }
        }

        private TreeNode[] GetChildNodes(DbObjectTypes dbObjectType)
        {
            switch (dbObjectType)
            {
                case DbObjectTypes.Tables:
                    return GetTables().ToList().Select(x => new TreeNode(x.Name, 
                            x.Columns.ToList().Select(y => new TreeNode(y.name)).ToArray())).ToArray();

                case DbObjectTypes.Views:
                    return GetViews().ToList().Select(x => new TreeNode(x.Name,
                            x.Columns.ToList().Select(y => new TreeNode(y.name)).ToArray())).ToArray();

                case DbObjectTypes.StoredProcedures:
                    return GetStoredProcedures().ToList().Select(x => new TreeNode(x.Name)).ToArray();

                case DbObjectTypes.TableValuedFunctions:
                    return GetTableValuedFunctions().ToList().Select(x => new TreeNode(x.Name)).ToArray();

                default:
                    return new TreeNode[0];
            }
        }

        private IEnumerable<TablesWithColumnsDto> GetTables()
        {
            return _retrieveDbObjectsService.GetDbObjects(DbObjectTypes.Tables);
        }

        private IEnumerable<TablesWithColumnsDto> GetViews()
        {
            return _retrieveDbObjectsService.GetDbObjects(DbObjectTypes.Views);
        }

        private IEnumerable<TablesWithColumnsDto> GetStoredProcedures()
        {
            return _retrieveDbObjectsService.GetDbObjects(DbObjectTypes.StoredProcedures);
        }

        private IEnumerable<TablesWithColumnsDto> GetTableValuedFunctions()
        {
            return _retrieveDbObjectsService.GetDbObjects(DbObjectTypes.TableValuedFunctions);
        }

        private void CheckUncheckChildNodes(TreeNodeCollection nodes, bool blnCheckUncheck)
        {
            //nodes.Cast<TreeNode>().ToList().ForEach(x => x.Checked = blnCheckUncheck);
        }

        private bool blnChild = false;

        private void tvDatabase_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tvDatabase.AfterCheck -= tvDatabase_AfterCheck;

            CheckUncheckParentNode(e);

            //if (e.Node.Parent != null)


                if (e.Action != TreeViewAction.Unknown)
                {
                    if (e.Node.Nodes.Count > 0)
                    {
                        e.Node.Nodes.Cast<TreeNode>().ToList().ForEach(x => x.Checked = e.Node.Checked);
                    }
                }

            tvDatabase.AfterCheck += tvDatabase_AfterCheck;
        }

        /// <summary>
        /// Unchecks the parent node, if one of its child node is unchecked
        /// </summary>
        /// <param name="e"></param>
        private void CheckUncheckParentNode(TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                e.Node.Parent.Checked = e.Node.Checked;
            }
        }

        private bool ChildNodesInSameState(TreeNode node)
        {
            if (node.Parent != null)
            {
                var childNodesState = node.Parent.Nodes.Cast<TreeNode>().ToList().Where(x => x.Checked == node.Checked).ToList().Count;

                return childNodesState == node.Parent.Nodes.Count;
            }

            return false;
        }
    }
}
