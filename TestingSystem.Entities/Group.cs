using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Group : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
