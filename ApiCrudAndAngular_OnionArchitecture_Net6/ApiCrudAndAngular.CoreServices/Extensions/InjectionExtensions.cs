using ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataOrganize;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.CustomsValidatorErrors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Exceptions;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful;
using ApiCrudAndAngular.CoreServices.Helpers.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCrudAndAngular.CoreServices.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionCoreServices(this IServiceCollection service)
        {
            //Register helpers services
            service.AddScoped(typeof(IDataOrganizeBasicsHelpersService<>), typeof(DataOrganizeBasicsHelpersService<>));
            service.AddScoped<ISuccessfulResponsesBasicHelpersService, SuccessfulResponsesBasicHelpersService>();
            service.AddScoped<ICustomValidatorErrorsBasicHelpersService, CustomValidatorErrorsBasicHelpersService>();
            service.AddScoped<IExceptionResponsesBasicHelpersService, ExceptionResponsesBasicHelpersService>();
            service.AddScoped<IErrorResponsesBasicHelpersService, ErrorResponsesBasicHelpersService>();

            return service;
        }
    }
}
