﻿using ApiCrudAndAngular.CoreAbstractions.Helpers.ApiControllers.Responses;
using ApiCrudAndAngular.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudAndAngular.WebApi.Extentions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionWebApiServices(this IServiceCollection service)
        {
            //Register controller helpers services
            service.AddScoped<IControllerBasicResponsesHelpersService, ControllerBasicResponsesHelpersService>();

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
