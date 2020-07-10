using System;
using AppDataAccess.Repositories;
using AppServices.Factory;
using AppServices.Interfaces;
using AppServices.Services;
using AppUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace MasGlobalTest.Tests.Controllers
{
    [TestClass]
    public class EmployeeServiceTest
    {
        [TestMethod]
        public void GetAllEmployees()
        {
            var repo = new EmployeeRepository();
            var fact = new EmployeeFactory();
            var util = new Utilities();
            EmployeeService es = new EmployeeService(repo, fact, util);
            var row = 1; var page = 0; var all = true;
            var re = es.GetAllEmployees(row, page, all);
            Assert.IsTrue(re.IsValid);
        }
    }
}
