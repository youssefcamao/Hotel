namespace Hotel.Configuration.Interfaces
{
    public interface ICheckService<in T>
    {
        bool CheckIfValid(T input);
    }
}