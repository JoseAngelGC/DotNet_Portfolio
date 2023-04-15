using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetItem;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;

namespace POS.Interactor.InteractorServices.CategoryInteractors.Queries.GetItem
{
    public class CategoryByIdInteractorService : QueryInteractorBasicHelpersHub, ICategoryByIdInteractor
    {
        private readonly ICategoryRepositoryQueriesUnitsOfWork<Category> _categoryQueriesUnitsOfWork;
        public CategoryByIdInteractorService(ICategoryRepositoryQueriesUnitsOfWork<Category> categoryQueriesUnitsOfWork)
        {
            _categoryQueriesUnitsOfWork = categoryQueriesUnitsOfWork;
        }
        public async Task<GenericQueryInteractorResponseDto<Category>> GetItemAsync(int id)
        {
            try
            {
                GenericQueryInteractorResponseDto<Category> successResponse = new();
                var categoryById = await _categoryQueriesUnitsOfWork.GenericGetEntityItemById.GetItemAsync(id);
                if (categoryById is null)
                {
                    var notFoundCollectorResponse = await QueryInteractorNotFoundBasicCollectorAsync<Category>(null);
                    return await QueryInteractorBasicServiceResponseAsync(notFoundCollectorResponse);
                }

                var successCollectorResponse = await QueryInteractorSuccessfulBasicCollectorAsync(categoryById, 1);
                return await QueryInteractorBasicServiceResponseAsync(successCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryInteractorExceptionBasicCollectorAsync<Category>(1300, e.HResult, e.Source);
                return await QueryInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
            }

        }
    }
}
