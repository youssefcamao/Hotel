using Dapper;
using Hotel.Configuration.Dapper;
using Hotel.Configuration.Interfaces.Repos;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Configuration.Repos
{
    public class DapperSqlDataAccess : ISqlDataAccess
    {
        private readonly string _connectionString;

        public DapperSqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
            SqlMapper.AddTypeHandler(new DapperSqlDateOnlyTypeHandler());
        }

        public IEnumerable<T> LoadData<T, U>(
            string storedProcedure,
            U parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            return connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public void SaveData<T>(
            string storedProcedure,
            T parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

             connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
