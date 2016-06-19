using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }


        
       
        //only for student
        public ICollection<Mark> Marks { get; set; }


    }
}
