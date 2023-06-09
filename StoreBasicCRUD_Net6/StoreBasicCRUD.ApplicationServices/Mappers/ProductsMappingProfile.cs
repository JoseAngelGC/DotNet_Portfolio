﻿using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.PivotsDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;


namespace StoreBasicCRUD.ApplicationServices.Mappers
{
    public class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ApplicationServiceQueryResponseDto<List<ProductDto>>, ApplicationCollectorQueryResponseEntity<List<ProductDto>>>().ReverseMap();
            CreateMap<ApplicationServiceQueryResponseDto<ProductDto>, ApplicationCollectorQueryResponseEntity<Product>>().ReverseMap();
            CreateMap<Product, ProductRequestDto>().ReverseMap();
            CreateMap<ProductPivotDto, ProductRequestDto>().ReverseMap();
            CreateMap<Product,ProductPivotDto>().ReverseMap();
        }
    }
}
