using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataOrganize.AbstractsBases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;

namespace ApiCrudAndAngular.CoreServices.Helpers.DataOrganize.Paginate
{
    internal class DataPaginateBasicHelper<T> : BaseDataOrganizeHelper<T> where T : BaseEntity
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
