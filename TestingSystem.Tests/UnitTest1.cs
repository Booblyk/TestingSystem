using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingSystem.Web.Controllers;
using System.Web.Mvc;

namespace TestingSystem.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var studController = new StudentController();
            var listOfTestView= studController.ListOfTests(1) as ViewResult;
            Assert.AreEqual("ListOfTests", listOfTestView.ViewName);

        }

        [TestMethod]
        public void TestMethod2()
        {
            var studController = new StudentController();
            var result = (RedirectToRouteResult)studController.ListOfTests(0);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }
        [TestMethod]
        public void TestMethod3()
        {
            var studController = new StudentController();
            var result = studController.ListOfTests(2) as ViewResult;
            Assert.AreEqual("ListOfTests", result.ViewName);

        }
    }
}
