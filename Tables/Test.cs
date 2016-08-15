using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Duration { get; set; }
        public DateTime MaxWork { get; set; }        //?
        public int CourseId { get; set; }
        public DateTime AccessibleDate { get; set; }


        public Course Course { get; set; }
        public ICollection<Question> Questions { get; set; }


    }
}
