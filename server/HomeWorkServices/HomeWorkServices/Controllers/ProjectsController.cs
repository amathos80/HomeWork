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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
