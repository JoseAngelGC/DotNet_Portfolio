using Microsoft.AspNetCore.Http;

namespace ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.MovieServiceResponse
{
    public class ImageMovieServiceResponse
    {
        public string ShortPathImageMovie { get; set; }
        public string FullPathImageMovie { get; set; }
        public IFormFileCollection ContextRequestFormFile { get; set; }
    }
}
