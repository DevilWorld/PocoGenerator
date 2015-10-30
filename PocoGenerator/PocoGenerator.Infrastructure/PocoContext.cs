using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PocoGenerator.Common;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;
using PocoGenerator.Infrastructure.Data.Mapping;

namespace PocoGenerator.Infrastructure
{
    public class PocoContext : DbContext
    {
        private readonly IConnectionStringService _connectionStringService;

        public PocoContext(IConnectionStringService connectionStringService)
        {
            _connectionStringService = connectionStringService;

            Database.SetInitializer<PocoContext>(null);
            //this.Database.Connection.ConnectionString = Global.ConnectionString;
        }

        public DbSet<SysObjects> SysObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SysObjectsMapping());
        }
    }
}
