using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.Helpers.DataFiltering
{
    public interface IProductFiltersBasicsHelpersService<T> where T : BaseEntity
    {
        Task<IQueryable<T>> ProductsByNameFilterBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
    }
}
