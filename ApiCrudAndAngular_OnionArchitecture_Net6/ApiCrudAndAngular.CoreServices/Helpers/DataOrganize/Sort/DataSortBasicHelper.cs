using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataOrganize.AbstractsBases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;
using System.Linq.Dynamic.Core;

namespace ApiCrudAndAngular.CoreServices.Helpers.DataOrganize.Sort
{
    internal class DataSortBasicHelper<T> : BaseDataOrganizeHelper<T> where T : BaseEntity
    {
        public DataSortBasicHelper(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> IQueryableDataArrangeAsync(CommonFiltersRequestDto filters)
        {
            /*If filters.SortByColumn is equal to null, then we will assign
              ProductColumnNameConstants.IDPRODUCT_COLUMN value by default*/
            filters.SortByColumn ??= "Id";

            var orderedItems = filters.OrderType.ToLower() == SortingConstants.DESCEND_ORDERING.ToLower() ? _items.OrderBy($"{filters.SortByColumn} descending") : _items.OrderBy($"{filters.SortByColumn} ascending");
            return await Task.FromResult(orderedItems);
        }
    }
}
