using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using AutoMapper;


namespace ApiCrudAndAngular.UseCases.Mappers
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<QueryResponseDto<IEnumerable<DepartmentDto>>, QueryResponseDto<IEnumerable<Department>>>().ReverseMap();
            CreateMap<QueryResponseDto<DepartmentDto>, QueryResponseDto<Department>>().ReverseMap();
            CreateMap<DepartmentRequestDtoInternal, DepartmentRequestDto>().ReverseMap();
            CreateMap<Department, DepartmentRequestDto>().ReverseMap();
            CreateMap<Department, DepartmentRequestDtoInternal>().ReverseMap();
        }
    }
}
