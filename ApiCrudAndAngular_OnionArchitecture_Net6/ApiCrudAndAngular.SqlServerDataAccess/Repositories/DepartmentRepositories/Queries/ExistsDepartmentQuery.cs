using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using ApiCrudAndAngular.SqlServerDataAccess.Connection;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories.Queries
{
    public class ExistsDepartmentQuery<T> : BaseExistsDepartmentQuery<T> where T : Department
    {
        private readonly CrudAngularDBContext _dbContext;
        private readonly AdoConnection _connection;
        private int existsRecord;
        public ExistsDepartmentQuery(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
            _connection = new AdoConnection(_dbContext);
        }
        public override Task<int> StoredProcedureActionAsync(int id)
        {
            using (var conn = _connection.GetConnection())
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_ExistsDepartment";

                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    existsRecord = reader.GetInt32("result");
                }

                conn.Close();
            }
            return Task.FromResult(existsRecord);
        }

        public override Task<int> StoredProcedureActionAsync(string name)
        {
            using (var conn = _connection.GetConnection())
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_ExistsDepartment";

                command.Parameters.AddWithValue("@name", name);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    existsRecord = reader.GetInt32("result");
                }

                conn.Close();
            }

            return Task.FromResult(existsRecord);
        }
    }
}
