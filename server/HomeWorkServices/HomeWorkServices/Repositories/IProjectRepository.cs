using HomeWorkServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Repositories
{
    public interface IProjectRepository
    {
        Task<int> AddAsync(Project project);
        Task<bool> UpdateAsync(Project project);
        Task<Project> GetByIdAsync(int id);
        Task<List<Project>> GetAllAsync();
        Task<int> SaveChangesAsync();
    }
}
