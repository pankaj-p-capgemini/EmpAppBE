using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpAppBE.Repositories;
using System.Data.Entity;
using EmpAppBE.Models;

namespace EmpAppBE.Repositories
{
    public class EmployeeUOW
    {
        private IMainRepository<employee> empGenObj = null;
        GenericRepository<EmpDBEntities, employee> lcEmpGenObj = new GenericRepository<EmpDBEntities, employee>();

        public EmployeeUOW() {
            empGenObj = new GenericRepository<EmpDBEntities, employee>();
        }

        public IQueryable<employee> GetAll()
        {
            var query = empGenObj.GetAll();
            return query;
        }

        public employee GetSingle(int empId)
        {
            var query = empGenObj.FindBy(empId);
            return query;
        }

        public void Insert(employee empObj)
        {
            empGenObj.Insert(empObj);
        }

        public void Update(employee empObj)
        {
            empGenObj.Update(empObj);
        }

        public void Delete(employee empObj)
        {
            empGenObj.Delete(empObj);
        }

        public void Save()
        {
            empGenObj.Save();
        }
    }
}