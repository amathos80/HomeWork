using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeWorkServices.Models;
using HomeWorkServices.Repositories;
using HomeWorkServices.Services.DTO;
using HomeWorkServices.Services.Interfaces;

namespace HomeWorkServices.Services
{
    public class ProjectService : IProjectService
    {
        IProjectRepository _projectRepository;
        IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public ProjectService(IMapper mapper,IProjectRepository projectRepository, IUnitOfWork unitOfWork) 
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public async Task<int> AddProjectAsync(ProjectDTO dto)
        {
            Project project = _mapper.Map<ProjectDTO, Project>(dto);
           await _projectRepository.AddAsync(project);
            _unitOfWork.Commit();
            return project.Id;
        }

        public async Task<bool> DeleteProjectAsync(ProjectDTO project)
        {
            await _projectRepository.DeleteAsync(project.Id);
            return await _unitOfWork.CommitAsync() != 0;
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            Project project = await _projectRepository.GetByIdAsync(id);
            return _mapper.Map<Project,ProjectDTO>(project);
        }

        public async Task<ICollection<ProjectDTO>> GetProjectsAsync()
        {
            var projects= await _projectRepository.Include("ProjectTasks").GetAllAsync();
            return  _mapper.Map<ICollection<Project>,ICollection<ProjectDTO>>(projects);
        }

        public async Task<bool> UpdateProjectAsync(ProjectDTO project)
        {
            var oldProject = await _projectRepository.GetByIdAsync(project.Id);
            var newTask = _mapper.Map<ICollection<ProjectTaskDTO>, ICollection< ProjectTask> >(project.ProjectTasks);
            _mapper.Map<ProjectDTO, Project>(project, oldProject);

            List<ProjectTask> toremove = new List<ProjectTask>();

            foreach (var task in oldProject.ProjectTasks)
            {
                toremove.Add(task);
            }

            foreach (var item in toremove)
            {
                oldProject.ProjectTasks.Remove(item);
            }

            foreach (var task in newTask)
            {
                oldProject.ProjectTasks.Add(task);
            }

           

            return await _unitOfWork.CommitAsync()!=0;
        }
    }
}
