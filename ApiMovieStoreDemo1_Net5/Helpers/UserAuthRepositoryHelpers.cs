using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.UserAuthRepositoryResponses;
using System.Collections.Generic;

namespace ApiMovieStoreDemo1_Net5.Helpers
{
    public class UserAuthRepositoryHelpers : IUserAuthRepositoryHelpers
    {
        public ExistUserAuthRepositoryResponse ExistUserAuthRepositoryResponseHelper(int code, string message, bool existUserAuth)
        {
            ExistUserAuthRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            response.ExistUserAuthRepoResponse = existUserAuth;
            return response;
        }

        public UserAuthListRepositoryResponse UsersAuthRepositoryResponseHelper(int code, string message, List<UserAuth> userAuthList)
        {
            UserAuthListRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            response.UsersAuthRepositoryResponse = userAuthList;
            return response;
        }

        public UserAuthRepositoryResponse UserAuthRepositoryResponseHelper(int code, string message)
        {
            UserAuthRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            return response;
        }

        public UserAuthRepositoryResponse UserAuthRepositoryResponseHelper(int code, string message, UserAuth userAuthData)
        {
            UserAuthRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            response.UserAuthDataRepositoryResponse = userAuthData;
            return response;
        }
    }
}
