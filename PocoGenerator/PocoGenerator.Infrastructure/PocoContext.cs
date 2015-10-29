using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PocoGenerator.Common;
using PocoGenerator.Domain.Models;
using PocoGenerator.Infrastructure.Data.Mapping;

namespace PocoGenerator.Infrastructure
{
    public class PocoContext : DbContext
    {
        

        public PocoContext() : base(@"Data Source=(localDb)\MSSQLLocalDb;Initial Catalog =master;Integrated Security=true;")
        {
            
            //this.Database.Connection.ConnectionString = Global.ConnectionString;
        }

        public DbSet<SysObjects> SysObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysObjectsMapping());
        }
    }
}
