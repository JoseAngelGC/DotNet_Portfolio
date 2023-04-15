using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos;
using POS.Infraestructure.SupportDtos.Commons.Requests;

namespace POS.Application.Interfaces.CategoryServices.Queries.GetLists
{
    public interface IFilteredCategoriesApplicationService
    {
        Task<GenericQueryApplicationResponseDto<List<CategoryDto>>> GetListAsync(GenericFiltersRequestDto filters);
    }
}
