using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Deployment;
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
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        

        // GET: Account
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Index(User client)
        {
            
            try
            {
                AccountModel am = new AccountModel();
                client = am.Login(client.Email, client.Password);
                if (string.IsNullOrEmpty(client.Email) ||
                    string.IsNullOrEmpty(client.Password) ||
                    am.Login(client.Email, client.Password) == null)
                {
                    ViewBag.Error = "Invalid account";
                    return View("Index");

                }
                else
                {
                    SessionPersister.Username = client.Email;

                    if (am.Login(client.Email, client.Password).Role == "Student")
                        return RedirectToAction("ListOfTests", "Student",new { id=client.Id});
                    if (am.Login(client.Email, client.Password).Role == "Teacher")
                        return RedirectToAction("GetAllTests", "T");
                    if (am.Login(client.Email, client.Password).Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Error = "Invalid Role";
                        return View("Index");
                    }
                }
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