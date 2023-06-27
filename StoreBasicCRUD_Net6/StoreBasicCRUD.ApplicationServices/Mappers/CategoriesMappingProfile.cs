using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Categories.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.ApplicationServices.Mappers
{
    public class CategoriesMappingProfile : Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ApplicationServiceQueryResponseDto<List<CategoryDto>>, ApplicationCollectorQueryResponseEntity<List<Category>>>().ReverseMap();
        }
    }
}
