using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Consts;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterData.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.FilterByColumnContent
{
    public class BasicCollectorFilterByColumnHelper<T> : BaseFilterDataHelper<T> where T : ProductDto
    {
        public BasicCollectorFilterByColumnHelper(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> ExecuteFilterAsync(CommonFiltersRequestDto filters)
        {
            if (filters.ColumnNameToFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.ColumnNameToFilter)
                {
                    case ProductColumnsName.NAME_COLUMN:
                        _filteredItems = _items.Where(x => x.Nombre!.Contains(filters.TextFilter));
                        break;
                    case ProductColumnsName.CATEGORY_COLUMN:
                        _filteredItems = _items.Where(x => x.Category!.Contains(filters.TextFilter));
                        break;
                }
            }

            return await Task.FromResult(_filteredItems);
        }
    }
}
