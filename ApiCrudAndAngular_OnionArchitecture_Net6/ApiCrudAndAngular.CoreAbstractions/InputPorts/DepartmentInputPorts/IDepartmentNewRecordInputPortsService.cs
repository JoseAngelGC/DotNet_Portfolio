using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts
{
    public interface IDepartmentNewRecordInputPortsService
    {
        Task<CommandResponseDto> RegisterDepartmentAsync(DepartmentRequestDto departmentRequestDto);
    }
}
