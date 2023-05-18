using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;
using POS.Persistence.Interfaces.UnitsOfWork.Generics;
using POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork;
using POS.Persistence.Repository.UnitsOfWork.CategoryUnitsOfWork;
using POS.Persistence.Repository.UnitsOfWork.Generics;
using POS.Persistence.Repository.UnitsOfWork.UserUnitsOfWork;

namespace POS.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection service, IConfiguration configuration) 
        {
            var assembly = typeof(POSContext).Assembly.FullName;
            service.AddDbContext<POSContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("POS_SqlServerConnectionDev"),
                b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                );

            service.AddTransient(typeof(IGenericRepositoryQueriesUnitOfWork<>), typeof(GenericRepositoryQueriesUnitOfWork<>));

            service.AddTransient(typeof(ICategoryRepositoryQueriesUnitsOfWork<>), typeof(CategoryRepositoryQueriesUnitsOfWork<>));
            service.AddTransient(typeof(ICategoryRepositoryCommandsUnitsOfWork<>), typeof(CategoryRepositoryCommandsUnitsOfWork<>));
            service.AddTransient(typeof(IUserQueriesUnitOfWork<>), typeof(UserQueriesUnitOfWork<>));
            service.AddTransient(typeof(IUserCommandsUnitOfWork<>), typeof(UserCommandsUnitOfWork<>));

            return service;
        }
    }
}
