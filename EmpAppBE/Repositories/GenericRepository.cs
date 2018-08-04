using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpAppBE.Models;
using System.Data;
using System.Data.Entity;

namespace EmpAppBE.Repositories
{
    public abstract class GenericRepository<Cntx, TEntity> : IMainRepository<TEntity> where TEntity : class where Cntx : DbContext, new()
    {
        // https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/
        // https://www.c-sharpcorner.com/UploadFile/b1df45/getting-started-with-repository-pattern-using-C-Sharp/ 
        // http://www.tugberkugurlu.com/archive/generic-repository-pattern-entity-framework-asp-net-mvc-and-unit-testing-triangle 

        private Cntx _entities = new Cntx();
        public Cntx Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual void Insert(TEntity entity)
        {
            _entities.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}