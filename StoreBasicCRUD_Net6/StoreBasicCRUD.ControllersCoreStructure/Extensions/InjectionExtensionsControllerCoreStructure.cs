using Microsoft.Extensions.DependencyInjection;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses.Interfaces;

namespace StoreBasicCRUD.ControllersCoreStructure.Extensions
{
    public static class InjectionExtensionsControllerCoreStructure
    {
        public static IServiceCollection AddInjectionControllerCoreStructure(this IServiceCollection service)
        {
            service.AddScoped<IGenericCustomResultResponse, GenericCustomResultResponse>();

            return service;
        }
    }
}
