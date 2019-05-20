using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkServices.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkServices.Repositories
{
    public class ProjectRepository : BaseRepository<Project, int>, IProjectRepository
    {
        public ProjectRepository(DbContext context)
           : base(context)
        {

        }
        public IProjectRepository Include(IEnumerable<string> navigationProperties)
        {

            foreach (var item in navigationProperties)
            {
               _queryableSet = _queryableSet.Include(item);
            }
            return this;
        }

        public IProjectRepository Include(string navigationProperty)
        {

            _queryableSet = _queryableSet.Include(navigationProperty);
            return this;
        }

    }
}
