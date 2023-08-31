using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories
{
    public interface IDepartmentCommandActionsRepository<T> where T : Department
    {
        Task<int?> AddDepartmentCommandAsync(T departmentEntity);
        Task<int?> UpdateDepartmentCommandAsync(T departmentEntity);
        Task<int?> RemoveDepartmentCommandAsync(T departmentEntity);
    }
}
