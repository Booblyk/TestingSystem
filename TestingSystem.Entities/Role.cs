using System.Collections.Generic;

namespace TestingSystem.Entities
{
    public class Role : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
