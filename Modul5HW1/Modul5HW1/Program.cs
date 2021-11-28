using Microsoft.Extensions.DependencyInjection;

namespace Modul5HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<Startup>()
                .BuildServiceProvider();

            var startup = services.GetService<Startup>();
            startup.Run();
        }
    }
}
