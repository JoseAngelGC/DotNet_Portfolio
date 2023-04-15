using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.UserAuthRepositoryResponses;
using System.Collections.Generic;

namespace ApiMovieStoreDemo1_Net5.Helpers.IHelpers
{
    public interface IUserAuthRepositoryHelpers
    {
        UserAuthRepositoryResponse UserAuthRepositoryResponseHelper(int code, string message);
        UserAuthRepositoryResponse UserAuthRepositoryResponseHelper(int code, string message, UserAuth userAuthData);
        ExistUserAuthRepositoryResponse ExistUserAuthRepositoryResponseHelper(int code, string message, bool existUserAuth);
        UserAuthListRepositoryResponse UsersAuthRepositoryResponseHelper(int code, string message, List<UserAuth> userAuthList);
    }
}
