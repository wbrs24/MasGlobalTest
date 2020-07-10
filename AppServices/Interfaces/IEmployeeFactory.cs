using AppDataAccess.Models;
using AppDataAccess.Models.ViewModels.EmployeeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Interfaces
{
    public interface IEmployeeFactory
    {
        EmployeeViewModel GetEmployeeObject(int contractType);
    }
}
