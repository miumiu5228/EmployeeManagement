using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.ResponseModel
{
    public class TaskResponseModel
    {
        public int EmpId { get; set; }
        public int TaskId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public List<EmployeeResponseModel> Employees { get; set; }

    }
}
