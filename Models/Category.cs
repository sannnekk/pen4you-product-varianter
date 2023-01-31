using ProductVarianter.Helpers;

namespace ProductVarianter.Models
{
    public class Category : IModel
    {
        public string ApiRoute { get; } = "category";
        public Category() { }
        public Category(IEnumerable<Category> children)
        {
            this.Children = children;
        }

        private IEnumerable<Category>? Children = null;

        public string? Name { get; set; }
        public string Id { get; set; }
    }
}