using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganizeHelpers.AbstractsBases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.Core.Helpers.DataOrganizeHelpers.Paginate
{
    public class DataPaginateBasicHelper<T> : BaseDataOrganizeHelper<T> where T : BaseEntity
    {
        public DataPaginateBasicHelper(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> IQueryableDataArrangeAsync(CommonFiltersRequestDto filters)
        {
            var paginatedItems = _items.Skip((filters.NumberPage - 1) * filters.NumberRecordsPage).Take(filters.NumberRecordsPage);
            return await Task.FromResult(paginatedItems);
        }
    }
}
