using Investimento.API.Interfaces;
using Investimento.API.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Investimento.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICdbService, CdbService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}