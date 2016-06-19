using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.ObjectBuilder2;
using TestingSystem.Services.Interfaces;
using TestingSystem.Services.Implementation;
using TestingSystem.DataBaseConfigurations.Infrastructure;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.DataBaseConfigurations.Extension;
using TestingSystem.Entities;

namespace TestingSystem.Web.App_Start
{
    public class UnityWebapiConfig
    {
        public static UnityContainer Сontainer { get; set; }
        
        public static void RegisterComponents()
        {
            Сontainer = new UnityContainer();

            Сontainer.RegisterType<IUserService, UserService>();

            Сontainer.RegisterType<IUnitOfWork, UnitOfWork>();

            Сontainer.RegisterType(typeof(IRepository<User>),typeof(Repository<User>),new InjectionConstructor(typeof(IDbProvide)));

            Сontainer.RegisterType<IDbProvide, DbProvide>();

            Сontainer.RegisterType<ITestPassingService, TestPassingService>();

            Сontainer.RegisterType<IQuestionService, QuestionService>();
        
            Сontainer.RegisterType<IMarkService, MarkService>();
        }

      

    }
}