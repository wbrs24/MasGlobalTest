using AppDataAccess.Models;
using AppDataAccess.Models.ViewModels.EmployeeViewModel;
using AppServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeViewModel GetEmployeeObject(int contractType) {

            switch (contractType)
            {
                case 1:
                    return new EmployeeMSViewModel();
                case 2:
                    return new EmployeeHSViewModel();
                default:
                    goto case 1;
            }
        }
    }
}
