using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Filters.FilterByColumns;
using POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Filters.FilterByDateRange;
using POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Filters.FilterByState;
using POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Organizators.Ordering;
using POS.Infraestructure.Helpers.Interactors.CategoryInteractor.Organizators.Paginate;
using POS.Infraestructure.Helpers.Interactors.Commons.Filters.Bases;
using POS.Infraestructure.Helpers.Interactors.Commons.Organizators.Bases;
using POS.Infraestructure.SupportDtos.Commons.Requests;
using POS.Interactor.Interfaces.EnterpriseBusinessRules.CategoryBusinessRules.Queries.GetEntityItemsList;
using POS.Utilities.CategoryUtilities.Consts;

namespace POS.Interactor.EnterpriseBusinessRules.CategoryBusinessRules.Queries.GetEntityItemsList
{
    public class GetFilteredCategoryList_EBR : IGetFilteredCategoryList_EBR
    {
        public async Task<IQueryable<Category>> GetFilteredListAsync(IQueryable<Category> categoryItems, GenericFiltersRequestDto filters)
        {

            if (categoryItems is not null)
            {
                EntityItemsBaseFilter<Category> BaseFilter;
                if (filters.NumberFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
                {
                    BaseFilter = new CategoriesFilterByNameOrDescriptionColumn<Category>(categoryItems);
                    categoryItems = await BaseFilter.FilterAsync(filters);
                }

                if (filters.StateFilter is not null)
                {
                    BaseFilter = new CategoriesFilterByState<Category>(categoryItems);
                    categoryItems = await BaseFilter.FilterAsync(filters);
                }

                if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
                {
                    BaseFilter = new CategoriesFilterByDateRange<Category>(categoryItems);
                    categoryItems = await BaseFilter.FilterAsync(filters);
                }


                //categoryItems = await ItemsOrganizateAsync(filters, categoryItems, !(bool)filters.Download!);
            }

            return categoryItems!;
        }

        public async Task<List<Category>> ItemsOrganizateAsync(GenericFiltersRequestDto filters, IQueryable<Category> items, bool pagination = false)
        {
            IQueryable<Category> organizatedItems;
            EntityItemsBaseOrganizator<Category> baseOrganizator;

            //filters.Sort = "CategoryId";
            filters.Sort ??= SortingByCategoryColumn.ID_COLUMN;

            baseOrganizator = new OrderingCategories<Category>(items);
            var orderedItems = await baseOrganizator.OrganizateItemsAsync(filters);
            organizatedItems = orderedItems;

            if (pagination)
            {
                baseOrganizator = new PaginateCategories<Category>(organizatedItems);
                var paginatedItems = await baseOrganizator.OrganizateItemsAsync(filters);
                organizatedItems = paginatedItems;
            }

            return organizatedItems.ToList();
        }
    }
}
