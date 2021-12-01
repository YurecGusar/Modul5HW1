using Modul5HW1.Models;
using Modul5HW1.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1
{
    class Startup
    {
        private const int _globalId = 2;
        private readonly IUserService _userService;
        private readonly IUnknownService _unknownService;

        public Startup(
            IUserService userService, 
            IUnknownService unknownService)
        {
            _userService = userService;
            _unknownService = unknownService;
        }
        public void Run()
        {
            var createUserModel = new UserPostModel()
            {
                Name = "morpheus",
                Job = "leader"
            };

            var updateUserModel = new UserPostModel()
            {
                Name = "morpheus",
                Job = "zion resident"
            };

            var t1 = Task.Run(async () =>
            {
                var user = await _userService.GetUserAsync(_globalId);

                Console.WriteLine(user.Data.Email);
            });

            var t2 = Task.Run(async () =>
            {
                var usersOnPage = await _userService.GetUsersOnPageAsync(_globalId);

                Console.WriteLine(usersOnPage.Per_page);
            });

            var t3 = Task.Run(async () =>
            {
                var createUserResp = await _userService.CreateUserAsync(createUserModel);

                Console.WriteLine(createUserResp.Name);
            });

            var t4 = Task.Run(async () =>
            {
                var updateUserResp = await _userService.PutUserAsync(updateUserModel, _globalId);

                Console.WriteLine(updateUserResp.Job);
            });

            var t5 = Task.Run(async () => 
            {
                var deleteUserResp = await _userService.DeleteUserAsync(_globalId);

                if (deleteUserResp == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("204, удаление прошло отлично");
                }
            });

            var t6 = Task.Run(async () =>
            {

                var updateUserResp = await _userService.PatchUserAsync(updateUserModel, _globalId);

                Console.WriteLine(updateUserResp.Job);
            });


            var t7 = Task.Run(async () =>
            {
                var unknown = await _unknownService.GetResource(_globalId);
                Console.WriteLine(unknown.Color);
            });

            Task.WhenAll(new[] { t1, t2, t3, t4, t5, t6, t7}).GetAwaiter().GetResult();
        }
    }
}
