using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class TestConfiguration:BaseEntityConfiguration<Test>
    {
        public TestConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(350);

            Property(t => t.Duration)
                .IsRequired();

            Property(t => t.MaxWork)
                .IsRequired();

            HasRequired(t => t.Course)
                .WithMany(t => t.Tests)
                .HasForeignKey(t => t.CourseId);

            HasMany(t => t.Questions)
                .WithRequired(t => t.Test)
                .HasForeignKey(t => t.TestId);

            HasRequired(t => t.UserCreator)
                .WithMany(t => t.Tests)
                .HasForeignKey(t => t.UserCreatorId)
                .WillCascadeOnDelete(false);


            HasMany(t => t.Marks)
                .WithRequired(t => t.Test)
                .HasForeignKey(t => t.TestId);

        }
    }
}
