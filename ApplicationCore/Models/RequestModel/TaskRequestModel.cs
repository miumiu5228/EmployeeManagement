using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.RequestModel
{
    public class TaskRequestModel
    {
        public int EmpId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Employee { get; set; }
    }
}
