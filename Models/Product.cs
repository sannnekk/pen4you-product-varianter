namespace ProductVarianter.Models
{
    public class Product : IModel
    {
        public string ApiRoute { get; } = "product";

        public Product(string number)
        {
            this.Number = number;
        }

        public string Id { get; set; }
        public string? Name { get; set; }
        public string? MetaName { get; set; }
        public string Number { get; private set; }
        public string? Manufacturer { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Price>? Prices { get; set; }

        // TODO: media 
    }
}