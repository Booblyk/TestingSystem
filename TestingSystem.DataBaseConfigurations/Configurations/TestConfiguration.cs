using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class TestConfiguration:BaseEntityConfiguration<Test>
    {
        public TestConfiguration()
        {
            Property(t => t.Description)
                .IsOptional()
                .HasMaxLength(350);

            Property(t => t.Duration)
                .IsRequired();

            HasMany(t => t.Questions)
                .WithRequired(t => t.Test)
                .HasForeignKey(t => t.TestId);

            HasMany(t => t.Marks)
                .WithRequired(t => t.Test)
                .HasForeignKey(t => t.TestId);

        }
    }
}
