using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Filters.Bases;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Filters.FilterByState
{
    public class CategoriesFilterByState<T> : EntityItemsBaseFilter<T> where T : Category
    {
        public CategoriesFilterByState(IQueryable<T> items) : base(items) { }
        public override async Task<IQueryable<T>> FilterAsync(GenericFiltersRequestDto filters)
        {
            if (filters.StateFilter is not null)
            {
                _filteredItems = _items.Where(x => x.State.Equals(filters.StateFilter));
            }

            return await Task.FromResult(_filteredItems);
        }
    }
}
