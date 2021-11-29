using Modul5HW1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Services.Abstractions
{
    internal interface IUserService
    {
        public Task<UsersOnPageModel> GetUsersOnPageAsync(int pageId);
        public Task<UserModel> GetUserAsync(int id);
        public Task<ResponseModel> CreateUserAsync(UserPostModel user);
        public Task<ResponseModel> PutUserAsync(UserPostModel user, int id);
        public Task<ResponseModel> PatchUserAsync(UserPostModel user, int id);
        public Task<HttpStatusCode> DeleteUserAsync(int id);
    }
}
