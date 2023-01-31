namespace ProductVarianter.Models.Requests
{
    public class AuthRequest
    {
        public string grant_type { get; set; } = "password";
        public string client_id { get; set; } = "administration";
        public string scopes { get; set; } = "write";
        public string username { get; set; }
        public string password { get; set; }

        public AuthRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}