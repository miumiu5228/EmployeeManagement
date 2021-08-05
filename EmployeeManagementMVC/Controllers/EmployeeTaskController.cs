using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private readonly IEmployeeTaskService _employeeTaskService;
        private readonly IEmployeeService _employeeService;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, IEmployeeService employeeService)
        {
            _employeeTaskService = employeeTaskService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllTask(int id)
        {
            var tasks = await _employeeTaskService.GetAllTaskByEmpId(id);
            var emp = await _employeeService.GetEmployeeById(id);
            ViewBag.name = emp.FirstName;
            ViewBag.empId = id;

            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var task = await _employeeTaskService.GetEmployee(id);
            var emp = await _employeeService.GetEmployeeById(task.EmpId);
            ViewBag.name = emp.FirstName;
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskRequestModel taskRequestModel)
        {
            if (!ModelState.IsValid) return View();

            var addTask = await _employeeTaskService.AddTask(taskRequestModel);

            return LocalRedirect("~/EmployeeTask/ListAllTask/" + addTask.EmpId);
        }

        public async Task<IActionResult> Update(int id)
        {
            var task = await _employeeTaskService.GetTaskById(id);
            var emp = await _employeeService.GetEmployeeById(task.EmpId);
            ViewBag.firstname = emp.FirstName;

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskResponseModel taskResponseModel)
        {
            var x = taskResponseModel;
            if (!ModelState.IsValid) return View();

            var updateTask = await _employeeTaskService.UpdateTask(taskResponseModel);

            return LocalRedirect("~/EmployeeTask/ListAllTask/" + updateTask.EmpId); 
         
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deletrTask = await _employeeTaskService.DeleteTask(id);
            return LocalRedirect("~/EmployeeTask/ListAllTask/" + deletrTask.EmpId);
        }
    }
}
