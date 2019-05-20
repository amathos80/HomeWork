using HomeWorkServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
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
             

            base.OnModelCreating(modelBuilder);

        }
        public HomeWorkContext(DbContextOptions options) : base(options)
        {
        }
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    try
        //    {


        //        var entities = from e in ChangeTracker.Entries()
        //                       where e.State == EntityState.Added
        //                           || e.State == EntityState.Modified
        //                       select e.Entity;
        //        foreach (var entity in entities)
        //        {
        //            var validationContext = new ValidationContext(entity);
        //            Validator.ValidateObject(
        //                entity,
        //                validationContext,
        //                validateAllProperties: true);
        //        }

        //        return base.SaveChangesAsync(cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        return base.SaveChangesAsync(cancellationToken);
        //    }

           
        //}
        //public override int SaveChanges()
        //{
        //    try
        //    {


        //        var entities = from e in ChangeTracker.Entries()
        //                       where e.State == EntityState.Added
        //                           || e.State == EntityState.Modified
        //                       select e.Entity;
        //        foreach (var entity in entities)
        //        {
        //            var validationContext = new ValidationContext(entity);
        //            Validator.ValidateObject(
        //                entity,
        //                validationContext,
        //                validateAllProperties: true);
        //        }

        //        return base.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }

        //}
    }
}
