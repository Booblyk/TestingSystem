using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Entities
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public int SunbjectId { get; set; }
        public int TeacherId { get; set; }

        public User Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
