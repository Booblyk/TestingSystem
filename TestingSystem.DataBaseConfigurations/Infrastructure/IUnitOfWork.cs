using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Question> QuestionRep { get; }
        IRepository<User> UserRep { get; }
        //IRepository<TeacherSubject> TeachSubRep { get; }
        // IRepository<Group> GroupRep { get; }
        //Repository<Answer> AnswerRep { get; }
        IRepository<Mark> MarkRep { get; }
        // IRepository<Role> RoleRep { get; }
        //IRepository<Subject> SubRep { get; }
        IRepository<Test> TestRep { get; }
        // IRepository<UserInRole> UserRoleRep { get; }
        void Commit();
        void Save();
    }
}
