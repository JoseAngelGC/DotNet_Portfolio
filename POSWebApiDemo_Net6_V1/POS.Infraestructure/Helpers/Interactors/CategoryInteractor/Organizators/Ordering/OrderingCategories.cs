using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Organizators.Bases;
using POS.Infraestructure.SupportDtos.Commons.Requests;
using POS.Utilities.Commons.Consts;
using System.Linq.Dynamic.Core;

namespace POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Organizators.Ordering
{
    public class OrderingCategories<T> : EntityItemsBaseOrganizator<T> where T : Category
    {
        public OrderingCategories(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> OrganizateItemsAsync(GenericFiltersRequestDto filters)
        {
            var orderedItems = filters.Order.ToLower() == OrderingType.DESCEND_ORDERING.ToLower() ? _items.OrderBy($"{filters.Sort} descending") : _items.OrderBy($"{filters.Sort} ascending");
            return await Task.FromResult(orderedItems);
        }
    }
}
