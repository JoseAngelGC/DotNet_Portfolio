using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.OrganizateData.Bases
{
    public abstract class BaseOrganizateDataHelper<T>
    {
        protected readonly IQueryable<T> _items;
        public BaseOrganizateDataHelper(IQueryable<T> items)
        {
            _items = items;
        }

        public abstract Task<IQueryable<T>> QueryableDataResponseAsync(CommonFiltersRequestDto filters);
    }
}
