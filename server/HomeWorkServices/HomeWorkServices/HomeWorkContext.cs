using HomeWorkServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices
{
    public class HomeWorkContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<ProjectTask>()
            .Property(b => b.Duration)
            .HasDefaultValue(0);

            modelBuilder.Entity<Project>().Ignore(p => p.SpentedHours);
            

            base.OnModelCreating(modelBuilder);

        }
        public HomeWorkContext(DbContextOptions options) : base(options)
        {
        }
    }
}
