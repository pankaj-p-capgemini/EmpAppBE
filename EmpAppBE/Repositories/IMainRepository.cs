using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAppBE.Repositories
{
    interface IMainRepository<T> where T : class
    {
        //IQueryable<T> GetAll();
        //IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
