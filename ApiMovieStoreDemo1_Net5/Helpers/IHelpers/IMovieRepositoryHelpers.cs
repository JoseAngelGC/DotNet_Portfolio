using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.MovieRepositoryResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Helpers.IHelpers
{
    public interface IMovieRepositoryHelpers
    {
        MovieRepositoryResponse MovieRepositoryResponseHelper(int code, string message);
        MovieRepositoryResponse MovieRepositoryResponseHelper(int code, string message, Movie movieData);
        MoviesRepositoryResponse MoviesRepositoryResponseHelper(int code, string message);
        MoviesRepositoryResponse MoviesRepositoryResponseHelper(int code, ICollection<Movie> movieCollection);
        ExistMovieRepositoryResponse ExistMovieRepoResponseHelper(int code, string message, bool existMovie);
        MoviesIQuerybleRepositoryResponse MoviesIQuerybleRepoResponseHelper(int code, string message, IQueryable<Movie> query);
    }
}
