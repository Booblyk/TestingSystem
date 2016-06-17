using System;
using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Test : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }     

        public ICollection<Question> Questions { get; set; }
        public ICollection<Mark> Marks { get; set; } 

    }
}
