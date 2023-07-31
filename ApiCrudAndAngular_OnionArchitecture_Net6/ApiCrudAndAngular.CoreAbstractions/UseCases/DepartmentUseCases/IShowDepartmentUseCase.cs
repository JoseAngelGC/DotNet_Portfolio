using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;


namespace ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases
{
    public interface IShowDepartmentUseCase<T> where T : Department
    {
        Task<QueryResponseDto<T>> GetDepartmentByNameAsync(string name);
    }
}
