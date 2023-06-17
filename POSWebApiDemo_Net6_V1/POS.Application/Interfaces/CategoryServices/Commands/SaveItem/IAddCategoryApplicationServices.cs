using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;

namespace POS.Application.Interfaces.CategoryServices.Commands.SaveItem
{
    public interface IAddCategoryApplicationServices
    {
        Task<CommandApplicationResponseDto> SaveItemAsync(CategoryRequestDto categoryRequestDto);    
    }
}
