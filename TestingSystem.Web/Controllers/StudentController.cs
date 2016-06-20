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
using TestingSystem.Web.Security;

namespace TestingSystem.Web.Controllers
{
    public class StudentController : Controller
    {
        // Test test;
        // GET: Test


        [CustomAuthorize(Roles = "Student")]
        public ActionResult ListOfTests(int id)
        {
            if (id < 1)return RedirectToAction("Index", "Account");
            UnityWebapiConfig.RegisterComponents();
            ViewBag.UserId = id;
            var TestService = UnityWebapiConfig.Сontainer.Resolve<ITestPassingService>();
            return View("ListOfTests",TestService.GetAllTests());
            
        }


        [CustomAuthorize(Roles = "Student")]
        [HttpGet]
        public ActionResult Index(int  id, int UserId)
    {
            UnityWebapiConfig.RegisterComponents(); 
            var testService = UnityWebapiConfig.Сontainer.Resolve<ITestPassingService>();
            Test test = testService.GetTestById(id);
            ViewBag.Questions = test.Questions;
            ViewBag.Test = test ;
            List<AnswersArray> model = new List<AnswersArray>();
            model.Add(new AnswersArray() { Answers = Convert.ToString(test.Id) });
            for(int i=1; i<=test.Questions.Count; i++)
            {
                model.Add(new AnswersArray() { Answers = "" }) ;
            }
           
            return View();
        }

        [CustomAuthorize(Roles = "Student")]
        [HttpPost]
        public ActionResult Index(int id,int UserId ,List<AnswersArray> model)
        {
            int sum = 0 ;
          //  int TestId = Convert.ToInt32(model[0].Answers) ;
            UnityWebapiConfig.RegisterComponents();
            var testService = UnityWebapiConfig.Сontainer.Resolve<ITestPassingService>();
            Test test = testService.GetTestById(id);
            try
            {
                for (int i = 0; i < model.Count; i++)
                {
                    if (model[i].Answers.ToLower() == test.Questions.ElementAt(i).Answer.ToLower())
                    {
                        sum++;
                    }
                }
                UnityWebapiConfig.RegisterComponents();
                IMarkService markService = UnityWebapiConfig.Сontainer.Resolve<IMarkService>();
                var userService = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
                Mark mark = markService.Create(userService.GetUser(UserId), test, sum);

                return View("Result", mark);
            }
            catch(NullReferenceException)
            {
                return View("Result", new Mark() { });
            }

        }
        //public ActionResult GetAllTests()
        //{

        //}

    }
    public class AnswersArray
    {
        public string Answers { get; set; }
    }


    

}