using Microsoft.EntityFrameworkCore.Storage;
using SIR.Common.DAL.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SIR.Common.DAL.EF
{
    public class EFDAO : IDAO, IDAOConfiguration
    {
        string Module;
        IDbContextTransaction Transaction;
        Context Context;

        IConfiguration _Config;
        public virtual IConfiguration Config => _Config = _Config ?? new Configuration.Configuration(this.Module, GetRepository<Configuration.Entities.Config>());

        public EFDAO(string connectionString, string moduleName, params Assembly[] assemblies)
        {
            this.Module = moduleName;
            this.Context = new Context(connectionString, assemblies);
        }

        /// <summary>
        /// Devuelve un IRepository para un tipo específico
        /// </summary>
        /// <typeparam name="T">Tipo de la entidad</typeparam>
        protected IRepository<T> GetRepository<T>() where T : class, new ()
        {
            return new Repository<T>(this.Context);
        }

        public void BeginTran()
        {
            if (Transaction == null)
                Transaction = this.Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (Transaction != null)
                Transaction.Commit();

            this.Context.SaveChanges();
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
                Transaction = null;
            }
        }
    }
}
