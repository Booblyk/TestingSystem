using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class GroupConfiguration: BaseEntityConfiguration<Group>
    {
        public GroupConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(t => t.Students)
                .WithRequired(t => t.Group)
                .HasForeignKey(t => t.GroupId);

            HasMany(t => t.Courses)
                 .WithRequired(t => t.Group)
                 .HasForeignKey(t => t.GroupId);
        }
    }
}
