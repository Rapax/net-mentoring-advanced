using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Persistance.Configurations
{
    internal class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigureFields(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(Constants.NameFieldMaxLength)
                .IsRequired();

            builder.Property(p => p.Image);

            builder.Property(p => p.ParentCategoryId);

            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildrenCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
