using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases
{
    public abstract class BaseGetDepartmentQuery<T> where T : Department
    {
        public abstract Task<T> StoredProcedureActionAsync(int id);
        public abstract Task<T> StoredProcedureActionAsync(string name);
    }
}
