using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Course : IBaseEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int TeacherSubjectId { get; set; }

        public Group Group { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
        public ICollection<Test> Tests { get; set; }


    }
}
