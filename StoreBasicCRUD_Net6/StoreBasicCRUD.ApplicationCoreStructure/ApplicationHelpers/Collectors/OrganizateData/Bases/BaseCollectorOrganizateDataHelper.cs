using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.OrganizateData.Bases
{
    public abstract class BaseCollectorOrganizateDataHelper
    {
        public abstract Task<IQueryable<T>> OrderingAndPaginateDataAsync<T>(CommonFiltersRequestDto filters, IQueryable<T> items);
    }
}
