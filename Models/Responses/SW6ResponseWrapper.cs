namespace ProductVarianter.Models.Responses
{
    [Serializable]
    public record class SW6ResponseWrapper<T>
    {
        public T data { get; set; }

        public SW6ResponseWrapper(T data)
        {
            this.data = data;
        }
    }
}