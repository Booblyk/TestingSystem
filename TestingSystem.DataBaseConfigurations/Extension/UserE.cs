using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DataBaseConfigurations.Repositories;
using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations.Extension
{
    public static class UserE
    {
        public static User GetById(this IRepository<User> UserRep, string mail)
        {
            return UserRep.GetAll().FirstOrDefault(o => o.Email == mail);
        }
    }

}
