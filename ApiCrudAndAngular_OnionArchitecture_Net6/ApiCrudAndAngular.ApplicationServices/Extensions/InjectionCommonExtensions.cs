using ApiCrudAndAngular.ApplicationServices.OutputPorts;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCrudAndAngular.ApplicationServices.Extensions
{
    public static class InjectionCommonExtensions
    {
        public static IServiceCollection AddInjectionApplicationCommonsServices(this IServiceCollection service)
        {
            service.AddScoped<IOutputPortsCommandResponses, OutputPortsCommandResponses>();
            service.AddScoped<IOutputPortsQueryResponses, OutputPortsQueryResponses>();

            return service;
        }
    }
}
