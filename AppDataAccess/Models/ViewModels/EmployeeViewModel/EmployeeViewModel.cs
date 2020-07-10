using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataAccess.Models.ViewModels.EmployeeViewModel
{
    public abstract class EmployeeViewModel
    {
        public int Id { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string ContactNumber { get; set; }
        public string ContractType { get; set; }
        public double Salary { get; set;}
        public double AnualSalary { get; set; }
        public abstract double GetAnualSalary(int salary);
    }
}
