using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories;
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
                options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionDev"),
                b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                );


            service.AddTransient(typeof(IDepartmentQueryActionsRespository<>), typeof(DepartmentQueryActionsRespository<>));
            service.AddTransient(typeof(IDepartmentCommandActionsRepository<>), typeof(DepartmentCommandActionsRepository<>));
            service.AddTransient(typeof(IDepartmentExistsRecordRepository<>), typeof(DepartmentExistsRecordRepository<>));

            return service;
        }
    }
}
