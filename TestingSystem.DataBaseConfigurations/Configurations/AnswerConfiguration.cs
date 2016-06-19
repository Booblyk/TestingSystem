using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class AnswerConfiguration: BaseEntityConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            HasRequired(t => t.User)
                .WithMany(t => t.Answers)
                .HasForeignKey(t => t.UserId);

            HasRequired(t => t.Question)
                .WithMany(t => t.Answers)
                .HasForeignKey(t => t.QuestionId);




        }
    }
}
