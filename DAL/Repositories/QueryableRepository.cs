using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace YerbaSoft.DAL.Repositories
{
    public abstract class QueryableRepository<T> : IRepository<T>
    {
        private IQueryable<T> _Query { get; set; }
        private System.Reflection.PropertyInfo _QueryPropGet { get; set; }
        private IQueryable<T> Query
        {
            get
            {
                if (_Query != null)
                    return _Query;
                if (_QueryPropGet != null)
                    return (IQueryable<T>)_QueryPropGet.GetValue(this);

                return null;
            }
        }

        public abstract bool UseTransaction { get; }
        public abstract T UpsertEntity(T entity);
        public abstract void DeleteEntity(T entity);
        public abstract T GetNew();
        public abstract void Commit();
        public abstract void RollBack();

        public QueryableRepository(IQueryable<T> queryable)
        {
            this._Query = queryable;
        }
        
        internal void SetSpecialQueriable(System.Reflection.PropertyInfo prop)
        {
            if (prop == null)
                throw new Exception("No se permite una propiedad nula");

            if (typeof(IQueryable<T>).FullName != prop.PropertyType.FullName && typeof(IQueryable<T>).IsAssignableFrom(prop.PropertyType))
                throw new Exception("La propiedad no es de tipo System.Linq.IQueryable<" + typeof(T).FullName + ">");

            this._QueryPropGet = prop;
        }

        public bool Any()
        {
            return Any(new Expression<Func<T, bool>>[] { });
        }

        public bool Any(IEnumerable<Expression<Func<T, bool>>> filters)
        {
            var exec = this.Query.AsQueryable<T>();
            if (filters != null)
                foreach (var f in filters)
                    exec = exec.Where(f);

            return exec.Any();
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return Any(new Expression<Func<T, bool>>[] { filter });
        }

        public int Count()
        {
            return Count(new Expression<Func<T, bool>>[] { });
        }

        public int Count(IEnumerable<Expression<Func<T, bool>>> filters)
        {
            var exec = this.Query.AsQueryable<T>();
            if (filters != null)
                foreach (var f in filters)
                    exec = exec.Where(f);

            return exec.Count();
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            return Count(new Expression<Func<T, bool>>[] { });
        }

        public IEnumerable<T> Find()
        {
            return Find(new Expression<Func<T, bool>>[] { }, null, null).Data;
        }

        public IEnumerable<T> Find(IEnumerable<Expression<Func<T, bool>>> filters)
        {
            return Find(filters, null, null).Data;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return Find(new Expression<Func<T, bool>>[] { filter }, null, null).Data;
        }

        public IEnumerable<T> Find(Pager pager)
        {
            return Find(new Expression<Func<T, bool>>[] { }, pager, null).Data;
        }

        public IEnumerable<T> Find(IEnumerable<Expression<Func<T, bool>>> filters, OrderBy orderBy)
        {
            return Find(filters, null, orderBy).Data;
        }

        public PagerResult<T> Find(IEnumerable<Expression<Func<T, bool>>> filters, Pager pager)
        {
            return Find(filters, pager, null);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter, OrderBy orderBy)
        {
            return Find(new Expression<Func<T, bool>>[] { filter }, null, orderBy).Data;
        }

        public PagerResult<T> Find(Expression<Func<T, bool>> filter, Pager pager)
        {
            return Find(new Expression<Func<T, bool>>[] { filter }, pager, null);
        }

        public PagerResult<T> Find(IEnumerable<Expression<Func<T, bool>>> filters, Pager pager, OrderBy orderBy)
        {
            var exec = this.Query.AsQueryable<T>();
            if (filters != null)
                foreach (var f in filters)
                    exec = exec.Where(f);

            var totalCount = pager != null && pager.IsValid() ? exec.Count() : 0;

            if (orderBy != null)
                exec = orderBy.Apply(exec);

            if (pager != null && pager.IsValid())
                exec = exec.Skip((pager.PageNum - 1) * pager.PageSize).Take(pager.PageSize);

            var result = new PagerResult<T>(exec.AsEnumerable<T>().ToArray());
            
            if (pager != null && pager.IsValid())
                result.SetInfo(pager.PageNum, pager.PageSize, totalCount);

            return result;
        }

        public PagerResult<T> Find(Expression<Func<T, bool>> filter, Pager pager, OrderBy orderBy)
        {
            return Find(new Expression<Func<T, bool>>[] { filter }, pager, orderBy);
        }
        
        public object Max(Expression<Func<T, object>> field)
        {
            return Max(new Expression<Func<T, bool>>[] { }, field);
        }

        public object Max(IEnumerable<Expression<Func<T, bool>>> filters, Expression<Func<T, object>> field)
        {
            var exec = this.Query.AsQueryable<T>();
            if (filters != null)
                foreach (var f in filters)
                    exec = exec.Where(f);

            return exec.Max(field);
        }

        public object Max(Expression<Func<T, bool>> filter, Expression<Func<T, object>> field)
        {
            return Max(new Expression<Func<T, bool>>[] { filter }, field);
        }

        public decimal Sum(Expression<Func<T, decimal>> field)
        {
            return Sum(new Expression<Func<T, bool>>[] { }, field);
        }

        public long Sum(Expression<Func<T, long>> field)
        {
            return Sum(new Expression<Func<T, bool>>[] { }, field);
        }

        public decimal Sum(IEnumerable<Expression<Func<T, bool>>> filters, Expression<Func<T, decimal>> field)
        {
            var exec = this.Query.AsQueryable<T>();
            if (filters != null)
                foreach (var f in filters)
                    exec = exec.Where(f);

            return exec.Sum(field);
        }

        public long Sum(IEnumerable<Expression<Func<T, bool>>> filters, Expression<Func<T, long>> field)
        {
            var exec = this.Query.AsQueryable<T>();
            if (filters != null)
                foreach (var f in filters)
                    exec = exec.Where(f);

            return exec.Sum(field);
        }

        public decimal Sum(Expression<Func<T, bool>> filter, Expression<Func<T, decimal>> field)
        {
            return Sum(new Expression<Func<T, bool>>[] { filter }, field);
        }

        public long Sum(Expression<Func<T, bool>> filter, Expression<Func<T, long>> field)
        {
            return Sum(new Expression<Func<T, bool>>[] { filter }, field);
        }
    }
}
