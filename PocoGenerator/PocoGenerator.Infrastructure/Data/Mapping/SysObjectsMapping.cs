using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PocoGenerator.Domain.Models;

namespace PocoGenerator.Infrastructure.Data.Mapping
{
    class SysObjectsMapping : EntityTypeConfiguration<SysObjects>
    {
        public SysObjectsMapping()
        {
            ToTable("SysObjects");

            Property(p => p.Id).HasColumnName("id").HasColumnType("int");
            Property(p => p.Name).HasColumnName("name").HasColumnType("sysname");
            Property(p => p.XType).HasColumnName("xtype").HasColumnType("char");
        }
    }
}
