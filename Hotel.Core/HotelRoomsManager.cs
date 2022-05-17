using Hotel.Configuration;
using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core
{
    public class HotelRoomsManager
    {
        public List<IRoomCategory> RoomCategories { get; } = new List<IRoomCategory>();
        public List<IRoom> HotelRoomsList { get; } = new List<IRoom>();

        public HotelRoomsManager()
        {
            InitiateComponenets();
        }
        private void InitiateComponenets()
        {
            //Initiate room categories
            RoomCategories.Add(new RoomCategory("SingleRoom", "This Room is only available for 1 Person", 1, 20));
            RoomCategories.Add(new RoomCategory("DoubleRoom", "this room is available up to 2 People", 2, 40));
            //Initiate Hotel Rooms
            HotelRoomsList.Add(new HotelRoom(12, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(10, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(50, true, RoomCategories[1].CategoryId));
            HotelRoomsList.Add(new HotelRoom(13, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(11, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(51, true, RoomCategories[1].CategoryId));
            HotelRoomsList.Add(new HotelRoom(14, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(12, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(52, true, RoomCategories[1].CategoryId));
            HotelRoomsList.Add(new HotelRoom(16, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(16, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(56, true, RoomCategories[1].CategoryId));
            HotelRoomsList.Add(new HotelRoom(17, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(17, true, RoomCategories[0].CategoryId));
            HotelRoomsList.Add(new HotelRoom(57, true, RoomCategories[1].CategoryId));
        }
        /// <summary>
        /// This Method returns a category from its id and returns Null if Category Not Found
        /// </summary>
        /// <param name="roomCategoryId"></param>
        /// <returns> IRoomCategory or Null If not found</returns>
        public IRoomCategory? GetCategoryFromId(Guid roomCategoryId)
        {
            return RoomCategories.FirstOrDefault(x => x.CategoryId == roomCategoryId);
        }
        public IRoomCategory? GetCategoryFromCategoryName(string categoryName)
        {
            var categories = RoomCategories.Where(x=> x.CategoryName == categoryName);
            if (categories.Count() == 0)
            {
                throw new ArgumentNullException("No Category was found!");
            }
            else if (categories.Count() != 1)
            {
                throw new InvalidOperationException("There is more than one category with the same name");
            }
            else
            {
                return categories.First();
            }
        }

        /// <summary>
        /// This Method returns a room from its roomNumber and returns Null if Category Not Found
        /// </summary>
        /// <param name="roomCategoryId"></param>
        /// <returns> IRoom or Null If not found</returns>
        public IRoom? GetRoomFromNumber(int roomNumber)
        {
            return HotelRoomsList.FirstOrDefault(x => x.RoomNumber == roomNumber);
        }
        public IRoomCategory? GetRoomCategoryFromId(Guid categoryId)
        {
            return RoomCategories.FirstOrDefault(x=> x.CategoryId == categoryId);
        }
    }
}
