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

        private IRepository<Answer> answerRep;
        private IRepository<Course> courseRep;
        private IRepository<Group> groupRep;
        private IRepository<Mark> markRep;
        private IRepository<Question> questionRep;
        private IRepository<Role> roleRep;
        private IRepository<Subject> subRep;
        private IRepository<TeacherSubject> teachSubRep;
        private IRepository<Test> testRep;
        private IRepository<User> userRep;
        private IRepository<UserInRole> userRoleRep;

        public UnitOfWork(IDbProvide DbProvide)
        {
            this.DbProvide = DbProvide;
        }
        public IRepository<Answer> AnswerRep
        {
            get
            {
                if (answerRep == null)
                {
                    answerRep = new Repository<Answer>(DbProvide);
                }

                return answerRep;
            }
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
        public IRepository<Group> GroupRep
        {
            get
            {
                if (groupRep == null)
                {
                    groupRep = new Repository<Group>(DbProvide);
                }

                return groupRep;
            }
        }

        public IRepository<Course> CourseRep
        {
            get
            {
                if (courseRep == null)
                {
                    courseRep = new Repository<Course>(DbProvide);
                }

                return courseRep;
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
        public IRepository<Role> RoleRep
        {
            get
            {
                if (roleRep == null)
                {
                    roleRep = new Repository<Role>(DbProvide);
                }

                return roleRep;
            }
        }
        public IRepository<Subject> SubRep
        {
            get
            {
                if (subRep == null)
                {
                    subRep = new Repository<Subject>(DbProvide);
                }

                return subRep;
            }
        }
        public IRepository<TeacherSubject> TeachSubRep
        {
            get
            {
                if (teachSubRep == null)
                {
                    teachSubRep = new Repository<TeacherSubject>(DbProvide);
                }

                return teachSubRep;
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
        public IRepository<UserInRole> UserRoleRep
        {
            get
            {
                if (userRoleRep == null)
                {
                    userRoleRep = new Repository<UserInRole>(DbProvide);
                }

                return userRoleRep;
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