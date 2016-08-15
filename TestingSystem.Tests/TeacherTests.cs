using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingSystem.Web.Controllers;
using System.Web.Mvc;
using TestingSystem.Entities;
using TestingSystem.Services.TeacherServices;
using System.Collections.Generic;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace TestingSystem.Tests
{
    [TestClass]
    public class TeacherTests
    {

        private Questions target;
        private Mock<IUnitOfWork> uow;
        private Mock<IRepository<Question>> questions;

        [TestInitialize]
        public void Setup()
        {
            uow = new Mock<IUnitOfWork>();
            target = new Questions();
            questions = new Mock<IRepository<Question>>();
            uow.Setup(x => x.QuestionRep).Returns(questions.Object);
        }

        [TestMethod]
        public void GetQuestions()
        {
            // Arrange

            List<Question> questionsList = new List<Question>();
            List<QuestionsDTO> expexted = new List<QuestionsDTO>();
            for (int i = 0; i < 5; ++i)
            {
                var std = new Question() { Id = i};
                questionsList.Add(std);
                expexted.Add(new QuestionsDTO { ID = i });
            }

            questions.Setup(a => a.Query()).Returns(questionsList.AsQueryable());

            // Act
            var actual = target.GetQuestion();

            // Assert
           // uow.Verify(u => u.QuestionRep, Times.Once);
            questions.Verify(a => a.Query(), Times.Once);
        }


    }
}
