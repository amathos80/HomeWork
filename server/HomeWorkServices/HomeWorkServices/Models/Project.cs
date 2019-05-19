using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Models
{
    public class Project : BaseEntity<int>
    {
        
        public Project()
        {
            ProjectTasks = new List<ProjectTask>();
        }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Priority { get; set; }
        public bool Completed { get; set; } = false;
        public ICollection<ProjectTask> ProjectTasks { get; set; }

    }
}
