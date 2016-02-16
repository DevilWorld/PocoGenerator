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
using PocoGenerator.Domain;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.ExtensionMethods;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.BaseObjects;
using PocoGenerator.Domain.Models.Dto;
using PocoGenerator.StartUp;
using PocoGenerator.ExtensionMethods;

namespace PocoGenerator
{
    public partial class PocoGenerator : Form
    {
        //public static ILifetimeScope scope { get; set; }

        //private readonly IDataTypeService _dataTypeService;
        private readonly IRetrieveDbObjectsService _retrieveDbObjectsService;
        private readonly IGenerateTemplate _generateTemplate;
        private readonly IRenderOutputStrategy<TablesWithColumnsDto> _renderOutputtable;
        private readonly IRenderOutputStrategy<IEnumerable<TablesWithColumnsDto>> _renderOutputtables;

        ImageList imgList;

        //TODO On namespace enabled checkbox, reload the dot liquid templates. DotLiquidConfiguration.Configure();
        public PocoGenerator(IRetrieveDbObjectsService retrieveDbObjectsService/*IDataTypeService dataTypeService*/, IGenerateTemplate generateTemplate, IRenderOutputStrategy<TablesWithColumnsDto> renderOutputtable, IRenderOutputStrategy<IEnumerable<TablesWithColumnsDto>> renderOutputtables)
        {
            InitializeComponent();

            //_dataTypeService = dataTypeService;
            _retrieveDbObjectsService = retrieveDbObjectsService;
            _generateTemplate = generateTemplate;
            _renderOutputtable = renderOutputtable;
            _renderOutputtables = renderOutputtables;
            //Test
            //using (var scope = Global.Container.BeginLifetimeScope())
            //{
            //    var templateService = scope.Resolve<IGenerateTemplate>();
            //    templateService.Generate(TemplateType.Class, new SysObjects() {name = "tblAddress",
            //                                Columns = new List<SysColumns>
            //                                {
            //                                    new SysColumns() { id=1, name="FirstName", colorder=1},
            //                                    new SysColumns() { id=1, name="LastName", colorder=2},
            //                                }
            //    });
            //}
            //Endof test

            DisplayConnectToDatabase();

            LoadDatabaseTree();

            SetPanelWidths();

            #region Checkbox

            tvDatabase.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(tvDatabase_DrawNode);

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
                TreeNode node = new TreeNode(" " + dbObjectType.GetDbObjectTypesDescription(), 1, 1, GetChildNodes(dbObjectType));

                //node.ImageIndex = 1;

                tvDatabase.Nodes.Add(node);
            }
        }

