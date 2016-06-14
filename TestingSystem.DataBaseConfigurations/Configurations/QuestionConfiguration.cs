using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class QuestionConfiguration: BaseEntityConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            Property(t => t.question)
                .IsRequired();

            HasRequired(t => t.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(t => t.TestId);

            HasMany(t => t.Answers)
                .WithRequired(t => t.Question)
                .HasForeignKey(t => t.QuestionId);

                   
        }
    }
}
