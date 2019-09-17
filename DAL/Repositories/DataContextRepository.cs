using System.Data.Linq;
using System.Linq;

namespace YerbaSoft.DAL.Repositories
{
    public class DataContextRepository<T> : YerbaSoft.DAL.Repositories.QueryableRepository<T> where T : class, new()
    {
        private DataContext DBModel { get; set; }

        public override bool UseTransaction { get { return true; } }

        public DataContextRepository(DataContext model) : base(model.GetTable<T>().AsQueryable<T>())
        {
            this.DBModel = model;
        }

        public override void DeleteEntity(T entity)
        {
            DBModel.GetTable<T>().DeleteOnSubmit(entity);
        }

        public override T GetNew()
        {
            return new T();
        }

        public override T UpsertEntity(T entity)
        {
            if (!DBModel.GetTable<T>().Contains(entity))
                DBModel.GetTable<T>().InsertOnSubmit(entity);

            return entity;
        }

        public override void Commit()
        {
            DBModel.SubmitChanges();
        }

        public override void RollBack()
        {
            if (DBModel.Transaction != null)
                DBModel.Transaction.Rollback();
        }

    }
}
