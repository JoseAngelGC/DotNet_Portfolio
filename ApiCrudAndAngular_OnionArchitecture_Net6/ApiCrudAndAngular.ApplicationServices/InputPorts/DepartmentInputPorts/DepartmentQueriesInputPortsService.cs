using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts;
using ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.ApplicationServices.InputPorts.DepartmentInputPorts
{
    internal class DepartmentQueriesInputPortsService : IDepartmentQueriesInputPortsService
    {
        private readonly IShowAllDepartmentsUseCase<Department> _showAllDepartmentsUseCase;
        private readonly IShowDepartmentByIdUseCase<Department> _showDepartmentByIdUseCase;

        public DepartmentQueriesInputPortsService(IShowAllDepartmentsUseCase<Department> showAllDepartmentsUseCase, IShowDepartmentByIdUseCase<Department> showDepartmentByIdUseCase)
        {
            _showAllDepartmentsUseCase = showAllDepartmentsUseCase;
            _showDepartmentByIdUseCase = showDepartmentByIdUseCase;
        }

        public async Task<QueryResponseDto<IEnumerable<DepartmentDto>>> GetDepartmentsAsync()
        {
            return await _showAllDepartmentsUseCase.GetRecordsListAsync();
        }

        public async Task<QueryResponseDto<DepartmentDto>> GetDepartmentByIdAsync(int id)
        {
            return await _showDepartmentByIdUseCase.GetRegisterAsync(id);
        }

    }
}
