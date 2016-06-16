using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.Services.Interfaces;
using TestingSystem.Services.Implementation;
using TestingSystem.Web.App_Start;
using Microsoft.Practices.Unity;

namespace TestingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            UnityWebapiConfig.RegisterComponents();  
            var userServ = UnityWebapiConfig.Сontainer.Resolve<IUserService>();
            userServ.CreateUser("123@gmail.com", "123");
            return "Some ";
        }
    }
}