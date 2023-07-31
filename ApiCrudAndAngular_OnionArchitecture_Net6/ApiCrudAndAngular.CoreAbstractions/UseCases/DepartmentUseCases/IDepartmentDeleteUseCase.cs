using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;


namespace ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases
{
    public interface IDepartmentDeleteUseCase
    {
        Task<CommandResponseDto> RemoveCommandAsync(DepartmentDto departmentPivotDto);
    }
}
