using ApplicationCore.Exceptions;
using ApplicationCore.Models.RequestModel;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                throw new NotFoundException("No employee found");
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequestModel model)
        {
            var employee = await _employeeService.AddEmployee(model);
            return Ok(employee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequestModel model)
        {
            var employee = await _employeeService.UpdateEmployee(model);

            return Ok(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            var delete = await _employeeService.DeleteEmpoyee(id);
            if (delete == null)
            {
                throw new NotFoundException("No employee found");
            }
            return Ok(delete);
        }
    }
}
