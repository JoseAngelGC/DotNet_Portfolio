using ApiCrudWithBlazor.Core.Helpers.Services;
using ApiCrudWithBlazor.Core.UseCases.CategoryUseCases;
using ApiCrudWithBlazor.Core.UseCases.ProductUseCases;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataFiltering;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganize;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.CategoryUseCases;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApiCrudWithBlazor.Core.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionCore(this IServiceCollection service)
        {
            //Register automapper assemblies
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Register Category use cases services
            service.AddScoped(typeof(ICategoriesListUseCase<>), typeof(CategoriesListUseCase<>));

            //Register Product use cases services
            service.AddScoped(typeof(IFilteredProductsUseCase<>), typeof(FilteredProductsUseCase<>));
            service.AddScoped(typeof(IShowProductUseCase<>), typeof(ShowProductUseCase<>));
            service.AddScoped(typeof(INewProductRegisterUseCase<>), typeof(NewProductRegisterUseCase<>));
            service.AddScoped(typeof(IProductEditUseCase<>), typeof(ProductEditUseCase<>));
            service.AddScoped(typeof(IProductDeleteUseCase<>), typeof(ProductDeleteUseCase<>));

            //Register helpers services
            service.AddScoped(typeof(IDataOrganizeBasicsHelpersService<>), typeof(DataOrganizeBasicsHelpersService<>));
            service.AddScoped(typeof(IProductFiltersBasicsHelpersService<>), typeof(ProductFiltersBasicsHelpersService<>));

            return service;
        }
    }
}
