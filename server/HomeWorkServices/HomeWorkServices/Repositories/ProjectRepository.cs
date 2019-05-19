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
        private DbContext _context;
        private DbSet<Project> _dbSet;
        public ProjectRepository(DbContext context)
        {
            _dbSet = context.Set<Project>();
            _context = context;
        }
            public async Task AddAsync(Project project)
        {
            try
            {
                await _dbSet.AddAsync(project);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<List<Project>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return  await _dbSet.Include(c=>c.ProjectTasks).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await  _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Project project)
        {
            return await Task.FromResult<bool>(_dbSet.Update(project)!=null);
        }
    }
}
