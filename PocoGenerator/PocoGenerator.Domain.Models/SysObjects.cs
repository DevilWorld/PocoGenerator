using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models
{
    public class SysObjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string XType { get; set; }
        public Int16 UId { get; set; }
        public Int16 Info { get; set; }
        public Int32 status { get; set; }
        public Int32 base_schema_ver { get; set; }
        public Int32 replinfo { get; set; }
        public Int32 parent_obj { get; set; }
        public DateTime crdate { get; set; }
        public Int16 ftcatid { get; set; }
        public Int32 schema_ver { get; set; }
        public Int32 stats_schema_ver { get; set; }
        public string type { get; set; }
        public Int16 userstat { get; set; }
        public Int16 sysstat { get; set; }
        public Int16 indexdel { get; set; }
        public DateTime refdate { get; set; }
        public Int32 version { get; set; }
        public Int32 deltrig { get; set; }
        public Int32 instrig { get; set; }
        public Int32 updtrig { get; set; }
        public Int32 seltrig { get; set; }
        public Int32 category { get; set; }
        public Int16 cache { get; set; }
    }
}
