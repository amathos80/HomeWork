using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Services.DTO
{
    public class ProjectTaskDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public double Duration { get; set; } = 0;
        public bool IsBillable { get; set; } = true;
    }
}
