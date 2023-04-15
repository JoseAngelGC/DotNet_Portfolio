using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Interactor.Interfaces.EnterpriseBusinessRules.CategoryBusinessRules.Queries.GetEntityItemsList
{
    public interface IGetFilteredCategoryList_EBR
    {
        Task<List<Category>> GetFilteredListAsync(IQueryable<Category> categoryItemsToFilter, GenericFiltersRequestDto filters);
    }
}
