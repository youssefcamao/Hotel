using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Hotel.Configuration.Enums;
using Hotel.Configuration;
using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;
using Moq;
using Hotel.Configuration.Models;

namespace Hotel.Core.Test
{
    public class ReservationSearchHelperTest
    {
        private HotelRoomsManager _hotelRoomsManager;
        private ReservationManager _reservationManager;
        private ReservationSearchHelper _reservationSearchHelper;
        private List<IRoom> _roomsList = new List<IRoom>();
        private List<IRoomCategory> _categoryList = new List<IRoomCategory>();
        private List<IHotelReservation> _reservationsList = new List<IHotelReservation>();
        private readonly Guid _userId;
        public ReservationSearchHelperTest()
        {
            _userId = Guid.NewGuid();
            InitiatTestComponents();
        }
        private void InitiatTestComponents()
        {
            var roomRepo = GetMockedModelRepo(_roomsList, (selectedRoom, existentRoom) => selectedRoom.RoomNumber == existentRoom.RoomNumber);
            var categoryRepo = GetMockedModelRepo(_categoryList, (selectedCategory, existentCategory) => selectedCategory.Id == existentCategory.Id);
            var reservationRepo = GetMockedModelRepo(_reservationsList, (selectedReservation, existentReservation) => selectedReservation.Id == existentReservation.Id);
            _hotelRoomsManager = new HotelRoomsManager(roomRepo, categoryRepo);
            _reservationManager = new ReservationManager(_hotelRoomsManager, reservationRepo);

            //Initiate room categories
            _categoryList.Add(new RoomCategory("SingleRoom", "This Room is only available for 1 Person", 20));
            _categoryList.Add(new RoomCategory("DoubleRoom", "this room is available up to 2 People", 40));
            //Initiate Hotel Rooms
            _roomsList.Add(new HotelRoom(12, true, _categoryList[0].Id));
            _roomsList.Add(new HotelRoom(10, true, _categoryList[0].Id));
            _roomsList.Add(new HotelRoom(50, true, _categoryList[1].Id));
            _roomsList.Add(new HotelRoom(51, true, _categoryList[1].Id));

            var singleRoomCategory = _hotelRoomsManager.RoomCategories[0];
            var doubleRoomCategory = _hotelRoomsManager.RoomCategories[1];
            _reservationManager.HotelRerservations.Clear();
            _reservationManager.AddNewReservation(new DateOnly(2022, 5, 26), new DateOnly(2022, 5, 27), doubleRoomCategory.Id, _userId, "ramon", "Grothe", "Ramon@email.com", ReservationStatus.Accepted);
            _reservationManager.AddNewReservation(new DateOnly(2022, 9, 26), new DateOnly(2022, 10, 10), singleRoomCategory.Id, _userId, "youssef", "ramon", "youssef@email.com", ReservationStatus.Accepted);
            _reservationManager.AddNewReservation(new DateOnly(2022, 5, 26), new DateOnly(2022, 5, 27), doubleRoomCategory.Id, _userId, "jannik", "camao", "jannik@email.com", ReservationStatus.Accepted);
            _reservationManager.AddNewReservation(new DateOnly(2022, 6, 26), new DateOnly(2022, 7, 2), singleRoomCategory.Id, _userId, "paul", "camao", "paul@email.com", ReservationStatus.Declined);
            _reservationSearchHelper = new ReservationSearchHelper(_hotelRoomsManager);
        }
        private IRepository<T> GetMockedModelRepo<T>(List<T> repoModelList, Func<T,T,bool> matchingFunc) where T : class
        {
            var mockedHotelRoomRepo = new Mock<IRepository<T>>();
            mockedHotelRoomRepo.Setup(x => x.GetAll()).Returns(repoModelList);
            mockedHotelRoomRepo.Setup(x => x.CreateNewModel(It.IsAny<T>())).Callback<T>(x => repoModelList.Add(x));
            mockedHotelRoomRepo.Setup(x => x.DeleteModel(It.IsAny<T>())).Callback<T>(x => repoModelList.RemoveAll(m => matchingFunc(m,x)));
            mockedHotelRoomRepo.Setup(x => x.UpdateModel(It.IsAny<T>())).Callback<T>(x => 
            {
                var modelIndex = repoModelList.FindIndex(m => matchingFunc(m, x));
                if (modelIndex == -1)
                {
                    throw new ArgumentNullException(nameof(x));
                }
                repoModelList[modelIndex] = x;
            });
            return mockedHotelRoomRepo.Object;
        }

        [Fact]
        public void GetReservationsFromName_Successfull()
        {
            var name = "Ramon";
            var result = _reservationSearchHelper.GetReservationsFromName(_reservationManager.HotelRerservations, name);
            Assert.Equal(2, result.Count);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void GetReservationsFromDateRange_Successfull(DateOnly? startDate, DateOnly? endDate, int expectedCount)
        {
            var result = _reservationSearchHelper.GetReservationsFromDateRange(_reservationManager.HotelRerservations, startDate, endDate);
            Assert.Equal(expectedCount, result.Count);
        }

        [Fact]
        public void GetReservationFromRoomType_Successfull()
        {
            var singleRoomCategory = _hotelRoomsManager.RoomCategories[0];
            var result = _reservationSearchHelper.GetReservationFromRoomType(_reservationManager.HotelRerservations, singleRoomCategory);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetReservationsFromStatus_Successfull()
        {
            var result = _reservationSearchHelper.GetReservationsFromStatus(_reservationManager.HotelRerservations, ReservationStatus.Accepted);
            Assert.Equal(3, result.Count);
        }
        [Theory]
        [InlineData(10, null, 4)]
        [InlineData(40, 120, 3)]
        [InlineData(null, 40, 2)]
        public void GetReservationsFromPriceRange_Successfull(double? minPrice, double? maxPrice, int expectedResultCount)
        {
            var result = _reservationSearchHelper.GetReservationsFromPriceRange(_reservationManager.HotelRerservations, minPrice, maxPrice);
            Assert.Equal(expectedResultCount, result.Count);
        }
        internal class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {new DateOnly(2022,5,23), new DateOnly(2022,7,27), 3},
                new object[] {null, new DateOnly(2022,7,27), 3},
                new object[] { new DateOnly(2022, 5, 23), null, 4},
                new object[] {null, null, 4}

            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}
