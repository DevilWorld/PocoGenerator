using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.BaseObjects
{
    public class SysColumns
    {
        public int id { get; set; }
        public string name { get; set; }
        public Int16 colorder { get; set; }
        public Int16 xtype { get; set; }

        public virtual SysObjects Table { get; set; }
    }
}
