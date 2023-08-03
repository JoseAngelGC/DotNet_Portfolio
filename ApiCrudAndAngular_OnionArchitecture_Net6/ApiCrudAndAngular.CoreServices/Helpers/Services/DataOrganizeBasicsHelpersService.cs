using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataOrganize;
using ApiCrudAndAngular.CoreAbstractions.Helpers.CoreServices.DataOrganize.AbstractsBases;
using ApiCrudAndAngular.CoreServices.Helpers.DataOrganize.Paginate;
using ApiCrudAndAngular.CoreServices.Helpers.DataOrganize.Sort;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;


namespace ApiCrudAndAngular.CoreServices.Helpers.Services
{
    public class DataOrganizeBasicsHelpersService<T> : IDataOrganizeBasicsHelpersService<T> where T : BaseEntity
    {
        private BaseDataOrganizeHelper<T>? _baseDataOrganizeHelper;
        public async Task<IQueryable<T>> DataPaginateBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items)
        {
            if (items is not null)
            {
                _baseDataOrganizeHelper = new DataPaginateBasicHelper<T>(items);
                items = await _baseDataOrganizeHelper.IQueryableDataArrangeAsync(filters);
            }

            return items!;
        }

        public async Task<IQueryable<T>> DataSortBasicHelperAsync(CommonFiltersRequestDto filters, IQueryable<T> items)
        {
            if (items is not null)
            {
                _baseDataOrganizeHelper = new DataSortBasicHelper<T>(items);
                items = await _baseDataOrganizeHelper.IQueryableDataArrangeAsync(filters);
            }

            return items!;
        }
    }
}
