using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.JobPositionRepositories.Bases
{
    public abstract class BaseJobPositionQuery<T> where T : JobPosition
    {
        public abstract Task<T> StoredProcedureActionAsync(int id);
        public abstract Task<T> StoredProcedureActionAsync(string name);
        public abstract Task<IEnumerable<T>> StoredProcedureActionAsync();
    }
}
