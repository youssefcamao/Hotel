namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IBaseRepository<TModel>
    {
        IList<TModel> GetAll();
        void UpdateModel(TModel model);
        void DeleteModel(TModel model);
    }
}
