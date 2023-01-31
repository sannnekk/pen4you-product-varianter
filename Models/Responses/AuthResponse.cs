namespace ProductVarianter.Models.Responses
{
    [Serializable]
    public record class AuthResponse
    {
        public string? access_token { get; set; }
        public string? refresh_token { get; set; }
        public string? expires_in { get; set; }
    }
}