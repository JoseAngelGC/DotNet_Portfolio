using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;


namespace ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataFiltering
{
    public interface IGenericFiltersBasicsHelpersService<T> where T : BaseEntity
    {
        Task<IQueryable<T>> FilterByNameBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
    }
}
