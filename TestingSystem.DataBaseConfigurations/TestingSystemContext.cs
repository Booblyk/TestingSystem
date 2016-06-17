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
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new MarkConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new TestConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }


}
