using AppDataAccess.Interfaces;
using AppDataAccess.Models.Common;
using AppDataAccess.Models.ViewModels.EmployeeViewModel;
using AppServices.Interfaces;
using AppUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IEmployeeFactory _fact;
        private readonly IUtilities _util;
        private ServiceResult _sr;

        public EmployeeService(IEmployeeRepository repository, IEmployeeFactory fact, IUtilities util)
        {
            _repo = repository;
            _fact = fact;
            _util = util;
        }

        public ServiceResult GetAllEmployees(int page, int rows, bool all)
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            List<EmployeeViewModel> lempvm;
            var emps = _repo.GetEmployees();
            if (emps == null)
            {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡Employees not found!";
                return _sr;
            }

            // total
            double totalPages = all ? 1 : Math.Ceiling((double)emps.Count() / rows);
            int cant = emps.Count();
            // paging
            if (!all) { emps = emps.Skip((page - 1) * rows).Take(rows).ToList(); }

            lempvm = new List<EmployeeViewModel>();
            foreach (var itm in emps)
            {
                var obj = _fact.GetEmployeeObject(itm.Contract);
                lempvm.Add(_util.MapObject(obj, itm));
            }

            var jsonData = new
            {
                total = totalPages,
                records = cant,
                page,
                rows = lempvm
            };
            _sr.ContentResult = JsonConvert.SerializeObject(jsonData);
            return _sr;
        }

        public ServiceResult GetEmployeeByIdNumber(int idNumber)
        {
            _sr = new ServiceResult() { IsValid = true, Error = new ServiceError() };
            var emp = _repo.GetEmployeeByIdNumber(idNumber);

            if (emp == null)
            {
                _sr.IsValid = false;
                _sr.Error.ErrorMessage = "¡Employee not found!";
                return _sr;
            }

            var obj = _fact.GetEmployeeObject(emp.Contract);
            var empvm = _util.MapObject(obj, emp);
            _sr.ContentResult = JsonConvert.SerializeObject(empvm);
            return _sr;
        }

    }
}
