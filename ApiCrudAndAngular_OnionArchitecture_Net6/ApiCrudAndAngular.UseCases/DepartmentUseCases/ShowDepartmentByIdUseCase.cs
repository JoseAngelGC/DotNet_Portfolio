using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories;
using ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using AutoMapper;

namespace ApiCrudAndAngular.UseCases.DepartmentUseCases
{
    internal class ShowDepartmentByIdUseCase<T> : IShowDepartmentByIdUseCase<T> where T : Department
    {
        private readonly IDepartmentQueryActionsRespository<T> _departmentQueryActionsRespository;
        private readonly IOutputPortsQueryResponses _outputPortsQueryResponses;
        private readonly CommonFiltersRequestDto filters;
        private readonly List<Department> departments;
        private readonly IMapper _mapper;
        public ShowDepartmentByIdUseCase(IDepartmentQueryActionsRespository<T> departmentQueryActionsRespository, IOutputPortsQueryResponses outputPortsQueryResponses, IMapper mapper)
        {
            _departmentQueryActionsRespository = departmentQueryActionsRespository;
            _outputPortsQueryResponses = outputPortsQueryResponses;
            filters = new CommonFiltersRequestDto();
            departments = new List<Department>();
            _mapper = mapper;
        }

        public async Task<QueryResponseDto<DepartmentDto>> GetRegisterAsync(int id)
        {
            try
            {
                //Get department record values calling the department repository
                var department = await _departmentQueryActionsRespository.GetDepartmentByIdQueryAsync(id);

                //Validate if department value is null
                if (department is null)
                    return await _outputPortsQueryResponses.NotFoundDataErrorResponseHelperAsync<DepartmentDto>();

                //Get Output Port successful response values
                var outputPortResponse = await _outputPortsQueryResponses.SuccessfulResponseHelperAsync(department);

                //Add Total Records values the output port response
                departments.Add(department);
                outputPortResponse.TotalRecords = departments.Count;

                //Add Total Paginates values the output port response
                var totalRecords = Convert.ToDouble(departments.Count);
                outputPortResponse.TotalPaginates = Convert.ToInt32(Math.Ceiling(totalRecords / filters.NumberRecordsPage));

                //Mapping Department to DepartmentDto
                var response = _mapper.Map<QueryResponseDto<DepartmentDto>>(outputPortResponse);

                //Return successful response
                return response;
            }
            catch (Exception e)
            {
                //Return exception response
                return await _outputPortsQueryResponses.ExceptionResponseHelperAsync<DepartmentDto>(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
