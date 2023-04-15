using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetLists;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;

namespace POS.Interactor.InteractorServices.CategoryInteractors.Queries.GetList
{
    public class AllCategoriesInteractorService : QueryInteractorBasicHelpersHub, IAllCategoriesInteractor
    {
        private readonly ICategoryRepositoryQueriesUnitsOfWork<Category> _categoryQueriesUnitsOfWork;
        public AllCategoriesInteractorService(ICategoryRepositoryQueriesUnitsOfWork<Category> categoryQueriesUnitsOfWork)
        {
            _categoryQueriesUnitsOfWork = categoryQueriesUnitsOfWork;
        }

        public async Task<GenericQueryInteractorResponseDto<IEnumerable<Category>>> GetItemsAsync()
        {
            try
            {
                IEnumerable<Category> categoryAllItems = await _categoryQueriesUnitsOfWork.GenericGetAllList.GetQueryableAsync();
                if (categoryAllItems is null)
                {
                    var notFoundCollectorResponse = await QueryInteractorNotFoundBasicCollectorAsync<IEnumerable<Category>>(null);
                    return await QueryInteractorBasicServiceResponseAsync(notFoundCollectorResponse);
                }

                var successCollectorResponse = await QueryInteractorSuccessfulBasicCollectorAsync(categoryAllItems, categoryAllItems.Count());
                return await QueryInteractorBasicServiceResponseAsync(successCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryInteractorExceptionBasicCollectorAsync<IEnumerable<Category>>(1200, e.HResult, e.Source);
                return await QueryInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
            }

        }
    }
}
