using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IRetrieveDbObjectsService
    {
        IEnumerable<SysObjects> GetDbObjects(DbObjectTypes dbObjectType);   //TODO change it to enum
    }
}
