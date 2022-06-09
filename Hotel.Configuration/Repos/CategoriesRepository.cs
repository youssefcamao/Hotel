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
        public void CreateNewModel(IRoomCategory model)
        {
            _dataAccess.SaveData("InsertCategory", model);
        }

        public void DeleteModel(IRoomCategory model)
        {
            _dataAccess.SaveData("DeleteCategory", model);
        }

        public IList<IRoomCategory> GetAll()
        {
            var dapperCategories =  _dataAccess.LoadData<DapperCategory, dynamic>("GetAllCategories", new { });
            var categories = dapperCategories.Select(x => x is IRoomCategory category ?
            category : throw new ArgumentException($"categories doesn't implement the interface IRoomCategory")).ToList();
            return categories;
        }

        public void UpdateModel(IRoomCategory model)
        {
            _dataAccess.SaveData("UpdateCategory", model);
        }
    }
}
