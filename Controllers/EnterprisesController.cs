using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using aariveros_reporting_api.Models;

namespace aariveros_reporting_api.Controllers
{
    [Route("[controller]")]
    public class EnterprisesController : Controller
    {
        public EnterprisesController(IEnterprisesRepository Enterprises)
        {
            this.Enterprises = Enterprises;
        }
        public IEnterprisesRepository Enterprises { get; set; }

        [HttpGet]
        public IEnumerable<Enterprise> GetAll()
        {
            return Enterprises.GetAll();
        }

        [HttpGet("{id}", Name = "enterprises")]
        public IActionResult GetById(int id)
        {
            var item = Enterprises.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Enterprise item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Enterprises.Add(item);

            return CreatedAtRoute("enterprises", new { id = item.enterpriseId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Enterprise item)
        {
            if (item == null || item.enterpriseId != id)
            {
                return BadRequest();
            }

            var enterprise = Enterprises.Find(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            enterprise.name = item.name;
            enterprise.managerId = item.managerId;
            enterprise.officePhone = item.officePhone;
            enterprise.cellPhone = item.cellPhone;
            enterprise.mail = item.mail;

            Enterprises.Update(enterprise);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enterprise = Enterprises.Find(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            Enterprises.Remove(id);
            return new NoContentResult();
        }
    }
}