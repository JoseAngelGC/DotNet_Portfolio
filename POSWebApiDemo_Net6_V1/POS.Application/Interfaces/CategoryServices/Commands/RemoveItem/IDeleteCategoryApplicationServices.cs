using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;


namespace POS.Application.Interfaces.CategoryServices.Commands.RemoveItem
{
    public interface IDeleteCategoryApplicationServices
    {
        Task<CommandApplicationResponseDto> RemoveItemAsync(int id, CategoryRequestDto categoryRequestDto);
    }
}
