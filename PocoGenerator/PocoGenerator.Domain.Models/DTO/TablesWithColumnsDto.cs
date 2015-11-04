using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator.Domain.Models.DTO
{
    public class TablesWithColumnsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        

        public IEnumerable<SysColumns> Columns { get; set; }
    }
}
