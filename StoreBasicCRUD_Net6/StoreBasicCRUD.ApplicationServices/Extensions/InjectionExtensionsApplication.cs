using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices;
using StoreBasicCRUD.ApplicationServices.Services.Categories;
using StoreBasicCRUD.ApplicationServices.Services.Products;
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
