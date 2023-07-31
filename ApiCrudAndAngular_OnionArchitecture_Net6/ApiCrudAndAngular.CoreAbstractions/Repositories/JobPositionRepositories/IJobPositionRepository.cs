using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.JobPositionRepositories
{
    internal interface IJobPositionRepository<T> where T : JobPosition
    {
        Task<List<T>> GetJobPositionsQueryAsync();
        Task<T> GetJobPositionByNameQueryAsync(string name);
        Task<T> GetJobPositionByIdQueryAsync(int id);
        Task<int> AddJobPositionCommandAsync(T departmentEntity);
        Task<int> UpdateJobPositionCommandAsync(T departmentEntity);
        Task<int> RemoveJobPositionCommandAsync(T departmentEntity);
    }
}
