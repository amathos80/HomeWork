using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkServices.Models;
using HomeWorkServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET api/values

        [HttpGet("GetProjects")]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _projectRepository.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("GetProject/{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        // POST api/values
        [HttpPost("AddProject")]
        public async Task<ActionResult<int>> AddProject([FromBody] Project project)
        {
            try
            {
                await _projectRepository.AddAsync(project);
                await _projectRepository.SaveChangesAsync();
                return project.Id;
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
              
            }
        }

        // PUT api/values/5
        [HttpPost("UpdateProject")]
        public async Task<bool> UpdateProject([FromBody] Project project)
        {
            var originalProject = await _projectRepository.GetByIdAsync(project.Id);
            originalProject.Name = project.Name;
            originalProject.Priority = project.Priority;
            originalProject.Completed = project.Completed;
            originalProject.Description = project.Description;
            originalProject.EndDate = project.EndDate;
            originalProject.StartDate = project.StartDate;

            List<ProjectTask> toremove = new List<ProjectTask>();

            foreach (var task in originalProject.ProjectTasks)
            {
                toremove.Add(task);
            }

            foreach (var item in toremove)
            {
               originalProject.ProjectTasks.Remove(item);
            }

            foreach (var task in project.ProjectTasks)
            {
                originalProject.ProjectTasks.Add(task);
            }
            return await _projectRepository.SaveChangesAsync() > 0;

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
