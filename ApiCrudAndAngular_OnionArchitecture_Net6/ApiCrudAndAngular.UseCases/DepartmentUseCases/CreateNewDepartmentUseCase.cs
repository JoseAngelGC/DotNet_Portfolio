using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories;
using ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using AutoMapper;

namespace ApiCrudAndAngular.UseCases.DepartmentUseCases
{
    internal class CreateNewDepartmentUseCase<T> : ICreateNewDepartmentUseCase<T> where T : Department
    {
        private readonly IDepartmentCommandActionsRepository<T> _departmentCommandActionsRepository;
        private readonly IOutputPortsCommandResponses _outputPortsCommandResponses;
        private readonly IDepartmentExistsRecordRepository<T> _existsDepartmentRepository;
        private readonly IMapper _mapper;
        public CreateNewDepartmentUseCase(IDepartmentCommandActionsRepository<T> departmentCommandActionsRepository, IOutputPortsCommandResponses outputPortsCommandResponses, IDepartmentExistsRecordRepository<T> existsDepartmentRepository, IMapper mapper)
        {
            _departmentCommandActionsRepository = departmentCommandActionsRepository;
            _outputPortsCommandResponses = outputPortsCommandResponses;
            _existsDepartmentRepository = existsDepartmentRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponseDto> AddRecordAsync(DepartmentRequestDto departmentRequestDto)
        {
            try
            {
                //Get boolean value if exists department
                var existsDepartment = await _existsDepartmentRepository.ByNameQueryAsync(departmentRequestDto.Name);

                //If exists department to back badrequest response
                if (existsDepartment == 1)
                    return await _outputPortsCommandResponses.ExistingRecordErrorResponseHelperAsync();

                if (existsDepartment == -1)
                    return await _outputPortsCommandResponses.ServerErrorResponseHelperAsync();

                //Mapping departmentRequestDto to department
                var department = _mapper.Map<T>(departmentRequestDto);

                //Save department record calling the repository
                var addDepartmentCommandResponse = await _departmentCommandActionsRepository.AddDepartmentCommandAsync(department);

                //Validate the repository response
                if (addDepartmentCommandResponse is null || addDepartmentCommandResponse == 0)
                {
                    return await _outputPortsCommandResponses.ServerErrorResponseHelperAsync();
                }

                //Return successful response
                return await _outputPortsCommandResponses.SuccessfulResponseHelperAsync(addDepartmentCommandResponse, ReplyMessageConstants.MESSAGE_SAVE);
            }
            catch (Exception e)
            {
                //Return exception response
                return await _outputPortsCommandResponses.ExceptionResponseHelperAsync(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
