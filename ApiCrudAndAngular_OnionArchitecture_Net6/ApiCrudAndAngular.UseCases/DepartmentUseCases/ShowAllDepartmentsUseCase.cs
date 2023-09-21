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
    internal class ShowAllDepartmentsUseCase<T> : IShowAllDepartmentsUseCase<T> where T : Department
    {
        private readonly IDepartmentQueryActionsRespository<T> _departmentQueryActionsRespository;
        private readonly IOutputPortsQueryResponses _outputPortsQueryResponses;
        private readonly CommonFiltersRequestDto filters;
        private readonly IMapper _mapper;
        public ShowAllDepartmentsUseCase(IDepartmentQueryActionsRespository<T> departmentQueryActionsRespository, IOutputPortsQueryResponses outputPortsQueryResponses, IMapper mapper)
        {
            _departmentQueryActionsRespository = departmentQueryActionsRespository;
            _outputPortsQueryResponses = outputPortsQueryResponses;
            filters = new CommonFiltersRequestDto();
            _mapper = mapper;
        }
        public async Task<QueryResponseDto<IEnumerable<DepartmentDto>>> GetRecordsListAsync()
        {
            try
            {
                //Get department list calling the department repository
                var departments = await _departmentQueryActionsRespository.GetDepartmentsQueryAsync();

                //Get Output Port  successful response values
                var outputPortResponse = await _outputPortsQueryResponses.SuccessfulResponseHelperAsync(departments);

                //Validate if output port response value is not null
                if (departments is not null)
                {
                    //Add Total Records values the output port response
                    outputPortResponse.TotalRecords = departments.Count();

                    //Add Total Paginates values the output port response
                    var totalRecords = Convert.ToDouble(departments.Count());
                    outputPortResponse.TotalPaginates = Convert.ToInt32(Math.Ceiling(totalRecords / filters.NumberRecordsPage));
                }

                //Mapping Department to DepartmentDto
                var response = _mapper.Map<QueryResponseDto<IEnumerable<DepartmentDto>>>(outputPortResponse);

                //Return successful response
                return response;
            }
            catch (Exception e)
            {
                //Return exception response
                return await _outputPortsQueryResponses.ExceptionResponseHelperAsync<IEnumerable<DepartmentDto>>(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
