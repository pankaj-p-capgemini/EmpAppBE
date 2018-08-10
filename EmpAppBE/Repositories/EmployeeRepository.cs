using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpAppBE.Models;

namespace EmpAppBE.Repositories
{
    public class EmployeeRepository : GenericRepository<EmpDBEntities, employee>
    {
        public employee GetSingle(int empID)
        {
            var query = Context.employees.FirstOrDefault(x => x.id == empID);
            return query;
        }
    }
}