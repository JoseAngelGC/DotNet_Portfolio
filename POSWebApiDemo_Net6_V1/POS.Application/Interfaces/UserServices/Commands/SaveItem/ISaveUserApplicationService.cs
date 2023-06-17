using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;

namespace POS.Application.Interfaces.UserServices.Commands.SaveItem
{
    public interface ISaveUserApplicationService
    {
        Task<CommandApplicationResponseDto> SaveItemAsync(UserRequestDto userRequestDto);
    }
}
