using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class RoleConfiguration:BaseEntityConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            HasMany(t => t.UserInRoles)
                .WithRequired(t => t.Role)
                .HasForeignKey(t => t.RoleId);
        }
    }
}
