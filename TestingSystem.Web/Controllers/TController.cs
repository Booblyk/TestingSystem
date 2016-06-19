using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using TestingSystem.Services.TeacherServices;
using System.Net;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations;
using TestingSystem.DataBaseConfigurations.Infrastructure;

namespace TestingSystem.Web.Controllers
{
    public class TController : Controller
    {
        private readonly IQuestions question;

        private TestingSystemContext db = new TestingSystemContext();
        // GET: /T/

        public TController()
        {
            
        }

        

        public ActionResult GetAllQuestions()
        {     
            Questions qu = new Questions();
            List<QuestionsDTO> qlist = new List<QuestionsDTO>(qu.GetQuestion());
            return View(qlist);
        }

        public ActionResult GetAllTests()
        {
            Tests qu = new Tests();
            List<TestsDTO> qlist = new List<TestsDTO>(qu.GetTest());
            return View(qlist);
        }
        [HttpGet]
        public ActionResult GetQuestionByTest(int id)
        {
            Questions qu = new Questions();
            List<QuestionsDTO> qlist = new List<QuestionsDTO>(qu.GetQuestionByCourse(id));
            qlist.Add(new QuestionsDTO() {TestID=id });
            return View(qlist);
        }

        [HttpPost]
        public ActionResult GetQuestionByTest(QuestionsDTO qlist)
        {
            Questions qu = new Questions();
            qu.CreateQuestion(qlist);
            List<QuestionsDTO> nlist = new List<QuestionsDTO>(qu.GetQuestionByCourse(qlist.TestID));
            return View(nlist);
        }
        [HttpGet]

        public ActionResult AddQuestions()
        {
            QuestionsDTO newQuestion = new QuestionsDTO();
            return View(newQuestion);
        }
        [HttpPost]

        public ActionResult AddQuestions(QuestionsDTO newQuestion)
        {
            Questions qu = new Questions();

            qu.CreateQuestion(newQuestion);
            return View();
        }

        [HttpGet]

        public ActionResult AddTest()
        {
            TestsDTO newTest = new TestsDTO();
            return View(newTest);
        }

        

        [HttpPost]

        public ActionResult AddTest(TestsDTO newTest)
        {
            Tests qu = new Tests();
            qu.CreateTest(newTest);
            ViewBag.TestAdded = "Test was added";
            return View();
        }

        public ActionResult DeleteQuestion(int id, int testId)
        {
            Questions qu = new Questions();
            qu.DeleteQuestion(id);
        //    List<QuestionsDTO> nlist = new List<QuestionsDTO>(qu.GetQuestionByCourse(id));
            return View(testId);
        }

        public ActionResult DeleteTest(int id)
        {
            Tests te = new Tests();
            te.DeleteTest(id);
            return View();
        }
    }
}
