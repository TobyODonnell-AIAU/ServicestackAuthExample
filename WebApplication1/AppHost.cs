using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using Funq;
using Unity;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("AQUARIUS WebPortal API", typeof(Service).Assembly) { }

        public override void Configure(Container container)
        {
            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Adapter = new UnityIocAdapter(UnityContainer.Instance);

            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
        new IAuthProvider[] {
            new BasicAuthProvider(),       //Sign-in with HTTP Basic Auth
            new CredentialsAuthProvider(), //HTML Form post of UserName/Password credentials
        }));

            var userRepo = new InMemoryAuthRepository();
            container.Register<IAuthRepository>(userRepo);
        }
    }
}
