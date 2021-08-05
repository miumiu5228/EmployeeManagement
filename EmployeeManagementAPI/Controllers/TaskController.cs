using ApplicationCore.Exceptions;
using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IEmployeeTaskService _employeeTaskService;
        private readonly IEmployeeService _employeeService;

        public TaskController(IEmployeeTaskService employeeTaskService, IEmployeeService employeeService)
        {
            _employeeTaskService = employeeTaskService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllTask(int id)
        {
            var tasks = await _employeeTaskService.GetAllTaskByEmpId(id);
            if (!tasks.Any())
            {
                throw new NotFoundException("No task found");
            }
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskRequestModel taskRequestModel)
        {
           
            var addTask = await _employeeTaskService.AddTask(taskRequestModel);
            if (addTask == null)
            {
                throw new NotFoundException("No task found");
            }
            return Ok(addTask);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskResponseModel taskResponseModel)
        {

            var updateTask = await _employeeTaskService.UpdateTask(taskResponseModel);
            if (updateTask == null)
            {
                throw new NotFoundException("No task found");
            }

            return Ok(updateTask);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletrTask = await _employeeTaskService.DeleteTask(id);
            if (deletrTask == null)
            {
                throw new NotFoundException("No task found");
            }
            return Ok(deletrTask);
        }

    }
}
