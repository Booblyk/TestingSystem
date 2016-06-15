using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace TestingSystem.DataBaseConfigurations.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        private TestingSystemContext dContext;

        protected IDbProvide DbProvide
        {
            get;
            set;
        }
        protected TestingSystemContext DataBaseContext
        {
            get { return dContext ?? (dContext = DbProvide.Init()); }
        }

        public Repository(IDbProvide Provide)
        {
            DbProvide = Provide;
        }

        /**/

        public IQueryable<T> GetAll()
        {
            return DataBaseContext.Set<T>();
        }
        public IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DataBaseContext.Set<T>().Where(predicate);
        }
        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DataBaseContext.Entry<T>(entity);
            DataBaseContext.Set<T>().Add(entity);
        }
        public void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = DataBaseContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DataBaseContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DataBaseContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
    }
}
