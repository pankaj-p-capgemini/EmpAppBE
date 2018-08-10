using System;
using System.Collections.Generic;
using System.Linq;
using EmpAppBE.Models;

namespace EmpAppBE.Repositories
{
    public class EmployeeUOW
    {
        private EmployeeRepository empGenObj = new EmployeeRepository();
        private EmployeeRepository empPerObj = new EmployeeRepository();
        private EmployeeRepository empConObj = new EmployeeRepository();
        private EmployeeRepository empQuaObj = new EmployeeRepository();

        public EmployeeUOW()
        {

        }

        public IQueryable<employee> GetAll()
        {
            var query = empGenObj.GetAll();
            return query;
        }

        public employee GetSingle(int empId)
        {
            var query = empGenObj.GetSingle(empId);
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