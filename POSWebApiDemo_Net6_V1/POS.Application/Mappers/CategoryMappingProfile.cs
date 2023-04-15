using AutoMapper;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Utilities.Commons.Enums;

namespace POS.Application.Mappers
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)RecordState.Active) ? "Active" : "Inactive"))
                .ReverseMap();

            CreateMap<Category, CategorySelectDto>().ReverseMap();

            CreateMap<GenericQueryInteractorResponseDto<List<Category>>, GenericMapperDto<List<CategoryDto>>>()
                .ReverseMap();

            CreateMap<GenericQueryInteractorResponseDto<IEnumerable<Category>>, GenericMapperDto<IEnumerable<CategorySelectDto>>>()
                .ReverseMap();

            CreateMap<GenericQueryInteractorResponseDto<Category>, GenericMapperDto<CategoryDto>>()
                .ReverseMap();

            CreateMap<CategoryRequestDto, Category>();
            CreateMap<CategoryRequestWithIdDto, Category>();
        }
    }
}
