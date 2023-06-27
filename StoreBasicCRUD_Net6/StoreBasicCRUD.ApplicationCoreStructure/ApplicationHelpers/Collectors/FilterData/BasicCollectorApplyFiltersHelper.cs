using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterByColumnContent;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterData.Bases;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterData
{
    public class BasicCollectorApplyFiltersHelper : BaseCollectorApplyFiltersHelper
    {
        public override async Task<IQueryable<ProductDto>> FilterDataAsync(CommonFiltersRequestDto filters, IQueryable<ProductDto> items)
        {
            if (items is not null)
            {
                /*Implement Liskov SOLID principle for substituting object instance from abstract class father
                * by instance of its abstracts class children */

                //Object Instance from abstract class father
                BaseFilterDataHelper<ProductDto> objectFilterDataHelper;

                //Filter by column content
                if (!string.IsNullOrEmpty(filters.ColumnNameToFilter) && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    objectFilterDataHelper = new BasicCollectorFilterByColumnHelper<ProductDto>(items);
                    items = await objectFilterDataHelper.ExecuteFilterAsync(filters);
                }

                //Implement filter 2

                //Implement filter 3

                //Implement filter ...

            }

            return items!;
        }
    }
}
