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
        public Task CreateUserAsync(UserPostModel user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            var content = await GetContentByUrlAsync($"https://reqres.in/api/users/2");

            var user = JsonConvert.DeserializeObject<UserModel>(content);

            return user;
        }

        public async Task<UsersOnPageModel> GetUsersOnPageAsync(int pageId)
        {
            var content = await GetContentByUrlAsync($"https://reqres.in/api/users?page={pageId}");

            var user = JsonConvert.DeserializeObject<UsersOnPageModel>(content);

            return user;
        }

        public Task PatchUserAsync(UserPostModel user)
        {
            throw new NotImplementedException();
        }

        public Task PutUserAsync(UserPostModel user)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetContentByUrlAsync(string url)
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

            return content;
        }
    }
}
