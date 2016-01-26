using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain;

namespace PocoGenerator.TypeMapping
{
    public partial class TypeMapper : Form
    {
        private readonly IDataTypeService _dataTypeService;

        public TypeMapper(IDataTypeService dataTypeService)
        {
            InitializeComponent();

            _dataTypeService = dataTypeService;

            CreateColumns();

            BindGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Global.DataTypeMapper =_dataTypeService.GetDataTypeMappings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUseDefaults_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void CreateColumns()
        {
            //SQL Server Data Type column
            DataGridViewTextBoxColumn dgvcolSqlServerDataTypeColumn = new DataGridViewTextBoxColumn();
            dgvcolSqlServerDataTypeColumn.Name = "sqlServerDataTypeColumn";
            dgvcolSqlServerDataTypeColumn.HeaderText = "SQL Server Data Type";
            dgvcolSqlServerDataTypeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvcolSqlServerDataTypeColumn.DataPropertyName = "DbDataTypeName";
            dgvcolSqlServerDataTypeColumn.ReadOnly = true;

            dgvTypes.Columns.Add(dgvcolSqlServerDataTypeColumn);

            //.Net Data Type Column
            DataGridViewComboBoxColumn dgvcolDotNetDataType = new DataGridViewComboBoxColumn();
            dgvcolDotNetDataType.Name = "dotNetDataType";
            dgvcolDotNetDataType.HeaderText = ".Net Data Type";
            dgvcolDotNetDataType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvcolDotNetDataType.DataPropertyName = "DotNetDataTypeName";

            dgvcolDotNetDataType.DataSource = _dataTypeService.GetAllDotNetDataTypes().ToList();            

            dgvTypes.Columns.Add(dgvcolDotNetDataType);
        }

        private void BindGrid()
        {            
            dgvTypes.DataSource = _dataTypeService.GetGridDatasource();
        }

        
    }
}
