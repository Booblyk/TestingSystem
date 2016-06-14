using System.Data.Entity.ModelConfiguration;
using TestingSystem.Entities;

namespace TestingSystem.DataBaseConfigurations
{
    class BaseEntityConfiguration<T>: EntityTypeConfiguration<T> where T:class,IBaseEntity
    {
        public BaseEntityConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}
