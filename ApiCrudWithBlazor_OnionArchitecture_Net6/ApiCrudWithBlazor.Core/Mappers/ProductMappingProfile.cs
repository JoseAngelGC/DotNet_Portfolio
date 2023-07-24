using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using AutoMapper;


namespace ApiCrudWithBlazor.Core.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<QueryResponseDto<ProductDto>, QueryResponseDto<Product>>().ReverseMap();
            CreateMap<Product, ProductRequestPivotDto>().ReverseMap();
            CreateMap<ProductRequestPivotDto, ProductRequestDto>().ReverseMap();
        }
    }
}
