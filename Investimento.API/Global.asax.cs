using Investimento.API.Interfaces;
using Investimento.API.Services;
using Newtonsoft.Json.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.WebApi;

namespace Investimento.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityConfig.RegisterComponents();

            //config.DependencyResolver = new UnityDependencyResolver(container);
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }
        protected void Application_BeginRequest()
        {
            if (Request.Url.AbsolutePath == "/")
            {
                Response.Redirect("/swagger");
            }
        }
    }
}
