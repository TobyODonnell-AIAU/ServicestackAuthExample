using ServiceStack;

namespace WebApplication1
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseServiceStack(new AppHost());
            app.UseMvcWithRoutes();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

        }
    }

    public static class RouteConfig
    {
        public static void UseMvcWithRoutes(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "Privacy", template: "Privacy", defaults: new { controller = "Home", action = "Privacy" });
                routes.MapRoute(name: "Default", template: "", defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
