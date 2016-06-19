using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Question : IBaseEntity
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Answer { get; set; }     
        public string Questionn { get; set; } 

        public Test Test { get; set; }
    }
}
