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
        public void CreateNewModel(IHotelReservation model)
        {
            _dataAccess.SaveData("InsertReservation", model);
        }

        public void DeleteModel(IHotelReservation model)
        {
            _dataAccess.SaveData("DeleteReservation", model);
        }

        public IList<IHotelReservation> GetAll()
        {
            var dapperReservation = _dataAccess.LoadData<DapperReservation, dynamic>("GetAllReservations", new { });
            var reservations = dapperReservation.Select(x => x is IHotelReservation reservation ?
            reservation : throw new ArgumentException("Reservation doesn't implement the interface IReservation")).ToList();
            return reservations;
        }

        public void UpdateModel(IHotelReservation model)
        {
            _dataAccess.SaveData("UpdateReservation", model);

        }
    }
}
