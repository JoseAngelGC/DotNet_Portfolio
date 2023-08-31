using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts
{
    public interface IDepartmentChangesRecordInputPortsService
    {
        Task<CommandResponseDto> EditDepartmentAsync(int id, DepartmentRequestDto departmentRequestDto);
        Task<CommandResponseDto> RemoveDepartmentAsync(int id, DepartmentRequestDto departmentRequestDto);
    }
}
