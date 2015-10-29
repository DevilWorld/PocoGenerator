using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Services
{
    public class RetrieveDbObjectsService : IRetrieveDbObjectsService
    {
        private readonly IRetrieveDbObjectsRepository _retrieveDbObjectsRepository;

        public RetrieveDbObjectsService(IRetrieveDbObjectsRepository retrieveDbObjectsRepository)
        {
            _retrieveDbObjectsRepository = retrieveDbObjectsRepository;
        }

        public IEnumerable<SysObjects> GetDbObjects(string strDbObjectType)
        {
            switch(strDbObjectType)
            {
                case "Tables":
                   return _retrieveDbObjectsRepository.GetTables();
                case "Stored Procedures":
                    return _retrieveDbObjectsRepository.GetStoredProcedures();
                case "Views":
                    return _retrieveDbObjectsRepository.GetViews();
                case "Table Valued Functions":
                    return _retrieveDbObjectsRepository.GetTableValuedFunctions();
                default:
                    return new List<SysObjects>();
            }
        }
    }
}
