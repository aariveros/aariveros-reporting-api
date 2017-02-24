using System.Collections.Generic;
using System.Linq;

namespace aariveros_reporting_api.Models
{
    public class ProjectsRepository : IProjectsRepository
    {
        private ReportingContext context;

        public ProjectsRepository(ReportingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Projects.ToList();
        }

        public Project Find(int id)
        {
            return context.Projects
                .FirstOrDefault(t => t.projectId == id);
        }

        public void Add(Project item)
        {
            context.Projects.Add(item);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Project Project = context.Projects
                .FirstOrDefault(t => t.projectId == id);
            context.Projects.Remove(Project);
            context.SaveChanges();
        }

        public void Update(Project item)
        {
            context.Projects.Update(item);
            context.SaveChanges();
        }
    }
}