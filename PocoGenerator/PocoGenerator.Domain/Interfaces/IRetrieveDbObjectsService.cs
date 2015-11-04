﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Models;
using PocoGenerator.Domain.Models.Enums;
using PocoGenerator.Domain.Models.DTO;

namespace PocoGenerator.Domain.Interfaces
{
    public interface IRetrieveDbObjectsService
    {
        IEnumerable<TablesWithColumnsDto> GetDbObjects(DbObjectTypes dbObjectType);   //TODO change it to enum
    }
}
