using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TestingSystem.Entities;


namespace TestingSystem.DataBaseConfigurations.Repositories
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        T GetSingle(int id);

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> All { get; }

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        void Add(T entity);

        void Delete(T entity);

        void DeleteA(T entity);

        T GetById(params object[] id);

        void Edit(T entity);
        void Insert(T entity);
        IQueryable<T> Query();
    }
}
