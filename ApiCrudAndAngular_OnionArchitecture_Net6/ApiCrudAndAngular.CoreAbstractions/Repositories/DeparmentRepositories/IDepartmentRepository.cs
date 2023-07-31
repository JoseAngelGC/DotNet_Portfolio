using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories
{
    public interface IDepartmentRepository<T> where T : Department
    {
        Task<IEnumerable<T>> GetDepartmentsQueryAsync();
        Task<T> GetDepartmentByNameQueryAsync(string name);
        Task<T> GetDepartmentByIdQueryAsync(int id);
        Task<int> AddDepartmentCommandAsync(T departmentEntity);
        Task<int> UpdateDepartmentCommandAsync(T departmentEntity);
        Task<int> RemoveDepartmentCommandAsync(T departmentEntity);
    }
}
