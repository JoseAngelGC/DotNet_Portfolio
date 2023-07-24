using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganize
{
    public interface IDataOrganizeBasicsHelpersService<T> where T : BaseEntity
    {
        Task<IQueryable<T>> DataPaginateBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
        Task<IQueryable<T>> DataSortBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
    }
}
