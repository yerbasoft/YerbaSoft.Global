using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SIR.Common.DAL
{
    public interface IRepository<TEntity> where TEntity : new()
    {
        /// <summary>
        /// Devuelve una nueva instancia de la entidad
        /// </summary>
        TEntity GetNew();

        /// <summary>
        /// Devuelve la lista completa de entidades existentes
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll();

        /// <summary>
        /// Inserta o actualiza la entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity UpsertEntity(TEntity entity);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="entity"></param>
        void DeleteEntity(TEntity entity);

        /// <summary>
        /// Busca en el repositorio según el criterio de búsqueda
        /// </summary>
        /// <param name="filter">filtro a aplicar</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Busca en el repositorio según el criterio de búsqueda
        /// </summary>
        /// <param name="filters">lista de filtros a aplicar</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(IEnumerable<Expression<Func<TEntity, bool>>> filters);

        /// <summary>
        /// Realiza la funcion agregada COUNT() sobre todos los elementos
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// Realiza la funcion agregada COUNT() en base a un criterio establecido
        /// </summary>
        /// <param name="filter">criterio</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Realiza la funcion agregada MAX()
        /// </summary>
        R Max<R>(Expression<Func<TEntity, R>> output);
        /// <summary>
        /// Realiza la funcion agregada MAX() aplicando un filtro
        /// </summary>
        /// <param name="filter">filtro</param>
        /// <param name="output">salida</param>
        R Max<R>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, R>> output);

        /// <summary>
        /// Indica si existe algún elemento
        /// </summary>
        /// <returns></returns>
        bool Any();
        /// <summary>
        /// Indica si existe algún elemento de acuerdo al criterio
        /// </summary>
        /// <param name="filter">criterio</param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Devuelve un objeto IQueryable para realizar querys LinQ complejas
        /// </summary>
        IQueryable<TEntity> AsQueryable();
    }
}
