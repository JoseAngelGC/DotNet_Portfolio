using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos;

namespace POS.Application.Interfaces.CategoryServices.Queries.GetLists
{
    public interface IAllCategoriesApplicationService
    {
        Task<GenericQueryApplicationResponseDto<IEnumerable<CategorySelectDto>>> GetItemsAsync();
    }
}
