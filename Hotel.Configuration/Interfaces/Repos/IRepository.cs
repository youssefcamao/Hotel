namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IRepository<TModel> : IBaseRepository<TModel>
    {
        void CreateNewModel(TModel model);
    }
}
