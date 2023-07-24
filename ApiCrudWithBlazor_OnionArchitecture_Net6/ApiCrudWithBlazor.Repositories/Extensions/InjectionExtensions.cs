using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Commands;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Queries;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.Repositories.Context;
using ApiCrudWithBlazor.Repositories.Generics.Commands;
using ApiCrudWithBlazor.Repositories.Generics.Queries;
using ApiCrudWithBlazor.Repositories.ProductRepositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ApiCrudWithBlazor.Repositories.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionRepositories(this IServiceCollection service, IConfiguration configuration)
        {
            //Register DbContext service
            var assembly = typeof(StoreBasicCrudContext).Assembly.FullName;
            service.AddDbContext<StoreBasicCrudContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("Store_SqlServerConnectionDev"),
                b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                );


            //Register generic repositories services
            service.AddTransient(typeof(IGetAllGenericRepository<>), typeof(GetAllGenericRepository<>));
            service.AddTransient(typeof(ISaveGenericRepository<>), typeof(SaveGenericRepository<>));
            service.AddTransient(typeof(IUpdateGenericRepository<>), typeof(UpdateGenericRepository<>));
            service.AddTransient(typeof(IRemoveGenericRepository<>), typeof(RemoveGenericRepository<>));

            //Register product repositories services
            service.AddTransient(typeof(IGetAllProductsRepository<>), typeof(GetAllProductsRepository<>));
            service.AddTransient(typeof(IGetProductDtoByIdRepository<>), typeof(GetProductDtoByIdRepository<>));
            service.AddTransient(typeof(INewProductExistRepository<>), typeof(NewProductExistRepository<>));
            service.AddTransient(typeof(IGetProductByIdRepository<>), typeof(GetProductByIdRepository<>));


            return service;
        }
    }
}
