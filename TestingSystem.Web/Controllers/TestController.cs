using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSystem.DataBaseConfigurations;
using TestingSystem.Entities;
using TestingSystem.Services.Implementation;
using TestingSystem.Services.Interfaces;
using TestingSystem.Web.App_Start;
using Microsoft.Practices.Unity;

namespace TestingSystem.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [HttpGet]
        public ActionResult Index(int  id)
        {
            UnityWebapiConfig.RegisterComponents();
            var testService = UnityWebapiConfig.Сontainer.Resolve<ITestPassingService>();
            Test test = testService.GetTestById(id);
            ViewBag.Questions = test.Questions;
            return View(new bool[test.Questions.Count]);
        }
        
        
    }
}