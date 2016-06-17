using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.Entities;
namespace TestingSystem.DataBaseConfigurations.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbProvide DbProvide;

        private TestingSystemContext context = new TestingSystemContext();

        private IRepository<Mark> markRep;
        private IRepository<Question> questionRep;
        private IRepository<Test> testRep;
        private IRepository<User> userRep;

        public UnitOfWork(IDbProvide DbProvide)
        {
            this.DbProvide = DbProvide;
        }
      
        public IRepository<User> UserRep
        {
            get
            {
                if (userRep == null)
                {
                    userRep = new Repository<User>(DbProvide);
                }

                return userRep;
            }
        }
       
       
        public IRepository<Mark> MarkRep
        {
            get
            {
                if (markRep == null)
                {
                    markRep = new Repository<Mark>(DbProvide);
                }

                return markRep;
            }
        }
        public IRepository<Question> QuestionRep
        {
            get
            {
                if (questionRep == null)
                {
                    questionRep = new Repository<Question>(DbProvide);
                }

                return questionRep;
            }
        }
       
        public IRepository<Test> TestRep
        {
            get
            {
                if (testRep == null)
                {
                    testRep = new Repository<Test>(DbProvide);
                }

                return testRep;
            }
        }
       
        
        public TestingSystemContext DbContext
        {
            get { return context ?? (context = DbProvide.Init()); }
        }
        public void Commit()
        {
            DbContext.Commit();
        }
    }
}