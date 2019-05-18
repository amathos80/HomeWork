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
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

            foreach (var task in originalProject.ProjectTasks)
            {
                originalProject.ProjectTasks.Remove(task);
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
