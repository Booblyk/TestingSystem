using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations;
using TestingSystem.Services.Interfaces;
using TestingSystem.Services.Implementation;
using TestingSystem.Web.App_Start;
using Microsoft.Practices.Unity;
using TestingSystem.Web;

namespace TestingSystem.Web.Controllers
{
    public class OlenaController : Controller
    {
        // GET: Home
        //public string Index()
        //{
        //    UnityWebapiConfig.RegisterComponents();  
        //    var userServ = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
        //    userServ.CreateUser("123@gmail.com", "123");
        //    return "Some ";
        //}
        public ActionResult Index()
        {
            using (var db = new TestingSystemContext())
            {
                return View(db.Users.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Response/Create
        [HttpPost]
        public ActionResult Create(User client)
        {
            try
            {

                UnityWebapiConfig.RegisterComponents();
                var userServ = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
                userServ.CreateUser("0@gmail.com", "123");
                return RedirectToAction("Olena/Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            using (var db = new TestingSystemContext())
            {
                return View(db.Users.Find(id));
            }
        }

        // POST: Response/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User client)
        {
            try
            {
                using (var context = new TestingSystemContext())
                {
                    context.Entry(client).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (var context = new TestingSystemContext())
            {
                return View(context.Users.Find(id));
            }
        }

        // POST: Response/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User client)
        {
            try
            {
                using (var context = new TestingSystemContext())
                {
                    context.Entry(client).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}