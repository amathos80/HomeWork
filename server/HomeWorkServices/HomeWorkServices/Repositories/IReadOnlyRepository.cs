using HomeWorkServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeWorkServices.Repositories
{

    public interface IReadOnlyRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
       
        IQueryable<T> Where(Expression<Func<T, bool>> predicate = null);

    }
}
