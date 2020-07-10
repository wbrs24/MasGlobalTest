using AppServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MasGlobalTest.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee/Get
        public IHttpActionResult GetAll()
        {
            var result = _employeeService.GetAllEmployees(0, 1, true);
            return Json(JsonConvert.SerializeObject(result));
        }

        // GET: api/Employee/Get
        public IHttpActionResult GetEmployee(int idNumber)
        {
            var result = _employeeService.GetEmployeeByIdNumber(idNumber);
            return Json(JsonConvert.SerializeObject(result));
        }

        // GET: api/Employee/GetAllEmployees
        public IHttpActionResult GetAllEmployees(int page = 1, int rows = 5)
        {
            var result = _employeeService.GetAllEmployees(page, rows, false);
            return Json(JsonConvert.SerializeObject(result));
        }
    }
}
