using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public double Duration { get; set; } = 0;
        public bool IsBillable { get; set; } = true;
    }
}
