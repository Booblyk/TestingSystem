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
    // [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            UnityWebapiConfig.RegisterComponents();
            var UserService = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
            return View(UserService.GetAll());
            
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User client)
        {
            try
            {

                UnityWebapiConfig.RegisterComponents();
                var userServ = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
                userServ.CreateUser(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            UnityWebapiConfig.RegisterComponents();
            var UserService = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
            return View(UserService.GetUser(id));           
        }

        // POST: Response/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User client)
        {
            try
            {

                UnityWebapiConfig.RegisterComponents();
                var userServ = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
                userServ.EditUser(client);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            UnityWebapiConfig.RegisterComponents();
            var UserService = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
            return View(UserService.GetUser(id));
        }

        // POST: Response/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User client)
        {
            try
            {
                using (var context = new TestingSystemContext())
                {
                    UnityWebapiConfig.RegisterComponents();
                    var userServ = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
                    userServ.DeleteUser(id);
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