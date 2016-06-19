using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Extension;
using TestingSystem.DataBaseConfigurations.Migrations;
using TestingSystem.Entities;

namespace TestingSystem.Services.TeacherServices
{
    public class Tests
    {
        private readonly IUnitOfWork uow = new UnitOfWork(new DbProvide());

        public List<TestsDTO> GetTest()
        {
            return (from test in uow.TestRep.Query() 
                     select new TestsDTO()
                     {
                         Id = test.Id,
                         Description = test.Description,
                         Duration = test.Duration
                     }).ToList();
        }

        public void CreateTest(TestsDTO dto)
        {
            var quest = new Test()
            {
                Id = dto.Id,
                Description = dto.Description,
                Duration = dto.Duration
            };

            uow.TestRep.Insert(quest);
            uow.Save();
        }

        public void DeleteTest(int id)
        {
            Questions q = new Questions();
            List<QuestionsDTO>questionsToDelete = new List<QuestionsDTO>() ;
            questionsToDelete =  q.GetQuestionByCourse(id);
            foreach(QuestionsDTO item in questionsToDelete)
            {
                q.DeleteQuestion(item.ID);
            }
            var student = uow.TestRep.GetById(id);
            uow.TestRep.Delete(student);
            uow.Save();
        }
    
    }
}
