using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using aariveros_reporting_api.Models;

namespace aariveros_reporting_api.Controllers
{
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        public ProjectsController(IProjectsRepository Projects)
        {
            this.Projects = Projects;
        }
        public IProjectsRepository Projects { get; set; }

        [HttpGet]
        public IEnumerable<Project> GetAll()
        {
            return Projects.GetAll();
        }

        [HttpGet("{id}", Name = "projects")]
        public IActionResult GetById(int id)
        {
            var item = Projects.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Project item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Projects.Add(item);

            return CreatedAtRoute("projects", new { id = item.projectId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Project item)
        {
            if (item == null || item.projectId != id)
            {
                return BadRequest();
            }

            var project = Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            project.name = item.name;

            Projects.Update(project);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            Projects.Remove(id);
            return new NoContentResult();
        }
    }
}