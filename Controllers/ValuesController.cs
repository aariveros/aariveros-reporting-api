using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using aariveros_reporting_api.Models;

namespace aariveros_reporting_api.Controllers
{
    [Route("")]
    public class ValuesController : Controller
    {
        public ReportingContext context;

        public ValuesController(ReportingContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var enterprises = context.Enterprises.ToList();
            var projects = context.Projects.ToList();
            return new string[] { "Welcome to aariveros reporting api" };
        }
    }
}
