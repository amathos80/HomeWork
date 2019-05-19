using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkServices.Models;
using HomeWorkServices.Repositories;
using HomeWorkServices.Services.DTO;
using HomeWorkServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProjectRepository _projectRepository;
        IProjectService _projectService;
        public ProjectsController(IProjectRepository projectRepository, IProjectService projectService)
        {
            _projectRepository = projectRepository;
            _projectService = projectService;
        }

        // GET api/values

        [HttpGet("GetProjects")]
        [HttpGet("")]
        public async Task<ActionResult<ICollection<ProjectDTO>>> GetProjects()
        {
            try
            {
                return Ok(await _projectService.GetProjectsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);

            }
        }

        // GET api/values/5
        [HttpGet("GetProject/{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            try
            {
                return Ok(await _projectService.GetProjectByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);

            }
        }

        // POST api/values
        [HttpPost("AddProject")]
        public async Task<ActionResult<int>> AddProject([FromBody] ProjectDTO project)
        {
            try
            {
                return Ok(await _projectService.AddProjectAsync(project));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);

            }
        }

        // PUT api/values/5
        [HttpPost("UpdateProject")]
        public async Task<ActionResult<bool>> UpdateProject([FromBody] ProjectDTO project)
        {
            try
            {
                return Ok(await _projectService.UpdateProjectAsync(project));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.GetBaseException().Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
