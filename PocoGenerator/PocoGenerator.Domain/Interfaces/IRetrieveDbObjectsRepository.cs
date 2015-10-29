using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IRetrieveDbObjectsRepository
    {
        IEnumerable<SysObjects> GetTables();
        IEnumerable<SysObjects> GetViews();
        IEnumerable<SysObjects> GetStoredProcedures();
        IEnumerable<SysObjects> GetTableValuedFunctions();
    }
}
