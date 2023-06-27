using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Consts;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Sort;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.OrganizateData.Bases;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Paginate;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.OrganizateData
{
    public class BasicCollectorOrganizateDataHelper : BaseCollectorOrganizateDataHelper
    {
        public override async Task<IQueryable<T>> OrderingAndPaginateDataAsync<T>(CommonFiltersRequestDto filters, IQueryable<T> items)
        {
            if (items is not null)
            {
                /*Implement Liskov SOLID principle for substituting object instance from abstract class father
                * by instance of its abstracts class children */

                //Object Instance from abstract class father
                BaseOrganizateDataHelper<T> objectOrganizateDataHelper;

                /*If filters.Sort is equal to null, then we will assign ProductsColumnToSort.ID_COLUMN value by default*/
                filters.SortByColumn ??= ProductColumnsName.IDPRODUCT_COLUMN;

                //Ordering data funcionality, implemently Liskov SOLID principle
                objectOrganizateDataHelper = new BasicCollectorSortDataHelper<T>(items);
                var orderedData = await objectOrganizateDataHelper.QueryableDataResponseAsync(filters);

                //Paginate data funcionality, implemently Liskov SOLID principle
                objectOrganizateDataHelper = new BasicCollectorPaginateDataHelper<T>(orderedData);
                var orderedPaginatedData = await objectOrganizateDataHelper.QueryableDataResponseAsync(filters);
                items = orderedPaginatedData;
            }
            
            return items!;
        }
    }
}
