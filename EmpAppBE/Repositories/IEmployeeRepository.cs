using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmpAppBE.Models;

namespace EmpAppBE.Repositories
{
    interface IEmployeeRepository : IMainRepository<employee>
    {
        employee GetSingle(int empId);
    }
}