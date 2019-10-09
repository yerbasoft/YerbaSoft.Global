using Microsoft.EntityFrameworkCore.Storage;
using SIR.Common.DAL.Configuration;
using SIR.Common.DAL.SP;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SIR.Common.DAL.EF
{
    /// <summary>
    /// Servicio con funcionalidad básica para la utilización de EntityFramework como ORM. Debe ser heredado en caso de querer agregarle funcionalidad. Utilice GetRepository<> para obtener Repositorios genéricos para objetos de base de datos.
    /// </summary>
    public class EFDAO : IDAO, IDAOConfig, IExecProcedurable
    {
        private string Module;
        private string ConnectionString;
        private IDbContextTransaction Transaction;
        private Context Context;
        private SP.StoredProcedure StoredProcedure;

        /// <summary>
        /// Crea una nueva instancia del DAO para EntityFramework
        /// </summary>
        /// <param name="connectionString">ConnectionString para el acceso a la base de datos</param>
        /// <param name="moduleName">Nombre único para el módulo de configuración del ssitema</param>
        /// <param name="assemblies">Listado de Assemblies que incluyan los mapeos/configuraciones de las Entities de EntityFramework</param>
        public EFDAO(string connectionString, string moduleName, params Assembly[] assemblies)
        {
            this.ConnectionString = connectionString;
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

        #region IDAO

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

        #endregion

        #region IDAOConfiguration

        IConfigService _Config;
        public virtual IConfigService Config => _Config = _Config ?? new Configuration.ConfigService(this.Module, GetRepository<Configuration.Entities.Config>());

        #endregion

        #region IExecProcedurable

        public virtual IList<T> ExecProcedure<T>(string name, Parameters parametros) where T : new() => ExecProcedure<T>(name, parametros, out _, out _);
        public virtual IList<T> ExecProcedure<T>(string name, Parameters parametros, out int count, out long timeTicks) where T : new()
        {
            StoredProcedure = StoredProcedure ?? new StoredProcedure(this.ConnectionString);
            return StoredProcedure.ExecProcedure<T>(name, parametros, out count, out timeTicks);
        }

        #endregion
    }
}
