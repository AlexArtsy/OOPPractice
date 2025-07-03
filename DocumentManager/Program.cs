using Microsoft.Extensions.DependencyInjection;

namespace DocumentManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependencyContainer.ConfigureServices();
            var app = serviceProvider.GetRequiredService<App>();

            app.Run();
        }

        
    }
}
