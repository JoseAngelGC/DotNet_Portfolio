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
    internal class RemoveDepartmentUseCase<T> : IRemoveDepartmentUseCase<T> where T : Department
    {
        private readonly IDepartmentCommandActionsRepository<T> _departmentCommandActionsRepository;
        private readonly IOutputPortsCommandResponses _outputPortsCommandResponses;
        private readonly IDepartmentExistsRecordRepository<T> _existsDepartmentRepository;
        private readonly IMapper _mapper;
        public RemoveDepartmentUseCase(IDepartmentCommandActionsRepository<T> departmentCommandActionsRepository, IOutputPortsCommandResponses outputPortsCommandResponses, IDepartmentExistsRecordRepository<T> existsDepartmentRepository, IMapper mapper)
        {
            _departmentCommandActionsRepository = departmentCommandActionsRepository;
            _outputPortsCommandResponses = outputPortsCommandResponses;
            _existsDepartmentRepository = existsDepartmentRepository;
            _mapper = mapper;
        }
        public async Task<CommandResponseDto> DeleteRecordAsync(DepartmentRequestDtoInternal departmentRequestDtoInternal)
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

            //Delete department record calling the repository
            var deleteDepartmentCommandResponse = await _departmentCommandActionsRepository.RemoveDepartmentCommandAsync(department);

            //Validate the repository response
            if (deleteDepartmentCommandResponse is null || deleteDepartmentCommandResponse == 0)
            {
                return await _outputPortsCommandResponses.ServerErrorResponseHelperAsync();
            }

            //Return successful response
            return await _outputPortsCommandResponses.SuccessfulResponseHelperAsync(deleteDepartmentCommandResponse, ReplyMessageConstants.MESSAGE_DELETE);
        }
    }
}
