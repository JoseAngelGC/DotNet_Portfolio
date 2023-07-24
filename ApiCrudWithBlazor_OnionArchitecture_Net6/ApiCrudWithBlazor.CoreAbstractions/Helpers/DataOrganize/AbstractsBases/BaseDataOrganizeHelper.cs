using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganizeHelpers.AbstractsBases
{
    public abstract class BaseDataOrganizeHelper<T> where T : BaseEntity
    {
        protected readonly IQueryable<T> _items;
        public BaseDataOrganizeHelper(IQueryable<T> items)
        {
            _items = items;
        }
        public abstract Task<IQueryable<T>> IQueryableDataArrangeAsync(CommonFiltersRequestDto filters);
    }
}
