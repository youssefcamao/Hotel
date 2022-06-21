namespace Hotel.Configuration.Interfaces.Repos
{
    public interface IBaseRepository<TModel>
    {
        /// <summary>
        /// this method returns all the models from tha database
        /// </summary>
        /// <returns> a list of all models in the database</returns>
        IList<TModel> GetAll();
        /// <summary>
        /// this method deletes a model from the database
        /// </summary>
        /// <param name="model"></param>
        void DeleteModel(TModel model);
    }
}
