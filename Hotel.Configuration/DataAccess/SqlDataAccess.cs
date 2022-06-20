using Dapper;
using Hotel.Configuration.Dapper;
using Hotel.Configuration.Interfaces.Repos;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Configuration.Repos
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
            SqlMapper.AddTypeHandler(new DapperSqlDateOnlyTypeHandler());
        }
        /// <summary>
        /// This Mehod loads data from the database using a stored procedure and a parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<T> LoadData<T, U>(
            string storedProcedure,
            U parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            return connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// This Method saves data in the database using a stored procedure and a parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
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
