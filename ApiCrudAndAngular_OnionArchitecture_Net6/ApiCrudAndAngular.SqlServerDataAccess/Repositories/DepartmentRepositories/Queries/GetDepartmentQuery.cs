using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using ApiCrudAndAngular.SqlServerDataAccess.Connection;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories.Queries
{
    internal class GetDepartmentQuery<T> : BaseGetDepartmentQuery<T> where T : Department
    {
        private readonly CrudAngularDBContext _dbContext;
        private readonly AdoConnection _connection;
        private readonly Department _departmentResponse;

        public GetDepartmentQuery(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
            _connection = new AdoConnection(_dbContext);
            _departmentResponse = new Department();
        }

        public override async Task<T> StoredProcedureActionAsync(int id)
        {
            using (var conn = _connection.GetConnection())
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_GetDepartmentById";

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", "");
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _departmentResponse.Id = reader.GetInt32("idDepartment");
                    _departmentResponse.Name = reader.GetString("name");
                    _departmentResponse.Active = reader.GetBoolean("active");
                }
                conn.Close();
            }
            
            return (T)await Task.FromResult(_departmentResponse);
        }

        public override async Task<T> StoredProcedureActionAsync(string name)
        {
            using (var conn = _connection.GetConnection())
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_GetDepartmentByNameUsers";

                command.Parameters.AddWithValue("@nameDepartment", name);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _departmentResponse.Id = reader.GetInt32("id");
                    _departmentResponse.Name = reader.GetString("name");
                    _departmentResponse.Active= reader.GetBoolean("active");
                }
                conn.Close();
            }

            return (T)await Task.FromResult(_departmentResponse);
        }
    }
}
