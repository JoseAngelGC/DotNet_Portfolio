using ApiMovieStoreDemo1_Net5.Models.Dtos.UserAuthDtos;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Services.IServices
{
    public interface IUserAuthService
    {
        Task<CommonServiceResponse> GetUsersAuthService();
        Task<CommonServiceResponse> UserAuthRegister(UserAuthRegisterDto userAuthRegisterDto);
        Task<CommonServiceResponse> UserAuthLogin(UserAuthLoginDto userAuthLoginDto);
    }
}
