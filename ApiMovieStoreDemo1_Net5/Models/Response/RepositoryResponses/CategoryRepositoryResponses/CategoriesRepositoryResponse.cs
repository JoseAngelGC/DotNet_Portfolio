using ApiMovieStoreDemo1_Net5.Models.Response.BaseResponses;
using System.Collections.Generic;

namespace ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.CategoryRepositoryResponses
{
    public class CategoriesRepositoryResponse:BaseRepositoryResponses
    {
        public ICollection<Category> CategoryCollectionRepositoryResponse { get; set; }
    }
}
