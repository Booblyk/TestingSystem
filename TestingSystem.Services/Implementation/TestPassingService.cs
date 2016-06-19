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
    public class TestPassingService : Interfaces.ITestPassingService
    {
        public List<Test> GetAllTests()
        {
            var _testRepositiry = new Repository<Test>(new DbProvide());
            return _testRepositiry.All.ToList();
        }

        public Test GetTestById(int id)
        {
            var _testRepository = new Repository<Test>(new DbProvide());

            var test = _testRepository.GetSingle(id);
            Interfaces.IQuestionService questionService = new QuestionService();
            var questions = questionService.GetAll();
            var qqq =
            from q in questions
            where q.TestId == id
            select q;
            test.Questions = qqq.ToList();
            return test;
        }
    }
}
