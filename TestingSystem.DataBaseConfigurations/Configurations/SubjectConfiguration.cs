using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class SubjectConfiguration: BaseEntityConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(t => t.TeacherSubjects)
                .WithRequired(t => t.Subject)
                .HasForeignKey(t => t.SunbjectId);


        }
    }
}
