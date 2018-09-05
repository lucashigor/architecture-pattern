﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Tier.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected Context _context;
        protected readonly DbSet<T> _dbSet;

        protected IFactoryBase _factoryBase
        {
            get;
            private set;
        }

        protected Context Context
        {
            get { return _context ?? (_context = _factoryBase.GetContext()); }
        }

        public BaseRepository(IFactoryBase factoryBase)
        {
            _factoryBase = factoryBase;
            _dbSet = Context.Set<T>();
        }

        #region Metodos Crud

        public virtual T Create(T entity)
        {
            this._dbSet.Add(entity);

            Context.SaveChanges();

            return entity;
        }

        public virtual T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            Context.SaveChanges();

            return entity;
        }

        public virtual void Delete(T entity)
        {
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }

            Context.SaveChanges();
        }

        protected virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);

            Context.SaveChanges();
        }

        public void Reload(T entity)
        {
            _context.Entry<T>(entity).Reload();
        }

        public void Reload(T entity, Expression<Func<T, object>> attribute)
        {
            _context.Entry<T>(entity).Reference(attribute).Load();
        }

        #endregion

        #region Metodos Get

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<T> GetAll(Func<T, object> order)
        {
            return _dbSet.OrderBy(order).AsQueryable();
        }

        public virtual IQueryable<T> GetAllDecreasing(Func<T, object> order)
        {
            return _dbSet.OrderByDescending(order).AsQueryable();
        }

        protected virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where);
        }

        protected virtual IQueryable<T> GetManyPagined(Expression<Func<T, bool>> where, Func<T, object> order, int pageSize, int pageIndex, out int totalPages)
        {
            totalPages = _dbSet.Where(where).Count();
            return _dbSet.Where(where).OrderBy(order).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
        }

        protected virtual IQueryable<T> GetManyPaginedDecreasing(Expression<Func<T, bool>> where, Func<T, object> order, int pageSize, int pageIndex, out int totalPages)
        {
            totalPages = _dbSet.Where(where).Count();
            return _dbSet.Where(where).OrderByDescending(order).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable();
        }

        protected T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }

        protected int Count(Func<T, bool> where)
        {
            return _dbSet.Count(where);
        }

        #endregion
    }
}
