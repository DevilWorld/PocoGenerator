using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using PocoGenerator.Domain.Models.BaseObjects;

namespace PocoGenerator.Infrastructure.Data.Mapping
{
    public class ForeignKeysMapping : EntityTypeConfiguration<ForeignKeys>
    {
        public ForeignKeysMapping()
        {
            ToTable("sys.foreign_keys");

            //Primary key configuration
            HasKey(pk => pk.name);

            //Properties
            Property(p => p.name).HasColumnName("name").HasColumnType("nvarchar");            
        }
    }
}
