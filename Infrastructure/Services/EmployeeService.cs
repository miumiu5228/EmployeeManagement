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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel employeeRequestModel)
        {

            var employee = new Employee
            {
                EmpId = employeeRequestModel.EmpId,
                FirstName = employeeRequestModel.FirstName,
                LastName = employeeRequestModel.LastName,
                HiredDate = employeeRequestModel.HiredDate
                
            };

            var add = await _employeeRepository.AddAsync(employee);

            var addEmployee = new EmployeeResponseModel
            {
                EmpId = add.EmpId,
                FirstName = add.FirstName,
                LastName = add.LastName,
                HiredDate = add.HiredDate

            };

            return addEmployee;



        }

        public async Task<EmployeeResponseModel> DeleteEmpoyee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
    
            var delete = await _employeeRepository.DeleteAsync(employee);

            var addEmployee = new EmployeeResponseModel
            {
                EmpId = delete.EmpId,
                FirstName = delete.FirstName,
                LastName = delete.LastName,

            };

            return addEmployee;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            var employeeResponseModel = new EmployeeResponseModel
            {
                EmpId = employee.EmpId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HiredDate = employee.HiredDate
            };
            return employeeResponseModel;

        }

        public async Task<List<EmployeeResponseModel>> ListAllEmployee()
        {
            var employees = await _employeeRepository.ListAllAsync();
            var list = new List<EmployeeResponseModel>();
            foreach (var emp in employees)
            {
                list.Add(new EmployeeResponseModel
                {
                    EmpId = emp.EmpId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    HiredDate = emp.HiredDate,
                });
            }
            return list;
        }

        public async Task<EmployeeResponseModel> UpdateEmployee(EmployeeRequestModel employeeRequestModel)
        {
            var dbemployee = await _employeeRepository.GetByIdAsync(employeeRequestModel.EmpId);



            dbemployee.EmpId = employeeRequestModel.EmpId;
            dbemployee.FirstName = employeeRequestModel.FirstName;
            dbemployee.LastName = employeeRequestModel.LastName;
            dbemployee.HiredDate = employeeRequestModel.HiredDate;
           

            var updatedemployee = await _employeeRepository.UpdateAsync(dbemployee);

            var employeeResponseModel = new EmployeeResponseModel
            {
                EmpId = updatedemployee.EmpId,
                FirstName = updatedemployee.FirstName,
                LastName = updatedemployee.LastName,
                HiredDate = updatedemployee.HiredDate
            };
            return employeeResponseModel;
        }
    }
}
