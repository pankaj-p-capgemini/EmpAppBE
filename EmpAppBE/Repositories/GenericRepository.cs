using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpAppBE.Models;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace EmpAppBE.Repositories
{
    public abstract class GenericRepository<Cntx, TEntity> : IMainRepository<TEntity> where TEntity : class where Cntx : DbContext, new()
    {
        private Cntx _entities = new Cntx();
        public Cntx Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>();
            return query;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            return query;
        }

        //public TEntity FindBy(int id)//Expression<Func<TEntity, bool>>  predicate
        //{
        //    TEntity query = _entities.Set<TEntity>().Find(id); //.Where(predicate);
        //    return query;
        //}

        public virtual TEntity Insert(TEntity entity)
        {
            _entities.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}