        private TreeNode[] GetChildNodes(DbObjectTypes dbObjectType)
        {
            switch (dbObjectType)
            {
                case DbObjectTypes.Tables:

                    return GetTables().Select(x =>
                    {
                        var folderNodes = new TreeNode(" " + x.Name,
                                                new TreeNode[] {
                                                                    new TreeNode("Columns", 1, 1, GetColumnsForTablesInTreeview(x)),
                                                                    //new TreeNode("Keys", 1, 1)
                                                                });
                        
                        folderNodes.ImageIndex = 3;
                        folderNodes.SelectedImageIndex = 3;
                        folderNodes.Tag = x;

                        return folderNodes;

                    }).ToArray();

                case DbObjectTypes.Views:

                    return GetViews().Select(x =>
                    {
                        var node = new TreeNode(" " + x.Name,
                                        x.Columns.Select(y =>
                                        {
                                            var columnNode = new TreeNode(y.name);
                                            columnNode.ImageIndex = 4;
                                            columnNode.SelectedImageIndex = 4;

                                            return columnNode;
                                        }).ToArray());

                        node.ImageIndex = 3;
                        node.SelectedImageIndex = 3;
                        node.Tag = x;

                        return node;

                    }).ToArray();

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
            var path = System.IO.Directory.GetCurrentDirectory();
            imgList = new ImageList();

            imgList.Images.Add("Database", Image.FromFile(path + @"\Images\database.jpg"));
            imgList.Images.Add("Folder", Image.FromFile(path + @"\Images\folder.png"));
            imgList.Images.Add("FolderOpen", Image.FromFile(path + @"\Images\folder_open.png"));
            imgList.Images.Add("Table", Image.FromFile(path + @"\Images\table1.png"));
            imgList.Images.Add("Columns", Image.FromFile(path + @"\Images\columns.png"));
            imgList.Images.Add("PrimaryKey", Image.FromFile(path + @"\Images\primary_key.png"));
            imgList.Images.Add("ForeignKey", Image.FromFile(path + @"\Images\foreign_key.png"));

            Point destPt = new Point(6, 0);
            Size size = new Size(22, 16);
            tvDatabase.ImageList = new ImageList();
            tvDatabase.ImageList.ImageSize = size;
            foreach (String imgKey in imgList.Images.Keys)
            {
                Bitmap bmp = new Bitmap(size.Width, size.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(imgList.Images[imgKey], destPt);
                g.Dispose();
                tvDatabase.ImageList.Images.Add(imgKey, (Image)bmp);
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

        private TreeNode[] GetColumnsForTablesInTreeview(TablesWithColumnsDto tablesWithColumns)
        {
            var columnsWithPrimaryOrForeignKey = tablesWithColumns.ColumnsWithKeys;

            return tablesWithColumns.Columns.Select(y =>
                                        {
                                            var columnNode = new TreeNode(y.name);
                                            //Set image for primary/foreign key
                                            var blnColumnExists = columnsWithPrimaryOrForeignKey.Any(x => x.COLUMN_NAME == y.name);
                                            if (blnColumnExists)
                                            {
                                                var keyType = columnsWithPrimaryOrForeignKey.Where(z => z.COLUMN_NAME == y.name).Select(k => k.KeyType).ToList();
                                                columnNode.ImageIndex = keyType.Contains("PRIMARY KEY") ? 5 : 6;
                                                columnNode.SelectedImageIndex = keyType.Contains("PRIMARY KEY") ? 5 : 6;
                                            }
                                            else
                                            {
                                                columnNode.ImageIndex = 4;
                                                columnNode.SelectedImageIndex = 4;
                                            }

                                            return columnNode;
                                        }).ToArray();

            //node.ImageIndex = 3;
            //node.SelectedImageIndex = 3;
            //node.Tag = tablesWithColumns;

            //return node;
        }

        private void CheckUncheckChildNodes(TreeNodeCollection nodes, bool blnCheckUncheck)
        {
            //nodes.Cast<TreeNode>().ToList().ForEach(x => x.Checked = blnCheckUncheck);
        }

        //private bool blnChild = false;

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

            //Get the list of checked nodes and send to RenderOutput()
            var checkedNodes = GetCheckedTreeNodes();

            //Write code to generate template
            RenderOutput(checkedNodes);

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

        private void tvDatabase_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Level == 2 || e.Node.Level == 3)
                e.Node.HideCheckBox();

            e.DrawDefault = true;
        }

        //private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        //{
        //    if (e.Node.Level == 2)
        //    {
        //        Color backColor, foreColor;
        //        if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
        //        {
        //            backColor = SystemColors.Highlight;
        //            foreColor = SystemColors.HighlightText;
        //        }
        //        else if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
        //        {
        //            backColor = SystemColors.HotTrack;
        //            foreColor = SystemColors.HighlightText;
        //        }
        //        else
        //        {
        //            backColor = e.Node.BackColor;
        //            foreColor = e.Node.ForeColor;
        //        }

        //        Rectangle newBounds = e.Node.Bounds;
        //        newBounds.X = 60;

        //        using (SolidBrush brush = new SolidBrush(backColor))
        //        {
        //            //e.Graphics.FillRectangle(brush, e.Node.Bounds);

        //            e.Graphics.DrawImage(imgList.Images[4], e.Bounds.Right + 75, e.Bounds.Top + 50);
        //        }
        //        TextRenderer.DrawText(e.Graphics, e.Node.Text, tvDatabase.Font, e.Node.Bounds, foreColor, backColor);
        //        //if ((e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused)
        //        //{
        //        //    ControlPaint.DrawFocusRectangle(e.Graphics, e.Node.Bounds, foreColor, backColor);
        //        //}


        //        e.DrawDefault = false;
        //    }
        //    else
        //    {
        //        e.DrawDefault = true;
        //    }
        //}
        private static bool IsThirdLevel(TreeNode node)
        {
            return node.Parent != null && node.Parent.Parent != null;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ContextMenu menu = new ContextMenu();

            //NameSpace Enable Settings
            var mnuNameSpace = new MenuItem() { Text = "Include NameSpace" };
            mnuNameSpace.Click += mnuNameSpace_Click;
            mnuNameSpace.Checked = Global.IsNameSpaceEnabled;
            menu.MenuItems.Add(mnuNameSpace);

            button.ContextMenu = menu;
            button.ContextMenu.Show(btnSettings, new Point(-122, 18));
        }

        private void mnuNameSpace_Click(object sender, EventArgs e)
        {
            var menu = (MenuItem)sender;

            if (menu == null)
                return;

            menu.Checked = !menu.Checked;
            Global.IsNameSpaceEnabled = menu.Checked;

            //Reload Templates for DotLiquid to Parse
            DotLiquidConfiguration.Configure();
        }

        private IEnumerable<TablesWithColumnsDto> GetCheckedTreeNodes()
        {
            return tvDatabase.Nodes
               .OfType<TreeNode>()
               .SelectMany(x => new[] { x }.Concat(x.Nodes.OfType<TreeNode>()))
               .Where(x => x.Checked)
               .Select(x => x.Tag as TablesWithColumnsDto)
               .Where(x => x != null);
        }

        private void RenderOutput(IEnumerable<TablesWithColumnsDto> tableWithColumnsDto)
        {
            //rtxtOutput.Text = _renderOutputtables.RenderOutput(tableWithColumnsDto);
            rtxtOutput.Clear();

            rtxtOutput.AppendColoredText(_renderOutputtables.RenderOutput(tableWithColumnsDto), Color.Blue);
        }

        private void RenderOutput(TablesWithColumnsDto tableWithColumnsDto)
        {
            //rtxtOutput.Text = _renderOutputtable.RenderOutput(tableWithColumnsDto);

            rtxtOutput.Clear();

            rtxtOutput.AppendColoredText( _renderOutputtable.RenderOutput(tableWithColumnsDto), Color.Blue);
        }

        //private void Render(IEnumerable<TablesWithColumnsDto> tableWithColumnsDto = null, TablesWithColumnsDto singleTable = null)
        //{
        //    var templateType = Global.IsNameSpaceEnabled ? TemplateType.Namespace : TemplateType.Class;

        //    var result = string.Empty;

        //    if (tableWithColumnsDto != null)
        //        tableWithColumnsDto.ToList().ForEach(x => result += _generateTemplate.Generate(templateType, x));

        //    if (singleTable!=null)
        //        result += _generateTemplate.Generate(templateType, singleTable);

        //    //Write to textbox
        //    rtxtOutput.Text = result;
        //}

        private void tvDatabase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!GetCheckedTreeNodes().Any())
                RenderOutput(e.Node.Tag as TablesWithColumnsDto);
        }

        private void scBody_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (scBody.SplitterDistance >= tvDatabase.Width)
                scBody.SplitterDistance = tvDatabase.Width;

            SetPanelWidths();
        }

        private void SetPanelWidths()
        {
            panel1.Width = scBody.Panel2.Width;
            pnlSettings.Width = scBody.Panel2.Width;            
        }
    }
}
