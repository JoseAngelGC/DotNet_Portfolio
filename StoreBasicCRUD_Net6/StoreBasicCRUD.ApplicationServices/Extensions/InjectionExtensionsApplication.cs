using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices.Queries;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Commands;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Queries;
using StoreBasicCRUD.ApplicationServices.Services.Categories.Queries;
using StoreBasicCRUD.ApplicationServices.Services.Products.Commands;
using StoreBasicCRUD.ApplicationServices.Services.Products.Queries;
using StoreBasicCRUD.ApplicationServices.Validators.Products;
using System.Reflection;

namespace StoreBasicCRUD.ApplicationServices.Extensions
{
    public static class InjectionExtensionsApplication
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection service, IConfiguration configuration)
        {
            //Configurations
            service.AddSingleton(configuration);
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddValidatorsFromAssemblyContaining<ProductRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<ProductPivotDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<ProductFiltersRequestDtoValidator>(ServiceLifetime.Transient);

            //Queries
            service.AddScoped<IGetAllProductsService, GetAllProductsService>();
            service.AddScoped<IGetProductByIdService, GetProductByIdService>();
            service.AddScoped<IGetAllCategoriesService, GetAllCategoriesService>();

            //Commands
            service.AddScoped<ISaveProductService, SaveProductService>();
            service.AddScoped<IUpdateProductService, UpdateProductService>();
            service.AddScoped<IRemoveProductService, RemoveProductService>();

            return service;
        }
    }
}
