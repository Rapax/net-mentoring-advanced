using CatalogService.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistance.Configurations
{
    internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            throw new NotImplementedException();
        }

        protected abstract void ConfigureFields(EntityTypeBuilder<T> builder);

        protected virtual void ConfigureTableName(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name);
        }

        protected virtual void ConfigurePrimaryKey(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
