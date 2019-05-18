using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkServices.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkServices.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private DbSet<Project> _dbSet;
        public ProjectRepository(DbContext context)
        {
            _dbSet = context.Set<Project>();
        }
            public async Task<int> AddAsync(Project project)
        {
            await _dbSet.AddAsync(project);
            return project.Id;
        }

        public Task<List<Project>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return  await _dbSet.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateAsync(Project project)
        {
            return await Task.FromResult<bool>(_dbSet.Update(project)!=null);
        }
    }
}
