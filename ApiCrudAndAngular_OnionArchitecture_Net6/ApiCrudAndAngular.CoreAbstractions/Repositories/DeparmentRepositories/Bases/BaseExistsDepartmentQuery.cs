using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases
{
    public abstract class BaseExistsDepartmentQuery<T> where T : Department
    {
        public abstract Task<int> StoredProcedureActionAsync(int id);
        public abstract Task<int> StoredProcedureActionAsync(string name);
    }
}
