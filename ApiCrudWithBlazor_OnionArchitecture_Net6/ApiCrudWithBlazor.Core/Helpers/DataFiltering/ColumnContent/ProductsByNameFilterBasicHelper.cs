using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataFiltering.AbstractsBases;


namespace ApiCrudWithBlazor.Core.Helpers.DataFiltering.ColumnContent
{
    public class ProductsByNameFilterBasicHelper<T> : BaseDataFilteringHelper<T> where T : ProductDto
    {
        public ProductsByNameFilterBasicHelper(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> IQueryableDataFilterAsync(CommonFiltersRequestDto filters)
        {
            if (filters.ColumnNameToFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                var response = _items.Where(x => x.Nombre!.Contains(filters.TextFilter));
                return await Task.FromResult(response);
            }

            return await Task.FromResult(_items);
        }
    }
}
