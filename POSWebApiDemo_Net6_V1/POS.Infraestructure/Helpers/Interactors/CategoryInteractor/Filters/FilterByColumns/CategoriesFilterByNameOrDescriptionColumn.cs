using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Filters.Bases;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Filters.FilterByColumns
{
    public class CategoriesFilterByNameOrDescriptionColumn<T> : EntityItemsBaseFilter<T> where T : Category
    {
        public CategoriesFilterByNameOrDescriptionColumn(IQueryable<T> items) : base(items) { }

        public override async Task<IQueryable<T>> FilterAsync(GenericFiltersRequestDto filters)
        {

            if (filters.NumberFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumberFilter)
                {
                    case 1:
                        _filteredItems = _items.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        _filteredItems = _items.Where(x => x.Description!.Contains(filters.TextFilter));
                        break;
                }
            }

            return await Task.FromResult(_filteredItems);
        }
    }
}
