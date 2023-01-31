using System.Net.Http.Headers;

namespace ProductVarianter.Helpers
{
    public static class HttpHelper
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<ResponseType?> SendPostRequest<RequestType, ResponseType>(string url, RequestType body, string? token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(
                JsonConverter.Serialize<RequestType>(body)
            );

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}", null, response.StatusCode);
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConverter.Deserialize<ResponseType>(responseString);

            return responseObject;
        }

        public static async Task SendPostRequest<RequestType>(string url, RequestType body, string? token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(
                JsonConverter.Serialize<RequestType>(body)
            );

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}", null, response.StatusCode);
            }
        }

        public static async Task<ResponseType?> SendGetRequest<ResponseType>(string url, string? token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}", null, response.StatusCode);
            }

            var responseString = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConverter.Deserialize<ResponseType>(responseString);

            return responseObject;
        }

        public static async Task SendPatchRequest<RequestType>(string url, RequestType body, string? token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            request.Content = new StringContent(JsonConverter.Serialize<RequestType>(body));

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}", null, response.StatusCode);
            }
        }

        public static async Task SendDeleteRequest(string url, string? token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}", null, response.StatusCode);
            }
        }
    }
}