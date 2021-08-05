using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseModel>> ListAllEmployee();
        Task<EmployeeResponseModel> GetEmployeeById(int id);
        Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel employeeRequestModel);
        Task<EmployeeResponseModel> UpdateEmployee(EmployeeRequestModel employeeRequestModel);
        Task<EmployeeResponseModel> DeleteEmpoyee(int id);
    }
}
