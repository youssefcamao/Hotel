using Hotel.Configuration.Interfaces.DataAccess;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models.DapperModels;

namespace Hotel.Configuration.Repos
{
    public class CategoriesRepository : IRepository<IRoomCategory>
    {
        private readonly ISqlDataAccess _dataAccess;

        public CategoriesRepository(ISqlDataAccess dataAccess)
        {
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }
            _dataAccess = dataAccess;
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoomCategory"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void CreateNewModel(IRoomCategory model)
        {
            _dataAccess.SaveData("InsertCategory", model);
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoomCategory"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void DeleteModel(IRoomCategory model)
        {
            _dataAccess.SaveData("DeleteCategory", model);
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoomCategory"/></para>
        /// <remarks>if <see cref="IRoomCategory"/> is not implemented from the dapper model <see cref="ArgumentException"/> is thrown.</remarks>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        /// <param name="model"></param>
        public IList<IRoomCategory> GetAll()
        {
            var dapperCategories = _dataAccess.LoadData<DapperCategory, dynamic>("GetAllCategories", new { });
            var categories = dapperCategories.Select(x => x is IRoomCategory category ?
            category : throw new ArgumentException($"categories doesn't implement the interface IRoomCategory")).ToList();
            return categories;
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoomCategory"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void UpdateModel(IRoomCategory model)
        {
            _dataAccess.SaveData("UpdateCategory", model);
        }
    }
}
