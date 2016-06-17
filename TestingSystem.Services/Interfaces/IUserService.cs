using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Entities;


namespace TestingSystem.Services.Interfaces
{
    public  interface IUserService
    {
        User GetUser(int UserId);
        User CreateUser(User us);
        User EditUser(User us);
        void DeleteUser(int UserId);
    }
}
