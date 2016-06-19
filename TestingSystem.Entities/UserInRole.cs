namespace TestingSystem.Entities
{
    public class UserInRole : IBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }


        public Role Role { get; set; }
        public User User { get; set; }
    }
}
