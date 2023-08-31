using ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases;
using ApiCrudAndAngular.UseCases.DepartmentUseCases;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApiCrudAndAngular.UseCases.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionUseCases(this IServiceCollection service)
        {
            //Register automapper assemblies
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Register Department use cases services
            service.AddScoped(typeof(IShowAllDepartmentsUseCase<>), typeof(ShowAllDepartmentsUseCase<>));
            service.AddScoped(typeof(IShowDepartmentByIdUseCase<>), typeof(ShowDepartmentByIdUseCase<>));
            service.AddScoped(typeof(ICreateNewDepartmentUseCase<>), typeof(CreateNewDepartmentUseCase<>));
            service.AddScoped(typeof(IUpdateDepartmentUseCase<>), typeof(UpdateDepartmentUseCase<>));
            service.AddScoped(typeof(IRemoveDepartmentUseCase<>), typeof(RemoveDepartmentUseCase<>));

            return service;
        }
    }
}
