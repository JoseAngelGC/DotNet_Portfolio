using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos;

namespace POS.Application.Interfaces.CategoryServices.Queries.GetItem
{
    public interface ICategoryByIdApplicationService
    {
        Task<GenericQueryApplicationResponseDto<CategoryDto>> GetItemAsync(int id);
    }
}
