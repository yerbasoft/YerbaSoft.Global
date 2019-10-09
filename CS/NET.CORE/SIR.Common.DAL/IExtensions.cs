using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Reflection;

namespace SIR.Common.DAL
{
    /// <summary>
    /// Extensiones de Aplicación relacionadas al acceso a la base de datos
    /// </summary>
    public static class IExtensions
    {
        #region Exceptions

        /// <summary>
        /// Indica que el campo será de tipo bool y se almacenará como Y/N
        /// </summary>
        public static PropertyBuilder<bool> YesNoType(this PropertyBuilder<bool> prop)
        {
            return prop.HasConversion(EF.Converter.YesNoType);
        }

        /// <summary>
        /// Indica que el campo será de tipo bool? y se almacenará como null/Y/N
        /// </summary>
        public static PropertyBuilder<bool?> YesNoType(this PropertyBuilder<bool?> prop)
        {
            return prop.HasConversion(EF.Converter.YesNoNullType);
        }

        #endregion

        #region Entity Framework

        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();
        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");
        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");
        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");
        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        /// <summary>
        /// Devuelve el QueryString SQL para un IQueriable<TEntity> construido en EntityFramework
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string GetSqlQuery<TEntity>(this IQueryable<TEntity> query) where TEntity : class
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

        #endregion
    }
}
