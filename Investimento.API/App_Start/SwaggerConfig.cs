using System.Web.Http;
using WebActivatorEx;
using Investimento.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Investimento.API
{
    public static class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Investimento.API");
                    })
                .EnableSwaggerUi();
        }
    }
}
