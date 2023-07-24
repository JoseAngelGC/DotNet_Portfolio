using ApiCrudWithBlazor.ApplicationServices.Helpers.Services;
using ApiCrudWithBlazor.ApplicationServices.InputPortsServices;
using ApiCrudWithBlazor.ApplicationServices.OutputPorstServices;
using ApiCrudWithBlazor.ApplicationServices.Validators.ProductValidator;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions;
using ApiCrudWithBlazor.CoreAbstractions.InputPorts;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace ApiCrudWithBlazor.ApplicationServices.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplicationServices(this IServiceCollection service)
        {
            //Register validators services
            service.AddValidatorsFromAssemblyContaining<ProductFiltersRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<ProductRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<ProductRequestPivotDtoValidator>(ServiceLifetime.Transient);

            //Register helpers services
            service.AddScoped<ISuccessfulResponseBasicsHelpersService, SuccessfulResponseBasicsHelpersService>();
            service.AddScoped<IErrorResponseBasicsHelpersService, ErrorResponseBasicsHelpersService>();
            service.AddScoped<IExceptionResponseBasicsHelpersService, ExceptionResponseBasicsHelpersService>();
            service.AddScoped<ICustomErrorResponsesBasicsHelpersService, CustomErrorResponsesBasicsHelpersService>();

            //Register InputPorts Services
            service.AddScoped<ICategoryInputPortsService, CategoryInputPortsService>();
            service.AddScoped<IProductInputPortsService, ProductInputPortsService>();

            //Register OutputPorts Services
            service.AddScoped<IResponsesOutputPortsBasicHelpersHub, ResponsesOutputPortsBasicHelpersHub>();

            return service;
        }
    }
}
