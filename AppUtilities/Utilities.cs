using AppDataAccess.Models;
using AppDataAccess.Models.ViewModels.EmployeeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtilities
{
    public class Utilities : IUtilities
    {
        public dynamic MapObject(object fobj, object aobj)
        {
            var objType = fobj.GetType();
            switch (objType.BaseType.Name) {
                case "EmployeeViewModel":
                    return MapEmployee((EmployeeViewModel)fobj, (Employee)aobj);
                default:
                    return new object();
            }
        }
        private static EmployeeViewModel MapEmployee(EmployeeViewModel fobj, Employee aobj) 
        {
            fobj.Id = aobj.Id;
            fobj.IdNumber = aobj.IdNumber;
            fobj.Name = aobj.Name;
            fobj.Surename = aobj.Surename;
            fobj.Email = aobj.Email;
            fobj.Address = aobj.Address;
            fobj.Gender = aobj.Gender == 1 ? "Masculino" : "Femenino";
            fobj.BirthDate = aobj.BirthDate;
            fobj.ContactNumber = aobj.ContactNumber;
            fobj.ContractType = aobj.Contract1.Type;
            fobj.Salary = aobj.Contract1.Salary;
            fobj.AnualSalary = fobj.GetAnualSalary(aobj.Contract1.Salary);
            return fobj;
        }
    }    
}
