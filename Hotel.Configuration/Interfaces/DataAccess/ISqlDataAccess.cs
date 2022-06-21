namespace Hotel.Configuration.Interfaces.Repos
{
    public interface ISqlDataAccess
    {
        /// <summary>
        /// This Method loads data from the database using a stored procedure and dapper parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> LoadData<T, U>(string storedProcedure, U parameters);
        /// <summary>
        /// Loads Data Async to database using a stored procedure and dapper parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters);
        /// <summary>
        /// This Method saves data in the database using a stored procedure and a parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        void SaveData<T>(string storedProcedure, T parameters);
    }
}