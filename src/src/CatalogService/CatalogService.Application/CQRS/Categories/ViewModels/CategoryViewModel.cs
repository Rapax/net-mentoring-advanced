namespace CatalogService.Application.CQRS.Categories.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Image { get; set; }

        public CategoryViewModel? ParentCategory { get; set; }

        public IEnumerable<int> ChildrenCategoryIds { get; set; } = Enumerable.Empty<int>();
    }
}
