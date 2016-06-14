using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Question : IBaseEntity
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Value { get; set; }     //?
        public string question { get; set; } 

        public Test Test { get; set; }
        public ICollection<Answer> Answers { get; set; }
       

    }
}
