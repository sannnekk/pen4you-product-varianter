namespace ProductVarianter.Models
{
    public class Price : IModel
    {
        public string ApiRoute { get; } = "product-price";
        public string Id { get; set; }

        public Price() { }

        public Price(double value, int from, int to = -1)
        {
            this.Value = value;
            this.From = from;
            this.To = to;
        }

        public int? From { get; set; }
        public int? To { get; set; }
        public double? Value { get; set; }
    }
}