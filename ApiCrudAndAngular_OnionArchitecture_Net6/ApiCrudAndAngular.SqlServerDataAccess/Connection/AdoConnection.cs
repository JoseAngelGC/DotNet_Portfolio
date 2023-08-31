using ApiCrudAndAngular.SqlServerDataAccess.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudAndAngular.SqlServerDataAccess.Connection
{
    public class AdoConnection
    {
        private readonly CrudAngularDBContext _dbContext;
        public AdoConnection(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SqlConnection GetConnection()
        {
            var conn = (SqlConnection)_dbContext.Database.GetDbConnection();
            conn.Open();
            return conn;
        }

        public void CloseConnection()
        {
            var conn = (SqlConnection)_dbContext.Database.GetDbConnection();
            conn.Close();
        }
    }
}
