using HomeWorkServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Repositories
{
    public interface IBaseRepository<T, Tkey> : IReadOnlyRepository<T, Tkey> where T : BaseEntity<Tkey>
    {
        Task AddAsync(T project);
        Task UpdateAsync(T project);
        Task DeleteAsync(T entity);
        Task DeleteAsync(Tkey id);
       
    }
}
