using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Dtos.MovieDtos;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.MovieServiceResponse;
using ApiMovieStoreDemo1_Net5.Repository.IRepository;
using ApiMovieStoreDemo1_Net5.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _imvRepo;
        private readonly ICommonServiceHelpers _icsh;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IHttpContextAccessor _accesor;
        public MovieService(IMovieRepository imovieRepository, ICommonServiceHelpers iCommonServiceHelpers, IMapper mapper, IWebHostEnvironment hostEnvironment, IHttpContextAccessor accessor)
        {
            _imvRepo = imovieRepository;
            _icsh = iCommonServiceHelpers;
            _mapper = mapper;
            _hostingEnvironment = hostEnvironment;
            _accesor = accessor;
        }

        public async Task<CommonServiceResponse> CreateMovieService(CreateMovieDto createMovieDto)
        {
            try
            {
                ImageMovieServiceResponse imageMovieServiceResponse = new();
                //Validate if exist new movie on database
                var existMovieByNameResponse = await _imvRepo.ExistMovieByName(createMovieDto.Nombre);
                if (existMovieByNameResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(existMovieByNameResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo REC802E!");
                }

                if (existMovieByNameResponse.ExistMovieRepoResponse)
                {
                    return _icsh.CommonServiceResponseHelper(existMovieByNameResponse.OperationCodeRepositoryResponse, "Exist");
                }

                //Create path and file from new ImageMovie
                var imageMovieFileCreated = false;
                if (!(createMovieDto.Photo == null || createMovieDto.Photo.Equals("") || createMovieDto.Photo.Length == 0))
                {
                    string imageMovieFolder = @"ImageMovies";

                    if (createMovieDto.Photo.Length > 0)
                    {
                        imageMovieServiceResponse = await this.PathImageMovieNewFile(imageMovieFolder);
                        imageMovieFileCreated = await CreateImageMovieNewFile(imageMovieServiceResponse.FullPathImageMovie, imageMovieServiceResponse.ContextRequestFormFile);
                    }

                }

                //Mapping from createMovieDto to movie model
                var movieModelMapper = _mapper.Map<Movie>(createMovieDto);

                //Addind aditional values to the new movie
                movieModelMapper.PathImage = imageMovieServiceResponse.ShortPathImageMovie;
                movieModelMapper.CreatedDate = DateTime.Now;
                movieModelMapper.UpdatedBy = createMovieDto.CreatedBy;
                movieModelMapper.UpdatedDate = DateTime.Now;

                //Create movie section
                var imageMovieNewFileDeleted = 0;
                var createMovieResponse = await _imvRepo.CreateMovie(movieModelMapper);
                if (createMovieResponse.OperationCodeRepositoryResponse == -1)
                {
                    //Delete new ImageMovie file,if would occur one error to create new movie on database
                    if (imageMovieFileCreated)
                    {
                        imageMovieNewFileDeleted = await DeleteImageMovieNewFile(imageMovieServiceResponse.FullPathImageMovie);
                    }
                    return _icsh.CommonServiceResponseHelper(createMovieResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R802E!");
                }

                return _icsh.CommonServiceResponseHelper(1, "Se creó de manera exitosa la pelicula!");
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S802E!");
            }
        }

        public async Task<CommonServiceResponse> DeleteMovieService(int movieId)
        {
            try
            {
                //Get movie  by Id that we want deleting
                var getMovieResponse = await _imvRepo.GetMovie(movieId);
                if (getMovieResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getMovieResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo RGM804E!");
                }

                if (getMovieResponse.MovieDataRepositoryResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(getMovieResponse.OperationCodeRepositoryResponse, "NotFound", null);
                }

                //Delete movie section
                var pathImageOld = getMovieResponse.MovieDataRepositoryResponse.PathImage;
                var deleteMovieResponse = await _imvRepo.DeleteMovie(getMovieResponse.MovieDataRepositoryResponse);
                if (deleteMovieResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(deleteMovieResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo RDM804E!");
                }

                //Delete the last ImageMovie file from movie deleted
                var imageMovieFileOldDeleted = await DeleteImageMovieFileOld(pathImageOld);

                return _icsh.CommonServiceResponseHelper(1, "Se eliminó de manera exitosa la pelicula!");
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S804E!");
            }
        }

        public async Task<CommonServiceResponse> GetMoviesService()
        {
            try
            {
                var movieListDto = new List<MovieDto>();
                var movieRepositoryResponse = await _imvRepo.GetMovies();
                if (movieRepositoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(movieRepositoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R800E!");
                }

                if (movieRepositoryResponse.MovieCollectionRepositoryResponse.Count == 0)
                {
                    return _icsh.CommonServiceResponseHelper(movieRepositoryResponse.OperationCodeRepositoryResponse, "No hay registros insertados!", null);
                }

                //Mapping data to the MovieDto model
                foreach (var lista in movieRepositoryResponse.MovieCollectionRepositoryResponse)
                {
                    movieListDto.Add(_mapper.Map<MovieDto>(lista));
                }

                return _icsh.CommonServiceResponseHelper(1, "Listado de peliculas!", movieListDto);
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S800E!");
            }
        }

        public async Task<CommonServiceResponse> GetMoviesByCategoryService(int categoryId)
        {
            try
            {
                var movieByCategoryListDto = new List<MovieDto>();
                //Get movies Data by category
                var movieRepositoryResponse = await _imvRepo.GetMoviesByCategory(categoryId);
                if (movieRepositoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(movieRepositoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R805E!");
                }

                if (movieRepositoryResponse.MovieCollectionRepositoryResponse.Count == 0)
                {
                    return _icsh.CommonServiceResponseHelper(movieRepositoryResponse.OperationCodeRepositoryResponse, "No hay registros insertados!", null);
                }

                //Mapping data to the MovieDto model
                foreach (var lista in movieRepositoryResponse.MovieCollectionRepositoryResponse)
                {
                    movieByCategoryListDto.Add(_mapper.Map<MovieDto>(lista));
                }

                return _icsh.CommonServiceResponseHelper(1, "Listado de peliculas por categoria!", movieByCategoryListDto);
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S805E!");
            }
        }

        public async Task<CommonServiceResponse> GetMovieService(int movieId)
        {
            try
            {
                var movieDto = new MovieDto();
                var movieRepositoryResponse = await _imvRepo.GetMovie(movieId);
                if (movieRepositoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(movieRepositoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R801E!");
                }

                if (movieRepositoryResponse.MovieDataRepositoryResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(movieRepositoryResponse.OperationCodeRepositoryResponse, "NotFound", null);
                }

                //Mapping data to the MovieDto model
                movieDto = _mapper.Map<MovieDto>(movieRepositoryResponse.MovieDataRepositoryResponse);

                return _icsh.CommonServiceResponseHelper(1, "Pelicula encontrada!", movieDto);
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S801E!");
            }
        }

        public async Task<CommonServiceResponse> SearchMovieService(string movieName)
        {
            try
            {
                MovieDto foundMovieDto = new();
                //Get Data from searching
                var searchMovieRepositoryResponse = await _imvRepo.SearchMovie(movieName);
                if (searchMovieRepositoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(searchMovieRepositoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R806E!");
                }

                //Null data validation
                if (searchMovieRepositoryResponse.MoviesIQuerybleRepoResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(searchMovieRepositoryResponse.OperationCodeRepositoryResponse, "NotFound", null);
                }

                //Mapping data to the MovieDto model
                foreach (var lista in searchMovieRepositoryResponse.MoviesIQuerybleRepoResponse)
                {
                    foundMovieDto = _mapper.Map<MovieDto>(lista);
                }

                return _icsh.CommonServiceResponseHelper(1, "Se encontraron coincidencias en la busqueda!", foundMovieDto);
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S806E!");
            }
        }

        public async Task<CommonServiceResponse> UpdateMovieService(UpdateMovieDto updateMovieDto)
        {
            ImageMovieServiceResponse imageMovieServiceResponse = new();
            try
            {
                //Get current moviedata
                var getMovieRepositoryResponse = await _imvRepo.GetMovie(updateMovieDto.MovieId);
                if (getMovieRepositoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getMovieRepositoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo RGM803E!");
                }

                if (getMovieRepositoryResponse.MovieDataRepositoryResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(getMovieRepositoryResponse.OperationCodeRepositoryResponse, "NotFound", null);
                }

                //Create path and file from new ImageMovie
                var imageMovieFileCreated = false;
                if (!(updateMovieDto.Photo == null || updateMovieDto.Photo.Equals("") || updateMovieDto.Photo.Length == 0))
                {
                    string imageMovieFolder = @"ImageMovies";

                    if (updateMovieDto.Photo.Length > 0)
                    {
                        imageMovieServiceResponse = await this.PathImageMovieNewFile(imageMovieFolder);
                        imageMovieFileCreated = await CreateImageMovieNewFile(imageMovieServiceResponse.FullPathImageMovie, imageMovieServiceResponse.ContextRequestFormFile);
                    }

                }

                //Update moviedata values
                string pathImageOld = null;
                if (imageMovieFileCreated == true)
                {
                    pathImageOld = getMovieRepositoryResponse.MovieDataRepositoryResponse.PathImage;
                    getMovieRepositoryResponse.MovieDataRepositoryResponse.PathImage = imageMovieServiceResponse.ShortPathImageMovie;
                }
                getMovieRepositoryResponse.MovieDataRepositoryResponse.MovieName = updateMovieDto.MovieName;
                getMovieRepositoryResponse.MovieDataRepositoryResponse.Description = updateMovieDto.Description;
                getMovieRepositoryResponse.MovieDataRepositoryResponse.Clasification = updateMovieDto.Clasification;
                getMovieRepositoryResponse.MovieDataRepositoryResponse.CategoryId = updateMovieDto.CategoryId;
                getMovieRepositoryResponse.MovieDataRepositoryResponse.MovieLength = updateMovieDto.MovieLength;
                getMovieRepositoryResponse.MovieDataRepositoryResponse.UpdatedBy = updateMovieDto.UpdatedBy;
                getMovieRepositoryResponse.MovieDataRepositoryResponse.UpdatedDate = DateTime.Now;

                //Update movie section
                var updateMovieResponse = await _imvRepo.UpdateMovie(getMovieRepositoryResponse.MovieDataRepositoryResponse);
                if (updateMovieResponse.OperationCodeRepositoryResponse == -1)
                {
                    //Delete new ImageMovie file,if would occur one error to update movie data on database
                    var imageMovieNewFileDeleted = 0;
                    if (imageMovieFileCreated)
                    {
                        imageMovieNewFileDeleted = await DeleteImageMovieNewFile(imageMovieServiceResponse.FullPathImageMovie);
                    }
                    return _icsh.CommonServiceResponseHelper(updateMovieResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo RUM803E!");
                }

                //Delete Old ImageMovie file
                if (pathImageOld != null)
                {
                    var imageMovieFileOldDeleted = await DeleteImageMovieFileOld(pathImageOld);
                }

                return _icsh.CommonServiceResponseHelper(1, "Se actualizó de manera exitosa la pelicula!");
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S803E!");
            }
        }

        private Task<ImageMovieServiceResponse> PathImageMovieNewFile(string imageMovieFolder)
        {
            ImageMovieServiceResponse imageMovieServiceResponse = new();
            string mainPath = _hostingEnvironment.WebRootPath;
            var fullMainPath = Path.Combine(mainPath, imageMovieFolder);

            var nameImage = Guid.NewGuid().ToString();
            HttpContext context = this._accesor.HttpContext;
            var imageMovieContextRequestFormFile = context.Request.Form.Files;
            var extension = Path.GetExtension(imageMovieContextRequestFormFile[0].FileName);
            string fullNameImage = nameImage + extension;

            imageMovieServiceResponse.ShortPathImageMovie = @"\" + imageMovieFolder + @"\" + fullNameImage;
            imageMovieServiceResponse.ContextRequestFormFile = imageMovieContextRequestFormFile;
            imageMovieServiceResponse.FullPathImageMovie = Path.Combine(fullMainPath, fullNameImage);

            return Task.FromResult(imageMovieServiceResponse);
        }

        private static Task<bool> CreateImageMovieNewFile(string fullPathImageMovieNewFile, IFormFileCollection imageMovieContextRequestFormFile)
        {
            try
            {
                using (var fileStreams = new FileStream(fullPathImageMovieNewFile, FileMode.Create))
                {
                    imageMovieContextRequestFormFile[0].CopyTo(fileStreams);
                }
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        private static Task<int> DeleteImageMovieNewFile(string fullPathDeleteFile)
        {
            try
            {
                int statusDelete = 0;
                if (File.Exists(fullPathDeleteFile))
                {
                    File.Delete(fullPathDeleteFile);
                    statusDelete = 1;
                }
                return Task.FromResult(statusDelete);
            }
            catch (Exception)
            {
                return Task.FromResult(-1);
            }

        }

        private Task<int> DeleteImageMovieFileOld(string pathImageMovieOld)
        {
            try
            {
                int statusDelete = 0;
                string mainPathDeleteFile = _hostingEnvironment.WebRootPath;
                var fullMainPathDeleteFile = Path.Combine(mainPathDeleteFile, pathImageMovieOld.Remove(12).Substring(1));
                string fullNameImageMovieFileOld = pathImageMovieOld.Substring(13);
                var fullPathDeleteFile = Path.Combine(fullMainPathDeleteFile, fullNameImageMovieFileOld);
                if (File.Exists(fullPathDeleteFile))
                {
                    File.Delete(fullPathDeleteFile);
                    statusDelete = 1;
                }
                return Task.FromResult(statusDelete);
            }
            catch (Exception)
            {
                return Task.FromResult(-1);
            }
        }
    }
}
