using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using WebAPI.Abstract.Products;
using WebAPI.Controllers;
using WebAPI.DAL;
using WebAPI.Mapping;
using WebAPI.Services.Products;
using WebAPI.Models;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Dependency Injection
            var builder = new ContainerBuilder();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DummyProductService>().As<IProductService>();
            builder.RegisterType<DataContractMapper>().As<IMapper>();
            builder.RegisterType<AuthService>().As<IAuthService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
