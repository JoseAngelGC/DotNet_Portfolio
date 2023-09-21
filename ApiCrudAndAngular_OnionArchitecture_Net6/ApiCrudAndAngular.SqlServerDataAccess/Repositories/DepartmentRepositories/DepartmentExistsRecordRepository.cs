using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories;
using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories.Queries;

namespace ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories
{
    public class DepartmentExistsRecordRepository<T> : IDepartmentExistsRecordRepository<T> where T : Department
    {
        private readonly CrudAngularDBContext _dbContext;
        private readonly BaseExistsDepartmentQuery<T> baseExistsDepartmentQuery;
        public DepartmentExistsRecordRepository(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
            baseExistsDepartmentQuery = new ExistsDepartmentQuery<T>(_dbContext);
        }

        public async Task<int> ByIdQueryAsync(int id)
        {
            return await baseExistsDepartmentQuery.StoredProcedureActionAsync(id);
        }

        public async Task<int> ByNameQueryAsync(string name)
        {
            return await baseExistsDepartmentQuery.StoredProcedureActionAsync(name);
        }
    }
}
