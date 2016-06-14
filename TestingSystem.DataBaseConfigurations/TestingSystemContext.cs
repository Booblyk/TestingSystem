namespace TestingSystem.DataBaseConfigurations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using TestingSystem.Entities;

    public class TestingSystemContext : DbContext
    {

        public TestingSystemContext()
            : base("name=TestingSystemContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeachersSubjects { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new MarkConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new TeacherSubjectConfiguration());
            modelBuilder.Configurations.Add(new TestConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserInRoleConfiguration());
        }
    }


}
