using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SIR.Common.DAL.EF
{
    internal class Repository<T> : IRepository<T> where T : class, new()
    {
        Context Context;
        DbSet<T> db;
        internal Repository(Context context)
        {
            this.Context = context;
            this.db = context.Set<T>();
        }

        public IQueryable<T> AsQueryable() => db.AsQueryable();

        public bool Any() => db.Any();
        public bool Any(Expression<Func<T, bool>> filter) => db.Where(filter).Any();

        public int Count() => db.Count();
        public int Count(Expression<Func<T, bool>> filter) => db.Where(filter).Count();

        public R Max<R>(Expression<Func<T, R>> output) => db.Max(output);
        public R Max<R>(Expression<Func<T, bool>> filter, Expression<Func<T, R>> output) => db.Where(filter).Max(output);

        public IEnumerable<T> FindAll() => db.AsEnumerable();
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter) => db.Where(filter);
        public IEnumerable<T> Find(IEnumerable<Expression<Func<T, bool>>> filters)
        {
            var query = db;
            foreach (var filter in filters)
                query.Where(filter);
            return query;
        }

        public T GetNew() => new T();

        public void DeleteEntity(T entity)
        {
            db.Remove(entity);
        }

        public T UpsertEntity(T entity)
        {
            var obj = this.Context.ChangeTracker.Entries().SingleOrDefault();

            if ((obj?.State ?? EntityState.Detached) == EntityState.Detached)
                return db.Add(entity).Entity;

            return db.Update(entity).Entity;
        }
    }
}
