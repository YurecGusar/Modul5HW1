using Microsoft.Extensions.DependencyInjection;
using Modul5HW1.Services;
using Modul5HW1.Services.Abstractions;

namespace Modul5HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<Startup>()
                .AddTransient<IUserService, UserService>()
                .BuildServiceProvider();

            var startup = services.GetService<Startup>();
            startup.Run();
        }
    }
}
