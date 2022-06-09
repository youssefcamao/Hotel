using Hotel.Configuration.Interfaces.Models;
using Hotel.Configuration.Interfaces.Repos;

namespace Hotel.Core
{
    public class HotelRoomsManager
    {
        private readonly IRepository<IRoom> _roomRepository;
        private readonly IRepository<IRoomCategory> _categoryRepository;

        public IList<IRoomCategory> RoomCategories => _categoryRepository.GetAll();
        public IList<IRoom> HotelRoomsList => _roomRepository.GetAll();

        public HotelRoomsManager(IRepository<IRoom> roomRepository, IRepository<IRoomCategory> categoryRepository)
        {
            _roomRepository = roomRepository;
            _categoryRepository = categoryRepository;
        }
        /// <summary>
        /// This Method returns a category from its id and returns Null if Category Not Found
        /// </summary>
        /// <param name="roomCategoryId"></param>
        /// <returns> IRoomCategory or Null If not found</returns>
        public IRoomCategory? GetCategoryFromId(Guid roomCategoryId)
        {
            return RoomCategories.FirstOrDefault(x => x.Id == roomCategoryId);
        }
        public IRoomCategory? GetCategoryFromCategoryName(string categoryName)
        {
            var selectedCategories = RoomCategories.Where(x => x.CategoryName == categoryName);
            if (selectedCategories.Count() == 0)
            {
                throw new ArgumentNullException("No Category was found!");
            }
            else if (selectedCategories.Count() != 1)
            {
                throw new InvalidOperationException("There is more than one category with the same name");
            }
            else
            {
                return selectedCategories.First();
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
            return RoomCategories.FirstOrDefault(x => x.Id == categoryId);
        }
    }
}
