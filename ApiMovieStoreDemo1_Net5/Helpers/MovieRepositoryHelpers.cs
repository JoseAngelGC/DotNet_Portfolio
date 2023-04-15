using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.MovieRepositoryResponses;
using System.Collections.Generic;
using System.Linq;

namespace ApiMovieStoreDemo1_Net5.Helpers
{
    public class MovieRepositoryHelpers : IMovieRepositoryHelpers
    {

        public MovieRepositoryResponse MovieRepositoryResponseHelper(int code, string message)
        {
            MovieRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            return response;
        }

        public MovieRepositoryResponse MovieRepositoryResponseHelper(int code, string message, Movie movieData)
        {
            MovieRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MovieDataRepositoryResponse = movieData;
            return response;
        }


        public MoviesRepositoryResponse MoviesRepositoryResponseHelper(int code, string message)
        {
            MoviesRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            return response;
        }

        public MoviesRepositoryResponse MoviesRepositoryResponseHelper(int code, ICollection<Movie> movieCollection)
        {
            MoviesRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MovieCollectionRepositoryResponse = movieCollection;
            return response;
        }

        public ExistMovieRepositoryResponse ExistMovieRepoResponseHelper(int code, string message, bool existMovie)
        {
            ExistMovieRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            response.ExistMovieRepoResponse = existMovie;
            return response;
        }

        public MoviesIQuerybleRepositoryResponse MoviesIQuerybleRepoResponseHelper(int code, string message, IQueryable<Movie> query)
        {
            MoviesIQuerybleRepositoryResponse response = new();
            response.OperationCodeRepositoryResponse = code;
            response.MessageRepositoryResponse = message;
            response.MoviesIQuerybleRepoResponse = query;
            return response;
        }
    }
}
