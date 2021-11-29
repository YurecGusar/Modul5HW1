using Modul5HW1.Models;
using Modul5HW1.Services.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Services
{
    internal class UserService : IUserService
    {
        public async Task<ResponseModel> CreateUserAsync(UserPostModel user)
        {
            var url = @"https://reqres.in/api/users";

            var result = await PostUserByUrlAsync(url, user);
            
            return result;
        }

        public async Task<HttpStatusCode> DeleteUserAsync(int id)
        {
            HttpResponseMessage resp;
            var url = $@"https://reqres.in/api/users/{id}";

            using (var httpClient = new HttpClient())
            {
                resp = await httpClient.DeleteAsync(url);
            }

            return resp.StatusCode;
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            var url = $"https://reqres.in/api/users/{id}";

            var user = await GetContentByUrlAsync<UserModel>(url);

            return user;
        }

        public async Task<UsersOnPageModel> GetUsersOnPageAsync(int pageId)
        {
            var url = $"https://reqres.in/api/users?page={pageId}";

            var user = await GetContentByUrlAsync<UsersOnPageModel>(url);

            return user;
        }

        public async Task<ResponseModel> PatchUserAsync(UserPostModel user, int id)
        {
            var url = @$"https://reqres.in/api/users/{id}";

            var result = await PostUserByUrlAsync(url, user);

            return result;
        }

        public async Task<ResponseModel> PutUserAsync(UserPostModel user, int id)
        {
            var url = $@"https://reqres.in/api/users/{id}";

            var result = await PostUserByUrlAsync(url, user);

            return result;
        }

        private async Task<ResponseModel> PostUserByUrlAsync(string url, UserPostModel user)
        {
            ResponseModel response;
            var content = string.Empty;

            using (var httpClient = new HttpClient())
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(url, httpContent);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    content = await result.Content.ReadAsStringAsync();
                }
            }

            response = JsonConvert.DeserializeObject<ResponseModel>(content);

            return response;
        }

        private async Task<T> GetContentByUrlAsync<T>(string url)
            where T : class
        {
            var content = string.Empty;

            using (var httpClient = new HttpClient())
            {

                var result = await httpClient.GetAsync(url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    content = await result.Content.ReadAsStringAsync();
                }
            }

            var obj = JsonConvert.DeserializeObject<T>(content);

            return obj;
        }
    }
}
