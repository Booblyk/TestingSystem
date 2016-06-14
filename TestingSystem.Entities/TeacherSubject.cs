using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class TeacherSubject : IBaseEntity
    {
        public int Id { get; set; }
        public int SunbjectId { get; set; }
        public int TeacherId { get; set; }

        public User Teacher { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
