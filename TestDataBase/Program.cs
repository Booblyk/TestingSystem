using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TestingSystem.DataBaseConfigurations.TestingSystemContext();
            db.Users.Add(new TestingSystem.Entities.User() { FirstName = "A", Id = 1 });
            db.SaveChanges();

        }
    }
}
