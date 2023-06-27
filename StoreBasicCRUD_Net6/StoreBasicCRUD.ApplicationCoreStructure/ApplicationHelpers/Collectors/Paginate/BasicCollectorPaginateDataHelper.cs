using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.OrganizateData.Bases;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Paginate
{
    public class BasicCollectorPaginateDataHelper<T> : BaseOrganizateDataHelper<T>
    {
        public BasicCollectorPaginateDataHelper(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> QueryableDataResponseAsync(CommonFiltersRequestDto filters)
        {
            var paginatedItems = _items.Skip((filters.NumberPage - 1) * filters.NumberRecordsPage).Take(filters.NumberRecordsPage);
            return await Task.FromResult(paginatedItems);
        }
    }
}
