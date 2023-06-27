using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterData.Bases
{
    public abstract class BaseFilterDataHelper<T> where T : ProductDto
    {
        protected readonly IQueryable<T> _items;
        protected IQueryable<T> _filteredItems;
        public BaseFilterDataHelper(IQueryable<T> items)
        {
            _items = items;
            _filteredItems = _items;
        }
        public abstract Task<IQueryable<T>> ExecuteFilterAsync(CommonFiltersRequestDto filters);
    }
}
