using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeeTaskService
    {
        Task<List<TaskResponseModel>> GetAllTaskByEmpId(int id);
        Task<TaskResponseModel> GetTaskById(int id);
        Task<TaskResponseModel> GeAllEmp();
        Task<TaskResponseModel> GetEmployee(int id);
        Task<TaskResponseModel> AddTask(TaskRequestModel taskRequestModel);
        Task<TaskResponseModel> UpdateTask(TaskResponseModel taskResponseModel);
        Task<TaskResponseModel> DeleteTask(int id);
        
    }
}
