using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Infrastructure;

namespace TestingSystem.Services.Implementation
{
    public class QuestionService : Interfaces.IQuestionService
    {
        public ICollection<Question> GetAll()
        {
            var _questionRepos = new Repository<Question>(new DbProvide());
            return _questionRepos.GetAll().ToList();

        }
    }
}
