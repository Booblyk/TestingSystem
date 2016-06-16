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
        User CreateUser(string email, string password);
    }
}
