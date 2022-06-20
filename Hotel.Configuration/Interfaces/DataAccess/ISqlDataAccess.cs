namespace Hotel.Configuration.Interfaces.Repos
{
    public interface ISqlDataAccess
    {
        IEnumerable<T> LoadData<T, U>(string storedProcedure, U parameters);
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters);
        void SaveData<T>(string storedProcedure, T parameters);
    }
}