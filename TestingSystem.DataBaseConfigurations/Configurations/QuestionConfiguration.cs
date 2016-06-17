using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class QuestionConfiguration: BaseEntityConfiguration<Question>
    {
        public QuestionConfiguration()
        {
           

            HasRequired(t => t.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(t => t.TestId);
            
            
                   
        }
    }
}
