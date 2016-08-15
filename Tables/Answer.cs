using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestingSystem.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }    //?  
        public string Value { get; set; }
        public bool IsCorrect { get; set; }

        public Question Question { get; set; }
        public User User { get; set; }   //?

      
    }
}
