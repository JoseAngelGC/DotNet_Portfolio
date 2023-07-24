using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ApiControllersResponses;
using ApiCrudWithBlazor.WebApi.Helpers.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudWithBlazor.WebApi.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionWebApiServices(this IServiceCollection service, string corsName)
        {
            //Register controller helpers services
            service.AddScoped<IControllerResponsesBasicsHelpersService, ControllerResponsesBasicsHelpersService>();

            //Cors service configuration
            service.AddCors(options =>
            {
                options.AddPolicy(name: corsName, builder =>
                {
                    builder.WithOrigins("*");
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            //Versioning service configuration
            service.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            return service;
        }
    }
}
