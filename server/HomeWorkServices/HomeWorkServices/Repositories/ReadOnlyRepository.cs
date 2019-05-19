using HomeWorkServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeWorkServices.Repositories
{
    public class ReadOnlyRepository<T, Tkey> : IReadOnlyRepository<T, Tkey> where T : BaseEntity<Tkey>
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        protected IQueryable<T> _queryableSet { get;  set; }


        public ReadOnlyRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
            _queryableSet = _dbSet.AsQueryable();
        }

       


        public IQueryable<T> GetAll()
        {

            return _dbSet;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            
            return await _queryableSet.ToListAsync();
        }

        public Task<T> GetByIdAsync(Tkey id)
        {

            return  _dbSet.FindAsync(id);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return _queryableSet.Where(predicate);
            else
                return _queryableSet;


        }
    }
}
