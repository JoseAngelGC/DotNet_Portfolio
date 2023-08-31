using ApiCrudAndAngular.ApplicationServices.Validators.DepartmentValidators;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using AutoMapper;

namespace ApiCrudAndAngular.ApplicationServices.InputPorts.DepartmentInputPorts
{
    internal class DepartmentChangesRecordInputPortsService : IDepartmentChangesRecordInputPortsService
    {
        private readonly IUpdateDepartmentUseCase<Department> _updateDepartmentUseCase;
        private readonly IRemoveDepartmentUseCase<Department> _removeDepartmentUseCase;
        private readonly DepartmentRequestDtoInternalValidator _departmentRequestDtoInternalValidator;
        private readonly IOutputPortsCommandResponses _outputPortsCommandResponses;
        private readonly IMapper _mapper;
        public DepartmentChangesRecordInputPortsService(IUpdateDepartmentUseCase<Department> updateDepartmentUseCase, IRemoveDepartmentUseCase<Department> removeDepartmentUseCase, DepartmentRequestDtoInternalValidator departmentRequestDtoInternalValidator, IOutputPortsCommandResponses outputPortsCommandResponses, IMapper mapper)
        {
            _updateDepartmentUseCase = updateDepartmentUseCase;
            _removeDepartmentUseCase = removeDepartmentUseCase;
            _departmentRequestDtoInternalValidator = departmentRequestDtoInternalValidator;
            _outputPortsCommandResponses = outputPortsCommandResponses;
            _mapper = mapper;
        }

        public async Task<CommandResponseDto> EditDepartmentAsync(int id, DepartmentRequestDto departmentRequestDto)
        {
            var departmentRequestDtoInternal = _mapper.Map<DepartmentRequestDtoInternal>(departmentRequestDto);
            departmentRequestDtoInternal.Id = id;

            //Request validator
            var validationResult = await _departmentRequestDtoInternalValidator.ValidateAsync(departmentRequestDtoInternal);
            if (!validationResult.IsValid)
            {
                //Custom validator errors response
                return await _outputPortsCommandResponses.CustomValidatorErrorsResponseHelperAsync(validationResult.Errors);

            }

            return await _updateDepartmentUseCase.EditRecordAsync(departmentRequestDtoInternal);
        }

        public async Task<CommandResponseDto> RemoveDepartmentAsync(int id, DepartmentRequestDto departmentRequestDto)
        {
            var departmentRequestDtoInternal = _mapper.Map<DepartmentRequestDtoInternal>(departmentRequestDto);
            departmentRequestDtoInternal.Id = id;

            //Request validator
            var validationResult = await _departmentRequestDtoInternalValidator.ValidateAsync(departmentRequestDtoInternal);
            if (!validationResult.IsValid)
            {
                //Custom validator errors response
                return await _outputPortsCommandResponses.CustomValidatorErrorsResponseHelperAsync(validationResult.Errors);

            }

            return await _removeDepartmentUseCase.DeleteRecordAsync(departmentRequestDtoInternal);
        }
    }
}
