using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PocoGenerator.DatabaseConnection;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Interfaces.Templates;
using Autofac;
using PocoGenerator.Common;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Common.ExtensionMethods;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Models.Dto;

namespace PocoGenerator
{
    public partial class PocoGenerator : Form
    {
        //public static ILifetimeScope scope { get; set; }

        //private readonly IDataTypeService _dataTypeService;
        private readonly IRetrieveDbObjectsService _retrieveDbObjectsService;

        public PocoGenerator(IRetrieveDbObjectsService retrieveDbObjectsService/*IDataTypeService dataTypeService*/)
        {
            InitializeComponent();

            //_dataTypeService = dataTypeService;
            _retrieveDbObjectsService = retrieveDbObjectsService;

            //Test
            using (var scope = Global.Container.BeginLifetimeScope())
            {
                var templateService = scope.Resolve<IGenerateTemplate>();
                templateService.Generate(TemplateType.Class, new SysObjects() {name = "tblAddress",
                                            Columns = new List<SysColumns>
                                            {
                                                new SysColumns() { id=1, name="FirstName", colorder=1},
                                                new SysColumns() { id=1, name="LastName", colorder=2},
                                            }
                });
            }
            //Endof test

            DisplayConnectToDatabase();

            LoadDatabaseTree();

            //HideTreeViewCheckboxes();

            #region Checkbox

            tvDatabase.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(treeView_DrawNode);

            AssignImagesToTreeView();

            #endregion
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
                TreeNode node = new TreeNode(" " + dbObjectType.GetDbObjectTypesDescription(), GetChildNodes(dbObjectType));

                tvDatabase.Nodes.Add(node);
            }
        }

        private TreeNode[] GetChildNodes(DbObjectTypes dbObjectType)
        {
            switch (dbObjectType)
            {
                case DbObjectTypes.Tables:
                    //return GetTables().ToList().Select(x => new TreeNode(" " + x.Name,
                    //        x.Columns.ToList().Select(y => new TreeNode(y.name)).ToArray())).ToArray();

                    return GetTables().ToList().Select(x =>
                    {
                        var node = new TreeNode(" " + x.Name,
                                        x.Columns.ToList().Select(y => new TreeNode(y.name)).ToArray());

                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 1;

                        return node;

                    }).ToArray();

                case DbObjectTypes.Views:
                    return GetViews().ToList().Select(x => new TreeNode(" " + x.Name,
                            x.Columns.ToList().Select(y => new TreeNode(y.name)).ToArray())).ToArray();

                case DbObjectTypes.StoredProcedures:
                    return GetStoredProcedures().ToList().Select(x => new TreeNode(" " + x.Name)).ToArray();

                case DbObjectTypes.TableValuedFunctions:
                    return GetTableValuedFunctions().ToList().Select(x => new TreeNode(" " + x.Name)).ToArray();

                default:
                    return new TreeNode[0];
            }
        }

        private void AssignImagesToTreeView()
        {
            ImageList imgList = new ImageList();

            var path = System.IO.Directory.GetCurrentDirectory();

            imgList.Images.Add(Image.FromFile(path + @"\Images\database.jpg"));
            imgList.Images.Add(Image.FromFile(path + @"\Images\folder.jpg"));
            imgList.Images.Add(Image.FromFile(path + @"\Images\table.png"));

            tvDatabase.ImageList = imgList;
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

        //private void HideTreeViewCheckboxes()
        //{
        //    tvDatabase.Nodes.Cast<TreeNode>()
        //        .Where(x => x.Text == "Tables")
        //        .Select(x => x.Nodes)
        //        .ToList()
        //        .ForEach(x => x.Cast<TreeNode>()
        //                        .ToList()
        //                        .ForEach(y => y.Nodes
        //                                        .Cast<TreeNode>()
        //                                        .ToList()
        //                                        .ForEach(z=> z.HideCheckBox()))
        //                );
        //}



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

        //private void tvDatabase_DrawNode(object sender, DrawTreeNodeEventArgs e)
        //{
        //    if (e.Node.Level == 2)
        //        e.Node.HideCheckBox();

        //    if (e.Node.Level == 0 || e.Node.Level == 1)
        //    {
        //        var nodeText = e.Node.Text;
        //        e.Graphics.DrawString(nodeText, e.Node.TreeView.Font, Brushes.Black,
        //            e.Node.Bounds.X, e.Node.Bounds.Y);
        //    }

        //    e.DrawDefault = true;
        //}

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level == 2)
            {
                Color backColor, foreColor;
                if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
                {
                    backColor = SystemColors.Highlight;
                    foreColor = SystemColors.HighlightText;
                }
                else if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
                {
                    backColor = SystemColors.HotTrack;
                    foreColor = SystemColors.HighlightText;
                }
                else
                {
                    backColor = e.Node.BackColor;
                    foreColor = e.Node.ForeColor;
                }

                Rectangle newBounds = e.Node.Bounds;
                newBounds.X = 60;

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.Node.Bounds);
                }
                TextRenderer.DrawText(e.Graphics, e.Node.Text, tvDatabase.Font, e.Node.Bounds, foreColor, backColor);
                if ((e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, e.Node.Bounds, foreColor, backColor);
                }
                e.DrawDefault = false;
            }
            else
            {
                e.DrawDefault = true;
            }
        }
        private static bool IsThirdLevel(TreeNode node)
        {
            return node.Parent != null && node.Parent.Parent != null;
        }
    }
}
