namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IRepository<TModel> : IBaseRepository<TModel>
    {
        /// <summary>
        /// this method creates a new row form a model in the database
        /// </summary>
        /// <param name="model"></param>
        void CreateNewModel(TModel model);
        /// <summary>
        /// this method updates a model in the databse by taking the new model
        /// </summary>
        /// <param name="model"></param>
        void UpdateModel(TModel model);
    }
}
