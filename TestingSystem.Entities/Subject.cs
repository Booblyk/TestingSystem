using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Subject : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TeacherSubject> TeacherSubjects { get; set; }

    }
}
