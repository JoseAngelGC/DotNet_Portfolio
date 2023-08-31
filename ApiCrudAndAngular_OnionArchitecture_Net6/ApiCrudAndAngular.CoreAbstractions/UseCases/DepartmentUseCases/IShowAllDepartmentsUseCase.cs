using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;


namespace ApiCrudAndAngular.CoreAbstractions.UseCases.DepartmentUseCases
{
    public interface IShowAllDepartmentsUseCase<T> where T : Department
    {
        Task<QueryResponseDto<IEnumerable<DepartmentDto>>> GetRecordsListAsync();
    }
}
