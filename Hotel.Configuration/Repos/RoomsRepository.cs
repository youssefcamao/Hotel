using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models.DapperModels;
using System.Reflection;

namespace Hotel.Configuration.Repos
{
    public class RoomsRepository : IRepository<IRoom>
    {
        private readonly ISqlDataAccess _dataAccess;

        public RoomsRepository(ISqlDataAccess dataAccess)
        {
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }
            _dataAccess = dataAccess;
        }
        public void CreateNewModel(IRoom model)
        {
            _dataAccess.SaveData("InsertRoom", model);
        }

        public void DeleteModel(IRoom model)
        {
            _dataAccess.SaveData("DeleteRoom", model);
        }

        public IList<IRoom> GetAll()
{
            var dapperRooms = _dataAccess.LoadData<DapperRoom,dynamic>("GetAllRooms", new { });
            var reservations = dapperRooms.Select(x => x is IRoom user ? 
            user : throw new ArgumentException("Reservation doesn't implement the interface IReservation")).ToList();
            return reservations;
        }

        public void UpdateModel(IRoom model)
        {
            _dataAccess.SaveData("UpdateRoom", model);
        }
    }

}
