using ServiceStack;
using Unity.Microsoft.DependencyInjection;

namespace WebApplication1
{
    public class Program
    {
        static Program()
        {
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
                .UseUnityServiceProvider(UnityContainer.Instance)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
