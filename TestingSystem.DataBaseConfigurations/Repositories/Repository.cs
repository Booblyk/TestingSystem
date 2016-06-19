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

        private readonly DbSet<T> dbSet;

        protected IDbProvide DbProvide
        {
            get;
            set;
        }
        protected TestingSystemContext DataBaseContext
        {

            get { return dContext ?? (dContext = DbProvide.Init()); }
        }

        public IQueryable<T> Query()
        {
            return dbSet.AsQueryable();
        }
        public Repository(IDbProvide Provide)
        {
            DbProvide = Provide;
            dbSet = DataBaseContext.Set<T>();
        }
        public Repository(TestingSystemContext context)
        {
            this.dContext = context;
            dbSet = context.Set<T>();
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }
        public void DeleteA(T entity)
        {
            dbSet.Remove(entity);
        }

        public T GetById(params object[] id)
        {
            return dbSet.Find(id);
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
            // DbEntityEntry dbEntityEntry = DataBaseContext.Entry<T>(entity);
            // var a = DataBaseContext.Set<T>();
            DataBaseContext.Set<T>().Add(entity);
            // a.Add(entity);
            DataBaseContext.SaveChanges();
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
        //private TestingSystemContext dContext;

        //private readonly DbSet<T> dbSet;

        //protected IDbProvide DbProvide
        //{
        //    get;
        //    set;
        //}
        //protected TestingSystemContext DataBaseContext
        //{
        //    get { return dContext ?? (dContext = DbProvide.Init()); }
        //}

        //public Repository(IDbProvide Provide)
        //{
        //    DbProvide = Provide;
        //}
        //public IQueryable<T> Query()
        //{
        //    return dbSet.AsQueryable();
        //}

        ///**/


        //public IQueryable<T> GetAll()
        //{
        //    return DataBaseContext.Set<T>();
        //}
        //public IQueryable<T> All
        //{
        //    get
        //    {
        //        return GetAll();
        //    }
        //}
        //public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        //{
        //    return DataBaseContext.Set<T>().Where(predicate);
        //}
        //public void Add(T entity)
        //{
        //   // DbEntityEntry dbEntityEntry = DataBaseContext.Entry<T>(entity);
        //   // var a = DataBaseContext.Set<T>();
        //    DataBaseContext.Set<T>().Add(entity);
        //   // a.Add(entity);
        //    DataBaseContext.SaveChanges();
        //}
        //public void Edit(T entity)
        //{
        //    //DbEntityEntry dbEntityEntry = DataBaseContext.Entry<T>(entity);
        //    //dbEntityEntry.State = EntityState.Modified;
        //    //DataBaseContext.SaveChanges();

        //    DataBaseContext.Entry(entity).State = EntityState.Unchanged;
        //    DataBaseContext.SaveChanges();
        //}

        //public T GetSingle(int id)
        //{
        //    return GetAll().FirstOrDefault(x => x.Id == id);
        //}

        //public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> query = DataBaseContext.Set<T>();
        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }
        //    return query;
        //}
        //public void Delete(T entity)
        //{
        //  //  DbEntityEntry dbEntityEntry = DataBaseContext.Entry<T>(entity);
        //  //  dbEntityEntry.State = EntityState.Deleted;
        //    DataBaseContext.Set<T>().Remove(entity);
        //    DataBaseContext.SaveChanges();
        //}
    }
}
