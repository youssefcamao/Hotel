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
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoom"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void CreateNewModel(IRoom model)
        {
            _dataAccess.SaveData("InsertRoom", model);
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoom"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void DeleteModel(IRoom model)
        {
            _dataAccess.SaveData("DeleteRoom", model);
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoom"/></para>
        /// <remarks>if <see cref="IHotelReservation"/> is not implemented from the dapper model <see cref="ArgumentException"/> is thrown.</remarks>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        /// <param name="model"></param>
        public IList<IRoom> GetAll()
{
            var dapperRooms = _dataAccess.LoadData<DapperRoom,dynamic>("GetAllRooms", new { });
            var reservations = dapperRooms.Select(x => x is IRoom user ? 
            user : throw new ArgumentException("Reservation doesn't implement the interface IReservation")).ToList();
            return reservations;
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IRoom"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void UpdateModel(IRoom model)
        {
            _dataAccess.SaveData("UpdateRoom", model);
        }
    }

}
