using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Filters.Bases
{
    public abstract class EntityItemsBaseFilter<T>
    {
        protected readonly IQueryable<T> _items;
        protected IQueryable<T> _filteredItems;
        public EntityItemsBaseFilter(IQueryable<T> items)
        {
            _items = items;
            _filteredItems = _items;
        }
        public abstract Task<IQueryable<T>> FilterAsync(GenericFiltersRequestDto filters);
    }
}
