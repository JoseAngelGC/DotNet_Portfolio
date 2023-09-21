using ApiCrudAndAngular.ApplicationServices.InputPorts.DepartmentInputPorts;
using ApiCrudAndAngular.ApplicationServices.OutputPorts;
using ApiCrudAndAngular.ApplicationServices.Validators.DepartmentValidators;
using ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCrudAndAngular.ApplicationServices.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplicationServices(this IServiceCollection service)
        {
            //Register OutputPorts Services
            service.AddScoped<IOutputPortsCommandResponses, OutputPortsCommandResponses>();
            service.AddScoped<IOutputPortsQueryResponses, OutputPortsQueryResponses>();

            //Register department input ports services
            service.AddScoped<IDepartmentQueriesInputPortsService, DepartmentQueriesInputPortsService>();
            service.AddScoped<IDepartmentNewRecordInputPortsService, DepartmentNewRecordInputPortsService>();
            service.AddScoped<IDepartmentChangesRecordInputPortsService, DepartmentChangesRecordInputPortsService>();
            //Register department validators services
            service.AddValidatorsFromAssemblyContaining<DepartmentRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<DepartmentRequestDtoInternalValidator>(ServiceLifetime.Transient);

            return service;
        }
    }
}
