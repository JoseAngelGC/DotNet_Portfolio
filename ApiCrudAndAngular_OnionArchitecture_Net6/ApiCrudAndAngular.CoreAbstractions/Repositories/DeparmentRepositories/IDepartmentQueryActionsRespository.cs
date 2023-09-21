using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories
{
    public interface IDepartmentQueryActionsRespository<T> where T : Department
    {
        Task<IEnumerable<T>> GetDepartmentsQueryAsync();
        Task<T> GetDepartmentByNameQueryAsync(string name);
        Task<T> GetDepartmentByIdQueryAsync(int id);
    }
}
