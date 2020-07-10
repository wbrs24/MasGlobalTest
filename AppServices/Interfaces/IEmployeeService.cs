using AppDataAccess.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Interfaces
{
    public interface IEmployeeService
    {
        ServiceResult GetAllEmployees(int page, int rows, bool all);
        ServiceResult GetEmployeeByIdNumber(int idNumber);
    }
}
