using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.BaseObjects
{
    public class SysTypes
    {
        public string name { get; set; }
        public Int16 xtype { get; set; }

        public virtual SysColumns Column { get; set; }
    }
}
