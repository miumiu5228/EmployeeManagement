using ApplicationCore.Models.RequestModel;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeRequestModel employeeRequestModel)
        {
            if (!ModelState.IsValid) return View();

            var addEmployee = await _employeeService.AddEmployee(employeeRequestModel);

            return LocalRedirect("~/");
        }

        public async Task<IActionResult> Update(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeRequestModel employeeRequestModel)
        {
            if (!ModelState.IsValid) return View();

            var addEmployee = await _employeeService.UpdateEmployee(employeeRequestModel);

            return LocalRedirect("~/");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmpoyee(id);
            return LocalRedirect("~/");
        }

    }
}
