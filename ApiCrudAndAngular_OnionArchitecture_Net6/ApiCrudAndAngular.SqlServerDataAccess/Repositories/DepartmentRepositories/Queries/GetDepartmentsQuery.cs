using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using ApiCrudAndAngular.SqlServerDataAccess.Connection;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories.Queries
{
    internal class GetDepartmentsQuery<T> : BaseGetDepartmentsQuery<T> where T : Department
    {
        private readonly CrudAngularDBContext _dbContext;
        private readonly AdoConnection _connection;
        private readonly List<Department> departmentsList;
        private IEnumerable<T>? departments;
        public GetDepartmentsQuery(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
            _connection = new AdoConnection(_dbContext);
            departmentsList = new List<Department>();
            departments = null;
            
        }

        public override async Task<IEnumerable<T>> StoredProcedureActionAsync()
        {
            using (var conn = _connection.GetConnection())
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_GetAllDepartments";
                SqlDataAdapter adapter = new(command);

                DataTable dt = new();
                adapter.Fill(dt);
                conn.Close();
                
                foreach (DataRow dr in dt.Rows)
                {
                    departmentsList!.Add(new Department
                    {
                        Id= Convert.ToInt32(dr["idDepartment"]),
                        Name = dr["name"].ToString()!,
                        Active = Convert.ToBoolean(dr["active"])
                    });
                }
            }

            departments = (IEnumerable<T>?)departmentsList;
            return await Task.FromResult(departments!);
        }

    }
}
