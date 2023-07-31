using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;


namespace ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataFiltering
{
    public interface IEmployeeFiltersHelpersService<T> where T : Employee
    {
        Task<IQueryable<T>> FilterByCurpBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
        Task<IQueryable<T>> FilterByJobPositionBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
        Task<IQueryable<T>> FilterByDepartmentBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items);
    }
}
