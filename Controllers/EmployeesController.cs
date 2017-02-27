using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using aariveros_reporting_api.Models;

namespace aariveros_reporting_api.Controllers
{
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        public EmployeesController(IEmployeesRepository Employees)
        {
            this.Employees = Employees;
        }
        public IEmployeesRepository Employees { get; set; }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return Employees.GetAll();
        }

        [HttpGet("{id}", Name = "employees")]
        public IActionResult GetById(int id)
        {
            var item = Employees.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Employees.Add(item);

            return CreatedAtRoute("employees", new { id = item.employeeId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee item    )
        {
            if (item == null || item.employeeId != id)
            {
                return BadRequest();
            }

            var employee = Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.firstName = item.firstName;
            employee.surName = item.surName;
            employee.cellPhone = item.cellPhone;
            employee.mail = item.mail;

            Employees.Update(employee);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Employee = Employees.Find(id);
            if (Employee == null)
            {
                return NotFound();
            }

            Employees.Remove(id);
            return new NoContentResult();
        }
    }
}