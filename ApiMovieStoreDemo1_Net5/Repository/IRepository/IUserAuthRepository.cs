using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.UserAuthRepositoryResponses;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Repository.IRepository
{
    public interface IUserAuthRepository
    {
        Task<UserAuthListRepositoryResponse> GetUsersAuth();
        Task<UserAuthRepositoryResponse> GetUserAuthByAlias(string userAlias);
        Task<ExistUserAuthRepositoryResponse> ExistUserAuth(string userAlias);
        Task<UserAuthRepositoryResponse> RegisterUserAuth(UserAuth userAuth);
    }
}
