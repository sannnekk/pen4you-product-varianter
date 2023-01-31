using System.Collections.ObjectModel;
using System.Net;
using ProductVarianter.Helpers;
using ProductVarianter.Models;
using ProductVarianter.Models.Requests;
using ProductVarianter.Models.Responses;

namespace ProductVarianter.Loaders
{
    public class SW6Loader : ILoader
    {
        private string baseUrl { get; set; }
        private string apiKey { get; set; }
        private string login { get; set; }
        private string password { get; set; }

        public SW6Loader(string baseUrl, string login, string password)
        {
            this.baseUrl = baseUrl;
            this.apiKey = "";
            this.login = login;
            this.password = password;

            this.Auth();
        }

        public async Task Auth()
        {
            var authResponse = await HttpHelper.SendPostRequest<AuthRequest, AuthResponse>(this.baseUrl + "oauth/token", new AuthRequest(this.login, this.password));

            if (authResponse != null && authResponse.access_token != null)
            {
                this.apiKey = authResponse.access_token;
                return;
            }

            throw new Exception("Auth failed");
        }

        public async Task<IEnumerable<T>> Get<T>(int start = 0, int count = -1) where T : IModel, new()
        {
            SW6ResponseWrapper<IEnumerable<T>>? response;
            string url = this.baseUrl + new T().ApiRoute + $"?&offset={start * 50}";

            if (count > 0)
                url += $"&limit={count}";

            try
            {
                response = await HttpHelper.SendGetRequest<SW6ResponseWrapper<IEnumerable<T>>>(url, this.apiKey);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await this.Auth();
                    response = await HttpHelper.SendGetRequest<SW6ResponseWrapper<IEnumerable<T>>>(url, this.apiKey);
                }

                throw e;
            }

            if (response == null)
                throw new Exception($"Response on {url}  is null");

            return response.data;
        }

        public async Task<T> Get<T>(string id) where T : IModel, new()
        {
            SW6ResponseWrapper<T>? response;
            string url = this.baseUrl + new T().ApiRoute + $"/{id}";

            try
            {
                response = await HttpHelper.SendGetRequest<SW6ResponseWrapper<T>>(url, this.apiKey);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await this.Auth();
                    response = await HttpHelper.SendGetRequest<SW6ResponseWrapper<T>>(url, this.apiKey);
                }

                throw e;
            }

            if (response == null)
                throw new Exception($"Response on {url}  is null");

            return response.data;
        }

        public async Task Update<T>(T item) where T : IModel, new()
        {
            string url = this.baseUrl + new T().ApiRoute;

            try
            {
                await HttpHelper.SendPatchRequest<T>(url, item, this.apiKey);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await this.Auth();
                    await HttpHelper.SendGetRequest<SW6ResponseWrapper<T>>(url, this.apiKey);
                }

                throw e;
            }
        }

        public async Task Update<T>(IEnumerable<T> items) where T : IModel, new()
        {
            string url = this.baseUrl + new T().ApiRoute;

            try
            {
                await HttpHelper.SendPatchRequest<IEnumerable<T>>(url, items, this.apiKey);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await this.Auth();
                    await HttpHelper.SendGetRequest<IEnumerable<T>>(url, this.apiKey);
                }

                throw e;
            }
        }

        public async Task Delete<T>(T item) where T : IModel, new()
        {
            string url = this.baseUrl + item.ApiRoute + "/" + item.Id;

            try
            {
                await HttpHelper.SendDeleteRequest(url, this.apiKey);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await this.Auth();
                    await HttpHelper.SendDeleteRequest(url, this.apiKey);
                }

                throw e;
            }
        }

        public async Task Delete<T>(string id) where T : IModel, new()
        {
            string url = this.baseUrl + new T().ApiRoute + "/" + id;

            try
            {
                await HttpHelper.SendDeleteRequest(url, this.apiKey);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await this.Auth();
                    await HttpHelper.SendDeleteRequest(url, this.apiKey);
                }

                throw e;
            }
        }

        public async Task Create<T>(T item) where T : IModel, new()
        {
            string url = this.baseUrl + item.ApiRoute;

            try
            {
                await HttpHelper.SendPostRequest<T>(url, item, this.apiKey);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.Unauthorized)
                {
                    await this.Auth();
                    await HttpHelper.SendPostRequest<T>(url, item, this.apiKey);
                }

                throw e;
            }
        }
    }
}