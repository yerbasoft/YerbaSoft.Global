using System;
using System.Collections.Generic;
using System.Linq;

namespace YerbaSoft.DAL.Repositories
{
    public class MemoryRepository<T> : QueryableRepository<T> where T : new()
    {
        private static List<T> Cache { get; set; } = new List<T>();

        public override bool UseTransaction { get { return false; } }

        public MemoryRepository() : base(Cache.AsQueryable<T>()) { }

        public override void DeleteEntity(T entity)
        {
            Cache.Remove(entity);
        }

        public override T GetNew()
        {
            return new T();
        }

        public override T UpsertEntity(T entity)
        {
            if (!Cache.Contains(entity))
                Cache.Add(entity);

            return entity;
        }

        public override void Commit() { }   // en memoria ya se auto-graba solo

        public override void RollBack() { } // no hay rollback
    }
}
