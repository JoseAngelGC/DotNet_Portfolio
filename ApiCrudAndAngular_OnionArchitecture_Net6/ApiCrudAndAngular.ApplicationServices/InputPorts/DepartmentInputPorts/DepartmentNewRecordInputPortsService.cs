using ApiCrudAndAngular.ApplicationServices.Validators.DepartmentValidators;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.InputPorts.DepartmentInputPorts;
using ApiCrudAndAngular.CoreAbstractions.OutputPorts.Responses;
using ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.ApplicationServices.InputPorts.DepartmentInputPorts
{
    internal class DepartmentNewRecordInputPortsService : IDepartmentNewRecordInputPortsService
    {
        private readonly ICreateNewDepartmentUseCase<Department> _createNewDepartmentUseCase;
        private readonly DepartmentRequestDtoValidator _departmentRequestDtoValidator;
        private readonly IOutputPortsCommandResponses _outputPortsCommandResponses;
        public DepartmentNewRecordInputPortsService(ICreateNewDepartmentUseCase<Department> createNewDepartmentUseCase, DepartmentRequestDtoValidator departmentRequestDtoValidator, IOutputPortsCommandResponses outputPortsCommandResponses)
        {
            _createNewDepartmentUseCase = createNewDepartmentUseCase;
            _departmentRequestDtoValidator = departmentRequestDtoValidator;
            _outputPortsCommandResponses = outputPortsCommandResponses;
        }

        public async Task<CommandResponseDto> RegisterDepartmentAsync(DepartmentRequestDto departmentRequestDto)
        {
            //Request validator
            var validationResult = await _departmentRequestDtoValidator.ValidateAsync(departmentRequestDto);
            if (!validationResult.IsValid)
            {
                //Custom validator errors response
                return await _outputPortsCommandResponses.CustomValidatorErrorsResponseHelperAsync(validationResult.Errors);

            }

            return await _createNewDepartmentUseCase.AddRecordAsync(departmentRequestDto);
        }

    }
}
