using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;


namespace ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataOrganize
{
    public interface IDataOrganizeBasicsHelpersService<T> where T : BaseEntity
    {
        Task<IQueryable<T>> DataPaginateBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
        Task<IQueryable<T>> DataSortBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
    }
}
