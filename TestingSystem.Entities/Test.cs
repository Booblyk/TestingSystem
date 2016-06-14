using System;
using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Test : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Duration { get; set; }
        public DateTime MaxWork { get; set; }        //?
        public int CourseId { get; set; }
        public DateTime AccessibleDate { get; set; }
        public int UserCreatorId { get; set; }


        public Course Course { get; set; }
        public ICollection<Question> Questions { get; set; }
        public User UserCreator { get; set; }
        public ICollection<Mark> Marks { get; set; }

    }
}
