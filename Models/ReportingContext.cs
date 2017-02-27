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
        public DbSet<Employee> Employees { get; set; }
    }
    

    public class Enterprise
    {
        public int enterpriseId { get; set; }
        public string name { get; set; }

        public int? managerId { get; set; }

        public string officePhone { get; set; }
        public string cellPhone { get; set; }
        public string mail { get; set; }

        public ICollection<Project> projects { get; set; }

        public ICollection<Employee> employees { get; set; }
    }

    public class Project
    {
        public int projectId { get; set; }
        public string name { get; set; }

        public int? managerId { get; set; }

        public string officePhone { get; set; }
        public string cellPhone { get; set; }
        public string mail { get; set; }

        public int enterpriseId { get; set; }
        public Enterprise enterprise { get; set; }
    }

    public class Employee
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }

        public string surName { get; set; }

        public string cellPhone { get; set; }
        public string mail { get; set; }

        public int enterpriseId { get; set; }
        public Enterprise enterprise { get; set; }

    }
}
