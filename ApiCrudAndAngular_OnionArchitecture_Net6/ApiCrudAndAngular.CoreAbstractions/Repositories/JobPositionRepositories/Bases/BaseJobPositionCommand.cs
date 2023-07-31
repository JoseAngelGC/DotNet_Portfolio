using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.JobPositionRepositories.Bases
{
    public abstract class BaseJobPositionCommand<T> where T : JobPosition
    {
        public abstract Task<int> StoredProcedureActionAsync(T departmentEntity);
    }
}
