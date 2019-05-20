using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Models
{
    public class ProjectTask:BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public double Duration { get; set; } = 0;
        public bool IsBillable { get; set; } = true;

    }
}
