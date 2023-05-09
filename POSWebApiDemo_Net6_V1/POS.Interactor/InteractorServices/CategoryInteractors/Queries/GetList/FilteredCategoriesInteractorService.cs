using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Commons.Requests;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Interactor.Interfaces.EnterpriseBusinessRules.CategoryBusinessRules.Queries.GetEntityItemsList;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetLists;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;

namespace POS.Interactor.InteractorServices.CategoryInteractors.Queries.GetList
{
    internal class FilteredCategoriesInteractorService : QueryInteractorBasicHelpersHub, IFilteredCategoriesInteractor
    {
        private readonly ICategoryRepositoryQueriesUnitsOfWork<Category> _categoryQueriesUnitsOfWork;
        private readonly IGetFilteredCategoryList_EBR _getFilterdCategoryList;
        public FilteredCategoriesInteractorService(IGetFilteredCategoryList_EBR getCategoryListFiltered, ICategoryRepositoryQueriesUnitsOfWork<Category> categoryQueriesUnitsOfWork)
        {
            _getFilterdCategoryList = getCategoryListFiltered;
            _categoryQueriesUnitsOfWork = categoryQueriesUnitsOfWork;
        }

        public async Task<GenericQueryInteractorResponseDto<List<Category>>> GetListAsync(GenericFiltersRequestDto filters)
        {
            try
            {
                IQueryable<Category> categoryItemsToFilter = await _categoryQueriesUnitsOfWork.GenericGetListToFiter.GetQueryableEntityItemsAsync(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null);
                if (categoryItemsToFilter is null)
                {
                    var notFoundCollectorResponse = await QueryInteractorNotFoundBasicCollectorAsync<List<Category>>(null);
                    return await QueryInteractorBasicServiceResponseAsync(notFoundCollectorResponse);
                }

                var filteredCategories = await _getFilterdCategoryList.GetFilteredListAsync(categoryItemsToFilter, filters);
                if (filteredCategories.Count() == 0)
                {
                    var notFoundCollectorResponse = await QueryInteractorNotFoundBasicCollectorAsync<List<Category>>(filteredCategories.Count());
                    return await QueryInteractorBasicServiceResponseAsync(notFoundCollectorResponse);
                }

                var paginatedCategoryList = await _getFilterdCategoryList.ItemsOrganizateAsync(filters, filteredCategories, !(bool)filters.Download!);
                var successCollectorResponse = await QueryInteractorSuccessfulBasicCollectorAsync(paginatedCategoryList, filteredCategories.Count());
                return await QueryInteractorBasicServiceResponseAsync(successCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryInteractorExceptionBasicCollectorAsync<List<Category>>(1100, e.HResult, e.Source);
                return await QueryInteractorBasicServiceResponseAsync(exceptionCollectorResponse);

            }
        }
    }
}
