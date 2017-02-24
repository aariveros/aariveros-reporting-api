using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace aariveros_reporting_api.Models
{
    public class ReportingContext : DbContext
    {
        public ReportingContext(DbContextOptions<ReportingContext> options)
            : base(options)
        { }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
    

    public class Enterprise
    {
        public int enterpriseId { get; set; }
        public string name { get; set; }

        public ICollection<Project> projects { get; set; }
    }

    public class Project
    {
        public int projectId { get; set; }
        public string name { get; set; }

        public int enterpriseId { get; set; }
        public Enterprise enterprise { get; set; }
    }
}
