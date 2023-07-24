using ApiCrudWithBlazor.Core.Abstraction.Utilities.Constants;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganizeHelpers.AbstractsBases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;
using System.Linq.Dynamic.Core;

namespace ApiCrudWithBlazor.Core.Helpers.DataOrganizate.Sort
{
    public class DataSortBasicHelper<T> : BaseDataOrganizeHelper<T> where T : BaseEntity
    {
        public DataSortBasicHelper(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> IQueryableDataArrangeAsync(CommonFiltersRequestDto filters)
        {
            /*If filters.SortByColumn is equal to null, then we will assign
              ProductColumnNameConstants.IDPRODUCT_COLUMN value by default*/
            filters.SortByColumn ??= ProductColumnNameConstants.IDPRODUCT_COLUMN;

            var orderedItems = filters.OrderType.ToLower() == SortingConstants.DESCEND_ORDERING.ToLower() ? _items.OrderBy($"{filters.SortByColumn} descending") : _items.OrderBy($"{filters.SortByColumn} ascending");
            return await Task.FromResult(orderedItems);
        }
    }
}
