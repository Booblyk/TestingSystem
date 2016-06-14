using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class TeacherSubjectConfiguration: BaseEntityConfiguration<TeacherSubject>
    {
        public TeacherSubjectConfiguration()
        {
            HasRequired(t => t.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(t => t.TeacherId);

            HasRequired(t => t.Subject)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(t => t.SunbjectId);

            HasMany(t => t.Courses)
                .WithRequired(t => t.TeacherSubject)
                .HasForeignKey(t => t.TeacherSubjectId);
                
        }
    }
}
