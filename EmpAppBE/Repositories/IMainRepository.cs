﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpAppBE.Repositories
{
    interface IMainRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T FindBy(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
