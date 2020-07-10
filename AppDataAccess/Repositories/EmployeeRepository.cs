using AppDataAccess.Interfaces;
using AppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppDataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MasGlobalTestEntities _dbContext;

        public EmployeeRepository() { }

        public IEnumerable<Employee> GetEmployees()
        {
            IEnumerable<Employee> le;
            using (_dbContext = new MasGlobalTestEntities())
            {
                le = _dbContext.Employees.Include("Contract1").ToList();
            }
            return le;
        }

        public Employee GetEmployeeByIdNumber(int idNumber)
        {
            Employee e;
            using (_dbContext = new MasGlobalTestEntities())
            {
                e = (from us in _dbContext.Employees.Include("Contract1")
                      where us.IdNumber == idNumber
                      select us).FirstOrDefault();
            }
            return e;
        }
    }
}
