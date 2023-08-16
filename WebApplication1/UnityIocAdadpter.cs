using Unity;
using ServiceStack.Configuration;
using Unity.Injection;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class UnityIocAdapter : IContainerAdapter
    {
        private readonly IUnityContainer container;

        public UnityIocAdapter(IUnityContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public T TryResolve<T>()
        {
            if (container.IsRegistered<T>())
            {
                return container.Resolve<T>();
            }

            return default(T);
        }
    }

    public static class UnityContainer
    {
        private static readonly Lazy<IUnityContainer> _instance = new Lazy<IUnityContainer>(CreateInstance);

        public static IUnityContainer Instance => _instance.Value;

        private static IUnityContainer CreateInstance()
        {
            var instance = new Unity.UnityContainer();
            instance.RegisterType<HomeController>();
            return instance;
        }
    }
}