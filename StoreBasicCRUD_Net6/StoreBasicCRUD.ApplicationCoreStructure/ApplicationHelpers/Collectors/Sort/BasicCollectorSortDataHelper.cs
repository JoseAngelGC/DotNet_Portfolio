using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.OrganizateData.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;
using System.Linq.Dynamic.Core;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Sort
{
    public class BasicCollectorSortDataHelper<T> : BaseOrganizateDataHelper<T>
    {
        public BasicCollectorSortDataHelper(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> QueryableDataResponseAsync(CommonFiltersRequestDto filters)
        {
            var orderedItems = filters.OrderType.ToLower() == OrderType.DESCEND_ORDERING.ToLower() ? _items.OrderBy($"{filters.SortByColumn} descending") : _items.OrderBy($"{filters.SortByColumn} ascending");
            return await Task.FromResult(orderedItems);
        }
    }
}
