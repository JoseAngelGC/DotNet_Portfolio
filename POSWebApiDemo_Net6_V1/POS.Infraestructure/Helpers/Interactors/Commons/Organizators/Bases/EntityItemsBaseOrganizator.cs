using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Organizators.Bases
{
    public abstract class EntityItemsBaseOrganizator<T>
    {
        protected readonly IQueryable<T> _items;
        public EntityItemsBaseOrganizator(IQueryable<T> items)
        {
            _items = items;
        }

        public abstract Task<IQueryable<T>> OrganizateItemsAsync(GenericFiltersRequestDto filters);
    }
}
