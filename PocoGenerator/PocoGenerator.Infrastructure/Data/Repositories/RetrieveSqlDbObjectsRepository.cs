using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PocoGenerator.Common;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.Dto;
using PocoGenerator.Infrastructure.Data.Repositories;
using PocoGenerator.Domain;

namespace PocoGenerator.Infrastructure.Data.Repositories
{
    public class RetrieveSqlDbObjectsRepository : IRetrieveDbObjectsRepository
    {
        private readonly PocoContext _pocoContext;

        public RetrieveSqlDbObjectsRepository(PocoContext pocoContext)
        {
            _pocoContext = pocoContext;
        }

        public IEnumerable<TablesWithColumnsDto> GetStoredProcedures()
        {
            SetConnectionStringForDbToBeConnected();

            //return _pocoContext.SysObjects.Where(x => x.xtype == "P").ToList();

            return new List<TablesWithColumnsDto>();
        }

        public IEnumerable<TablesWithColumnsDto> GetTables()
        {
            SetConnectionStringForDbToBeConnected();

            //return _pocoContext.SysObjects.Where(x => x.xtype == "U").ToList();

            var tables = (from obj in _pocoContext.SysObjects
                          where obj.xtype == "U"
                          select new TablesWithColumnsDto
                          {
                              Id = obj.id,
                              Name = obj.name,
                              Columns = obj.Columns
                          }).ToList();

            return tables;
        }

        public IEnumerable<TablesWithColumnsDto> GetTableValuedFunctions()
        {
            SetConnectionStringForDbToBeConnected();

            //return _pocoContext.SysObjects.Where(x => x.xtype == "FT").ToList();

            return new List<TablesWithColumnsDto>();
        }

        public IEnumerable<TablesWithColumnsDto> GetViews()
        {
            SetConnectionStringForDbToBeConnected();

            //return _pocoContext.SysObjects.Where(x => x.xtype == "V").ToList();

            var views = (from obj in _pocoContext.SysObjects
                         where obj.xtype == "V"
                         select new TablesWithColumnsDto
                         {
                             Id = obj.id,
                             Name = obj.name,
                             Columns = obj.Columns
                         }).ToList();

            return views;
        }

        public IEnumerable<ColumnsWithKeysDto> GetColumnsWithKeys()
        {
            var columns = _pocoContext.KeyColumnNames.ToList();

            var columnsWithKeys = (from col in _pocoContext.KeyColumnNames
                                   join fk in _pocoContext.ForeignKeys on col.CONSTRAINT_NAME equals fk.name
                                   into keys
                                   from c in keys.DefaultIfEmpty()
                                   select new ColumnsWithKeysDto
                                   {
                                       CONSTRAINT_CATALOG = col.CONSTRAINT_CATALOG,
                                       CONSTRAINT_SCHEMA = col.CONSTRAINT_SCHEMA,
                                       CONSTRAINT_NAME = col.CONSTRAINT_NAME,
                                       TABLE_CATALOG = col.TABLE_CATALOG,
                                       TABLE_SCHEMA = col.TABLE_SCHEMA,
                                       TABLE_NAME = col.TABLE_NAME,
                                       COLUMN_NAME = col.COLUMN_NAME,
                                       ORDINAL_POSITION = col.ORDINAL_POSITION,
                                       KeyType = c == null ? "Primary Key" : "Foreign Key"
                                   }).ToList();

            return columnsWithKeys;
                                 
        }

        private void SetConnectionStringForDbToBeConnected()
        {
            _pocoContext.Database.Connection.ConnectionString = Global.ConnectionString;
        }
    }
}
