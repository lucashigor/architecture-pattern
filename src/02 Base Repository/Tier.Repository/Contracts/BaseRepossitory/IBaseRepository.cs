using System;
using System.Linq;
using System.Linq.Expressions;

namespace Tier.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);

        void Delete(T entity);
        void Delete(int id);
        //void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);
        //T Get(Expression<Func<T, bool>> where);

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Func<T, object> order);
        IQueryable<T> GetAllDecreasing(Func<T, object> order);


        //IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        //IQueryable<T> GetManyPagined(Expression<Func<T, bool>> where, Func<T, object> order, int pageSize, int pageIndex, out int totalPages);
        //IQueryable<T> GetManyPaginedDecreasing(Expression<Func<T, bool>> where, Func<T, object> order, int pageSize, int pageIndex, out int totalPages);

        //int Count(Func<T, bool> where);

        void Reload(T entity);

        void Reload(T entity, Expression<Func<T, object>> attribute);
    }
}
