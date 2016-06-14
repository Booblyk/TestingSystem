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

            Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.PasswordSalt)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(u => u.Group)
                .WithMany(z => z.Students)
                .HasForeignKey(t => t.GroupId);

            HasMany(t => t.UserInRoles)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);

            HasMany(t => t.TeacherSubjects)
               .WithRequired(t => t.Teacher)
               .HasForeignKey(t => t.TeacherId);

            HasMany(t => t.Tests)
                .WithRequired(t => t.UserCreator)
                .HasForeignKey(t => t.UserCreatorId)
                .WillCascadeOnDelete(false);

            HasMany(t => t.Answers)
                .WithRequired(t => t.User)
                .HasForeignKey(t => t.UserId);

            HasMany(t => t.Marks)
                .WithRequired(t => t.Student)
                .HasForeignKey(t => t.StudentId);

        }
    }
}
