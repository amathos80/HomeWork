using HomeWorkServices.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Services.Interfaces
{
    public interface IProjectService
    {
        Task<int> AddProjectAsync(ProjectDTO project);
        Task<bool> UpdateProjectAsync(ProjectDTO project);
        Task<ProjectDTO> GetProjectByIdAsync(int id);
        Task<ICollection<ProjectDTO>> GetProjectsAsync();
        Task<bool> DeleteProjectAsync(ProjectDTO project);
    }
}
