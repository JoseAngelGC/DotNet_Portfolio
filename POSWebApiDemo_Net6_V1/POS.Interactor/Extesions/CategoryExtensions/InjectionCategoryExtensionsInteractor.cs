using Microsoft.Extensions.DependencyInjection;
using POS.Interactor.EnterpriseBusinessRules.CategoryBusinessRules.Queries.GetEntityItemsList;
using POS.Interactor.InteractorServices.CategoryInteractors.Commands.RemoveItem;
using POS.Interactor.InteractorServices.CategoryInteractors.Commands.SaveItem;
using POS.Interactor.InteractorServices.CategoryInteractors.Commands.UpdateItem;
using POS.Interactor.InteractorServices.CategoryInteractors.Queries.GetItem;
using POS.Interactor.InteractorServices.CategoryInteractors.Queries.GetList;
using POS.Interactor.Interfaces.EnterpriseBusinessRules.CategoryBusinessRules.Queries.GetEntityItemsList;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.RemoveItem;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.SaveItem;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.UpdateItem;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetItem;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetLists;

namespace POS.Interactor.Extesions.CategoryExtensions
{
    public static class InjectionCategoryExtensionsInteractor
    {
        public static IServiceCollection AddInjectionCategoryInteractor(this IServiceCollection service)
        {
            //Queries Services
            service.AddTransient<IFilteredCategoriesInteractor, FilteredCategoriesInteractorService>();
            service.AddTransient<IAllCategoriesInteractor, AllCategoriesInteractorService>();
            service.AddTransient<ICategoryByIdInteractor, CategoryByIdInteractorService>();

            //Commands Services
            service.AddTransient<IAddCategoryInteractor, AddCategoryInteractorService>();
            service.AddTransient<IAlterCategoryInteractor, AlterCategoryInteractorService>();
            service.AddTransient<IDeleteCategoryInteractor, DeleteCategoryInteractorService>();

            //Enterprise Business Rules
            service.AddTransient<IGetFilteredCategoryList_EBR, GetFilteredCategoryList_EBR>();

            return service;
        }
    }
}
