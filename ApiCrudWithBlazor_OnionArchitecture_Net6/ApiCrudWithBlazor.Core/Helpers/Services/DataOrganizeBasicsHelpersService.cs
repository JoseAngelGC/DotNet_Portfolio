using ApiCrudWithBlazor.Core.Helpers.DataOrganizate.Sort;
using ApiCrudWithBlazor.Core.Helpers.DataOrganizeHelpers.Paginate;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganize;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganizeHelpers.AbstractsBases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;

namespace ApiCrudWithBlazor.Core.Helpers.Services
{
    public class DataOrganizeBasicsHelpersService<T> : IDataOrganizeBasicsHelpersService<T> where T: BaseEntity
    {
        private  BaseDataOrganizeHelper<T>? _baseDataOrganizeHelper;
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
