using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int AnswerId { get; set; }
        public string Value { get; set; }
        public int UserCreatorId { get; set; } 
        public string question { get; set; } 

        public Test Test { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public User UserCreator { get; set; }

    }
}
