using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using Funq;
using Unity;
using WebApplication1;

namespace WebApplication.UnitTests.Controllers
{
    public class TestAppHost : AppHostBase
    {
        public TestAppHost() : base("AQUARIUS WebPortal API", typeof(Service).Assembly) { }

        public override void Configure(Container container)
        {
            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Adapter = new UnityIocAdapter(WebApplication1.UnityContainer.Instance);

            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
        new IAuthProvider[] {
            new BasicAuthProvider(),       //Sign-in with HTTP Basic Auth
            new CredentialsAuthProvider(), //HTML Form post of UserName/Password credentials
        }));

            var userRepo = new InMemoryAuthRepository();
            container.Register<IAuthRepository>(userRepo);
            //container.Register<IAuthSession>(new AuthUserSession());
            //TestMode = true;
            //WebApplication1.UnityContainer.Instance.RegisterInstance(new AuthUserSession());
        }
    }
}
