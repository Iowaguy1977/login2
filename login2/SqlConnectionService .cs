using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace login2
{
    public class SqlConnectionService: IDisposable
    {
        private readonly SqlConnection _connection;

        public SqlConnectionService(IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(connString);
            _connection.Open();
        }
        public SqlCommand CreateCommand(string sql)
        {
            return new SqlCommand(sql, _connection);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}

