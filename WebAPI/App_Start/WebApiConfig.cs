using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebAPI.Abstract.Products;
using WebAPI.Impl.Products;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Autofac
            var builder = new ContainerBuilder();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DummyProductService>().As<IProductService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
