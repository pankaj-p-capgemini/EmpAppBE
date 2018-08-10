using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpAppBE.Repositories
{
    public interface IMainRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        //T FindBy(int id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
