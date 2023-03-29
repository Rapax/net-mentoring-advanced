using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistance.Configurations
{
    internal class ProductConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigureFields(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(Constants.NameFieldMaxLength)
                .IsRequired();

            builder.Property(p => p.Description);

            builder.Property(p => p.Image);

            builder.Property(p => p.CategoryId)
                .IsRequired();

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
