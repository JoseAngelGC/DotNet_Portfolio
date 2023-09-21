using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories;
using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories.Commands;

namespace ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories
{
    public class DepartmentCommandActionsRepository<T> : IDepartmentCommandActionsRepository<T> where T : Department
    {
        private readonly CrudAngularDBContext _dbContext;
        private BaseDepartmentCommand<T>? baseDepartmentCommand;
        public DepartmentCommandActionsRepository(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
            baseDepartmentCommand = null;
        }

        public async Task<int?> AddDepartmentCommandAsync(T departmentEntity)
        {
            baseDepartmentCommand = new AddDepartmentCommand<T>(_dbContext);
            return await baseDepartmentCommand.StoredProcedureActionAsync(departmentEntity);
        }

        public async Task<int?> UpdateDepartmentCommandAsync(T departmentEntity)
        {
            baseDepartmentCommand = new UpdateDepartmentCommand<T>(_dbContext);
            return await baseDepartmentCommand.StoredProcedureActionAsync(departmentEntity);
        }

        public async Task<int?> RemoveDepartmentCommandAsync(T departmentEntity)
        {
            baseDepartmentCommand = new RemoveDepartmentCommand<T>(_dbContext);
            return await baseDepartmentCommand.StoredProcedureActionAsync(departmentEntity);
        }

    }
}
