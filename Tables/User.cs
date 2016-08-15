using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }

        
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
        public Group Group { get; set; }

    }
}
