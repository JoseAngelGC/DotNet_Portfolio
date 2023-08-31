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
    internal class UpdateDepartmentUseCase<T> : IUpdateDepartmentUseCase<T> where T : Department
    {
        private readonly IDepartmentCommandActionsRepository<T> _departmentCommandActionsRepository;
        private readonly IOutputPortsCommandResponses _outputPortsCommandResponses;
        private readonly IDepartmentExistsRecordRepository<T> _existsDepartmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentUseCase(IDepartmentCommandActionsRepository<T> departmentCommandActionsRepository, IOutputPortsCommandResponses outputPortsCommandResponses, IDepartmentExistsRecordRepository<T> existsDepartmentRepository, IMapper mapper)
        {
            _departmentCommandActionsRepository = departmentCommandActionsRepository;
            _outputPortsCommandResponses = outputPortsCommandResponses;
            _existsDepartmentRepository = existsDepartmentRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponseDto> EditRecordAsync(DepartmentRequestDtoInternal departmentRequestDtoInternal)
        {
            try
            {
                //Get boolean value if exists department
                var existsDepartment = await _existsDepartmentRepository.ByIdQueryAsync(departmentRequestDtoInternal.Id);

                //If not exists department to back notfound response
                if (existsDepartment == 0)
                    return await _outputPortsCommandResponses.NotFoundDataErrorResponseHelperAsync();

                if (existsDepartment == -1)
                    return await _outputPortsCommandResponses.ServerErrorResponseHelperAsync();

                //Mapping departmentRequestDto to department
                var department = _mapper.Map<T>(departmentRequestDtoInternal);

                //Update department record calling the repository
                var updateDepartmentCommandResponse = await _departmentCommandActionsRepository.UpdateDepartmentCommandAsync(department);

                //Validate the repository response
                if (updateDepartmentCommandResponse is null || updateDepartmentCommandResponse == 0)
                {
                    return await _outputPortsCommandResponses.ServerErrorResponseHelperAsync();
                }

                //Return successful response
                return await _outputPortsCommandResponses.SuccessfulResponseHelperAsync(updateDepartmentCommandResponse, ReplyMessageConstants.MESSAGE_UPDATE);
            }
            catch (Exception e)
            {
                //Return exception response
                return await _outputPortsCommandResponses.ExceptionResponseHelperAsync(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
