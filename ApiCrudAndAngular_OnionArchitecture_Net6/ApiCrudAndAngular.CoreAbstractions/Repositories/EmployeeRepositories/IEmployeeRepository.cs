using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;

namespace ApiCrudAndAngular.CoreAbstractions.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository<T> where T : Employee
    {
        Task<IQueryable<T>> GetFilteredEmployeesQueryAsync(CommonFiltersRequestDto commonFiltersRequestDto);
        Task<T> GetEmployeeByNameQueryAsync(string name);
        Task<T> GetEmployeeByIdQueryAsync(int id);
        Task<int> AddEmployeeCommandAsync(T employeeEntity);
        Task<int> UpdateEmployeeCommandAsync(T employeeEntity);
        Task<int> RemoveEmployeeCommandAsync(T employeeEntity);
    }
}
