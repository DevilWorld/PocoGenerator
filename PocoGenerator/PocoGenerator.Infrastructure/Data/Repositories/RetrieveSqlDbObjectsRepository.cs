using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Common;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;
using PocoGenerator.Infrastructure.Data.Repositories;

namespace PocoGenerator.Infrastructure.Data.Repositories
{
    public class RetrieveSqlDbObjectsRepository : IRetrieveDbObjectsRepository
    {
        private readonly PocoContext _pocoContext;

        public RetrieveSqlDbObjectsRepository(PocoContext pocoContext)
        {
            _pocoContext = pocoContext;
        }

        public IEnumerable<SysObjects> GetStoredProcedures()
        {
            SetConnectionStringForDbToBeConnected();

            return _pocoContext.SysObjects.Where(x => x.xtype == "P").ToList();
        }

        public IEnumerable<SysObjects> GetTables()
        {
            SetConnectionStringForDbToBeConnected();

            return _pocoContext.SysObjects.Where(x => x.xtype == "U").ToList();
        }

        public IEnumerable<SysObjects> GetTableValuedFunctions()
        {
            SetConnectionStringForDbToBeConnected();

            return _pocoContext.SysObjects.Where(x => x.xtype == "FT").ToList();
        }

        public IEnumerable<SysObjects> GetViews()
        {
            SetConnectionStringForDbToBeConnected();

            return _pocoContext.SysObjects.Where(x => x.xtype == "V").ToList();
        }

        private void SetConnectionStringForDbToBeConnected()
        {
            _pocoContext.Database.Connection.ConnectionString = Global.ConnectionString;
        }
    }
}
