using Modul5HW1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Services.Abstractions
{
    internal interface IUserService
    {
        public Task<UsersOnPageModel> GetUsersOnPageAsync(int pageId);
        public Task<UserModel> GetUserAsync(int id);
        public Task CreateUserAsync(UserPostModel user);
        public Task PutUserAsync(UserPostModel user);
        public Task PatchUserAsync(UserPostModel user);
        public Task DeleteUserAsync(int id);
    }
}
