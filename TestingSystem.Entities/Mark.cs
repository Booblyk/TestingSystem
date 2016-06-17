using System;

namespace TestingSystem.Entities
{
    public class Mark : IBaseEntity
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public int Value { get; set; }

        public Test Test { get; set; }
        public User Student { get; set; }

    }
}
