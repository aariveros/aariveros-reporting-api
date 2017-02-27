using System.Collections.Generic;

namespace aariveros_reporting_api.Models
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Find(int id);
        void Add(Employee item);
        void Remove(int id);
        void Update(Employee item);
    }
}