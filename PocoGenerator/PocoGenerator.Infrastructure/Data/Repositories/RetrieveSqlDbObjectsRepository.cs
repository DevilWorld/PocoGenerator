using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public IEnumerable<SysObjects> GetTables()
        {
            return _pocoContext.SysObjects.Where(x => x.XType == "U").ToList();
        }

        public IEnumerable<SysObjects> GetTableValuedFunctions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SysObjects> GetViews()
        {
            throw new NotImplementedException();
        }
    }
}
