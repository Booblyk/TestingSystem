using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingSystem.Web.Controllers;
using System.Web.Mvc;
using TestingSystem.Web.App_Start;
using TestingSystem.Entities;
using Microsoft.Practices.Unity;
using TestingSystem.Services.Interfaces;
using Moq;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations.Repositories;

namespace TestingSystem.Tests
{
    [TestClass]
    public class StudentTests
    {

       
        [TestMethod]
        public void STestMethod1()
        {
            //Mock<ITestPassingService> testPassingServiceMock = new Mock<ITestPassingService>();
            //testPassingServiceMock.Setup(x => x.GetAllTests()).Returns(new List<Test>() { new })
            //UnityWebapiConfig.Сontainer.RegisterInstance<ITestPassingService>(testPassingServiceMock.Object);
            //var studController = new StudentController();
            //var listOfTestView= studController.ListOfTests(1) as ViewResult;
            //Assert.AreEqual("ListOfTests", listOfTestView.ViewName);

            var studController = new StudentController();

            var listOfTestView = studController.ListOfTests(1) as ViewResult;

            Assert.AreEqual("ListOfTests", listOfTestView.ViewName);

        }

        [TestMethod]
        public void STestMethod2()
        {
            var studController = new StudentController();
            var result = (RedirectToRouteResult)studController.ListOfTests(0);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }
        [TestMethod]
        public void STestMethod3()
        {
            var studController = new StudentController();
            var result = studController.Index(4, 1, new System.Collections.Generic.List<AnswersArray>() { new AnswersArray() { Answers = "No" }, new AnswersArray() { Answers = "No" }, new AnswersArray() { Answers = "Yes" } }) as ViewResult;
            Mark mark = (Mark)result.ViewData.Model;
            Assert.AreEqual(3, mark.Value);
        }
    }
}
