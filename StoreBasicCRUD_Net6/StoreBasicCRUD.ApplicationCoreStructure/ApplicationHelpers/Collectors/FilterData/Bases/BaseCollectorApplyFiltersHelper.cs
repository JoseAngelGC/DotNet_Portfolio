using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterData.Bases
{
    public abstract class BaseCollectorApplyFiltersHelper
    {
        public abstract Task<IQueryable<ProductDto>> FilterDataAsync(CommonFiltersRequestDto filters, IQueryable<ProductDto> items);
    }
}
