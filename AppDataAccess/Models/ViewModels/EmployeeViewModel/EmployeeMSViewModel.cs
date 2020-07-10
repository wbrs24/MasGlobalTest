using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataAccess.Models.ViewModels.EmployeeViewModel
{
    public class EmployeeMSViewModel : EmployeeViewModel
    {
        public override double GetAnualSalary(int salary)
        {
            return salary * 12;
        }
    }
}
