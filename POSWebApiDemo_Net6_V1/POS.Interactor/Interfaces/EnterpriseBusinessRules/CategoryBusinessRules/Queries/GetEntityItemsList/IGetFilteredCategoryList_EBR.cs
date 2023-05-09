using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Interactor.Interfaces.EnterpriseBusinessRules.CategoryBusinessRules.Queries.GetEntityItemsList
{
    public interface IGetFilteredCategoryList_EBR
    {
        Task<IQueryable<Category>> GetFilteredListAsync(IQueryable<Category> categoryItemsToFilter, GenericFiltersRequestDto filters);
        Task<List<Category>> ItemsOrganizateAsync(GenericFiltersRequestDto filters, IQueryable<Category> items, bool pagination = false);
    }
}
