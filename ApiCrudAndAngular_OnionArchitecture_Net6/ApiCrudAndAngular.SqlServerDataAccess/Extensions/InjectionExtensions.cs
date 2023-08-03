using ApiCrudAndAngular.SqlServerDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ApiCrudAndAngular.SqlServerDataAccess.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionSqlServerDataAccess(this IServiceCollection service, IConfiguration configuration)
        {
            //Register DbContext service
            var assembly = typeof(CrudAngularDBContext).Assembly.FullName;
            service.AddDbContext<CrudAngularDBContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("CrudAngular_SqlServerConnectionDev"),
                b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                );

            return service;
        }
    }
}
