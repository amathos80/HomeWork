using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Models
{
    public class Project
    {
        
        public Project()
        {
            ProjectTasks = new List<ProjectTask>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Priority { get; set; }
        public bool Completed { get; set; } = false;

        [NotMapped]
        public double SpentedHours{ get => CalculateSpentedHours(); }

        public ICollection<ProjectTask> ProjectTasks { get; set; }

        private Double CalculateSpentedHours()
        {
            if (ProjectTasks.Count > 0)
                return ProjectTasks.Sum(c => c.Duration);
            else
                return 0;
        }

    }
}
