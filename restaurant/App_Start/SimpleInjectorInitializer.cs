[assembly: WebActivator.PostApplicationStartMethod(typeof(restaurant.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace restaurant.App_Start
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Mvc;
    using restaurant.Interface;
    using restaurant.Services;
    using restaurant.Utilities;
    using restaurant.ViewModelFactory;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // For instance:
            container.Register<IRestaurantService, RestaurantService>(Lifestyle.Singleton);
            container.Register<IRestaurantViewModelBuilder, RestaurantViewModelBuilder>(Lifestyle.Singleton);
            container.Register<IWebApiClient, WebApiClient>(Lifestyle.Singleton);
            container.Register<IHttpRequestBuilder, HttpRequestBuilder>(Lifestyle.Singleton);

        }
    }
}