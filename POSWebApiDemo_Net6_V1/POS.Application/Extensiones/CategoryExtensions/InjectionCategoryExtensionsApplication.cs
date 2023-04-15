using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces.CategoryServices.Commands.RemoveItem;
using POS.Application.Interfaces.CategoryServices.Commands.SaveItem;
using POS.Application.Interfaces.CategoryServices.Commands.UpdateItem;
using POS.Application.Interfaces.CategoryServices.Queries.GetItem;
using POS.Application.Interfaces.CategoryServices.Queries.GetLists;
using POS.Application.Services.CategoryServices.Commands.RemoveItem;
using POS.Application.Services.CategoryServices.Commands.SaveItem;
using POS.Application.Services.CategoryServices.Commands.UpdateItem;
using POS.Application.Services.CategoryServices.Queries.GetItem;
using POS.Application.Services.CategoryServices.Queries.GetLists;
using POS.Application.Validators.CategoryValidators.Commands.Commons;
using POS.Application.Validators.CategoryValidators.Commands.SaveItemRequests;
using POS.Application.Validators.Commons.Queries.GetFilteredList;
using POS.Application.Validators.Commons.Queries.GetItemById;
using System.Reflection;

namespace POS.Application.Extensiones.CategoryExtensions
{
    public static class InjectionCategoryExtensionsApplication
    {
        public static IServiceCollection AddInjectionCategoryApplication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton(configuration);
            service.AddValidatorsFromAssemblyContaining<CategoryRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<CategoryRequesPlusDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<GenericFiltersRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<IdParamRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Queries
            service.AddScoped<IFilteredCategoriesApplicationService, FilteredCategoriesApplicationService>();
            service.AddScoped<IAllCategoriesApplicationService, AllCategoriesApplicationService>();
            service.AddScoped<ICategoryByIdApplicationService, CategoryByIdApplicationService>();

            //Commands
            service.AddScoped<IAddCategoryApplication,AddCategoryApplicationService>();
            service.AddScoped<IAlterCategoryApplication, AlterCategoryApplicationService>();
            service.AddScoped<IDeleteCategoryApplication, DeleteCategoryApplicationService>();

            return service;
        }
    }
}
