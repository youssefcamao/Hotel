namespace Hotel.Configuration.Interfaces
{
    public interface ICheckService<in T>
    {
        /// <summary>
        /// the method returns a true if the input matches the function logic
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool CheckIfValid(T input);
    }
}