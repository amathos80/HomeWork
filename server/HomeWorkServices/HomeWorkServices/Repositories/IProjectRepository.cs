using HomeWorkServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project, int>
    {
        IProjectRepository Include(IEnumerable<string> navigationProperties);
        IProjectRepository  Include(string navigationProperty);
    }
}
