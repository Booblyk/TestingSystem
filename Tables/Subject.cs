using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystem.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TeacherSubject> TeacherSubjects { get; set; }

    }
}
