using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;

namespace ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts
{
    public interface IDepartmentQueriesInputPortsService
    {
        Task<QueryResponseDto<IEnumerable<DepartmentDto>>> GetDepartmentsAsync();
        Task<QueryResponseDto<DepartmentDto>> GetDepartmentByIdAsync(int id);
    }
}
