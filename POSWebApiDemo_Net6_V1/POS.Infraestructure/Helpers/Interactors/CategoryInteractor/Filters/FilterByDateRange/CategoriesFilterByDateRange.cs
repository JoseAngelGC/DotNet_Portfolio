using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Filters.Bases;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Filters.FilterByDateRange
{
    public class CategoriesFilterByDateRange<T> : EntityItemsBaseFilter<T> where T : Category
    {
        public CategoriesFilterByDateRange(IQueryable<T> entity) : base(entity) { }
        public override async Task<IQueryable<T>> FilterAsync(GenericFiltersRequestDto filters)
        {
            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                _filteredItems = _items.Where(x => x.AuditCreateDate > Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate < Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            return await Task.FromResult(_filteredItems);
        }
    }
}
