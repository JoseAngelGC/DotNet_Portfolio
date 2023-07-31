using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.EmployeeRepositories.Bases
{
    public abstract class BaseEmployeeCommand<T> where T : Employee
    {
        public abstract Task<int> StoredProcedureActionAsync(T departmentEntity);
    }
}
