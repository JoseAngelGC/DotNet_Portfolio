using ApiCrudWithBlazor.Core.Helpers.DataFiltering.ColumnContent;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataFiltering;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataFiltering.AbstractsBases;


namespace ApiCrudWithBlazor.Core.Helpers.Services
{
    public class ProductFiltersBasicsHelpersService<T> : IProductFiltersBasicsHelpersService<T> where T : ProductDto
    {
        private BaseDataFilteringHelper<T>? _dataFilteringHelper;
        public async Task<IQueryable<T>> ProductsByNameFilterBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items)
        {            
            if (filters.ColumnNameToFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                _dataFilteringHelper = new ProductsByNameFilterBasicHelper<T>(items);
                items = await _dataFilteringHelper.IQueryableDataFilterAsync(filters);
            }

            return items;
        }
    }
}
