using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YerbaSoft.DAL;

namespace YerbaSoft.DAL
{
    public interface IRepository
    {

    }

    public interface IRepository<T> : IRepository
    {
        #region Persistencia 

        /// <summary>
        /// Indica si el repositorio utiliza Transacción (Commit() y RollBack() necesario)
        /// </summary>
        bool UseTransaction { get; }

        /// <summary>
        /// Devuelve una nueva instancia de la entidad
        /// </summary>
        /// <returns></returns>
        T GetNew();

        /// <summary>
        /// Inserta o Actualiza la entidad (Si el repositorio usa transacción debe realizar el Commit())
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T UpsertEntity(T entity);

        /// <summary>
        /// Elimina la entidad del repositorio
        /// </summary>
        /// <param name="entity"></param>
        void DeleteEntity(T entity);

        /// <summary>
        /// Guarda los datos definitivamente (Si UseTransaction es false, éste método no tirará error)
        /// </summary>
        void Commit();

        /// <summary>
        /// Descarta los cambios realizados Guarda los datos definitivamente (Si UseTransaction es false, éste método no tirará error)
        /// </summary>
        void RollBack();


        #endregion

        #region Búsqueda

        IEnumerable<T> Find();
        IEnumerable<T> Find(Pager pager);
        IEnumerable<T> Find(Expression<Func<T, bool>> filter);
        PagerResult<T> Find(Expression<Func<T, bool>> filter, Pager pager);
        IEnumerable<T> Find(Expression<Func<T, bool>> filter, OrderBy orderBy);
        PagerResult<T> Find(Expression<Func<T, bool>> filter, Pager pager, OrderBy orderBy);
        IEnumerable<T> Find(IEnumerable<Expression<Func<T, bool>>> filters);
        PagerResult<T> Find(IEnumerable<Expression<Func<T, bool>>> filters, Pager pager);
        IEnumerable<T> Find(IEnumerable<Expression<Func<T, bool>>> filters, OrderBy orderBy);
        PagerResult<T> Find(IEnumerable<Expression<Func<T, bool>>> filters, Pager pager, OrderBy orderBy);

        bool Any();
        bool Any(Expression<Func<T, bool>> filter);
        bool Any(IEnumerable<Expression<Func<T, bool>>> filters);

        int Count();
        int Count(Expression<Func<T, bool>> filter);
        int Count(IEnumerable<Expression<Func<T, bool>>> filters);

        object Max(Expression<Func<T, object>> field);
        object Max(Expression<Func<T, bool>> filter, Expression<Func<T, object>> field);
        object Max(IEnumerable<Expression<Func<T, bool>>> filters, Expression<Func<T, object>> field);
        
        long Sum(Expression<Func<T, long>> field);
        long Sum(Expression<Func<T, bool>> filter, Expression<Func<T, long>> field);
        long Sum(IEnumerable<Expression<Func<T, bool>>> filters, Expression<Func<T, long>> field);
        decimal Sum(Expression<Func<T, decimal>> field);
        decimal Sum(Expression<Func<T, bool>> filter, Expression<Func<T, decimal>> field);
        decimal Sum(IEnumerable<Expression<Func<T, bool>>> filters, Expression<Func<T, decimal>> field);

        #endregion
    }
}
