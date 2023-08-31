using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories
{
    public interface IDepartmentExistsRecordRepository<T> where T : Department
    {
        Task<int> ByIdQueryAsync(int id);
        Task<int> ByNameQueryAsync(string name);
    }
}
