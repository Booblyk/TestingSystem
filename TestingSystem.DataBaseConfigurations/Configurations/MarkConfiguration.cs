using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class MarkConfiguration: BaseEntityConfiguration<Mark>
    {
        public MarkConfiguration()
        {
            HasRequired(t => t.Student)
                .WithMany(t => t.Marks)
                .HasForeignKey(t => t.StudentId);
            HasRequired(t => t.Test)
                .WithMany(t => t.Marks)
                .HasForeignKey(t => t.TestId);

        }
    }
}
