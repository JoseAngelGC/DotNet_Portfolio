using ApiMovieStoreDemo1_Net5.Models.Response.BaseResponses;
using System.Collections.Generic;

namespace ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.UserAuthRepositoryResponses
{
    public class UserAuthListRepositoryResponse:BaseRepositoryResponses
    {
        public List<UserAuth> UsersAuthRepositoryResponse { get; set; }
    }
}
