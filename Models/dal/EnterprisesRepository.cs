using System.Collections.Generic;
using System.Linq;

namespace aariveros_reporting_api.Models
{
    public class EnterprisesRepository : IEnterprisesRepository
    {
        private ReportingContext context;

        public EnterprisesRepository(ReportingContext context)
        {
            this.context = context;
        }

        public IEnumerable<Enterprise> GetAll()
        {
            return context.Enterprises.ToList();
        }

        public Enterprise Find(int id)
        {
            return context.Enterprises
                .FirstOrDefault(t => t.enterpriseId == id);
        }

        public void Add(Enterprise item)
        {
            context.Enterprises.Add(item);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            Enterprise Enterprise = context.Enterprises
                .FirstOrDefault(t => t.enterpriseId == id);
            context.Enterprises.Remove(Enterprise);
            context.SaveChanges();
        }

        public void Update(Enterprise item)
        {
            context.Enterprises.Update(item);
            context.SaveChanges();
        }
    }
}