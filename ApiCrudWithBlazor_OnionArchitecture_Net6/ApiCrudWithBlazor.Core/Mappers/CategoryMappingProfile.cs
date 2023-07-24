using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.CategoryDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using AutoMapper;


namespace ApiCrudWithBlazor.Core.Mappers
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<QueryResponseDto<IEnumerable<CategoryDto>>, QueryResponseDto<IEnumerable<Category>>>().ReverseMap();
        }
    }
}
