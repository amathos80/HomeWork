using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Services.DTO
{
    public class ProjectDTO
    {
        public ProjectDTO()
        {
            ProjectTasks = new List<ProjectTaskDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Priority { get; set; }
        public bool Completed { get; set; } = false;
        public ICollection<ProjectTaskDTO> ProjectTasks { get; set; }
        public double SpentHours { get => CalculateSpentHours(); }
        private Double CalculateSpentHours()
        {
            if (ProjectTasks.Count > 0)
                return ProjectTasks.Where(c => c.IsBillable == true).Sum(c => c.Duration);
            else
                return 0;
        }
    }
}
