using CatalogService.Domain.Common;

namespace CatalogService.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public string? Image { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Product> Products { get; set;}

        public ICollection<Category> ChildrenCategories { get; set; }
    }
}
