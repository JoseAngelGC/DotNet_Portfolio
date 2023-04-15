using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Organizators.Bases;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Organizators.Paginate
{
    public class PaginateCategories<T> : EntityItemsBaseOrganizator<T> where T : Category
    {
        public PaginateCategories(IQueryable<T> items) : base(items)
        {
        }

        public override async Task<IQueryable<T>> OrganizateItemsAsync(GenericFiltersRequestDto filters)
        {
            var paginatedItems = _items.Skip((filters.NumberPage - 1) * filters.Records).Take(filters.Records);
            return await Task.FromResult(paginatedItems);
        }
    }
}
