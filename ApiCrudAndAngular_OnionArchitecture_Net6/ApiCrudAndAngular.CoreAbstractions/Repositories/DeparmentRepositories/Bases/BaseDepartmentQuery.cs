using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases
{
    public abstract class BaseDepartmentQuery<T> where T : Department
    {
        public abstract Task<T> StoredProcedureActionAsync(int id);
        public abstract Task<T> StoredProcedureActionAsync(string name);
        public abstract Task<IEnumerable<T>> StoredProcedureActionAsync();
    }
}
