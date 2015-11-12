using System;
using System.Collections.Generic;
using System.Linq;
using PocoGenerator.Domain.Models;
using DotLiquid;

namespace PocoGenerator.Domain.DotLiquidDrops
{
    internal class SysColumnsDrop : Drop
    {
        private readonly SysColumns _sysColumns;

        public SysColumnsDrop(SysColumns sysColumns)
        {
            _sysColumns = sysColumns;
        }

        public string name => _sysColumns.name;
    }
}
