using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }

        //common properties for student and teacher
        public ICollection<UserInRole> UserInRoles { get; set; }

        //only for teacher
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<Test> Tests { get; set; }
        //only for student
        public Group Group { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Mark> Marks { get; set; }


    }
}
