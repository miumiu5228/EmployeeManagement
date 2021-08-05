using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        private readonly IEmployeeTaskRepository _employeeTaskRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeTaskService(IEmployeeTaskRepository employeeTaskRepository, IEmployeeRepository employeeRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<TaskResponseModel> AddTask(TaskRequestModel taskRequestModel)
        {
            var task = new EmployeeTask
            {
                EmpId = taskRequestModel.EmpId,
                TaskId = taskRequestModel.TaskId,
                TaskName = taskRequestModel.TaskName,
                StartTime = taskRequestModel.StartTime,
                Deadline = taskRequestModel.Deadline

            };

            var add = await _employeeTaskRepository.AddAsync(task);

            var addTask = new TaskResponseModel
            {
                EmpId = taskRequestModel.EmpId,
                TaskId = taskRequestModel.TaskId,
                TaskName = taskRequestModel.TaskName,
                StartTime = taskRequestModel.StartTime,
                Deadline = taskRequestModel.Deadline

            };

            return addTask;
        }

        public async Task<TaskResponseModel> DeleteTask(int id)
        {
            var task = await _employeeTaskRepository.GetByIdAsync(id);

            var delete = await _employeeTaskRepository.DeleteAsync(task);

            var deleteTask = new TaskResponseModel
            {
                EmpId = delete.EmpId,
                TaskId = delete.TaskId,
                TaskName = delete.TaskName,
                StartTime = delete.StartTime,

            };

            return deleteTask;
        }

        public async Task<List<TaskResponseModel>> GetAllTaskByEmpId(int id)
        {
            var tasks = await _employeeTaskRepository.GetTaskbyEmployee(id);

            var list = new List<TaskResponseModel>();

            foreach (var task in tasks)
            {
                if(task.EmpId == id)
                {
                 
                    list.Add(
                        new TaskResponseModel
                        {
                            EmpId = task.EmpId,
                            TaskId = task.TaskId,
                        
                            TaskName = task.TaskName,
                            StartTime = task.StartTime,
                            Deadline = task.Deadline

                        }
                    );

                }
            }

            return list;
        }

        public async Task<TaskResponseModel> GeAllEmp()
        {
          
            var employees = await _employeeRepository.ListAllAsync();

            var taskResponse = new TaskResponseModel
            {
                Employees = new List<EmployeeResponseModel>()

            };

            foreach (var e in employees)
            {
                taskResponse.Employees.Add(
                    new EmployeeResponseModel
                    {
                        EmpId = e.EmpId,
                        FirstName = e.FirstName

                    });
            }

            return taskResponse;

        }

        public async Task<TaskResponseModel> GetTaskById(int id)
        {
            var task = await _employeeTaskRepository.GetByIdAsync(id);

            var taskResponse = new TaskResponseModel
            {
                EmpId = task.EmpId,
                TaskId = task.TaskId,
           
                TaskName = task.TaskName,
                StartTime = task.StartTime,
                Deadline = task.Deadline

            };

            return taskResponse;

        }

        public async Task<TaskResponseModel> UpdateTask(TaskResponseModel model)
        {

            var dbtask = await _employeeTaskRepository.GetByIdAsync(model.TaskId);

           
            dbtask.EmpId = model.EmpId;
            dbtask.TaskId = model.TaskId;
            dbtask.TaskName = model.TaskName;
            dbtask.StartTime = model.StartTime;
            dbtask.Deadline = model.Deadline;


            var updatedeTask = await _employeeTaskRepository.UpdateAsync(dbtask);

            var taskResponseModel = new TaskResponseModel
            {
                EmpId = updatedeTask.EmpId,
                TaskId = updatedeTask.TaskId,
                TaskName = updatedeTask.TaskName,
                StartTime = updatedeTask.StartTime,
                Deadline = updatedeTask.Deadline
        };
            return taskResponseModel;
        }

        public async Task<TaskResponseModel> GetEmployee(int id)
        {
            var emp = await _employeeRepository.GetByIdAsync(id);

            var taskResponseModel = new TaskResponseModel
            {
                EmpId = emp.EmpId,
                EmpFirstName = emp.FirstName
              
            };

            return taskResponseModel;

        }
    }
}
