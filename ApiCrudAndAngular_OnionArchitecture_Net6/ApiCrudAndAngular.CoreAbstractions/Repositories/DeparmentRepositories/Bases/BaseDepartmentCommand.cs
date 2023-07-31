using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases
{
    public abstract class BaseDepartmentCommand<T> where T : Department
    {
        public abstract Task<int> StoredProcedureActionAsync(T departmentEntity);
    }
}
