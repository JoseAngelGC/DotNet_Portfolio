using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases
{
    public interface IUpdateDepartmentUseCase<T> where T : Department
    {
        Task<CommandResponseDto> EditRecordAsync(DepartmentRequestDtoInternal departmentRequestDtoInternal);
    }
}
