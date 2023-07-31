using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;


namespace ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases
{
    public interface IShowDepartmentRecordsUseCase<T> where T : Department
    {
        Task<QueryResponseDto<IQueryable<T>>> GetAllDepartmentsAsync();
    }
}
