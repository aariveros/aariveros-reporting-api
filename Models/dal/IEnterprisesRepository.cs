using System;
using System.Collections.Generic;

namespace aariveros_reporting_api.Models
{
    public interface IEnterprisesRepository
    {
        IEnumerable<Enterprise> GetAll();
        Enterprise Find(int id);
        void Add(Enterprise item);
        void Remove(int id);
        void Update(Enterprise item);
    }
}