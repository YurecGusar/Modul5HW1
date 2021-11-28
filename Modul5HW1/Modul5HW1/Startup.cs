using Modul5HW1.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1
{
    class Startup
    {
        private readonly IUserService _userService;

        public Startup(
            IUserService userService)
        {
            _userService = userService;
        }
        public void Run()
        {
            var user = _userService.GetUserAsync(2).GetAwaiter().GetResult();

            var usersOnPage = _userService.GetUsersOnPageAsync(2).GetAwaiter().GetResult();

            Console.WriteLine(usersOnPage.Per_page);
            Console.WriteLine(user.Data.Email);
        }
    }
}
