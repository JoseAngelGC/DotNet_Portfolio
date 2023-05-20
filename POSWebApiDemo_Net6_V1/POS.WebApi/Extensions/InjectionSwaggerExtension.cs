using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace POS.WebApi.Extensions
{
    public static class InjectionSwaggerExtension
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection service)
        {
            var openApi = new OpenApiInfo
            {
                Title = "POS API Net6",
                Version = "v1",
                Description = "Demo Punto de Venta 2023",
                TermsOfService = new Uri("https://opensource.org/licenses/NIT"),
                Contact = new OpenApiContact
                {
                    Name = "Jose Angel Contreras",
                    Email = "emailTem@gmail.com",
                    Url = new Uri("https://portaldev.com.mx") 
                },
                License = new OpenApiLicense
                {
                    Name= "License",
                    Url = new Uri("https://opensource.org/licenses/")
                }
            };

            service.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1",openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "JWT Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securityScheme.Reference.Id,securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[] {} }
                });
            });

            return service;
        }
    }
}
