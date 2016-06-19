using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations.Repositories;

namespace TestingSystem.Services.Implementation
{
    public class MarkService : Interfaces.IMarkService
    {
        public Mark Create(User student, Test test, int Value)
        {
            Mark result = new Mark() { StudentId = student.Id, TestId = test.Id, Value = Value };
            IRepository<Mark> markRepos = new Repository<Mark>(new DbProvide());
            markRepos.Add(result);
            return result;
        }
    }
}
