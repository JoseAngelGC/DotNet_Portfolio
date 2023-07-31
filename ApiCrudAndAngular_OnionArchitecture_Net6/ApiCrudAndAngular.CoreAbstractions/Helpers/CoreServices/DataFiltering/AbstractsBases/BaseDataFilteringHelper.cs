using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;


namespace ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataFiltering.AbstractsBases
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
