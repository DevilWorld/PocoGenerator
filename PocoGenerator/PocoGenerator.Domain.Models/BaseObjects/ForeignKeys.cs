using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.BaseObjects
{
    public class ForeignKeys
    {
        public string name { get; set; }

        //Navigation Property
        public KeyColumnUsage KeyColumns { get; set; }
    }
}
