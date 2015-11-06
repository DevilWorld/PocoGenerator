using System;
using System.Collections.Generic;
using System.Linq;
using DotLiquid;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Domain.DotLiquidDrops
{
    internal class SysObjectsDrop : Drop
    {
        private readonly SysObjects _sysObjects;

        public SysObjectsDrop(SysObjects sysObjects)
        {
            _sysObjects = sysObjects;
        }

        #region Properties

        public string Name => _sysObjects.name;

        #endregion
    }
}
