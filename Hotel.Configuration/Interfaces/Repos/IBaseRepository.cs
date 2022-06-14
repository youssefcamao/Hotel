namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IBaseRepository<TModel>
    {
        IList<TModel> GetAll();
        void DeleteModel(TModel model);
    }
}
