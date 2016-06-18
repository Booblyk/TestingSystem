using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Entities;
using TestingSystem.DataBaseConfigurations;

namespace TestingSystem.Web.Models.Account
{
    public class AccountModel
    {
        private List<User> listAccounts = new List<User>();

        public AccountModel()
        {
            var db = new TestingSystemContext();
            listAccounts.AddRange(db.Users.ToList());
        }

        public User Find(string username)
        {
            return listAccounts.Where(acc => acc.Email.Equals(username)).FirstOrDefault();
        }

        public User Login(string username, string password)
        {
            return listAccounts.Where(acc => acc.Email.Equals(username) && acc.Password.Equals(password)).FirstOrDefault();
        }
    }
}
