using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }


        public Test Test { get; set; }
        public User Student { get; set; }

    }
}
