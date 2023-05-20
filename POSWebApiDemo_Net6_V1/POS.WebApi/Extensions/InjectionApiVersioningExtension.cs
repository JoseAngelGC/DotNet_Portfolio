using Microsoft.AspNetCore.Mvc;

namespace POS.WebApi.Extensions
{
    public static class InjectionApiVersioningExtension
    {
        public static IServiceCollection AddInjectionApiVersioning(this IServiceCollection service)
        {
            service.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1,0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            return service;
        }
    }
}
