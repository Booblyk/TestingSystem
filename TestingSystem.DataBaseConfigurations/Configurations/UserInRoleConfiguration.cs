using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class UserInRoleConfiguration:BaseEntityConfiguration<UserInRole>
    {
        public UserInRoleConfiguration()
        {
            HasRequired(t => t.User)
                .WithMany(t => t.UserInRoles)
                .HasForeignKey(t => t.UserId);

            HasRequired(t => t.Role)
                .WithMany(t => t.UserInRoles)
                .HasForeignKey(t => t.RoleId);
        }
    }
}
