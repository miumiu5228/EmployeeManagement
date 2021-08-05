using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeTaskRepository : EfRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(EmployeeManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<EmployeeTask>> GetTaskbyEmployee(int Id)
        {
            var task = await _dbContext.EmployeeTasks.Include(t => t.Employee).Where(t => t.EmpId == Id).ToListAsync();
            return task;
        }
    }
}

