using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;

namespace POS.Application.Interfaces.UserServices.Queries.GetToken
{
    public interface IGetTokenApplicationService
    {
        Task<GenericQueryApplicationResponseDto<string>> ResponseAsync(TokenRequestDto tokenRequestDto);
    }
}
