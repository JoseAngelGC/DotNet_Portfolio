using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.Helpers.DataFiltering.AbstractsBases
{
    public abstract class BaseDataFilteringHelper<T> where T : BaseEntity
    {
        protected readonly IQueryable<T> _items;
        public BaseDataFilteringHelper(IQueryable<T> items)
        {
            _items = items;
        }
        public abstract Task<IQueryable<T>> IQueryableDataFilterAsync(CommonFiltersRequestDto filters);
    }
}
