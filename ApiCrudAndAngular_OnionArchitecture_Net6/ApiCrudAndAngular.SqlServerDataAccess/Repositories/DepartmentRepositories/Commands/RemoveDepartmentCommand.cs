﻿using ApiCrudAndAngular.CoreAbstractions.Repositories.DeparmentRepositories.Bases;
using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs;
using ApiCrudAndAngular.SqlServerDataAccess.Connection;
using ApiCrudAndAngular.SqlServerDataAccess.Context;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ApiCrudAndAngular.SqlServerDataAccess.Repositories.DepartmentRepositories.Commands
{
    internal class RemoveDepartmentCommand<T> : BaseDepartmentCommand<T> where T : Department
    {
        private readonly CrudAngularDBContext _dbContext;
        private readonly AdoConnection _connection;
        private int? affectedRecords;
        public RemoveDepartmentCommand(CrudAngularDBContext dbContext)
        {
            _dbContext = dbContext;
            _connection = new AdoConnection(_dbContext);
            affectedRecords = null;
        }
        public override async Task<int?> StoredProcedureActionAsync(T departmentEntity)
        {
            using (var conn = _connection.GetConnection())
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_DeleteDepartment";

                command.Parameters.AddWithValue("@id", departmentEntity.Id);
                command.Parameters.AddWithValue("@name", departmentEntity.Name);
                affectedRecords = command.ExecuteNonQuery();
                conn.Close();
            }

            return await Task.FromResult(affectedRecords);
        }
    }
}
