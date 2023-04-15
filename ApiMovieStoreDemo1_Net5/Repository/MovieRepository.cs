using ApiMovieStoreDemo1_Net5.Data;
using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.MovieRepositoryResponses;
using ApiMovieStoreDemo1_Net5.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;
        private readonly IMovieRepositoryHelpers _imrh;
        public MovieRepository(AppDbContext db, IMovieRepositoryHelpers imovieRepositoryHelpers)
        {
            _db = db;
            _imrh = imovieRepositoryHelpers;
        }
        public async Task<MovieRepositoryResponse> CreateMovie(Movie movieModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Movies.Add(movieModel);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return _imrh.MovieRepositoryResponseHelper(1, null);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return _imrh.MovieRepositoryResponseHelper(-1, ex.Message);
                }
            }
        }

        public async Task<MovieRepositoryResponse> DeleteMovie(Movie movieModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Movies.Remove(movieModel);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return _imrh.MovieRepositoryResponseHelper(1, null);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return _imrh.MovieRepositoryResponseHelper(-1, ex.Message);
                }
            }
        }

        public async Task<ExistMovieRepositoryResponse> ExistMovie(int movieId)
        {
            try
            {
                var existMovie = await _db.Movies.AnyAsync(c => c.MovieId == movieId);
                return _imrh.ExistMovieRepoResponseHelper(1, null, existMovie);
            }
            catch (Exception ex)
            {
                return _imrh.ExistMovieRepoResponseHelper(-1, ex.Message, false);
            }
        }

        public async Task<ExistMovieRepositoryResponse> ExistMovieByName(string movieName)
        {
            try
            {
                var existMovieByName = await _db.Movies.AnyAsync(c => c.MovieName.ToLower().Trim() == movieName.ToLower().Trim());
                return _imrh.ExistMovieRepoResponseHelper(1, null, existMovieByName);
            }
            catch (Exception ex)
            {
                return _imrh.ExistMovieRepoResponseHelper(-1, ex.Message, false);
            }
        }

        public async Task<MovieRepositoryResponse> GetMovie(int movieId)
        {
            try
            {
                Movie movieDataById = await _db.Movies.FirstOrDefaultAsync(c => c.MovieId == movieId);
                return _imrh.MovieRepositoryResponseHelper(1, null, movieDataById);
            }
            catch (Exception ex)
            {
                return _imrh.MovieRepositoryResponseHelper(-1, ex.Message);
            }
        }

        public async Task<MoviesRepositoryResponse> GetMovies()
        {
            try
            {
                List<Movie> movieDataList = await _db.Movies.OrderBy(c => c.MovieName).ToListAsync();
                return _imrh.MoviesRepositoryResponseHelper(1, movieDataList);
            }
            catch (Exception ex)
            {
                return _imrh.MoviesRepositoryResponseHelper(-1, ex.Message);
            }
        }

        public async Task<MoviesRepositoryResponse> GetMoviesByCategory(int categoryId)
        {
            try
            {
                List<Movie> movieDataListByCategory = await _db.Movies.Include(ca => ca.MovieCategory).Where(c => c.CategoryId == categoryId).ToListAsync();
                return _imrh.MoviesRepositoryResponseHelper(1, movieDataListByCategory);
            }
            catch (Exception ex)
            {
                return _imrh.MoviesRepositoryResponseHelper(-1, ex.Message);
            }
        }

        public async Task<MoviesIQuerybleRepositoryResponse> SearchMovie(string movieName)
        {
            try
            {
                //Get all movie data
                IQueryable<Movie> query = _db.Movies;

                //Searching query
                query = query.Where(e => e.MovieName.Contains(movieName.TrimStart().TrimEnd()) || e.Description.Contains(movieName.TrimStart().TrimEnd()));

                //Found data validation
                bool foundData = await query.AnyAsync(n => n.MovieName.Contains(movieName.TrimStart().TrimEnd()) || n.Description.Contains(movieName.TrimStart().TrimEnd()));
                if (!foundData)
                {
                    return _imrh.MoviesIQuerybleRepoResponseHelper(1, null, null);
                }

                return _imrh.MoviesIQuerybleRepoResponseHelper(1, null, query);
            }
            catch (Exception ex)
            {
                return _imrh.MoviesIQuerybleRepoResponseHelper(-1, ex.Message, null);
            }
        }

        public async Task<MovieRepositoryResponse> UpdateMovie(Movie movieModel)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Movies.Update(movieModel);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return _imrh.MovieRepositoryResponseHelper(1, null);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return _imrh.MovieRepositoryResponseHelper(-1, ex.Message);
                }
            }
        }
    }
}
