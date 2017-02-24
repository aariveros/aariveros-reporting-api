using System;
using System.Collections.Generic;

namespace aariveros_reporting_api.Models
{
    public interface IProjectsRepository
    {
        IEnumerable<Project> GetAll();
        Project Find(int id);
        void Add(Project item);
        void Remove(int id);
        void Update(Project item);
    }
}