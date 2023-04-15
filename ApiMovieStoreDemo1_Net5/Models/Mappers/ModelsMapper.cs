using ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos;
using ApiMovieStoreDemo1_Net5.Models.Dtos.MovieDtos;
using ApiMovieStoreDemo1_Net5.Models.Dtos.UserAuthDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Models.Mappers
{
    public class ModelsMapper:Profile
    {
        public ModelsMapper()
        {
            //Category models mappers
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ForMember(d => d.Nombre, o => o.MapFrom(s => s.CategoryName)).ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ForMember(d => d.Nombre, o => o.MapFrom(s => s.CategoryName)).ReverseMap();

            //Movie models mappers
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ForMember(d => d.Nombre, o => o.MapFrom(s => s.MovieName)).ReverseMap();
            CreateMap<Movie, UpdateMovieDto>().ReverseMap();

            //User models mappers
            CreateMap<UserAuthRegisterDto, UserAuth>().ForMember(d => d.AliasUser, o => o.MapFrom(s => s.UserAlias));
            CreateMap<UserAuthDto, UserAuth>().ReverseMap();
        }
    }
}
