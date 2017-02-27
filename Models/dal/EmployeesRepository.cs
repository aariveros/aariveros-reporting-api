using System.Collections.Generic;
using System.Linq;

namespace aariveros_reporting_api.Models
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private ReportingContext context;

        public EmployeesRepository(ReportingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee Find(int id)
        {
            return context.Employees
                .FirstOrDefault(t => t.employeeId == id);
        }

        public void Add(Employee item)
        {
            context.Employees.Add(item);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Employee Employee = context.Employees
                .FirstOrDefault(t => t.employeeId == id);
            context.Employees.Remove(Employee);
            context.SaveChanges();
        }

        public void Update(Employee item)
        {
            context.Employees.Update(item);
            context.SaveChanges();
        }
    }
}