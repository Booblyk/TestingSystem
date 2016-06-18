using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Web;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations;
using TestingSystem.Services.Interfaces;
using TestingSystem.Services.Implementation;
using TestingSystem.Web.App_Start;
using Microsoft.Practices.Unity;
using TestingSystem.Web.Models.Account;
using TestingSystem.Web.Security;

namespace TestingSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User client)
        {
            try
            {
                AccountModel am = new AccountModel();
                if (string.IsNullOrEmpty(client.Email) ||
                    string.IsNullOrEmpty(client.Password) ||
                    am.Login(client.Email, client.Password) == null)
                {
                    ViewBag.Error = "Invalid account";
                    return View("Index");

                }
                
                SessionPersister.Username = client.Email;
                return View("SuccessAccount");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Index");
        }
    }
}