using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.Persistence_SQLServer.UnitsOfWork;

namespace StoreBasicCRUD.Persistence_SQLServer.Extensions
{
    public static class InjectionExtensionsPersistence
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection service, IConfiguration configuration)
        {
            var assembly = typeof(StoreBasicCrudContext).Assembly.FullName;
            service.AddDbContext<StoreBasicCrudContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("Store_SqlServerConnectionDev"),
                b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                );

            service.AddTransient(typeof(IProductsUnitOfWork<>), typeof(ProductsUnitOfWork<>));
            service.AddTransient(typeof(ICategoriesUnitOfWork<>), typeof(CategoriesUnitOfWork<>));

            return service;
        }
    }
}
