using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases
{
    public abstract class BaseGetDepartmentsQuery<T> where T : Department
    {
        public abstract Task<IEnumerable<T>> StoredProcedureActionAsync();
    }
}
