namespace ProductVarianter.Models
{
    public interface IModel
    {
        public string ApiRoute { get; }
        public string Id { get; set; }
    }
}