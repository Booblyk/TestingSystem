using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class CourseConfiguration: BaseEntityConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasMany(t => t.Tests)
                .WithRequired(t => t.Course)
                .HasForeignKey(t => t.CourseId);

            HasRequired(t => t.Group)
                .WithMany(t => t.Courses)
                .HasForeignKey(t => t.GroupId);

            HasRequired(t => t.TeacherSubject)
                .WithMany(t => t.Courses)
                .HasForeignKey(t => t.TeacherSubjectId);

        }
    }
}
