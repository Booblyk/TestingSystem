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
    public class Questions : IQuestions
    {
        private readonly IUnitOfWork uow = new UnitOfWork(new DbProvide());

        //public Questions(IUnitOfWork uow)
        //{
        //    this.uow = uow;
        //}

        public List<QuestionsDTO> GetQuestion()
        {
            return (from question in uow.QuestionRep.Query() 
                     select new QuestionsDTO()
                     {
                         ID = question.Id,
                         TestID = question.TestId,
                         Value = question.Answer,
                         Question = question.Questionn
                         
                     }).ToList();
        }

        public List<QuestionsDTO> GetQuestionByCourse(int id)
        {
            return (from question in uow.QuestionRep.Query().Where(x=>x.TestId==id)
                    select new QuestionsDTO()
                    {
                        ID = question.Id,
                        TestID = question.TestId,
                        Value = question.Answer,
                        Question = question.Questionn
                    }).ToList();
        }

        public void CreateQuestion(QuestionsDTO dto)
        {
            var quest = new Question()
            {
                Id = dto.ID,
                TestId = dto.TestID,
                Answer = dto.Value,
                Questionn = dto.Question

            };

            uow.QuestionRep.Insert(quest);
            uow.Save();
        }

        public void DeleteQuestion(int id)
        {
            var student = uow.QuestionRep.GetById(id);
            uow.QuestionRep.Delete(student);
            uow.Save();
        }
    }
}
