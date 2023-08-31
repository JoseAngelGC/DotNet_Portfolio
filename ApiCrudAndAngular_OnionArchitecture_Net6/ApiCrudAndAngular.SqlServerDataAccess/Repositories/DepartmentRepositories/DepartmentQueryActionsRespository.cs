using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories;
using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories.Queries;

namespace ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories
{
    public class DepartmentQueryActionsRespository<T> : IDepartmentQueryActionsRespository<T> where T : Department
    {
        private readonly CrudAngularDBContext _dbContext;
        private readonly BaseGetDepartmentsQuery<T> baseGetDepartmentsQuery;
        private readonly BaseGetDepartmentQuery<T> baseGetDepartmentQuery;
        public DepartmentQueryActionsRespository(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
            baseGetDepartmentsQuery = new GetDepartmentsQuery<T>(_dbContext);
            baseGetDepartmentQuery = new GetDepartmentQuery<T>(_dbContext);
        }

        public async Task<T> GetDepartmentByIdQueryAsync(int id)
        {
            return await baseGetDepartmentQuery.StoredProcedureActionAsync(id);
        }

        public async Task<T> GetDepartmentByNameQueryAsync(string name)
        {
            return await baseGetDepartmentQuery.StoredProcedureActionAsync(name);
        }

        public async Task<IEnumerable<T>> GetDepartmentsQueryAsync()
        {
            return await baseGetDepartmentsQuery.StoredProcedureActionAsync();
        }
    }
}
