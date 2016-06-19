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
            var listOfTestView = studController.ListOfTests(1);
            Assert.AreEqual("ListOfTests", listOfTestView);

        }
    }
}
