//using System;
//using Xunit;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections;
//using Hotel.Configuration.Enums;
//using Hotel.Configuration;

//namespace Hotel.Core.Test
//{
//    public class ReservationSearchHelperTest
//    {
//        private HotelRoomsManager _hotelRoomsManager;
//        private ReservationManager _reservationManager;
//        private ReservationSearchHelper _reservationSearchHelper;
//        public ReservationSearchHelperTest()
//        {
//            InitiatTestComponents();
//        }
//        private void InitiatTestComponents()
//        {
//            var userManager = new UserManager();
//            _hotelRoomsManager = new HotelRoomsManager();
//            _reservationManager = new ReservationManager(userManager, _hotelRoomsManager);
//            var singleRoomCategory = _hotelRoomsManager.RoomCategories[0];
//            var doubleRoomCategory = _hotelRoomsManager.RoomCategories[1];
//            _reservationManager.HotelRerservations.Clear();
//            var ramonAdmin = userManager.GetUserFromEmailPass("ramon@admin.com", "ramon123") ?? throw new ArgumentNullException("ramonUser Not found!");
//            _reservationManager.AddNewReservation(new DateOnly(2022, 5, 26), new DateOnly(2022, 5, 27), doubleRoomCategory.Id, ramonAdmin.Id, "ramon", "Grothe", "Ramon@email.com", ReservationStatus.Accepted);
//            _reservationManager.AddNewReservation(new DateOnly(2022, 9, 26), new DateOnly(2022, 10, 10), singleRoomCategory.Id, ramonAdmin.Id, "youssef", "ramon", "youssef@email.com", ReservationStatus.Accepted);
//            _reservationManager.AddNewReservation(new DateOnly(2022, 5, 26), new DateOnly(2022, 5, 27), doubleRoomCategory.Id, ramonAdmin.Id, "jannik", "camao", "jannik@email.com", ReservationStatus.Accepted);
//            _reservationManager.AddNewReservation(new DateOnly(2022, 6, 26), new DateOnly(2022, 7, 2), singleRoomCategory.Id, ramonAdmin.Id, "paul", "camao", "paul@email.com", ReservationStatus.Declined);
//            _reservationSearchHelper = new ReservationSearchHelper(_hotelRoomsManager);
//        }
//        [Fact]
//        public void GetReservationsFromName_Successfull()
//        {
//            var name = "Ramon";
//            var resutl = _reservationSearchHelper.GetReservationsFromName(_reservationManager.HotelRerservations, name);
//            Assert.Equal(2, resutl.Count);
//        }
//        [Theory]
//        [ClassData(typeof(TestDataGenerator))]
//        public void GetReservationsFromDateRange_Successfull(DateOnly? startDate, DateOnly? endDate, int expectedCount)
//        {
//            var result = _reservationSearchHelper.GetReservationsFromDateRange(_reservationManager.HotelRerservations, startDate, endDate);
//            Assert.Equal(expectedCount, result.Count);
//        }
//        [Fact]
//        public void GetReservationFromRoomType_Successfull()
//        {
//            var singleRoomCategory = _hotelRoomsManager.RoomCategories[0];
//            var resutl = _reservationSearchHelper.GetReservationFromRoomType(_reservationManager.HotelRerservations, singleRoomCategory);
//            Assert.Equal(2, resutl.Count);
//        }

//        [Fact]
//        public void GetReservationsFromStatus_Successfull()
//        {
//            var resutl = _reservationSearchHelper.GetReservationsFromStatus(_reservationManager.HotelRerservations, ReservationStatus.Accepted);
//            Assert.Equal(3, resutl.Count);
//        }
//        [Theory]
//        [InlineData(10,null,4)]
//        [InlineData(40, 120,3)]
//        [InlineData(null, 40,2)]
//        public void GetReservationsFromPriceRange_Successfull(double? minPrice, double? maxPrice, int expectedResultCount)
//        {
//            var result = _reservationSearchHelper.GetReservationsFromPriceRange(_reservationManager.HotelRerservations, minPrice, maxPrice);
//            Assert.Equal(expectedResultCount, result.Count);
//        }
//        internal class TestDataGenerator : IEnumerable<object[]>
//        {
//            private readonly List<object[]> _data = new List<object[]>
//            {
//                new object[] {new DateOnly(2022,5,23), new DateOnly(2022,7,27), 3},
//                new object[] {null, new DateOnly(2022,7,27), 3},
//                new object[] { new DateOnly(2022, 5, 23), null, 4},
//                new object[] {null, null, 4}

//            };

//            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

//            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//        }

//    }
//}
