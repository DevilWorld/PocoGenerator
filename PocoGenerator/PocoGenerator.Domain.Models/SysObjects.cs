using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models
{
    public class SysObjects
    {
        public int id { get; set; }
        public string name { get; set; }
        public string xtype { get; set; }

        public virtual ICollection<SysColumns> Columns { get; set; }
    }
}
