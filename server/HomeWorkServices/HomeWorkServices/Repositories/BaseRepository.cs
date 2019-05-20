using HomeWorkServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Repositories
{
    public class BaseRepository<T, Tkey> : ReadOnlyRepository<T, Tkey>, IBaseRepository<T, Tkey> where T : BaseEntity<Tkey>
    {
        public BaseRepository(DbContext context) : base(context)
        {
        }

        public async Task AddAsync(T project)
        {
            await _dbSet.AddAsync(project);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

       

        public async Task UpdateAsync(T project)
        {
            await Task.FromResult( _dbSet.Update(project));
        }
    }
}

