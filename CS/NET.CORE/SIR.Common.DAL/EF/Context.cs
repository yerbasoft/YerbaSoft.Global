using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SIR.Common.DAL.EF
{
    internal class Context : DbContext
    {
        protected string ConnectionString;
        protected Assembly[] Assemblies;

        public Context(string cs, params Assembly[] assemblies)
        {
            this.ConnectionString = cs;
            this.Assemblies = assemblies;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                        
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var a in this.Assemblies)
                modelBuilder.ApplyConfigurationsFromAssembly(a);

            // UpperCase Convention
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.Relational().TableName.ToUpper();
                foreach (var p in entity.GetProperties())
                {
                    p.Relational().ColumnName = p.Relational().ColumnName.ToUpper();
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(this.ConnectionString);
            }
        }
    }
}
