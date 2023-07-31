using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;


namespace ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataOrganize.AbstractsBases
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
