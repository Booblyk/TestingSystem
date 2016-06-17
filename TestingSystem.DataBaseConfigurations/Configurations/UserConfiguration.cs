using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class UserConfiguration:BaseEntityConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(100);

            //HasMany(t => t.Marks)
            //    .WithOptional(t => t.Student);

        }
    }
}
