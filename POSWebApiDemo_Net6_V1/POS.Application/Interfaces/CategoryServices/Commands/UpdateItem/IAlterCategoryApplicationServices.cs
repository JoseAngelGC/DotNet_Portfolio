using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;


namespace POS.Application.Interfaces.CategoryServices.Commands.UpdateItem
{
    public interface IAlterCategoryApplicationServices
    {
        Task<CommandApplicationResponseDto> UpdateItemAsync(int id, CategoryRequestDto categoryRequestDto);
    }
}
