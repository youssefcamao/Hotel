using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Hotel.Configuration.Models.DapperModels;

namespace Hotel.Configuration.Repos
{
    public class ReservationsRepository : IRepository<IHotelReservation>
    {
        private readonly ISqlDataAccess _dataAccess;

        public ReservationsRepository(ISqlDataAccess dataAccess)
        {
            if (dataAccess == null)
            {
                throw new ArgumentNullException(nameof(dataAccess));
            }
            _dataAccess = dataAccess;
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IHotelReservation"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void CreateNewModel(IHotelReservation model)
        {
            _dataAccess.SaveData("InsertReservation", model);
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IHotelReservation"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void DeleteModel(IHotelReservation model)
        {
            _dataAccess.SaveData("DeleteReservation", new {Id = model.Id});
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IHotelReservation"/></para>
        /// <remarks>if <see cref="IHotelReservation"/> is not implemented from the dapper model <see cref="ArgumentException"/> is thrown.</remarks>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        /// <param name="model"></param>
        public IList<IHotelReservation> GetAll()
        {
            var dapperReservation = _dataAccess.LoadData<DapperReservation, dynamic>("GetAllReservations", new { });
            var reservations = dapperReservation.Select(x => x is IHotelReservation reservation ?
            reservation : throw new ArgumentException("Reservation doesn't implement the interface IReservation")).ToList();
            return reservations;
        }
        /// <summary>
        /// <inheritdoc/>
        /// <para>the param must be of type <see cref="IHotelReservation"/></para>
        /// </summary>
        /// <param name="model"></param>
        public void UpdateModel(IHotelReservation model)
        {
            _dataAccess.SaveData("UpdateReservation", model);

        }
    }
}
