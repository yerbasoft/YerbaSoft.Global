using System.Linq;
using System.Collections.Generic;
using System.Text;
using SIR.Common.DTO;
using SIR.Common.DAL.Configuration.Entities;
using SIR.Common.Log;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query;

namespace SIR.Common.DAL.Configuration
{
    internal class Configuration : IConfiguration
    {
        private string Module;
        private IRepository<Entities.Config> Configs;

        internal Configuration(string module, IRepository<Entities.Config> repository)
        {
            this.Module = module;
            this.Configs = repository;
        }

        /// <summary>
        /// Obtiene una configuración
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Response<Config> Get(string key)
        {
            var configs = this.Configs.Find(p => p.ModuleId == this.Module && p.Key == key);

            var sql = configs.AsQueryable().ToSql();

            if (configs.Count() == 0)
                return new Response<Config>(new KeyNotFoundException($"No se encontró la Key: '{key}' para el ModuleId:'{this.Module}'."));

#if DEBUG
            // DEBUG: Me sirve cualquier KEY (prioridad a DEBUG = 1)
            return new Response<Config>(configs.OrderByDescending(p => p.Debug).First());
#else
            // RELEASE: Sólo es válida la KEY donde DEBUG=0
            if (configs.Where(p => p.Debug == 0).Count() != 1)
                return new Response<Config>(new KeyNotFoundException($"No se encontró la Key: '{key}' para el ModuleId:'{this.Module}' para el modo Release."));
            else
                return new Response<Config>(configs.OrderBy(p => p.Debug).First());
#endif
        }

        public Config Get(string key, Logger logger)
        {
            return logger.Log(Get(key)).Data;
        }
    }

    public static class IQueryableExtensions
    {
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
            var modelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
            var queryModel = modelGenerator.ParseQuery(query.Expression);
            var database = (IDatabase)DataBaseField.GetValue(queryCompiler);
            var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
            var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
            var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            var sql = modelVisitor.Queries.First().ToString();

            return sql;
        }
    }
}
